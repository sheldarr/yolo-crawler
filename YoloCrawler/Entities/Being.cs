namespace YoloCrawler.Entities
{
    public class Being : IAm
    {
        public string Name { get; protected set; }
        public Position Position { get; protected set; }
        public int Hitpoints { get; protected set; }

        public bool IsDead
        {
            get { return Hitpoints <= 0; }
        }
    }
}