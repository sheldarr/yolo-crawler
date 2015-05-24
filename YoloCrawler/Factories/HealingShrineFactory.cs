namespace YoloCrawler.Factories
{
    using Configuration;

    public interface HealingShrineFactory
    {
        HealingShrine GetShrine(HealingShrinesConfiguration configuration);
    }
}