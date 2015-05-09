namespace YoloCrawler.ConsolePresentation
{
    using System;
    using YoloCrawler.Entities;

    internal class ConsoleUi : Presentation
    {
        private readonly Window _logWindow;
        private readonly Window _mapWindow;

        public ConsoleUi()
        {
            Console.WindowWidth = 60;
            Console.WindowHeight = 31;
            _mapWindow = new Window(new Dimensions(new Point(0,0), new Size(60, 20)));
            _logWindow = new Window(new Dimensions(new Point(0,20), new Size(60, 10)));

            InitializeMapWindow();

            Console.SetCursorPosition(0, 30);
        }

        private void InitializeMapWindow()
        {
            _mapWindow.WriteLine(new string('#', 60));
            for (int i = 0; i < 8; i++)
            {
                _mapWindow.WriteLine("#" + new string(' ', 58) + "#");
            }
            _mapWindow.WriteLine("#" + new string(' ', 19) + "map is gonna be here" + new string(' ', 19) + "#");
            for (int i = 0; i < 9; i++)
            {
                _mapWindow.WriteLine("#" + new string(' ', 58) + "#");
            }
            _mapWindow.WriteLine(new string('#', 60));
        }

        public void Log(string output)
        {
            _logWindow.WriteLine(output);
        }
    }
}