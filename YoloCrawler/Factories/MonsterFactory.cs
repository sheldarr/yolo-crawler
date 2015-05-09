namespace YoloCrawler.Factories
{
    using Entities;
    using Fighting;

    public static class MonsterFactory
    {
        public static Monster CreateRandomMonster(Room room, Position position)
        {
            var monsters = MonsterNamesLoader.Load();
            var randomMonsterNameIndex = RandomGenerator.Random.Next(1, monsters.Count);

            var monsterName = monsters[randomMonsterNameIndex];
            
            return new Monster(monsterName, position);
        }
    }
}