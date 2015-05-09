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

        public static Position operator + (Position position, Offset offset)
        {
            position.X += offset.X;
            position.Y += offset.Y;

            return position;
        }
    }
}