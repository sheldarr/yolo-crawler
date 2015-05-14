namespace YoloCrawler.Factories
{
    using System.Collections.Generic;
    using Entities;

    public class MapFactory
    {
        private static readonly YoloDice YoloDice = new YoloDice();
        const int MinNeighboursCount = 1;
        const int MaxNeighboursCount = 3;

        public static Map GenerateRandomMap()
        {
            var roomCount = YoloDice.RollK100();
            var origin = GetNewRandomRoom();

            var rooms = new List<Room>();
            var neighbourQueue = new Queue<Room>();

            neighbourQueue.Enqueue(origin);
            rooms.Add(origin);

            while (roomCount != 0)
            {
                var room = neighbourQueue.Dequeue();
                var newRooms = GenerateNeighbours(room, MinNeighboursCount, MaxNeighboursCount);

                roomCount -= newRooms.Count;
                newRooms.ForEach(neighbourQueue.Enqueue);
                rooms.AddRange(newRooms);
            }

            rooms.ForEach(room => room.SpawnMonsters(1));

            return new Map
            {
                Rooms = rooms
            };
        }

        private static List<Room> GenerateNeighbours(Room room, int minCount, int maxCount)
        {
            var neighbourCount = YoloDice.RollForNeighboursCount(minCount, maxCount);

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

        private static Room GetNewRandomRoom()
        {
            int randomWidth;
            do
            {
                randomWidth = YoloDice.RollForRandomRoomWidth();
            } while (randomWidth % 2 != 0);

            int randomHeight;

            do
            {
                randomHeight = YoloDice.RollForRandomRoomHeight();
            } while (randomHeight % 2 != 0);

            var roomSize = new Size(randomWidth, randomHeight);
            var startingPosition = new Position(1, 1);
            return RoomFactory.CreateEmptyRoom(roomSize, startingPosition);
        }
    }
}