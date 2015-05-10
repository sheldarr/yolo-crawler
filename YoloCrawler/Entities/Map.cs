namespace YoloCrawler.Entities
{
    using System;
    using System.Collections.Generic;

    public class Map
    {
        private readonly Random _random;
        public List<Room> Rooms { get; set; }

        public Map()
        {
            Rooms = new List<Room>();
            _random = new Random();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room GetRandomRoom()
        {
            var randomIndex = _random.Next(0, Rooms.Count - 1);

            return Rooms[randomIndex];
        }
    }
}