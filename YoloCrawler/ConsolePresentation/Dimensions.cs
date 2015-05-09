namespace YoloCrawler.ConsolePresentation
{
    internal struct Dimensions
    {
        public Point Origin;
        public Size DisplaySize;

        public Dimensions(Point origin, Size displaySize)
        {
            DisplaySize = displaySize;
            Origin = origin;
        }
    }
}