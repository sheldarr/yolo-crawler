namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster : Being, ICanAttack, ICanBeAttacked
    {
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

        public void Move(Offset offset)
        {
            Position += offset;
        }
    }
}