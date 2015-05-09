namespace YoloCrawler
{
    using System;

    public class ConsoleInput
    {
        private readonly Engine _engine;
        private readonly KeyMapping _keyMapping;

        public ConsoleInput(Engine engine)
        {
            _engine = engine;
            _keyMapping = KeyMappingLoader.Load();
        }

        public void MainLoop()
        {
            while (true)
            {
                var pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == _keyMapping.Quit)
                {
                    return;
                }

                if (pressedKey == _keyMapping.LeftUp)
                {
                }

                if (pressedKey == _keyMapping.Up)
                {
                }

                if (pressedKey == _keyMapping.RightUp)
                {
                }

                if (pressedKey == _keyMapping.Left)
                {
                }

                if (pressedKey == _keyMapping.Right)
                {
                }

                if (pressedKey == _keyMapping.LeftDown)
                {
                }

                if (pressedKey == _keyMapping.Down)
                {
                }

                if (pressedKey == _keyMapping.RightDown)
                {
                }
            }
        }
    }
}