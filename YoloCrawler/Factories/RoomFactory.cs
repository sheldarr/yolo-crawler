namespace YoloCrawler.Factories
{
    using YoloCrawler.Entities;

    public static class RoomFactory
    {
        public static Room CreateEmptyRoom(int width, int height)
        {
            var room = new Room(width, height);

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    room.Tiles[w, h] = new Tile(TileTypes.Floor);
                }
            }

            return room;
        }

        private static void CreateWalls(Room room)
        {
            for (int i = 0; i < room.height; i++)
            {
                
            }
        }
    }
}