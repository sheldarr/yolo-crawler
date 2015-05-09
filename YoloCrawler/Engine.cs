namespace YoloCrawler
{
    internal class Engine
    {
        private readonly Presentation _pres;

        public Engine(Presentation pres)
        {
            _pres = pres;
        }

        public void Move()
        {
            
        }

        public void SayHello()
        {
            _pres.WriteLine("hello!");
        }
    }
}