namespace YoloCrawler
{
    using System.Threading;
    using ConsolePresentation;

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
            var thread = new Thread(RunEgnine);
            thread.IsBackground = true;
            thread.Start();
            _engineInitialized.WaitOne();
            var input = new ConsoleInput(_engine);
            input.MainLoop();
        }

        private void RunEgnine()
        {
            var pres = new ConsoleUi();
            _engine = new Engine(pres);
            _engineInitialized.Set();
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
