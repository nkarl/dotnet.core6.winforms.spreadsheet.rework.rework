using NUnit.Framework;

namespace ExpressionTreeTests;

using SpreadSheetEngine.ArithmeticExpressionTree;
using System.Linq;

[TestFixture]
public class NodeExpressionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("A1+B2+C3", new [] {"var", "op", "var", "op", "var"})]
    public void NodeExpressionTest(string expression, string[] expected)
    {
        ExpressionTree tree = new ExpressionTree(expression);
        var blocks = tree.StrToBlockExpression(expression);
        var nodes = tree.BlockToNodeExpression(blocks);

        var output = (
            from n in nodes
            select n.NodeType).ToArray();
        
        Assert.That(output, Is.EqualTo(expected));
    }
}