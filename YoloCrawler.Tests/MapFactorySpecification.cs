namespace YoloCrawler.Tests
{
    using Configuration;
    using Entities;
    using Factories;
    using FakeItEasy;
    using NUnit.Framework;

    public class MapFactorySpecification
    {
        [Test]
        public void ShouldSpawnShrinesAccordingToMapConfiguration()
        {
            //given
            var shrinePosition = new Position(2, 2);
            var mapConfiguration = new MapConfiguration();

            var dice = A.Fake<Dice>();
            const int k100RollResult = 1;
            A.CallTo(() => dice.RollK100()).Returns(k100RollResult);
            A.CallTo(() => dice.RollChance(mapConfiguration.ShrineSpawnChance)).Returns(true);
            A.CallTo(() => dice.RollPosition(A<int>.Ignored, A<int>.Ignored)).Returns(shrinePosition);

            var shrineFactory = A.Fake<HealingShrineFactory>();
            var shrine = new HealingShrine(1, 1);
            A.CallTo(() => shrineFactory.GetShrine(A<HealingShrinesConfiguration>.Ignored)).Returns(shrine);
            var mapFactory = new MapFactory(dice, shrineFactory);

            //when
            var map = mapFactory.GenerateMap(mapConfiguration);

            //then
            Assert.That(map.Rooms.Count, Is.EqualTo(k100RollResult));
            var firstRoom = map.Rooms[0];

            Assert.That(firstRoom.Tiles[shrinePosition.X, shrinePosition.Y].HasShrine);
        }
    }
}