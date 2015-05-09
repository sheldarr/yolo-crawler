namespace YoloCrawler.Fighting
{
    using System;
    using ConsolePresentation;

    public class YoloTeamFightingStrategy : FightingStrategy
    {
        private readonly Logger _logger;

        public YoloTeamFightingStrategy(Logger logger)
        {
            _logger = logger;
        }

        public void Attack(ICanBeAttacked monster)
        {
            const int damage = 1;
            monster.Take(new Damage
            {
                Hitpoints = 1
            });

            var message = String.Format("YoloTeam attacking {0} at ({1}, {2}). {3} damage! {4} hp left.",
                monster.Name,
                monster.Position.X,
                monster.Position.Y,
                damage,
                monster.Hitpoints);
            _logger.Log(message);
        }
    }
}