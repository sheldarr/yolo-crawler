namespace YoloCrawler.Entities
{
    using System;
    using System.Collections.Generic;

    public class Map
    {
        public List<Room> Rooms { get; set; }

        public Map()
        {
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room GetRandomRoom()
        {
            var randomIndex = (new Random()).Next(0, Rooms.Count - 1);

            return Rooms[randomIndex];
        }
    }
}