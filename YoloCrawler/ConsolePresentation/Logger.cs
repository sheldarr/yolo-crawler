namespace YoloCrawler.ConsolePresentation
{
    using Fighting;

    public interface Logger
    {
        void Log(string output);
        void LogFight(ICanAttack attacker, ICanBeAttacked victim);
    }
}