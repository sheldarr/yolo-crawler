namespace YoloCrawler.Entities
{
    using Fighting;

    public class Monster : Being, ICanAttack, ICanBeAttacked
    {
        const int MinHitpoints = 2;
        const int MaxHitpoints = 8;

        public Monster(string name, Position position)
        {
            Name = name;
            Position = position;            
            Hitpoints = new YoloDice().RollForHitpoints(MinHitpoints, MaxHitpoints);
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