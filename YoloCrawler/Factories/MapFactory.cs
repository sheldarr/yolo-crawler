namespace YoloCrawler.Factories
{
    using System.Collections.Generic;
    using Configuration;
    using Entities;

    public class MapFactory
    {
        private readonly Dice _dice;
        private readonly HealingShrineFactory _healingShrineFactory;
        private const int MaxRoomHeightBasedOnMaxDisplayHeight = 18;
        private const int MaxRoomWidthBasedOnMaxDisplayWidth = 58;

        public MapFactory(Dice dice, HealingShrineFactory healingShrineFactory)
        {
            _dice = dice;
            _healingShrineFactory = healingShrineFactory;
        }

        public Map GenerateMap(MapConfiguration mapConfiguration)
        {
            var roomCount = _dice.RollBetween(mapConfiguration.RoomCountBetween.Item1, mapConfiguration.RoomCountBetween.Item2);
            var origin = GetNewRandomRoom();

            var rooms = new List<Room>();
            var neighbourQueue = new Queue<Room>();

            neighbourQueue.Enqueue(origin);
            rooms.Add(origin);
            roomCount--;

            while (roomCount != 0)
            {
                var room = neighbourQueue.Dequeue();
                int maxNeighboursCount = (mapConfiguration.MaxRoomNeighboursCount > roomCount) ? roomCount : mapConfiguration.MaxRoomNeighboursCount;
                var newRooms = GenerateNeighbours(room, mapConfiguration.MinRoomNeighboursCount, maxNeighboursCount);

                roomCount -= newRooms.Count;
                newRooms.ForEach(neighbourQueue.Enqueue);
                rooms.AddRange(newRooms);
            }

            rooms.ForEach(room => room.SpawnMonsters(1));

            SpawnShrines(rooms, mapConfiguration.HealingShrines);

            return new Map
            {
                Rooms = rooms
            };
        }

        private void SpawnShrines(IEnumerable<Room> rooms, HealingShrinesConfiguration healingShrinesConfiguration)
        {
            foreach (var room in rooms)
            {
                var shouldSpawnShrine = _dice.RollChance(healingShrinesConfiguration.ShrinePercentageSpawnChance);

                if (!shouldSpawnShrine)
                {
                    continue;
                }

                var newShrine = _healingShrineFactory.GetShrine(healingShrinesConfiguration);
                var shrinePosition = _dice.RollPosition(room.Size.Width, room.Size.Height);

                room.BuildShrine(newShrine, shrinePosition);
            }
        }

        private List<Room> GenerateNeighbours(Room room, int minCount, int maxCount)
        {
            var neighbourCount = _dice.RollBetween(minCount, maxCount);

            var rooms = new List<Room>();

            for (var i = 0; i < neighbourCount; i++)
            {
                var newRoom = GetNewRandomRoom();
                rooms.Add(newRoom);

                room.AddLink(newRoom);
                newRoom.AddLink(room);
            }

            return rooms;
        }

        private Room GetNewRandomRoom()
        {
            int randomWidth;
            do
            {
                randomWidth = _dice.RollBetween(4, MaxRoomWidthBasedOnMaxDisplayWidth);
            } while (randomWidth % 2 != 0);

            int randomHeight;

            do
            {
                randomHeight = _dice.RollBetween(4, MaxRoomHeightBasedOnMaxDisplayHeight);
            } while (randomHeight % 2 != 0);

            var roomSize = new Size(randomWidth, randomHeight);
            var startingPosition = new Position(1, 1);
            return RoomFactory.CreateEmptyRoom(roomSize, startingPosition);
        }
    }
}