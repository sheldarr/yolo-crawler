namespace YoloCrawler.Entities
{
    using System;

    public class Room
    {
        private readonly Tile[,] _tiles;

        public Room(int width, int height)
        {
            _tiles = new Tile[width,height];
        }

        public Tile[,] Tiles
        {
            get { return _tiles; }
        }

        public void Draw()
        {
            foreach (var tile in _tiles)
            {
                Console.Write(tile);
            }
        }
    }
}