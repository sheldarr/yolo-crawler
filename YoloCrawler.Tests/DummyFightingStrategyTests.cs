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
            var dummyFightingStrategy = new DummyFightingStrategy(logger);

            var position = A.Dummy<Position>();
            var monster = new Monster(position);
            var monsterHitPoints = monster.HitPoints;

            //when
            dummyFightingStrategy.Attack(monster);

            //then
            Assert.That(monster.HitPoints, Is.EqualTo(monsterHitPoints - 1));
        }
    }
}