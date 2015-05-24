namespace YoloCrawler.Tests.HealingMechanicsSpecification
{
    using Entities;
    using FakeItEasy;
    using NUnit.Framework;

    class HealingShrineSpecification
    {
        private const int DefaultShrineUseCount = 1;

        [Test]
        public void ShouldHealProperNumberOfHitpoints()
        {
            //given
            const int hitpointsToBeHealed = 2;
            var canHeal = A.Fake<ICanHeal>();

            var shrine = new HealingShrine(DefaultShrineUseCount, hitpointsToBeHealed);

            //when
            shrine.Heal(canHeal);

            //then
            A.CallTo(() => canHeal.Heal(hitpointsToBeHealed)).MustHaveHappened();
        }

        [Test]
        public void ShouldHealLimitedNumberOfTimes()
        {
            //given
            var canHeal = A.Fake<ICanHeal>();

            const int hitpointsToBeHealed = 2;
            const int shrineUseCount = 1;
            var shrine = new HealingShrine(shrineUseCount, hitpointsToBeHealed);

            //when
            shrine.Heal(canHeal);
            shrine.Heal(canHeal);

            //then
            A.CallTo(() => canHeal.Heal(hitpointsToBeHealed)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}