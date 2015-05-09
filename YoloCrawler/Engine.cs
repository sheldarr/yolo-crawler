namespace YoloCrawler
{
    using System.Linq;
    using System.Threading;
    using ConsolePresentation;
    using Entities;
    using Factories;

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
            var startingPosition = new Position(1,1);
            var roomSize = new Size(10, 10);

            var factory = new MapFactory(roomSize, startingPosition);
            Map = factory.GenerateRandomMap(4);
            _room = Map.GetRandomRoom();
            _yoloTeam = new YoloTeam(_room.StartingPosition);
            _worldRepresentation = new WorldRepresentation(_room, _yoloTeam);
        }

        public void Move(Offset offset)
        {
            if (WinLossConditionsMet())
            {
                return;
            }

            YoloTeamAction(offset);
            _room.RemoveDeadMonsters(_logger);
            _room.Monsters.ForEach(MonsterAction);

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
                _logger.LogFight(_yoloTeam, monsterToAttack);

                return;
            }

            _yoloTeam.Move(offset);

            if (nextTile.Type == TileType.Door)
            {
                _room = nextTile.GetNextRoom();
                _yoloTeam.EnterRoom(_room.StartingPosition);
            }
        }

        private void MonsterAction(Monster monster)
        {
            var nextPosition = monster.Position + monster.Position.GetOffsetTowards(_yoloTeam.Position);

            var nextTile = _room.Tiles[nextPosition.X, nextPosition.Y];

            if (nextTile.Type == TileType.Wall)
            {
                return;
            }

            if (nextPosition.Equals(_yoloTeam.Position))
            {
                monster.Attack(_yoloTeam);
                _logger.LogFight(monster, _yoloTeam);
            }
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000 / 24);

                if (WinLossConditionsMet())
                {
                    break;
                }
            }
        }

        private bool WinLossConditionsMet()
        {
            return _yoloTeam.IsDead;
        }

        public void AnounceResult()
        {
            if (_yoloTeam.IsDead)
            {
                _logger.Log("LOL YOU DIED, TRY AGAIN (#YOLO)");
            }
        }
    }
}