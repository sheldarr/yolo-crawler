namespace YoloCrawler.Extensions
{
    using Entities;

    public static class RoomExtensionMethods
    {
        public static void WithRandomMonster(this Room room, Position position)
        {
            var monster = new Monster(room, position);

            room.Monsters.Add(monster);
        }
    }
}