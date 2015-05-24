namespace YoloCrawler.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;

    public class Room
    {
        private readonly Tile[,] _tiles;
        private readonly Size _size;
        private readonly Position _startingPosition;
        private readonly Dice _dice;

        public List<Monster> Monsters { get; set; }

        public Tile[,] Tiles
        {
            get { return _tiles; }
        }

        public Size Size
        {
            get { return _size; }
        }

        public Room(Size size, Position startingPosition, Dice dice)
        {
            _tiles = new Tile[size.Width, size.Height];
            _size = size;
            _startingPosition = startingPosition;
            _dice = dice;
            Monsters = new List<Monster>();
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
            var horizontalOrVertical = _dice.RollK100();

            if (horizontalOrVertical < 50) //vertical
            {
                var leftOrRight = _dice.RollK100();
                var y = _dice.RollForPlaceOnTheWall(_size.Height);

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
            var x = _dice.RollForPlaceOnTheWall(_size.Width);

            var upOrDown = _dice.RollK100();
            if (upOrDown < 50) //up
            {
                Tiles[x, 0].AddDoorTo(newRoom);

                return;
            }

            // down
            Tiles[x, _size.Height - 1].AddDoorTo(newRoom);
        }

        public bool MonsterOccupiesPosition(Position position)
        {
            return Monsters.Any(monster => Equals(monster.Position, position));
        }

        public void RemoveDeadMonsters(ConsolePresentation.Logger logger)
        {
            Monsters.RemoveAll(monster => monster.IsDead);
        }
        
        public Tile GetDoorTo(Room room)
        {
            var doors = new List<Tile>();

            foreach (var tile in Tiles)
            {
                if (tile.Type == TileType.Door)
                {
                    doors.Add(tile);
                }
            }

            var door = doors.Single(t => t.HasDoorTo(room));

            return door;
        }

        public void SpawnMonsters(int monsterCount)
        {
            Enumerable.Range(0, monsterCount).ToList().ForEach(_ =>
            {
                Position randomPosition;
                do
                {
                    randomPosition = _dice.RollPosition(Size.Width, Size.Height);
                } while (!MonsterCanSpawnOn(randomPosition));
                
                Monsters.Add(MonsterFactory.CreateRandomMonster(randomPosition));
            });
        }

        private bool MonsterCanSpawnOn(Position position)
        {
            var monstersOnPosition = Monsters.Any(monster => monster.Position.Equals(position));
            var nearDoor = false;

            foreach (var tile in Tiles)
            {
                if (tile.HasDoor && tile.CloseTo(position))
                {
                    nearDoor = true;
                    break;
                }
            }

            var notOnWall = NotOnWall(position);

            return !monstersOnPosition && !nearDoor && notOnWall;
        }

        private bool NotOnWall(Position position)
        {
            return position.X != 0 && position.X != Size.Width - 1 && position.Y != 0 && position.Y != Size.Height - 1;
        }

        public void BuildShrine(HealingShrine newShrine, Position shrinePosition)
        {
            Tiles[shrinePosition.X, shrinePosition.Y].BuildShrine(newShrine);
        }
    }
}