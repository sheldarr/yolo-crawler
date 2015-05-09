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
            var room = RoomFactory.CreateEmptyRoom(4, 4);

            var position = new Position(1, 1);

            var fightingStrategy = A.Dummy<TeamFightingStrategy>();

            var team = new YoloTeam(room, position, fightingStrategy);

            // when
            team.Move(MovementOffsets.RightDown);

            // then
            Assert.That(team.Position, Is.EqualTo(new Position(2, 2)));
        }
    }
}