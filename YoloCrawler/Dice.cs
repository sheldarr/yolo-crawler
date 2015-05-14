namespace YoloCrawler
{
    using Entities;

    public interface Dice
    {
        int RollForFreeAvailableCoordinateValueBasedOn(int width);
        int RollK100();
        int RollForPlaceOnTheWall(int wallLength);
        Position RollPosition(int width, int height);
    }
}