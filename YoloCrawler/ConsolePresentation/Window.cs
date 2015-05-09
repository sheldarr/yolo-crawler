namespace YoloCrawler.ConsolePresentation
{
    using System;
    using System.Collections.Generic;

    class Window
    {
        private readonly Dimensions _dimensions;
        private ConsoleState _savedConsoleState;
        private List<string> _linesBuffer;

        public Window(Dimensions dimensions)
        {
            _linesBuffer = new List<string>();
            _dimensions = dimensions;
        }

        public void WriteLine(string output)
        {
            SaveConsoleState();

            var windowLines = BreakInputIntoLines(output);
            _linesBuffer.AddRange(windowLines);

            DisplayLines();

            ReloadConsoleState();
        }

        private void DisplayLines()
        {
            if (_linesBuffer.Count >= 100)
            {
                CleanBuffer();
            }

            var linesToDisplay = _linesBuffer;
            if (linesToDisplay.Count > _dimensions.DisplaySize.Height)
            {
                linesToDisplay = GetLastScreen(linesToDisplay);
            }

            for (int i = 0; i < linesToDisplay.Count; i++)
            {
                Console.SetCursorPosition(_dimensions.Origin.X, _dimensions.Origin.Y + i);
                ClearLine();
                Console.Write(linesToDisplay[i]);
            }
        }

        private void CleanBuffer()
        {
            _linesBuffer = GetLastScreen(_linesBuffer);
        }

        private List<string> GetLastScreen(List<string> linesToDisplay)
        {
            return linesToDisplay.GetRange(linesToDisplay.Count - _dimensions.DisplaySize.Height,
                _dimensions.DisplaySize.Height);
        }

        private void ClearLine()
        {
            var emptyStringForWholeWidth = new string(' ', _dimensions.DisplaySize.Width);
            Console.Write(emptyStringForWholeWidth);
            CaretReturn();
        }

        private void CaretReturn()
        {
            Console.SetCursorPosition(_dimensions.Origin.X, Console.CursorTop);
        }

        private IEnumerable<string> BreakInputIntoLines(string line)
        {
            if (line.Length <= _dimensions.DisplaySize.Width)
            {
                return new[] {line};
            }

            var first = line.Substring(0, _dimensions.DisplaySize.Width);

            var rest = line.Substring(_dimensions.DisplaySize.Width);

            var lines = new List<string>();
            lines.Add(first);

            var shorterLineMaxLength = _dimensions.DisplaySize.Width - 1;
            var shorterSubstringsCount = Math.Ceiling((double)rest.Length/shorterLineMaxLength);
            var paddedString = rest.PadRight((int)shorterSubstringsCount*_dimensions.DisplaySize.Width);

            for (int i = 0; i < shorterSubstringsCount; i++)
            {
                var part = paddedString.Substring(i*shorterLineMaxLength, shorterLineMaxLength);
                lines.Add(" "+part);
            }

            return lines;
        }

        private void SaveConsoleState()
        {
            _savedConsoleState = new ConsoleState
            {
                CursorLeft = Console.CursorLeft,
                CursorTop = Console.CursorTop
            };
        }

        private void ReloadConsoleState()
        {
            Console.CursorLeft = _savedConsoleState.CursorLeft;
            Console.CursorTop = _savedConsoleState.CursorTop;
        }

        public void WriteLines(List<string> displayLines)
        {
            SaveConsoleState();

            _linesBuffer.AddRange(displayLines);

            DisplayLines();

            ReloadConsoleState();
        }
    }
}
