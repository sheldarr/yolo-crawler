namespace YoloCrawler.Entities
{
    using System;

    public class Room
    {
        private readonly Tile[,] _tiles;
        private readonly Size _size;
        private readonly Position _startingPosition;

        public Room(int width, int height, Position startingPosition)
        {
            _tiles = new Tile[width,height];
            _size = new Size(width, height);
            _startingPosition = startingPosition;
        }

        public Tile[,] Tiles
        {
            get { return _tiles; }
        }

        public Size Size
        {
            get { return _size; }
        }

        public Position StartingPosition
        {
            get { return _startingPosition; }
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