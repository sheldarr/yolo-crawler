namespace YoloCrawler.Entities
{
    public class Tile
    {
        private readonly TileType _type;

        public Tile(TileType type)
        {
            _type = type;
        }

        public TileType Type
        {
            get { return _type; }
        }

        public override string ToString()
        {
            switch (_type)
            {
                case TileType.Wall:
                    return "#";
                    break;
                default:
                    return ".";
            }
        }
    }
}