namespace YoloCrawler.Tests
{
    using NUnit.Framework;
    using Entities;
    using Factories;

    [TestFixture]
    public class YoloTeamTests
    {
        private const int YoloTeamHitpoints = 10;

        [Test]
        public void ShouldMoveInRoomWhenPossible()
        {
            // given
            var room = RoomFactory.CreateEmptyRoom(new Size(4, 4), new Position(1, 1));

            var team = new YoloTeam(room.StartingPosition, YoloTeamHitpoints);

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
            var team = new YoloTeam(room.StartingPosition, YoloTeamHitpoints);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }
    }
}