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
        public void InstantiateSheetTest()
        {
            var sheet = new Sheet(50, 50);
        }
    }
}