namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster
    {
        public int HitPoints { get; set; }

        public bool IsDead
        {
            get { return HitPoints <= 0; }
        }

        public Position Position;

        public Monster(Position position)
        {
            Position = position;
            HitPoints = RandomGenerator.Random.Next(3, 8);
        }
    }
}