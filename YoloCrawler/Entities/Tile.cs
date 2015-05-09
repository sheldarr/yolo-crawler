namespace YoloCrawler.Entities
{
    public class Tile
    {
        public TileType Type { get; private set; }

        public Tile(TileType tileType)
        {
            Type = tileType;
        }
    }
}