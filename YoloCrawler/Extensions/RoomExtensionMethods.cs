namespace YoloCrawler.Extensions
{
    using Entities;
    using Factories;

    public static class RoomExtensionMethods
    {
        public static Room WithRandomMonster(this Room room, Position position)
        {
            var monster = MonsterFactory.CreateRandomMonster(room, position);

            room.Monsters.Add(monster);

            return room;
        }
    }
}