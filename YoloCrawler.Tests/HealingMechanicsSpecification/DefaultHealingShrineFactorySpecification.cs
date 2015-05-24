namespace YoloCrawler.Tests.HealingMechanicsSpecification
{
    using System;
    using Configuration;
    using Entities;
    using Factories;
    using FakeItEasy;
    using NUnit.Framework;

    class DefaultHealingShrineFactorySpecification
    {
        private DefaultHealingHealingShrineFactory _shrineFactory;
        private Dice _dice;

        [SetUp]
        public void Setup()
        {
            _dice = A.Fake<Dice>();
            _shrineFactory = new DefaultHealingHealingShrineFactory(_dice);
        }

        [Test]
        public void ShouldBuildShrineWithUseCountFromConfiguration()
        {
            //given
            var configuration = new HealingShrinesConfiguration
            {
                UseCountRange = Tuple.Create(1, 2),
                HealedHitpointsBetween = Tuple.Create(2, 4)
            };
            const int shrineUseCount = 2;
            A.CallTo(() => _dice.RollBetween(configuration.UseCountRange.Item1, configuration.UseCountRange.Item2)).Returns(shrineUseCount);

            var healingShrine = _shrineFactory.GetShrine(configuration);

            var toBeHealed = A.Fake<ICanHeal>();

            //when
            for (int i = 0; i < 100; i++)
            {
                healingShrine.Heal(toBeHealed);
            }

            //then
            A.CallTo(() => toBeHealed.Heal(A<int>.Ignored)).MustHaveHappened(Repeated.Exactly.Times(shrineUseCount));
        }

        [Test]
        public void ShouldCreateShrinesHealingHitpointsAsSpecifiedByConfig()
        {
            //given
            var toBeHealed = A.Fake<ICanHeal>();
            var configuration = new HealingShrinesConfiguration
            {
                UseCountRange = Tuple.Create(1, 2),
                HealedHitpointsBetween = Tuple.Create(2, 4)
            };
            const int shrineHealingPower = 3;
            A.CallTo(() => _dice.RollBetween(A<int>.Ignored, A<int>.Ignored)).Returns(1);
            A.CallTo(
                () =>
                    _dice.RollBetween(configuration.HealedHitpointsBetween.Item1,
                        configuration.HealedHitpointsBetween.Item2)).Returns(shrineHealingPower);

            var healingShrine = _shrineFactory.GetShrine(configuration);

            //when
            healingShrine.Heal(toBeHealed);

            //then
            A.CallTo(() => toBeHealed.Heal(A<int>.That.Matches(hitpointsHealed => hitpointsHealed == shrineHealingPower))).MustHaveHappened();
        }
    }

    internal class DefaultHealingHealingShrineFactory : HealingShrineFactory
    {
        private readonly Dice _dice;

        public DefaultHealingHealingShrineFactory(Dice dice)
        {
            _dice = dice;
        }

        public HealingShrine GetShrine(HealingShrinesConfiguration configuration)
        {
            var useCount = _dice.RollBetween(configuration.UseCountRange.Item1, configuration.UseCountRange.Item2);
            var healedHitpoints = _dice.RollBetween(configuration.HealedHitpointsBetween.Item1, configuration.HealedHitpointsBetween.Item2);

            return new HealingShrine(useCount, healedHitpoints);
        }
    }
}