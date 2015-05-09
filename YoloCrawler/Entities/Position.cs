namespace YoloCrawler.Entities
{
    public class Position
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;

            if (position == null)
            {
                return false;
            }

            return _x == position._x && _y == position._y;
        }

        public static Position operator +(Position position, Offset offset)
        {
            var positionX = position._x + offset.X;
            var positionY = position._y + offset.Y;

            return new Position(positionX, positionY);
        }
    }
}