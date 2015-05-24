namespace YoloCrawler
{
    using Entities;

    public class HealingShrine
    {
        private int _useCount;
        private readonly int _hitpointsHealed;

        public HealingShrine(int useCount, int hitpointsHealed)
        {
            _useCount = useCount;
            _hitpointsHealed = hitpointsHealed;
        }

        public void Heal(ICanHeal canHeal)
        {
            if (_useCount > 0)
            {
                canHeal.Heal(_hitpointsHealed);
                _useCount--;
            } 
        }
    }
}