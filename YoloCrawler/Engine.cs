namespace YoloCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using ConsolePresentation;
    using Entities;
    using Extensions;
    using Factories;
    using Fighting;

    public class Engine
    {
        private readonly Presentation _presentation;
        private readonly Logger _logger;
        private Room _room;
        private YoloTeam _team;
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
            var startingPosition = new Position(1,1);
            var roomSize = new Size(10, 10);
            var dummyFightingStrategy = new DummyFightingStrategy(_logger);

            var factory = new MapFactory(roomSize, startingPosition);
            Map = factory.GenerateRandomMap(4);
            _room = Map.GetRandomRoom();
            _team = new YoloTeam(_room, dummyFightingStrategy);
            _worldRepresentation = new WorldRepresentation(_room, _team);
        }

        public void Move(Offset offset)
        {
            _team.Move(offset);
            _worldRepresentation = new WorldRepresentation(_room, _team);
            RemoveDeadMonsters(_room.Monsters);            
            _presentation.Draw(_worldRepresentation);
        }

        private void RemoveDeadMonsters(List<Monster> monsters)
        {
            var monstersToRemove = monsters.Where(monster => monster.IsDead).ToList();

            monstersToRemove.ForEach(monster =>
            {
                var message = String.Format("{0} defeated at ({1}, {2})! Good job yolo team!", monster.Name, monster.Position.X, monster.Position.Y);
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