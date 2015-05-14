namespace YoloCrawler.Tests
{
    using System.Linq;
    using Entities;
    using Factories;
    using FakeItEasy;
    using NUnit.Framework;

    class RoomSpecification
    {
        private const int Width = 20;
        private const int Height = 30;
        private Dice _dice;
        private Room _room;

        [SetUp]
        public void Setup()
        {
            _dice = A.Fake<Dice>();
            _room = RoomFactory.CreateEmptyRoom(new Size(Width, Height), new Position(1,1), _dice);
        }

        [Test]
        public void ShouldSpawnOneMonsterInsideRoomBoundaries()
        {
            //given
            const int monsterCount = 1;
            var randomMonsterPosition = new Position(2, 2);

            A.CallTo(() => _dice.RollPosition(Width, Height)).ReturnsNextFromSequence(new [] { randomMonsterPosition });

            //when
            _room.SpawnMonsters(monsterCount);

            //then
            Assert.That(_room.Monsters.Count, Is.EqualTo(monsterCount));
            Assert.That(_room.Monsters.First().Position, Is.EqualTo(randomMonsterPosition));
        }

        [Test]
        public void ShouldNotSpawnMultipleMonstersOnTheSameTile()
        {
            //given
            const int monsterCount = 2;
            var randomMonsterPosition = new Position(2, 2);
            var secondRandomMonsterPosition = new Position(2,3);

            A.CallTo(() => _dice.RollPosition(Width, Height)).ReturnsNextFromSequence(new[] { randomMonsterPosition, randomMonsterPosition, secondRandomMonsterPosition});

            //when
            _room.SpawnMonsters(monsterCount);

            //then
            Assert.That(_room.Monsters.Count, Is.EqualTo(monsterCount));
            var firstMonster = _room.Monsters[0];
            Assert.That(firstMonster.Position, Is.EqualTo(randomMonsterPosition));
            var secondMonster = _room.Monsters[1];
            Assert.That(secondMonster.Position, Is.EqualTo(secondRandomMonsterPosition));
        }

        [Test]
        public void ShouldNotSpawnMonsterOnPlacesTwoTilesFromDoorInTheMiddleOfTheRoom()
        {
            //given
            const int monsterCount = 1;
            var doorPosition = new Position(5, 5);

            _room.Tiles[doorPosition.X, doorPosition.Y].AddDoorTo(RoomFactory.CreateEmptyRoom(new Size(5,5), new Position(1,1)));

            var monsterPositionsTooCloseToTheDoor = new[]
            {
                new Position(7, 7), new Position(3,3), new Position(3, 7), new Position(7, 3)
            };
            var validMonsterPosition = new Position(8, 8);

            A.CallTo(() => _dice.RollPosition(Width, Height)).ReturnsNextFromSequence(monsterPositionsTooCloseToTheDoor.Concat(new[] { validMonsterPosition }).ToArray());

            //when
            _room.SpawnMonsters(monsterCount);

            //then
            Assert.That(_room.Monsters.Count, Is.EqualTo(monsterCount));
            Assert.That(_room.Monsters.First().Position, Is.EqualTo(validMonsterPosition));
        }

        [Test]
        public void ShouldNotSpawnMonsterOnPlacesTwoTilesFromDoorOnAWall()
        {
            //given
            const int monsterCount = 1;
            var doorPosition = new Position(0, 5);

            _room.Tiles[doorPosition.X, doorPosition.Y].AddDoorTo(RoomFactory.CreateEmptyRoom(new Size(1, 1), new Position(1, 1)));

            var monsterPositionsTooCloseToTheDoor = new[]
            {
                new Position(2, 3), new Position(2,7), new Position(2, 5)  
            };
            var validMonsterPosition = new Position(3, 5);

            A.CallTo(() => _dice.RollPosition(Width, Height)).ReturnsNextFromSequence(monsterPositionsTooCloseToTheDoor.Concat(new[] { validMonsterPosition }).ToArray());

            //when
            _room.SpawnMonsters(monsterCount);

            //then
            Assert.That(_room.Monsters.Count, Is.EqualTo(monsterCount));
            Assert.That(_room.Monsters.First().Position, Is.EqualTo(validMonsterPosition));
        }
    }
}
