namespace YoloCrawler
{
    using System;

    internal class ConsoleUi : Presentation
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}