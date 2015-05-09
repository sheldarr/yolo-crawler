namespace YoloCrawler
{
    using System.Collections.Generic;
    using System.Threading;
    using Entities;
    using Extensions;
    using Factories;
    using Fighting;

    public class Engine

    {
        private readonly Presentation _presentation;
        private Room _room;
        private YoloTeam _team;
        private WorldRepresentation _worldRepresentation;
        public Map Map { get; set; }

        public Engine(Presentation presentation)
        {
            _presentation = presentation;
            InitializeGame();
        }

        private void InitializeGame()
        {
            var startingPosition = new Position(1,1);
            var roomSize = new Size(16, 16);
            var dummyFightingStrategy = new DummyFightingStrategy();

            var factory = new MapFactory(roomSize, startingPosition);
            Map = factory.GenerateRandomMap(4);
            _room = Map.GetRandomRoom();
            _team = new YoloTeam(_room, dummyFightingStrategy);
            _worldRepresentation = new WorldRepresentation(_room, _team);
        }

        public void Move(Offset offset)
        {
            RemoveDeadMonsters(_room.Monsters);
            _team.Move(offset);
            _worldRepresentation = new WorldRepresentation(_room, _team);
            _presentation.Draw(_worldRepresentation);
        }

        private void RemoveDeadMonsters(List<Monster> monsters)
        {
            monsters.RemoveAll(monster => monster.HitPoints <= 0);
        }

        public void SayHello()
        {
            _presentation.Log("hello!");
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000 / 24);
            }
        }
    }

    internal class DummyFightingStrategy : TeamFightingStrategy
    {
        public void Attack(Monster monster)
        {
            monster.HitPoints -= 1;
        }
    }
}