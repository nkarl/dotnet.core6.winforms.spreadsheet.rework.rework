namespace SpreadSheetEngineTests
{
    using SpreadSheetEngine.SheetLogic.Components;

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