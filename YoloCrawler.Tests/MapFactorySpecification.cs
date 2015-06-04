namespace YoloCrawler.Tests
{
    using System;
    using Configuration;
    using Entities;
    using Factories;
    using FakeItEasy;
    using NUnit.Framework;

    public class MapFactorySpecification
    {
        private MapFactory _mapFactory;
        private HealingShrineFactory _healingShrineFactory;
        private Dice _dice;

        [SetUp]
        public void Setup()
        {
            _dice = GetDiceMock();
            _healingShrineFactory = A.Fake<HealingShrineFactory>();
            _mapFactory = new MapFactory(_dice, _healingShrineFactory);
        }

        private Dice GetDiceMock()
        {
            var realDice = new YoloDice();
            var diceMock = A.Fake<Dice>();
            A.CallTo(() => diceMock.RollK100()).Returns(realDice.RollK100());
            A.CallTo(() => diceMock.RollBetween(A<int>.Ignored, A<int>.Ignored))
                .ReturnsLazily((int low, int high) => realDice.RollBetween(low, high));
            A.CallTo(() => diceMock.RollChance(A<int>.Ignored)).ReturnsLazily((int chance) => realDice.RollChance(chance));
            A.CallTo(() => diceMock.RollPosition(A<int>.Ignored, A<int>.Ignored))
                .ReturnsLazily((int width, int height) => realDice.RollPosition(width, height));

            return diceMock;
        }

        [Test]
        public void ShouldCreateRoomsAccordingToMapConfiguration()
        {
            //given
            var mapConfiguration = new MapConfiguration
            {
                RoomCountBetween = Tuple.Create(1, 2),
                MinRoomNeighboursCount = 1,
                MaxRoomNeighboursCount = 3,
                HealingShrines = new HealingShrinesConfiguration()
            };
            const int roomCount = 2;
            A.CallTo(
                () =>
                    _dice.RollBetween(mapConfiguration.RoomCountBetween.Item1, mapConfiguration.RoomCountBetween.Item2)).Returns(roomCount);

            //when
            var map = _mapFactory.GenerateMap(mapConfiguration);

            //then
            Assert.That(map.Rooms.Count, Is.EqualTo(roomCount));
        }

        [Test]
        public void ShouldSpawnShrinesAccordingToMapConfigurationAtRolledPosition()
        {
            //given
            var shrinePosition = new Position(2, 2);
            const int roomCount = 1;

            var mapConfiguration = new MapConfiguration
            {
                RoomCountBetween = Tuple.Create(roomCount, roomCount),
                MinRoomNeighboursCount = 1,
                MaxRoomNeighboursCount = 3,
                HealingShrines = new HealingShrinesConfiguration
                {
                    ShrinePercentageSpawnChance = 30
                }
            };

            A.CallTo(() =>_dice.RollBetween(mapConfiguration.RoomCountBetween.Item1, mapConfiguration.RoomCountBetween.Item2)).Returns(roomCount);
            A.CallTo(() => _dice.RollChance(mapConfiguration.HealingShrines.ShrinePercentageSpawnChance)).Returns(true);
            A.CallTo(() => _dice.RollPosition(A<int>.Ignored, A<int>.Ignored)).Returns(shrinePosition);

            var shrine = new HealingShrine(1, 1);
            A.CallTo(() => _healingShrineFactory.GetShrine(A<HealingShrinesConfiguration>.Ignored)).Returns(shrine);

            //when
            var map = _mapFactory.GenerateMap(mapConfiguration);

            //then
            var firstRoom = map.Rooms[0];

            Assert.That(firstRoom.Tiles[shrinePosition.X, shrinePosition.Y].Shrine, Is.EqualTo(shrine));
            Assert.That(firstRoom.Tiles[shrinePosition.X, shrinePosition.Y].HasShrine);
        }
    }
}