namespace YoloCrawler.Entities
{
    public class WorldRepresentation
    {
        private readonly Room _room;
        private readonly YoloTeam _team;

        public WorldRepresentation(Room room, YoloTeam team)
        {
            _room = room;
            _team = team;
        }

        public Room Room
        {
            get { return _room; }
        }

        public YoloTeam Team
        {
            get { return _team; }
        }
    }
}