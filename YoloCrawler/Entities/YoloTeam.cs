namespace YoloCrawler.Entities
{
    public class YoloTeam
    {
        private readonly Room _room;
        private readonly Position _position;

        public YoloTeam(Room room, Position position)
        {
            _room = room;
            _position = position;
        }

        public Position Position
        {
            get { return _position; }
        }

        public void Move(Offset offset)
        {
            
        }
    }
}