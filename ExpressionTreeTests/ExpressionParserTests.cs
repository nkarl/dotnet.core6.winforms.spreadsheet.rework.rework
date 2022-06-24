using System.Collections.Immutable;

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
        var blocks = ExpressionParser.FromStrToBlocks(input);
        var nodes = ExpressionParser.FromBlocksToNodes(blocks);
        var output = (
            from n in nodes
            select n.Type).ToImmutableList();
        
        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase("A1+B2+C3", new [] {"VarNode", "VarNode", "OpNodeAdd", "VarNode", "OpNodeAdd"})]
    public void ConvertNodesToPostfixTest(string input, string[] expected)
    {
        var blocks = ExpressionParser.FromStrToBlocks(input);
        var nodes = ExpressionParser.FromBlocksToNodes(blocks);
        var postfix = ExpressionParser.MakePostfix(nodes);
        var output = (
            from n in postfix 
            select n.Type).ToImmutableList();

        Assert.That(output, Is.EqualTo(expected));
    }
}