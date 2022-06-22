namespace ExpressionTreeTests
{
    using SpreadSheetEngine.ArithmeticExpressionTree;
    public class BlockExpressionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("A1+B2+C3", new []{"A1", "+", "B2", "+", "C3"})]
        [TestCase("A1+Hello+2", new []{"A1", "+", "Hello", "+", "2"})]
        public void Test1(string expression, string[] blocks)
        {
            ExpressionTree tree = new ExpressionTree(expression);
            var output = tree.StrToBlockExpression(expression).ToArray();
            Assert.That(output, Is.EqualTo(blocks));
        }
    }
}