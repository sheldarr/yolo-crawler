namespace YoloCrawler.Extensions
{
    using Entities;
    using Factories;
    using Fighting;
    using Input;

    public static class RoomExtensionMethods
    {
        public static Room WithRandomMonster(this Room room, Position position)
        {
            var monsters = MonsterNamesLoader.Load();
            var randomMonsterNameIndex = RandomGenerator.Random.Next(1, monsters.Count);

            var monsterName = monsters[randomMonsterNameIndex];
            var monster = new Monster(monsterName, position);

            room.Monsters.Add(monster);

            return room;
        }
    }
}