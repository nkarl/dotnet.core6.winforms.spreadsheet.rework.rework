namespace SpreadSheetEngineTests
{
    public class CellTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(_tuples))]
        public void Instantiate_Single_Cell((int rIndex, int cIndex) passed, (int rIndex, int cIndex) expected)
        {
            
            if (passed.CompareTo((0, 0)) < 0)
            {
                Assert.Throws<OverflowException>(() => throw new OverflowException());
            }
            
            var cell = new Cell(passed.rIndex, passed.cIndex);
            Assert.That(expected, Is.EqualTo((cell.RowIndex, cell.ColumnIndex)));
        }

        private static object[] _tuples =
        {
            new object[] { (0, 0), (0, 0) },
            new object[] { (int.MaxValue, int.MaxValue), (int.MaxValue, int.MaxValue)},
            new object[] { (unchecked(int.MaxValue + 1), unchecked(int.MaxValue + 1)), (unchecked(int.MaxValue + 1), unchecked(int.MaxValue + 1))}
        };
    }
}