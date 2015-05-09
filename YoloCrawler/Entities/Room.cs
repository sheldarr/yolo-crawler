namespace YoloCrawler.Entities
{
    using System;
    using System.Collections.Generic;

    public class Room
    {
        private readonly Tile[,] _tiles;
        private readonly Size _size;
        private readonly Position _startingPosition;

        public List<Monster> Monsters { get; set; }

        public Room(Size size, Position startingPosition)
        {
            _tiles = new Tile[size.Width, size.Height];
            _size = size;
            _startingPosition = startingPosition;
            Monsters = new List<Monster>();
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