namespace YoloCrawler.ConsolePresentation
{
    using System;
    using YoloCrawler.Entities;

    internal class ConsoleUi : Presentation
    {
        private readonly Window _logWindow;
        private int _counterForShitsAndGiggles;
        private readonly Window _secondLogWindow;

        public ConsoleUi()
        {
            _counterForShitsAndGiggles = 0;
            Console.WindowHeight = 25;
            Console.WindowWidth = 110;
            _logWindow = new Window(new Dimensions(new Point(0,5), new Size(6, 10)));
            _secondLogWindow = new Window(new Dimensions(new Point(7, 5), new Size(9, 10)));
        }

        public void Log(string output)
        {
            _logWindow.WriteLine(string.Format("{0}{1}", output, ++_counterForShitsAndGiggles));
            _secondLogWindow.WriteLine(string.Format("{0}{1}", output, _counterForShitsAndGiggles));
        }
    }
}