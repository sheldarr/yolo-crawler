namespace YoloCrawler.Entities
{
    public class Tile
    {
        private Room _room;
        public TileType Type { get; private set; }

        public Tile(TileType tileType)
        {
            Type = tileType;
        }

        public void AddDoorTo(Room room)
        {
            _room = room;
            Type = TileType.Doors;
        }
    }
}