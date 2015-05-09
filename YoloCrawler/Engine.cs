namespace YoloCrawler
{
    public class Engine
    {
        private readonly Presentation _pres;

        public Engine(Presentation pres)
        {
            _pres = pres;
        }

        public void SayHello()
        {
            _pres.Log("hello!");
        }

        public void Move(Offset offset)
        {
            throw new System.NotImplementedException();
        }
    }
}