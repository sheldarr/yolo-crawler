namespace YoloCrawler.Factories
{
    using Entities;

    public static class MonsterFactory
    {
        private static readonly Dice Dice = new Dice();

        public static Monster CreateRandomMonster(Room room, Position position)
        {
            var monsters = MonsterNamesLoader.Load();
            var randomMonsterNameIndex = Dice.RollForMonsterNameIndex(monsters.Count);

            var monsterName = monsters[randomMonsterNameIndex];
            
            return new Monster(monsterName, position);
        }
    }
}