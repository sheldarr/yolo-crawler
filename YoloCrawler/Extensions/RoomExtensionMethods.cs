namespace YoloCrawler.Extensions
{
    using Entities;

    public static class RoomExtensionMethods
    {
        public static Room WithRandomMonster(this Room room, Position position)
        {
            var monster = new Monster(position);

            room.Monsters.Add(monster);

            return room;
        }
    }
}