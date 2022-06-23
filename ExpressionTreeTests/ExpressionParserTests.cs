namespace ExpressionTreeTests;

using NUnit.Framework;
using SpreadSheetEngine.ArithmeticExpressionTree;

[TestFixture]
public class ExpressionParserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("A1+B2+C3", new [] {"VarNode", "OpNodeAdd", "VarNode", "OpNodeAdd", "VarNode"})]
    [TestCase("A1+22+C3", new [] {"VarNode", "OpNodeAdd", "ConstNode", "OpNodeAdd", "VarNode"})]
    [TestCase("11+22+33", new [] {"ConstNode", "OpNodeAdd", "ConstNode", "OpNodeAdd", "ConstNode"})]
    public void ParseNodeFromStringTest(string input, string[] expected)
    {
        ExpressionParser parser = new ExpressionParser();
        var blocks = ExpressionParser.StrToBlockExpression(input);
        var nodes = ExpressionParser.BlockToNodeExpression(blocks);
        var output = (
            from n in nodes
            select n.Type).ToArray();
        
        Assert.That(output, Is.EqualTo(expected));
    }
}