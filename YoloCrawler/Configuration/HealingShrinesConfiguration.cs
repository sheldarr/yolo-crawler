namespace YoloCrawler.Configuration
{
    using System;

    public class HealingShrinesConfiguration
    {
        public Tuple<int, int> UseCountRange { get; set; }
        public Tuple<int, int> HealedHitpointsBetween { get; set; }
        public int ShrinePercentageSpawnChance { get; set; }

        public static HealingShrinesConfiguration Default
        {
            get
            {
                return new HealingShrinesConfiguration
                {
                    ShrinePercentageSpawnChance = 33,
                    HealedHitpointsBetween = Tuple.Create(2, 3),
                    UseCountRange = Tuple.Create(1, 2)
                };
            }
        }
    }
}