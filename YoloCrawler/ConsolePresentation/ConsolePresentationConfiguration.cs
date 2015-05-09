namespace YoloCrawler.ConsolePresentation
{
    using Entities;

    internal class ConsolePresentationConfiguration
    {
        public char GetTileCharacter(Tile tile)
        {
            switch (tile.Type)
            {
                case TileType.Wall:
                    return '#';
                default:
                    return '.';
            }
        }

        public char VerticalDisplayBorder
        {
            get { return '|'; }
        }

        public char HorizontalDisplayBorder
        {
            get { return '-'; }
        }

        public char EmptySpace
        {
            get { return ' '; }
        }

        public char TeamCharacter
        {
            get { return 'Y'; }
        }

        public char MonsterCharacter
        {
            get { return 'M'; }
        }
    }
}