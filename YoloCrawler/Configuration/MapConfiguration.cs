namespace YoloCrawler.Configuration
{
    using System;

    public class MapConfiguration
    {
        public int ShrineSpawnChance { get; set; }
        public HealingShrinesConfiguration HealingShrines { get; set; }
    }

    public class HealingShrinesConfiguration
    {
        public Tuple<int, int> UseCountRange { get; set; }
        public Tuple<int, int> HealedHitpointsBetween { get; set; }
    }
}