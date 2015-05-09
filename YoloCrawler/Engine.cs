namespace YoloCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using ConsolePresentation;
    using Entities;
    using Factories;
    using Fighting;

    public class Engine
    {
        private readonly Presentation _presentation;
        private readonly Logger _logger;
        private YoloTeam _yoloTeam;
        private Room _room;
        private WorldRepresentation _worldRepresentation;
        public Map Map { get; set; }

        public Engine(Presentation presentation, Logger logger)
        {
            _presentation = presentation;
            _logger = logger;
            InitializeGame();
        }

        private void InitializeGame()
        {
            var dummyFightingStrategy = new DummyFightingStrategy(_logger);
            Map = MapFactory.GenerateRandomMap(4);
            _room = Map.GetRandomRoom();
            _yoloTeam = new YoloTeam(dummyFightingStrategy, _room.StartingPosition);
            _worldRepresentation = new WorldRepresentation(_room, _yoloTeam);
            _presentation.Draw(_worldRepresentation);
        }

        public void Move(Offset offset)
        {
            YoloTeamAction(offset);
            RemoveDeadMonsters(_room.Monsters);

            _worldRepresentation = new WorldRepresentation(_room, _yoloTeam);
            _presentation.Draw(_worldRepresentation);
        }

        private void YoloTeamAction(Offset offset)
        {
            var nextPosition = _yoloTeam.Position + offset;

            var nextTile = _room.Tiles[nextPosition.X, nextPosition.Y];

            if (nextTile.Type == TileType.Wall)
            {
                return;
            }

            if (_room.MonsterOccupiesPosition(nextPosition))
            {
                var monsterToAttack = _room.Monsters.FirstOrDefault(monster => Equals(monster.Position, nextPosition));
                _yoloTeam.Attack(monsterToAttack);

                return;
            }

            if (nextTile.Type == TileType.Door)
            {
                EnterNextRoom(nextTile);
                return;
            }

            _yoloTeam.Move(offset);
        }

        private void EnterNextRoom(Tile nextTile)
        {
            var nextRoom = nextTile.GetRoom();
            Tile doorToNextRoom = nextRoom.GetDoorTo(_room);
            _yoloTeam.EnterRoom(doorToNextRoom.GetStartingPosition(nextRoom));
            _room = nextRoom;
        }

        private void RemoveDeadMonsters(List<Monster> monsters)
        {
            var monstersToRemove = monsters.Where(monster => monster.IsDead).ToList();

            monstersToRemove.ForEach(monster =>
            {
                var message = String.Format("{0} defeated at ({1}, {2})! Good job #yolo team!", monster.Name, monster.Position.X, monster.Position.Y);
                _logger.Log(message);
            });
            
            monsters.RemoveAll(monster => monster.IsDead);
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000 / 24);
            }
        }
    }
}