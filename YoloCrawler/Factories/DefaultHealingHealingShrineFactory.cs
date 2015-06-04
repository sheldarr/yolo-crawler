namespace YoloCrawler.Factories
{
    using Configuration;

    public class DefaultHealingHealingShrineFactory : HealingShrineFactory
    {
        private readonly Dice _dice;

        public DefaultHealingHealingShrineFactory(Dice dice)
        {
            _dice = dice;
        }

        public HealingShrine GetShrine(HealingShrinesConfiguration configuration)
        {
            var useCount = _dice.RollBetween(configuration.UseCountRange.Item1, configuration.UseCountRange.Item2);
            var healedHitpoints = _dice.RollBetween(configuration.HealedHitpointsBetween.Item1, configuration.HealedHitpointsBetween.Item2);

            return new HealingShrine(useCount, healedHitpoints);
        }
    }
}