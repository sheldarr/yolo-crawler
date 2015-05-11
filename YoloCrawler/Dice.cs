namespace YoloCrawler
{
    using System;

    public class Dice
    {
        private readonly Random _random;
        private const int FixingStupidUpperBound = 1;

        public Dice()
        {
            _random = new Random();
        }

        public int RollK100()
        {
            return _random.Next(1, 100 + FixingStupidUpperBound);
        }

        public int RollForPlaceOnTheWall(int roomWallSize)
        {
            const int minDistanceToAvoidTheCorner = 1;
            return _random.Next(minDistanceToAvoidTheCorner, roomWallSize - minDistanceToAvoidTheCorner);
        }

        public int RollForFreeAvailableCoordinateValueBasedOn(int roomWallSize)
        {
            const int minDistanceToWall = 2;
            return _random.Next(minDistanceToWall, roomWallSize - minDistanceToWall);
        }

        public int RollForNeighboursCount(int minCount, int maxCount)
        {
            return _random.Next(minCount, maxCount + FixingStupidUpperBound);
        }

        public int RollForRandomRoomWidth()
        {
            const int minRoomWidth = 4;
            const int maxRoomWidthBasedOnMaxDisplayWidth = 58;
            return _random.Next(minRoomWidth, maxRoomWidthBasedOnMaxDisplayWidth + FixingStupidUpperBound);
        }

        public int RollForRandomRoomHeight()
        {
            const int minRoomHeight = 4;
            const int maxRoomHeightBasedOnMaxDisplayHeight = 18;
            return _random.Next(minRoomHeight, maxRoomHeightBasedOnMaxDisplayHeight + FixingStupidUpperBound);
        }

        public int RollForHitpoints(int minHitpoints, int maxHitpoints)
        {
            return _random.Next(minHitpoints, maxHitpoints + FixingStupidUpperBound);
        }

        public int RollForRandomRoomIndex(int roomCount)
        {
            return _random.Next(0, roomCount);
        }

        public int RollForMonsterNameIndex(int monstersCount)
        {
            return _random.Next(0, monstersCount);
        }
    }
}