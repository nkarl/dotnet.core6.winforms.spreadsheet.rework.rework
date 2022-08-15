namespace ExpressionTreeTests
{
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
        [TestCase("11/0", double.PositiveInfinity)]
        [TestCase("-11/0", double.NegativeInfinity)]
        public void EvaluateTreeTest(string input, double expected)
        {
            var tree = new ExpressionTree(input);
            var result = tree.Evaluate();
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("A1", "A1")]
        [TestCase("B1", "B1")]
        [TestCase("C1", "C1")]
        [TestCase("C1", "C1", "A1+11+22+33+B1+44+C1")]
        [TestCase("D1", null, "A1+11+22+33+B1+44+C1")]
        public void GetVarTest(string varName, string expected, string expression = "A1+B1+C1")
        {
            var tree = new ExpressionTree(expression);
            var result = tree.LookUpVar(varName);
            Assert.That(result?.Name, Is.EqualTo(expected));
        }
    }
}