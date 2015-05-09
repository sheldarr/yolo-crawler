namespace YoloCrawler
{
    using System.Threading;
    using ConsolePresentation;
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
        }

        private void RunEngine()
        {
            var mapSize = new Size(60, 20);
            var presentation = new ConsoleUi(mapSize, new ConsolePresentationConfiguration());
            _engine = new Engine(presentation);
            _engineInitialized.Set();
            _engine.Run();
        }
    }
}
