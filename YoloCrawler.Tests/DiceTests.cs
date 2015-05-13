namespace YoloCrawler.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DiceTests
    {
        private readonly Dice _dice = new Dice();

        [Test]
        public void ShouldRollNumberFrom1To100WhenRolingK100()
        {
            // when
            var result = _dice.RollK100();

            // then
            Assert.That(result, Is.InRange(1, 100));
        }

        [Test]
        public void ShouldRollForPlaceOnTheWallWhenPassigRoomWallSize()
        {
            // given
            const int wallSize = 10;

            // when
            var placeOnTheWall = _dice.RollForPlaceOnTheWall(wallSize);

            // then
            Assert.That(placeOnTheWall, Is.InRange(1, 9));
        }

        [Test]
        public void ShouldRollForFreeAvailableCoordinateInsideOfRoomLeavingOneFreeSpaceFromTheWallWhenPassingWallSize()
        {
            // given
            const int wallSize = 10;

            // when
            var coordinateValue = _dice.RollForFreeAvailableCoordinateValueBasedOn(wallSize);

            // then
            Assert.That(coordinateValue, Is.InRange(2, wallSize - 2));
        }

        [Test]
        public void ShouldRolForNeigbourningRoomCountWhenPassinMinAndMaxCount()
        {
            // given
            const int minCount = 4;
            const int maxCount = 5;

            // when
            var neighboursCount = _dice.RollForNeighboursCount(minCount, maxCount);

            // then
            Assert.That(neighboursCount, Is.InRange(4, 5));
        }

        [Test]
        public void ShouldRollForRollForRandomRoomWidthAndSizeThatIsNotBiggerThanDisplaySize()
        {
            // given
            // numbers that are divisable by 2
            const int maxDisplayWidth = 58;
            const int maxDisplayHeight = 18;

            // when
            var randomRoomWidth = _dice.RollForRandomRoomWidth();
            var randomRoomHeight = _dice.RollForRandomRoomHeight();

            // then
            Assert.That(randomRoomWidth, Is.InRange(4, maxDisplayWidth));
            Assert.That(randomRoomHeight, Is.InRange(4, maxDisplayHeight));
        }

        [Test]
        public void ShouldRollForRandomRoomIndexBasedOnRoomCount()
        {
            // given
            const int roomCount = 4;

            // when
            var randomRoomIndex = _dice.RollForRandomRoomIndex(roomCount);

            // then
            Assert.That(randomRoomIndex, Is.InRange(0, 3));
        }

        [Test]
        public void ShouldRollForHitpointsWhenMinAndMaxHitpointsValuesAreProvided()
        {
            // given
            const int minHitpoints = 1;
            const int maxHitpoints = 2;

            // when
            var hitpoints = _dice.RollForHitpoints(minHitpoints, maxHitpoints);

            // then
            Assert.That(hitpoints, Is.InRange(minHitpoints, maxHitpoints));
        }

        [Test]
        public void ShouldRollForMonsterNameIndex()
        {
            // given
            const int monstersCount = 4;

            // when
            var nameIndexes = new List<int>();

            for (var i = 0; i < 100000; i++)
            {
                var nameIndex = _dice.RollForMonsterNameIndex(monstersCount);
                nameIndexes.Add(nameIndex);
            }
            
            // then
            Assert.That(nameIndexes, Is.All.InRange(0, 3));
            Assert.That(nameIndexes.Contains(3), Is.True);
        }
    }
}