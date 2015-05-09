namespace YoloCrawler.Tests
{
    using NUnit.Framework;
    using YoloCrawler.Entities;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void ShouldCreateARoom()
        {
            // given
            var room = new Room(16, 16);

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    room.Tiles[i,j] = new Tile(TileTypes.Wall);
                }
            }

            // when
            room.Draw();

            // then

        }
    }
}