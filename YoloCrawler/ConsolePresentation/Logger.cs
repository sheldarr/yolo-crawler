namespace YoloCrawler.ConsolePresentation
{
    using Entities;
    using Fighting;

    public interface Logger
    {
        void Log(string output);
        void LogFight(ICanAttack attacker, ICanBeAttacked victim);
        void LogHeal(Being healedBeing, int hitpointsBeforeHeal);
    }
}