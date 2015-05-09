namespace YoloCrawler.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using YoloCrawler.Entities;

    [TestFixture]
    public class YoloTeamTests
    {
        [Test]
        public void ShouldMoveInRoomWhenPossible()
        {
            // given
            var room = new Room(4, 4);
            room.CreateEmptyRoom();

            var position = new Position(1, 1);

            var team = new YoloTeam(room, position);

            // when
            team.Move(MovementOffsets.RightDown);

            // then
            Assert.That(team.Position, Is.EqualTo(new Position(2, 2)));
        }
    }
}