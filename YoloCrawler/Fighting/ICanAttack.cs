namespace YoloCrawler.Fighting
{
    using Entities;

    public interface ICanAttack : IAm
    {
        void Attack(ICanBeAttacked target);
    }
}