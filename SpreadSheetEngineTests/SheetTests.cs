namespace SpreadSheetEngineTests
{
    public class SheetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Instantiate_Sheet()
        {
            var sheet = new Sheet(50, 50);
        }
    }
}