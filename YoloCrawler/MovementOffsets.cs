namespace YoloCrawler
{
    public static class MovementOffsets
    {
        public static Offset LeftUp = new Offset(-1, -1);
        public static Offset Up = new Offset(0, -1);
        public static Offset RightUp = new Offset(1, -1);
        public static Offset Left = new Offset(-1, 0);
        public static Offset Right = new Offset(1, 0);
        public static Offset LeftDown = new Offset(-1, 1);
        public static Offset Down = new Offset(0, 1);
        public static Offset RightDown = new Offset(1, 1);
    }
}