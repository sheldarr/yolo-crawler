namespace YoloCrawler
{
    using System;

    public class Dice
    {
        private readonly Random _random;

        public Dice()
        {
            _random = new Random();
        }

        public int RollK100()
        {
            return _random.Next(1, 100);
        }

        public int RollForPlaceOnTheWall(int roomHeight)
        {
            const int minDistanceToAvoidTheCorner = 1;
            return _random.Next(minDistanceToAvoidTheCorner, roomHeight - minDistanceToAvoidTheCorner);
        }

        public int RollForFreeAvailableCoordinateValueBasedOn(int widthOrHeight)
        {
            const int minDistanceToWall = 2;
            return _random.Next(minDistanceToWall, widthOrHeight - minDistanceToWall);
        }

        public int RollForNeighboursCount(int minCount, int maxCount)
        {
            return _random.Next(minCount, maxCount);
        }

        public int RollForRandomRoomWidth()
        {
            const int minRoomWidth = 4;
            const int maxRoomWidthBasedOnMaxDisplayWidth = 58;
            return _random.Next(minRoomWidth, maxRoomWidthBasedOnMaxDisplayWidth);
        }

        public int RollForRandomRoomHeight()
        {
            const int minRoomHeight = 4;
            const int maxRoomHeightBasedOnMaxDisplayHeight = 18;
            return _random.Next(minRoomHeight, maxRoomHeightBasedOnMaxDisplayHeight);
        }

        public int RollForRandomRoomIndex(int roomCount)
        {
            return _random.Next(0, roomCount - 1);
        }

        public int RollForHitpoints(int minHitpoints, int maxHitpoints)
        {
            return _random.Next(minHitpoints, maxHitpoints);
        }

        public int RollForMonsterNameIndex(int monstersCount)
        {
            return _random.Next(1, monstersCount);
        }
    }
}