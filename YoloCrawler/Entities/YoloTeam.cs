namespace YoloCrawler.Entities
{
    using Fighting;

    public class YoloTeam
    {
        private Position _position;
        private readonly TeamFightingStrategy _teamFightingStrategy;

        public YoloTeam(TeamFightingStrategy teamFightingStrategy, Position startingPosition)
        {
            _position = startingPosition;
            _teamFightingStrategy = teamFightingStrategy;
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
            _teamFightingStrategy.Attack(monsterToAttack);
        }

        public void EnterRoom(Position newRoomStartingPosition)
        {
            _position = newRoomStartingPosition;
        }
    }
}