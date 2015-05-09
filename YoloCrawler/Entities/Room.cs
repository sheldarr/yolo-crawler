namespace YoloCrawler.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class Room
    {
        private readonly Tile[,] _tiles;
        private readonly Size _size;
        private readonly Position _startingPosition;
        private readonly Random _random;

        public List<Monster> Monsters { get; set; }

        public Room(Size size, Position startingPosition)
        {
            _tiles = new Tile[size.Width, size.Height];
            _size = size;
            _startingPosition = startingPosition;
            _random = new Random();
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
            var horizontalOrVertical = _random.Next(0, 100);

            if (horizontalOrVertical < 50) //vertical
            {
                var leftOrRight = _random.Next(0, 100);
                var y = _random.Next(1, _size.Height - 2);

                if (leftOrRight < 0)
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
            var x = _random.Next(1, _size.Width - 2);

            var upOrDown = _random.Next(0, 100);
            if (upOrDown < 50) //up
            {
                Tiles[x, 0].AddDoorTo(newRoom);

                return;
            }

            // down
            Tiles[x, _size.Height - 1].AddDoorTo(newRoom);
        }

        public Position GetRandomAvailablePosition()
        {
            var x = _random.Next(2, _size.Width - 1);
            var y = _random.Next(2, _size.Height - 1);

            return new Position(x, y);
        }

        public bool MonsterOccupiesPosition(Position position)
        {
            return Monsters.Any(monster => Equals(monster.Position, position));
        }

        public Tile GetDoorTo(Room room)
        {
            foreach (var tile in Tiles)
            {
                if (tile.Type == TileType.Door && tile.HasDoorTo(room))
                {
                    return tile;
                }
            }

            throw new Exception("sth went wrong");
        }
    }
}