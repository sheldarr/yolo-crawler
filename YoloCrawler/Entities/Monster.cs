namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster : ICanAttack, ICanBeAttacked, IAm
    {
        public string Name { get; private set; }
        public Position Position { get; private set; }
        public int Hitpoints { get; private set; }

        public bool IsDead
        {
            get { return Hitpoints <= 0; }
        }

        public Monster(string name, Position position)
        {
            Name = name;
            Position = position;
            Hitpoints = RandomGenerator.Random.Next(3, 8);
        }
        public void Take(Damage dmg)
        {
            Hitpoints -= dmg.Hitpoints;
        }

        public void Attack(ICanBeAttacked target)
        {
            target.Take(new Damage
            {
                Hitpoints = 1
            });
        }
    }
}