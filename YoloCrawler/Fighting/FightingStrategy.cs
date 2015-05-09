namespace YoloCrawler.Fighting
{
    public interface FightingStrategy
    {
        void Attack(ICanBeAttacked monster);
    }
}