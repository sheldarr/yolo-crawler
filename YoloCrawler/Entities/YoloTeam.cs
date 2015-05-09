namespace YoloCrawler.Entities
{
    using System.Linq;
    using Fighting;

    public class YoloTeam
    {
        private readonly Room _room;
        private Position _position;
        private readonly TeamFightingStrategy _teamFightingStrategy;

        public YoloTeam(Room room, TeamFightingStrategy teamFightingStrategy)
        {
            _room = room;
            _position = _room.StartingPosition;
            _teamFightingStrategy = teamFightingStrategy;
        }

        public Position Position
        {
            get { return _position; }
        }

        public void Move(Offset offset)
        {
            var nextPosition = _position + offset;

            if (_room.Tiles[nextPosition.X, nextPosition.Y].Type == TileType.Wall)
            {
                return;
            }

            if (MonsterOccupiesPosition(nextPosition))
            {
                AttackMonster();
            }

            _position += offset;
        }

        private void AttackMonster()
        {
            var monsterToAttack = _room.Monsters.Single(monster => Equals(monster.Position, _position));
            _teamFightingStrategy.Attack(monsterToAttack);
        }

        public bool MonsterOccupiesPosition(Position position)
        {
            return _room.Monsters.Any(monster => Equals(monster.Position, position));
        }
    }
}