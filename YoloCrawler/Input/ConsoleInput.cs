namespace YoloCrawler.Input
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
                    _engine.Move(MovementOffsets.LeftUp);
                }

                if (pressedKey == _keyMapping.Up)
                {
                    _engine.Move(MovementOffsets.Up);
                }

                if (pressedKey == _keyMapping.RightUp)
                {
                    _engine.Move(MovementOffsets.RightUp);
                }

                if (pressedKey == _keyMapping.Left)
                {
                    _engine.Move(MovementOffsets.Left);
                }

                if (pressedKey == _keyMapping.Right)
                {
                    _engine.Move(MovementOffsets.Right);
                }

                if (pressedKey == _keyMapping.LeftDown)
                {
                    _engine.Move(MovementOffsets.LeftDown);
                }

                if (pressedKey == _keyMapping.Down)
                {
                    _engine.Move(MovementOffsets.Down);
                }

                if (pressedKey == _keyMapping.RightDown)
                {
                    _engine.Move(MovementOffsets.RightDown);
                }
            }
        }
    }
}