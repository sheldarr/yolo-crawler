namespace YoloCrawler
{
    using System.Threading;
    using ConsolePresentation;
    using Input;

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
            var thread = new Thread(RunEgnine) {IsBackground = true};
            thread.Start();
            _engineInitialized.WaitOne();
            var input = new ConsoleInput(_engine);
            input.MainLoop();
        }

        private void RunEgnine()
        {
            var presentation = new ConsoleUi();
            _engine = new Engine(presentation);
            _engineInitialized.Set();
            _engine.Run();
        }
    }
}
