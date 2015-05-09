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
            var startingPosition = new Position(1,1);
            var roomSize = new Size(16, 16);
            var dummyFightingStrategy = new DummyFightingStrategy();

            _room = RoomFactory.CreateEmptyRoom(roomSize, startingPosition);
            _team = new YoloTeam(_room, dummyFightingStrategy);
            _worldRepresentation = new WorldRepresentation(_room, _team);
        }

        public void Move(Offset offset)
        {
            _team.Move(offset);
            _worldRepresentation = new WorldRepresentation(_room, _team);
            _presentation.Draw(_worldRepresentation);

        }

        public void SayHello()
        {
            _presentation.Log("hello!");
        }

        public void Run()
        {
            while (true)
            {
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