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
            var room = RoomFactory.CreateEmptyRoom(new Size(4, 4), new Position(1, 1));

            var team = new YoloTeam(room.StartingPosition);

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
            var room = RoomFactory.CreateEmptyRoom(new Size(4,4), startingPosition);

            // when
            var team = new YoloTeam(room.StartingPosition);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }
    }
}