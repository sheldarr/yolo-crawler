namespace YoloCrawler.Entities
{
    public class Tile
    {
        private readonly TileTypes _wall;

        public Tile(TileTypes wall)
        {
            _wall = wall;
        }

        public override string ToString()
        {
            switch (_wall)
            {
                case TileTypes.Wall:
                    return "#";
                    break;
                case TileTypes.Floor:
                    return ".";
                default:
                    return "_";
            }
        }
    }
}