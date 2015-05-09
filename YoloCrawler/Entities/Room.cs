namespace YoloCrawler.Entities
{
    using System;

    public class Room
    {
        private readonly Tile[,] _tiles;
        private readonly Size _size;

        public Room(Size size)
        {
            _tiles = new Tile[size.Width, size.Height];
            _size = size;
        }

        public Tile[,] Tiles
        {
            get { return _tiles; }
        }

        public Size Size
        {
            get { return _size; }
        }

        public void Draw()
        {
            for (int h = 0; h < _size.Height; h++)
            {
                for (int w = 0; w < _size.Width; w++)
                {
                    Console.Write(_tiles[w,h]);
                }
                Console.WriteLine();
            }
        }
    }
}