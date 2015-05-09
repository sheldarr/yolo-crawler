namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster
    {
        public int HitPoints { get; set; }
        public Position Position;

        private readonly Room _room;

        public Monster(Room room, Position position)
        {
            _room = room;
            Position = position;
            HitPoints = RandomGenerator.Random.Next(1, 8);
        }
    }
}