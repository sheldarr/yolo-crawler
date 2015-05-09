namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }

        public bool IsDead
        {
            get { return HitPoints <= 0; }
        }

        public Position Position;

        public Monster(string name, Position position)
        {
            Name = name;
            Position = position;
            HitPoints = RandomGenerator.Random.Next(3, 8);
        }
    }
}