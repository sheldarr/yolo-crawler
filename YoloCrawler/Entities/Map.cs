namespace YoloCrawler.Entities
{
    using System.Collections.Generic;

    public class Map
    {
        private readonly Dice _dice;
        public List<Room> Rooms { get; set; }

        public Map()
        {
            _dice = new Dice();
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room GetRandomStartingRoom()
        {
            var randomIndex = _dice.RollForRandomRoomIndex(Rooms.Count);

            return Rooms[randomIndex];
        }
    }
}