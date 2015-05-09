namespace YoloCrawler.Tests
{
    using ConsolePresentation;
    using Entities;
    using FakeItEasy;
    using Fighting;
    using NUnit.Framework;

    [TestFixture]
    class DummyFightingStrategyTests
    {
        [Test]
        public void ShouldDealOneDamageToMonster()
        {
            //given
            var logger = A.Dummy<Logger>();
            var dummyFightingStrategy = new YoloTeamFightingStrategy(logger);

            var position = A.Dummy<Position>();
            var monster = new Monster("TestMonster", position);
            var monsterHitPoints = monster.HitPoints;

            //when
            dummyFightingStrategy.Attack(monster);

            //then
            Assert.That(monster.HitPoints, Is.EqualTo(monsterHitPoints - 1));
        }
    }
}