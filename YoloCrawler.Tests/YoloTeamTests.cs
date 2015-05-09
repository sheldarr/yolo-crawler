namespace YoloCrawler.Tests
{
    using FakeItEasy;
    using Fighting;
    using NUnit.Framework;
    using Entities;
    using Factories;

    [TestFixture]
    public class YoloTeamTests
    {
        [Test]
        public void ShouldMoveInRoomWhenPossible()
        {
            // given
            var startingPosition = new Position(1, 1);
            var room = RoomFactory.CreateEmptyRoom(4, 4, startingPosition);

            var fightingStrategy = A.Dummy<TeamFightingStrategy>();

            var team = new YoloTeam(room, fightingStrategy);

            // when
            team.Move(MovementOffsets.RightDown);

            // then
            Assert.That(team.Position, Is.EqualTo(new Position(2, 2)));
        }

        [Test]
        public void ShouldPlaceYoloTeamAtRoomStartingPosition()
        {
            // given
            var startingPosition = new Position(1, 1);
            var room = RoomFactory.CreateEmptyRoom(4, 4, startingPosition);

            var dummyFightingStrategy = A.Dummy<TeamFightingStrategy>();

            // when
            var team = new YoloTeam(room, dummyFightingStrategy);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }

        [Test]
        public void ShouldNotAllowWalkingIntoTheWall()
        {
            // given
            var startingPosition = new Position(1, 1);
            var room = RoomFactory.CreateEmptyRoom(4, 4, startingPosition);

            var dummyFightingStrategy = A.Dummy<TeamFightingStrategy>();

            var team = new YoloTeam(room, dummyFightingStrategy);

            // when
            team.Move(MovementOffsets.LeftUp);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }
    }
}