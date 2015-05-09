namespace YoloCrawler.Factories
{
    using Entities;

    public static class RoomFactory
    {
        public static Room CreateEmptyRoom(Size size, Position startingPosition)
        {
            var room = new Room(size, startingPosition);

            CreateFloor(room);
            CreateWalls(room);

            return room;
        }

        private static void CreateFloor(Room room)
        {
            for (var w = 1; w < room.Size.Width - 1; w++)
            {
                for (var h = 1; h < room.Size.Height - 1; h++)
                {
                    room.Tiles[w, h] = new Tile(TileType.Floor, new Position(w, h));
                }
            }
        }

        private static void CreateWalls(Room room)
        {
            for (var w = 0; w < room.Size.Width; w++)
            {
                room.Tiles[w, 0] = new Tile(TileType.Wall, new Position(w, 0));
            }

            for (var w = 0; w < room.Size.Width; w++)
            {
                room.Tiles[w, room.Size.Height - 1] = new Tile(TileType.Wall, new Position(w, room.Size.Height - 1));
            }

            for (var h = 0; h < room.Size.Height; h++)
            {
                room.Tiles[0, h] = new Tile(TileType.Wall, new Position(0, h));
            }

            for (var h = 0; h < room.Size.Height; h++)
            {
                room.Tiles[room.Size.Width - 1, h] = new Tile(TileType.Wall, new Position(room.Size.Width - 1, h));
            }
        }
    }
}