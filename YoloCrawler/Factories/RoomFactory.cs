namespace YoloCrawler.Factories
{
    using YoloCrawler.Entities;

    public static class RoomFactory
    {
        public static Room CreateEmptyRoom(int width, int height, Position startingPosition)
        {
            var room = new Room(width, height, startingPosition);

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
                    room.Tiles[w, h] = new Tile(TileType.Floor);
                }
            }
        }

        private static void CreateWalls(Room room)
        {
            for (var w = 0; w < room.Size.Width; w++)
            {
                room.Tiles[w, 0] = new Tile(TileType.Wall);
            }

            for (var w = 0; w < room.Size.Width; w++)
            {
                room.Tiles[w, room.Size.Height - 1] = new Tile(TileType.Wall);
            }

            for (var h = 0; h < room.Size.Height; h++)
            {
                room.Tiles[0, h] = new Tile(TileType.Wall);
            }

            for (var h = 0; h < room.Size.Height; h++)
            {
                room.Tiles[room.Size.Width - 1, h] = new Tile(TileType.Wall);
            }
        }
    }
}