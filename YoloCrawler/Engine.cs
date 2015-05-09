namespace YoloCrawler
{
    using YoloCrawler.Entities;
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
            _room = new Room(16, 16);
            _room.CreateEmptyRoom();

            _team = new YoloTeam(_room, new Position(0, 0));
        }

        public void Move(Offset offset)
        {
            _team.Move(offset);
        }

        public void SayHello()
        {
            _presentation.WriteLine("hello!");
        }
    }
}