namespace YoloCrawler.Tests
{
    using System;
    using System.Linq;
    using Entities;
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
            _room = new Room(new Size(Width, Height), new Position(1, 1), _dice);
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
    }
}
