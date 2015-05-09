namespace YoloCrawler.Tests
{
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

            var team = new YoloTeam(room);

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

            // when
            var team = new YoloTeam(room);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }

        [Test]
        public void ShouldNotAllowWalkingIntoTheWall()
        {
            // given
            var startingPosition = new Position(1, 1);
            var room = RoomFactory.CreateEmptyRoom(4, 4, startingPosition);

            var team = new YoloTeam(room);

            // when
            team.Move(MovementOffsets.LeftUp);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }
    }
}