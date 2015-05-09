namespace YoloCrawler
{
    public class Offset
    {
        private readonly int _x;
        private readonly int _y;

        public Offset(int x, int y)
        {
            _x = ClampValue(x);
            _y = ClampValue(y);
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        private int ClampValue(int value)
        {
            if (value > 1)
            {
                value = 1;
            }

            if (value < -1)
            {
                value = -1;
            }

            return value;
        }
    }
}