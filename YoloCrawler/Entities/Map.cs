namespace YoloCrawler.Entities
{
    using System.Collections.Generic;

    public class Map
    {
        private readonly YoloDice _yoloDice;
        public List<Room> Rooms { get; set; }

        public Map()
        {
            _yoloDice = new YoloDice();
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room GetRandomStartingRoom()
        {
            var randomIndex = _yoloDice.RollForRandomRoomIndex(Rooms.Count);

            return Rooms[randomIndex];
        }
    }
}