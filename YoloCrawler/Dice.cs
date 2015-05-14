namespace YoloCrawler
{
    using Entities;

    public interface Dice
    {
        int RollK100();
        int RollForPlaceOnTheWall(int wallLength);
        Position RollPosition(int width, int height);
    }
}