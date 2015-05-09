namespace YoloCrawler.Entities
{
    public interface IAm
    {
        string Name { get; }
        Position Position { get; }
        int Hitpoints { get; }
    }
}