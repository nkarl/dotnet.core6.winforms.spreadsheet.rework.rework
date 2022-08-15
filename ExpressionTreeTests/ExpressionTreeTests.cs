namespace ExpressionTreeTests
{
    using SpreadSheetEngine.ArithmeticExpressionTree;

    [TestFixture]
    public class ExpressionTreeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1+2+3", 6)]
        [TestCase("1.1+2+3", 6.1)]
        [TestCase("1.1+2.2+3.3", 6.6)]
        [TestCase("1*2+3", 5)]
        [TestCase("5*7-12", 23)]
        [TestCase("12-5*7", -23)]
        [TestCase("11*4/2", 22)]
        public void TreeTest(string input, double expected)
        {
            var tree = new ExpressionTree(input);
            var result = tree.Evaluate();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}