namespace YoloCrawler.Fighting
{
    using System;
    using ConsolePresentation;
    using Entities;

    public class DummyFightingStrategy : TeamFightingStrategy
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

            var message = String.Format("YoloTeam attacking {0} at ({1}, {2}). {3} damage! {4} hp left.",
                monster.Name,
                monster.Position.X,
                monster.Position.Y,
                damage,
                monster.HitPoints);
            _logger.Log(message);
        }
    }
}