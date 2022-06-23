using SpreadSheetEngine.ArithmeticExpressionTree;

namespace ExpressionTreeTests;

[TestFixture]
public class OperatorNodeTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase('+', ExpectedResult = "OpNodeAdd")]
    [TestCase('-', ExpectedResult = "OpNodeSub")]
    [TestCase('*', ExpectedResult = "OpNodeMul")]
    [TestCase('/', ExpectedResult = "OpNodeDiv")]
    public string OpNodeFactoryTest(char op)
    {
        var parser = new ExpressionParser();
        var newNode = parser.OpNodeFactory(op);
        return newNode.Type;
    }
}