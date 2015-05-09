namespace YoloCrawler
{
    using YoloCrawler.Entities;

    public interface Presentation
    {
        void Log(string output);
        void Draw(WorldRepresentation worldRepresentation);
    }
}