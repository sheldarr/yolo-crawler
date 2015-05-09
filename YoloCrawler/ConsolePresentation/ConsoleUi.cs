namespace YoloCrawler.ConsolePresentation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Entities;

    internal class ConsoleUi : Presentation
    {
        private readonly Size _mapDisplaySize;
        private readonly Window _logWindow;
        private readonly Window _mapWindow;
        private readonly ConsolePresentationConfiguration _consolePresentationConfiguration;

        public ConsoleUi(Size mapSize, ConsolePresentationConfiguration consolePresentationConfiguration)
        {
            _mapDisplaySize = new Size(mapSize.Width + 4, mapSize.Height + 4);

            _consolePresentationConfiguration = consolePresentationConfiguration;
            const int logWindowHeight = 6;

            Console.WindowWidth = _mapDisplaySize.Width;
            Console.WindowHeight = _mapDisplaySize.Height + logWindowHeight + 1;

            _mapWindow = new Window(new Dimensions(new Point(0,0), _mapDisplaySize));
            _logWindow = new Window(new Dimensions(new Point(0,_mapDisplaySize.Height), new Size(_mapDisplaySize.Width, logWindowHeight)));

            InitializeMapWindow();

            Console.SetCursorPosition(0, _mapDisplaySize.Height + logWindowHeight);
        }

        private void InitializeMapWindow()
        {
            DrawHorizontalBorder();

            for (int i = 0; i < _mapDisplaySize.Height - 2; i++)
            {
                DrawEmptyLine();
            }

            DrawHorizontalBorder();
        }

        private void DrawHorizontalBorder()
        {
            _mapWindow.WriteLine(new string(_consolePresentationConfiguration.HorizontalDisplayBorder, _mapDisplaySize.Width));
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
            var availableSpace = _mapDisplaySize.Width - 2 - roomLine.Length;

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
            _mapWindow.WriteLine(_consolePresentationConfiguration.VerticalDisplayBorder + new string(_consolePresentationConfiguration.EmptySpace, _mapDisplaySize.Width - 2) + _consolePresentationConfiguration.VerticalDisplayBorder);
        }

        private List<string> GetRoomLines(Room room, YoloTeam team)
        {
            var roomLines = new List<string>();
            for (int h = 0; h < room.Size.Height; h++)
            {
                var stringBuilder = new StringBuilder();
                for (int w = 0; w < room.Size.Width; w++)
                {
                    var position = new Position(w, h);
                    if (position.Equals(team.Position))
                    {
                        stringBuilder.Append(_consolePresentationConfiguration.TeamCharacter);
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