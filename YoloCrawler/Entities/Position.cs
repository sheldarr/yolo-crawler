namespace YoloCrawler.Entities
{
    public class Position
    {
        public int Y { get; private set; }
        public int X { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;

            if (position == null)
            {
                return false;
            }

            return X == position.X && Y == position.Y;
        }

        public static Position operator +(Position position, Offset offset)
        {
            var positionX = position.X + offset.X;
            var positionY = position.Y + offset.Y;

            return new Position(positionX, positionY);
        }

        public Offset GetOffsetTowards(Position target)
        {
            var offsetX = target.X - X == 0 ? 0 : (target.X - X < 0 ? -1 : 1);
            var offsetY = target.Y - Y == 0 ? 0 : (target.Y - Y < 0 ? -1 : 1);

            return new Offset(offsetX, offsetY);
        }

        public override string ToString()
        {
            return string.Format("({0};{1})", X, Y);
        }
    }
}