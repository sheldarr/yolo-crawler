namespace YoloCrawler.Configuration
{
    using System;

    public class HealingShrinesConfiguration
    {
        public Tuple<int, int> UseCountRange { get; set; }
        public Tuple<int, int> HealedHitpointsBetween { get; set; }
    }
}