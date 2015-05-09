namespace YoloCrawler
{
    using Entities;
    using Factories;
    using Fighting;

    public class Engine

    {
        private readonly Presentation _presentation;
        private Room _room;
        private YoloTeam _team;

        public Engine(Presentation presentation)
        {
            _presentation = presentation;
            InitializeGame();
        }

        private void InitializeGame()
        {
            _room = RoomFactory.CreateEmptyRoom(16, 16);
            var dummyFightingStrategy = new DummyFightingStrategy();
            _team = new YoloTeam(_room, new Position(0, 0), dummyFightingStrategy);
        }

        public void Move(Offset offset)
        {
            _team.Move(offset);
            _presentation.Draw(new WorldRepresentation(_room, _team));
        }

        public void SayHello()
        {
            _presentation.Log("hello!");
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