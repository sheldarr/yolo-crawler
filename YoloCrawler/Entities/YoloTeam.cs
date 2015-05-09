namespace YoloCrawler.Entities
{
    public class YoloTeam
    {
        private readonly Room _room;
        private Position _position;

        public YoloTeam(Room room)
        {
            _room = room;
            _position = room.StartingPosition;
        }

        public Position Position
        {
            get { return _position; }
        }

        public void Move(Offset offset)
        {
            var positionTemp = _position + offset;

            if (_room.Tiles[positionTemp.X, positionTemp.Y].Type == TileType.Wall)
            {
                return;
            }

            _position = positionTemp;
        }
    }
}