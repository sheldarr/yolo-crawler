namespace YoloCrawler
{
    using YoloCrawler.Entities;
    using YoloCrawler.Factories;

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

            _team = new YoloTeam(_room, new Position(0, 0));
        }

        public void Move(Offset offset)
        {
            _team.Move(offset);
        }

        public void SayHello()
        {
            _presentation.Log("hello!");
        }
    }
}