namespace YoloCrawler.Tests.HealingMechanicsSpecification
{
    using System.Collections.Generic;
    using ConsolePresentation;
    using Entities;
    using Factories;
    using FakeItEasy;
    using Fighting;
    using NUnit.Framework;

    class EngineHealingSpecification
    {
        private readonly Size RoomSize = new Size(20, 20);

        [Test]
        public void ShouldHealYoloTeamWhenTheyMoveOnATileWithShrine()
        {
            //given
            var roomStartingPosition = new Position(1, 1);
            var shrinePosition = new Position(2, 1);
            var offsetFromStartToShrine = new Offset(1, 0);
            const int shrineHealingPower = 1;

            var map = GetMapWithARoomWithHealingShrineAt(roomStartingPosition, shrineHealingPower, shrinePosition);

            var yoloTeam = GetDamagedYoloTeam();
            var hitpointsBeforeHealing = yoloTeam.Hitpoints;

            var engine = new Engine(A.Fake<Presentation>(), A.Fake<Logger>(), map, yoloTeam);
            
            //when
            engine.Move(offsetFromStartToShrine);

            //then
            Assert.That(yoloTeam.Hitpoints, Is.EqualTo(hitpointsBeforeHealing + shrineHealingPower));
        }

        private Map GetMapWithARoomWithHealingShrineAt(Position roomStartingPosition, int shrineHealingPower, Position shrinePosition)
        {
            var roomWithAShrine = RoomFactory.CreateEmptyRoom(RoomSize, roomStartingPosition);
            var shrine = new HealingShrine(1, shrineHealingPower);
            roomWithAShrine.BuildShrine(shrine, shrinePosition);
            var map = new Map
            {
                Rooms = new List<Room> {roomWithAShrine}
            };
            return map;
        }

        private static YoloTeam GetDamagedYoloTeam()
        {
            var yoloTeam = new YoloTeam(10);
            yoloTeam.Take(new Damage
            {
                Hitpoints = 4
            });
            return yoloTeam;
        }
    }
}
