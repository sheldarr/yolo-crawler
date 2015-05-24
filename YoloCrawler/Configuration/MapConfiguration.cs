namespace YoloCrawler.Configuration
{
    using System;

    public class MapConfiguration
    {
        public int MinRoomNeighboursCount { get; set; }
        public int MaxRoomNeighboursCount { get; set; }
        public Tuple<int, int> RoomCountBetween { get; set; }
        public HealingShrinesConfiguration HealingShrines { get; set; }

        public static MapConfiguration Default
        {
            get
            {
                return new MapConfiguration
                {
                    RoomCountBetween = Tuple.Create(4, 10),
                    MinRoomNeighboursCount = 1,
                    MaxRoomNeighboursCount = 3,
                    HealingShrines = new HealingShrinesConfiguration
                    {
                        ShrinePercentageSpawnChance = 33,
                        HealedHitpointsBetween = Tuple.Create(2, 3),
                        UseCountRange = Tuple.Create(1, 2)
                    }
                };
            }
        }
    }
}