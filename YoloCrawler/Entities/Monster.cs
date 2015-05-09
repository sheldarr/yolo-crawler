namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster
    {
        public int HitPoints { get; set; }
        public Position Position;

        public Monster(Position position)
        {
            Position = position;
            HitPoints = RandomGenerator.Random.Next(1, 8);
        }
    }
}