namespace YoloCrawler.Entities
{
    using Fighting;

    public class YoloTeam : Being, ICanAttack, ICanBeAttacked
    {
        private readonly int _baseHitpoints;

        public YoloTeam(Position startingPosition, int maxHitpoints)
        {
            Position = startingPosition;
            _baseHitpoints = maxHitpoints;
            Hitpoints = maxHitpoints;
            Name = "#YoloTeam";
        }

        public void Move(Offset offset)
        {
            Position += offset;
        }

        public void EnterRoom(Position newRoomStartingPosition)
        {
            Position = newRoomStartingPosition;
        }

        public void Attack(ICanBeAttacked target)
        {
            target.Take(new Damage
            {
                Hitpoints = 1
            });
        }

        public void Take(Damage dmg)
        {
            Hitpoints -= dmg.Hitpoints;
        }

        public void Heal(int hitpointsToHeal)
        {
            var hitpointsAfterHealing = Hitpoints + hitpointsToHeal;

            if (hitpointsAfterHealing > _baseHitpoints)
            {
                Hitpoints = _baseHitpoints;
                return;
            }

            Hitpoints = hitpointsAfterHealing;
        }
    }
}