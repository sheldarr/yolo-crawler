namespace YoloCrawler.Tests.HealingMechanicsSpecification
{
    using Entities;
    using Fighting;
    using NUnit.Framework;

    internal class YoloTeamHealing
    {
        private static Position StartingPosition { get { return new Position(0,0); } }

        [Test]
        public void ShouldHealSpecifiedNumberOfHitpoints()
        {
            //given
            const int teamMaxHitpoints = 10;
            var yoloTeam = new YoloTeam(StartingPosition, teamMaxHitpoints);
            yoloTeam.Take(new Damage {Hitpoints = 2});
            var hitpointsWhenHealing = yoloTeam.Hitpoints;

            const int hitpointsToHeal = 1;

            //when
            yoloTeam.Heal(hitpointsToHeal);

            //then
            Assert.That(yoloTeam.Hitpoints, Is.EqualTo(hitpointsWhenHealing + hitpointsToHeal));
        }

        [Test]
        public void ShouldNotExceedBaseHitpointsWhenHealing()
        {
            //given
            const int teamMaxHitpoints = 10;
            var yoloTeam = new YoloTeam(StartingPosition, teamMaxHitpoints);
            yoloTeam.Take(new Damage { Hitpoints = 2 });

            const int hitpointsToHeal = 4;

            //when
            yoloTeam.Heal(hitpointsToHeal);

            //then
            Assert.That(yoloTeam.Hitpoints, Is.EqualTo(teamMaxHitpoints));
        }
    }
}
