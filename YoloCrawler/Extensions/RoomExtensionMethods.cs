namespace YoloCrawler.Extensions
{
    using System;
    using Entities;
    using Factories;

    public static class RoomExtensionMethods
    {
        public static Room WithRandomMonster(this Room room)
        {
            Position randomAvailablePosition = room.GetRandomAvailablePosition();
            var monster = MonsterFactory.CreateRandomMonster(room, randomAvailablePosition);

            room.Monsters.Add(monster);

            return room;
        }
    }
}