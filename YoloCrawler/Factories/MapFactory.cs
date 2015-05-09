namespace YoloCrawler.Factories
{
    using System;
    using System.Collections.Generic;
    using YoloCrawler.Entities;
    using YoloCrawler.Extensions;

    public class MapFactory
    {
        private static readonly Random Random = new Random();

        public static Map GenerateRandomMap(int roomCount)
        {
            var origin = GetNewRandomRoom();

            var rooms = new List<Room>();
            var neighbourQueue = new Queue<Room>();

            neighbourQueue.Enqueue(origin);
            rooms.Add(origin);

            while (roomCount != 0)
            {
                var room = neighbourQueue.Dequeue();
                var newRooms = GenerateNeighbours(room, 1, 3);

                roomCount -= newRooms.Count;
                newRooms.ForEach(neighbourQueue.Enqueue);
                rooms.AddRange(newRooms);
            }

            return new Map
            {
                Rooms = rooms
            };
        }

        private static List<Room> GenerateNeighbours(Room room, int minCount, int maxCount)
        {
            var neighbourCount = Random.Next(minCount, maxCount);

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
            var randomWidth = 9;
            while (randomWidth % 2 != 0)
            {
                randomWidth = Random.Next(4, 58);
            }

            var randomHeight = 9;
            while (randomHeight % 2 != 0)
            {
                randomHeight = Random.Next(4, 18);
            }

            var roomSize = new Size(randomWidth, randomHeight);
            var startingPosition = new Position(1, 1);
            return RoomFactory.CreateEmptyRoom(roomSize, startingPosition).WithRandomMonster();
        }
    }
}