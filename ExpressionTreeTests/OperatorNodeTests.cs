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
        var newNode = ExpressionParser.OpNodeFactory(op);
        return newNode.Type;
    }
}