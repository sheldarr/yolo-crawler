namespace YoloCrawler.Fighting
{
    using System;
    using ConsolePresentation;
    using Entities;

    internal class DummyFightingStrategy : TeamFightingStrategy
    {
        private readonly Logger _logger;

        public DummyFightingStrategy(Logger logger)
        {
            _logger = logger;
        }

        public void Attack(Monster monster)
        {
            const int damage = 1;
            monster.HitPoints -= damage;

            var message = String.Format("YoloTeam attacking monster at ({0}, {1}). {2} damage! {3} hp left.",
                monster.Position.X,
                monster.Position.Y,
                damage,
                monster.HitPoints);
            _logger.Log(message);
        }
    }
}