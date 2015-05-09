namespace YoloCrawler.Fighting
{
    using Entities;

    public interface ICanBeAttacked : IAm
    {
        void Take(Damage dmg);
    }
}