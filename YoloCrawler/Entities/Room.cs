namespace YoloCrawler.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;

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
                    Console.Write(_tiles[w, h]);
                }
                Console.WriteLine();
            }
        }

        public void AddLink(Room newRoom)
        {
            var horizontalOrVertical = (new Random()).Next(0, 1);

            if (horizontalOrVertical == 0) //vertical
            {
                var leftOrRight = (new Random()).Next(0, 1);
                var y = (new Random()).Next(1, _size.Height - 2);

                if (leftOrRight == 0)
                {
                    //left
                    Tiles[0, y].AddDoorTo(newRoom);

                    return;
                }

                // right
                Tiles[_size.Width - 1, y].AddDoorTo(newRoom);

                return;
            }

            // horizontal
            var x = (new Random()).Next(1, _size.Width - 2);

            var upOrDown = (new Random()).Next(0, 1);
            if (upOrDown == 0) //up
            {
                Tiles[x, 0].AddDoorTo(newRoom);

                return;
            }

            // down
            Tiles[x, _size.Height - 1].AddDoorTo(newRoom);
        }

        public Position GetRandomAvailablePosition()
        {
            var x = new Random().Next(2, _size.Width - 1);
            var y = new Random().Next(2, _size.Height - 1);

            return new Position(x, y);
        }
    }
}