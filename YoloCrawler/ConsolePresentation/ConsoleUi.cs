namespace YoloCrawler.ConsolePresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Entities;
    using Fighting;

    internal class ConsoleUi : Presentation, Logger
    {
        private readonly Size _displaySize;
        private readonly Window _logWindow;
        private readonly Window _mapWindow;
        private readonly ConsolePresentationConfiguration _consolePresentationConfiguration;

        public ConsoleUi(Size displaySize, ConsolePresentationConfiguration consolePresentationConfiguration)
        {
            _displaySize = new Size(displaySize.Width, displaySize.Height);

            _consolePresentationConfiguration = consolePresentationConfiguration;
            const int logWindowHeight = 6;

            Console.WindowWidth = _displaySize.Width;
            Console.WindowHeight = _displaySize.Height + logWindowHeight + 1;

            _mapWindow = new Window(new Dimensions(new Point(0,0), _displaySize));
            _logWindow = new Window(new Dimensions(new Point(0,_displaySize.Height), new Size(_displaySize.Width, logWindowHeight)));

            InitializeMapWindow();

            Console.SetCursorPosition(0, _displaySize.Height + logWindowHeight);
        }

        public void Log(string output)
        {
            _logWindow.WriteLine(output);
        }

        public void LogFight(ICanAttack attacker, ICanBeAttacked victim)
        {
            _logWindow.WriteLine(string.Format("{0} attacked {1}. {1} is now angry at {2} hp.", attacker.Name, victim.Name, victim.Hitpoints));
        }

        private void InitializeMapWindow()
        {
            GetHorizontalBorder();

            for (int i = 0; i < _displaySize.Height - 2; i++)
            {
                GetEmptyLine();
            }

            GetHorizontalBorder();
        }

        private string GetHorizontalBorder()
        {
            return new string(_consolePresentationConfiguration.HorizontalDisplayBorder, _displaySize.Width);
        }

        public void Draw(WorldRepresentation worldRepresentation)
        {
            var displayLines = new List<string>();

            var availableSpace = _displaySize.Height - 2 - worldRepresentation.Room.Size.Height;

            var availableSpaceHeightIsEven = availableSpace % 2 == 0;

            if (!availableSpaceHeightIsEven)
            {
                throw new NotImplementedException("oops, odd number of lines to center");
            }

            var emptyLinesAboveAndBelowRoom = availableSpace / 2;

            displayLines.Add(GetHorizontalBorder());

            for (int i = 0; i < emptyLinesAboveAndBelowRoom; i++)
            {
                displayLines.Add(GetEmptyLine());
            }
            

            displayLines.AddRange(GetRoomLines(worldRepresentation.Room, worldRepresentation.Team));

            for (int i = 0; i < emptyLinesAboveAndBelowRoom; i++)
            {
                displayLines.Add(GetEmptyLine());
            }
            displayLines.Add(GetHorizontalBorder());

            _mapWindow.WriteLines(displayLines);
        }

        private string GetEmptyLine()
        {
            return _consolePresentationConfiguration.VerticalDisplayBorder + new string(_consolePresentationConfiguration.EmptySpace, _displaySize.Width - 2) + _consolePresentationConfiguration.VerticalDisplayBorder;
        }

        private IEnumerable<string> GetRoomLines(Room room, YoloTeam team)
        {
            var roomLines = new List<string>();
            for (int h = 0; h < room.Size.Height; h++)
            {
                var stringBuilder = new StringBuilder();
                for (int w = 0; w < room.Size.Width; w++)
                {
                    var currentTilePosition = new Position(w, h);
                    if (currentTilePosition.Equals(team.Position))
                    {
                        stringBuilder.Append(_consolePresentationConfiguration.TeamCharacter);
                    }
                    else if (room.Monsters.Any(monster => monster.Position.Equals(currentTilePosition)))
                    {
                        stringBuilder.Append(_consolePresentationConfiguration.MonsterCharacter);
                    }
                    else if (room.Tiles[currentTilePosition.X, currentTilePosition.Y].HasShrine)
                    {
                        stringBuilder.Append(_consolePresentationConfiguration.ShrineCharacter);
                    }
                    else
                    {
                        stringBuilder.Append(_consolePresentationConfiguration.GetTileCharacter(room.Tiles[w, h]));
                    }
                }
                roomLines.Add(CenterHorizontally(stringBuilder.ToString(), _displaySize.Width - 2));
            }

            return roomLines;
        }

        private string CenterHorizontally(string lineToCenter, int width)
        {
            var availableSpace = width - lineToCenter.Length;

            var availableSpaceWidthIsEven = availableSpace % 2 == 0;

            if (availableSpaceWidthIsEven)
            {
                var spaceAroundCenteredContent = availableSpace / 2;

                return _consolePresentationConfiguration.VerticalDisplayBorder + new string(_consolePresentationConfiguration.EmptySpace, spaceAroundCenteredContent)
                    + lineToCenter + new string(_consolePresentationConfiguration.EmptySpace, spaceAroundCenteredContent) + _consolePresentationConfiguration.VerticalDisplayBorder;
            }

            throw new NotImplementedException("oops, odd number of characters to center");
        }
    }
}