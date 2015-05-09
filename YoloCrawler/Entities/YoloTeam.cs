namespace YoloCrawler.Entities
{
    using Fighting;

    public class YoloTeam
    {
        private Position _position;
        private readonly FightingStrategy _fightingStrategy;

        public YoloTeam(FightingStrategy fightingStrategy, Position startingPosition)
        {
            _position = startingPosition;
            _fightingStrategy = fightingStrategy;
        }

        public Position Position
        {
            get { return _position; }
        }

        public void Move(Offset offset)
        {
            _position += offset;
        }

        public void Attack(Monster monsterToAttack)
        {
            _fightingStrategy.Attack(monsterToAttack);
        }

        public void EnterRoom(Position newRoomStartingPosition)
        {
            _position = newRoomStartingPosition;
        }
    }
}