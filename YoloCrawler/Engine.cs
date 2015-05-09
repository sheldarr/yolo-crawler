namespace YoloCrawler
{
    using System.Threading;
    using Entities;
    using Factories;
    using Fighting;

    public class Engine

    {
        private readonly Presentation _presentation;
        private Room _room;
        private YoloTeam _team;
        private WorldRepresentation _worldRepresentation;

        public Engine(Presentation presentation)
        {
            _presentation = presentation;
            InitializeGame();
        }

        private void InitializeGame()
        {
            var startingPosition = new Position(1, 1);

            var dummyFightingStrategy = new DummyFightingStrategy();

            _room = RoomFactory.CreateEmptyRoom(16, 16, startingPosition);
            _team = new YoloTeam(_room, dummyFightingStrategy);
            _worldRepresentation = new WorldRepresentation(_room, _team);
        }

        public void Move(Offset offset)
        {
            _team.Move(offset);
            _worldRepresentation = new WorldRepresentation(_room, _team);
        }

        public void SayHello()
        {
            _presentation.Log("hello!");
        }

        public void Run()
        {
            while (true)
            {
                _presentation.Draw(_worldRepresentation);
                Thread.Sleep(1000 / 24);
            }
        }
    }

    internal class DummyFightingStrategy : TeamFightingStrategy
    {
        public void Attack(Monster monster)
        {
            monster.HitPoints -= 1;
        }
    }
}