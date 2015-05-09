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
        private readonly TeamFightingStrategy _dummyFightingStrategy = A.Dummy<TeamFightingStrategy>();

        [Test]
        public void ShouldMoveInRoomWhenPossible()
        {
            // given
            var room = RoomFactory.CreateEmptyRoom(new Size(4, 4), new Position(1, 1));

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
            var room = RoomFactory.CreateEmptyRoom(new Size(4,4), startingPosition);

            // when
            var team = new YoloTeam(room, _dummyFightingStrategy);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }

        [Test]
        public void ShouldNotAllowWalkingIntoTheWall()
        {
            // given
            var startingPosition = new Position(1, 1);
            var room = RoomFactory.CreateEmptyRoom(new Size(4,4), startingPosition);

            var team = new YoloTeam(room, _dummyFightingStrategy);

            // when
            team.Move(MovementOffsets.LeftUp);

            // then
            Assert.That(team.Position, Is.EqualTo(startingPosition));
        }
    }
}