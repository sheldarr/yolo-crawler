namespace YoloCrawler.Factories
{
    using System;
    using System.Collections.Generic;
    using YoloCrawler.Entities;

    public class MapFactory
    {
        private readonly Position _startingPosition;
        private readonly Size _size;

        public MapFactory(Size roomSize, Position startingPosition)
        {
            _size = roomSize;
            _startingPosition = startingPosition;
        }

        public Map GenerateRandomMap(int roomCount)
        {
            var origin = GetNewRoom(_size, _startingPosition);

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

        private Room GetNewRoom(Size size, Position startingPosition)
        {
            return RoomFactory.CreateEmptyRoom(size, startingPosition);
        }

        private List<Room> GenerateNeighbours(Room room, int minCount, int maxCount)
        {
            var neighbourCount = (new Random()).Next(minCount, maxCount);

            var rooms = new List<Room>();

            for (int i = 0; i < neighbourCount; i++)
            {
                var newRoom = GetNewRoom(_size, _startingPosition);
                rooms.Add(newRoom);

                room.AddLink(newRoom);
                newRoom.AddLink(room);
            }

            return rooms;
        }
    }
}