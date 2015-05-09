namespace YoloCrawler.ConsolePresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Entities;

    internal class ConsoleUi : Presentation, Logger
    {
        private readonly Size _displaySize;
        private readonly Window _logWindow;
        private readonly Window _mapWindow;
        private readonly ConsolePresentationConfiguration _consolePresentationConfiguration;

        public ConsoleUi(Size displaySize, ConsolePresentationConfiguration consolePresentationConfiguration)
        {
            _displaySize = new Size(displaySize.Width + 4, displaySize.Height + 4);

            _consolePresentationConfiguration = consolePresentationConfiguration;
            const int logWindowHeight = 6;

            Console.WindowWidth = _displaySize.Width;
            Console.WindowHeight = _displaySize.Height + logWindowHeight + 1;

            _mapWindow = new Window(new Dimensions(new Point(0,0), _displaySize));
            _logWindow = new Window(new Dimensions(new Point(0,_displaySize.Height), new Size(_displaySize.Width, logWindowHeight)));

            InitializeMapWindow();

            Console.SetCursorPosition(0, _displaySize.Height + logWindowHeight);
        }

        private void InitializeMapWindow()
        {
            DrawHorizontalBorder();

            for (int i = 0; i < _displaySize.Height - 2; i++)
            {
                DrawEmptyLine();
            }

            DrawHorizontalBorder();
        }

        private void DrawHorizontalBorder()
        {
            _mapWindow.WriteLine(new string(_consolePresentationConfiguration.HorizontalDisplayBorder, _displaySize.Width));
        }

        public void Log(string output)
        {
            _logWindow.WriteLine(output);
        }

        public void Draw(WorldRepresentation worldRepresentation)
        {
            DrawHorizontalBorder();
            DrawEmptyLine();

            var roomLines = GetRoomLines(worldRepresentation.Room, worldRepresentation.Team);

            roomLines.ForEach(DrawCentered);

            DrawEmptyLine();
            DrawHorizontalBorder();
        }

        private void DrawCentered(string roomLine)
        {
            var availableSpace = _displaySize.Width - 2 - roomLine.Length;

            var availableSpaceWidthIsEven = availableSpace%2 == 0;

            if (availableSpaceWidthIsEven)
            {
                var spaceAroundCenteredContent = availableSpace/2;

                _mapWindow.WriteLine(_consolePresentationConfiguration.VerticalDisplayBorder + new string(_consolePresentationConfiguration.EmptySpace, spaceAroundCenteredContent)
                    + roomLine + new string(_consolePresentationConfiguration.EmptySpace, spaceAroundCenteredContent) + _consolePresentationConfiguration.VerticalDisplayBorder);
            }
        }

        private void DrawEmptyLine()
        {
            _mapWindow.WriteLine(_consolePresentationConfiguration.VerticalDisplayBorder + new string(_consolePresentationConfiguration.EmptySpace, _displaySize.Width - 2) + _consolePresentationConfiguration.VerticalDisplayBorder);
        }

        private List<string> GetRoomLines(Room room, YoloTeam team)
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
                    else
                    {
                        stringBuilder.Append(_consolePresentationConfiguration.GetTileCharacter(room.Tiles[w, h]));
                    }
                }
                roomLines.Add(stringBuilder.ToString());
            }

            return roomLines;
        }
    }
}