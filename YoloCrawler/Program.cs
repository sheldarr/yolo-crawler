namespace YoloCrawler
{
    using System.Threading;
    using Configuration;
    using ConsolePresentation;
    using Factories;
    using Input;
    using Entities;

    class Program
    {
        private Engine _engine;
        private readonly AutoResetEvent _engineInitialized = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            var thread = new Thread(RunEngine) {IsBackground = true};
            thread.Start();
            _engineInitialized.WaitOne();
            var input = new ConsoleInput(_engine);
            input.MainLoop();
            thread.Join();
        }

        private void RunEngine()
        {
            var displaySize = new Size(60, 20);
            var consoleUi = new ConsoleUi(displaySize, new ConsolePresentationConfiguration());
            var presentation = consoleUi as Presentation;
            var logger = consoleUi as Logger;
            var configuration = MapConfiguration.Default;
            var dice = new YoloDice();
            var mapFactory = new MapFactory(dice, new DefaultHealingHealingShrineFactory(dice));
            _engine = new Engine(presentation, logger, mapFactory.GenerateMap(configuration));
            _engineInitialized.Set();
            _engine.Run();

            _engine.AnounceResult();
        }
    }
}
