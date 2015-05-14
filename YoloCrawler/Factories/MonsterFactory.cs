namespace YoloCrawler.Factories
{
    using Entities;

    public static class MonsterFactory
    {
        private static readonly YoloDice YoloDice = new YoloDice();

        public static Monster CreateRandomMonster(Room room, Position position)
        {
            var monsters = MonsterNamesLoader.Load();
            var randomMonsterNameIndex = YoloDice.RollForMonsterNameIndex(monsters.Count);

            var monsterName = monsters[randomMonsterNameIndex];
            
            return new Monster(monsterName, position);
        }
    }
}