namespace YoloCrawler.Factories
{
    using Entities;

    public static class MonsterFactory
    {
        public static Monster CreateRandomMonster(Position position)
        {
            return new Monster("Clayton", position);
        }
    }
}