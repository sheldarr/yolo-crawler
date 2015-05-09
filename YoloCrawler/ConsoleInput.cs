namespace YoloCrawler
{
    using System;

    class ConsoleInput
    {
        private readonly Engine _engine;

        public ConsoleInput(Engine engine)
        {
            _engine = engine;
        }

        public void MainLoop()
        {
            while (Console.ReadKey(true).KeyChar != 'q')
            {
                _engine.SayHello();
            }
        }
    }
}