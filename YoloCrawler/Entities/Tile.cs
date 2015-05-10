namespace YoloCrawler.Entities
{
    public class Tile
    {
        private readonly Position _position;
        private Room _room;
        public TileType Type { get; private set; }

        public Tile(TileType tileType, Position position)
        {
            _position = position;
            Type = tileType;
        }

        public void AddDoorTo(Room room)
        {
            _room = room;
            Type = TileType.Door;
        }

        public Room GetRoom()
        {
            return _room;
        }

        public Position GetStartingPosition(Room nextRoom)
        {
            if (_position.X == 0)
            {
                return new Position(1, _position.Y);
            }
            if (_position.X == nextRoom.Size.Width - 1)
            {
                return new Position(nextRoom.Size.Width - 2, _position.Y);
            }
            if (_position.Y == 0)
            {
                return new Position(_position.X, 1);
            }

            return new Position(_position.X, nextRoom.Size.Height - 2);
        }

        public bool HasDoorTo(Room room)
        {
            return _room.Equals(room);
        }
    }
}