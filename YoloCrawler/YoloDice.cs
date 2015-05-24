namespace YoloCrawler
{
    using System;
    using Entities;

    public class YoloDice : Dice
    {
        private readonly Random _random;
        private const int FixingStupidUpperBound = 1;

        public YoloDice()
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

        public Position RollPosition(int width, int height)
        {
            return new Position(_random.Next(1, width - 1), _random.Next(1, height - 1));
        }

        public bool RollChance(int percentChance)
        {
            var k100 = RollK100();

            if (k100 <= percentChance)
            {
                return true;
            }

            return false;
        }

        public int RollBetween(int lowerBound, int upperBound)
        {
            return _random.Next(lowerBound, upperBound + FixingStupidUpperBound);
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