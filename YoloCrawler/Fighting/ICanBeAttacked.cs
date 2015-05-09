namespace YoloCrawler.Fighting
{
    using Entities;

    public interface ICanBeAttacked : IAm
    {
        int Hitpoints { get; }
        void Take(Damage dmg);
    }
}