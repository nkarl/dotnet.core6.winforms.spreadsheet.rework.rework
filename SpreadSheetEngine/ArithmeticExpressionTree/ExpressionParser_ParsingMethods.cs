using System.Text;
using SpreadSheetEngine.ArithmeticExpressionTree.Components;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

namespace SpreadSheetEngine.ArithmeticExpressionTree;

internal partial class ExpressionParser
{
    /// <summary>
    /// Converts the string expression to block expression.
    /// </summary>
    /// <param name="expression">the original expression as string.</param>
    /// <returns>List of operand and operator string blocks.</returns>
    public List<string> StrToBlockExpression(string expression)
    {
        // From an expression string, iterate through each character and try to build up blocks of operands and operators.
        //  the block resets at either the next operator or the end of expression.
        List<string> allBlocks = new List<string>();
        StringBuilder block = new StringBuilder();
        string opList = "+-*/";
        foreach (var c in expression)
        {
            if (opList.Contains(c))
            {
                allBlocks.Add(block.ToString());
                allBlocks.Add(c.ToString());
                block = new StringBuilder();
                continue;
            }

            block.Append(c);
        }

        allBlocks.Add(block.ToString());
        return allBlocks;
    }

    private static readonly string opList = "+-*/";

    /// <summary>
    /// Converts the block expression into a node expression.
    /// </summary>
    /// <param name="expression">the expression converted into blocks.</param>
    /// <returns>the expression as nodes.</returns>
    public List<Node> BlockToNodeExpression(List<string> expression)
    {
        List<Node> nodeExpr = new List<Node>();

        foreach (var block in expression)
        {
            // when block's length is 1.
            if (block.Length == 1)
            {
                var c = block[0];
            }
            // otherwise, when block's length is larger than 1.
            else
            {
                Node newNode;
                try
                {
                    int constant = int.Parse(block);
                    newNode = new ConstNode(constant);
                }
                catch (FormatException e)
                {
                    newNode = new VarNode(block);
                }

                nodeExpr.Add(newNode);
            }
        }

        return nodeExpr;
    }

    /// <summary>
    /// Node Factory. Creates a new node from a single char.
    /// </summary>
    /// <param name="c">the single character.</param>
    /// <returns>the newly created node.</returns>
    /// <exception cref="NotImplementedException"></exception>
    private Node NodeFromChar(char c)
    {
        Node newNode;
        var alphabet = UpperCase;
        var numerical = Digits;
        if (opList.Contains(c))
        {
            /*
             * TODO: Implement the hashmap for OpNodeFactory.
             */
            newNode = new OpNodeAdd(); // operator node
        }
        else if (alphabet.Contains(c))
        {
            newNode = new VarNode("var"); // var node
        }
        else if (numerical.Contains(c))
        {
            newNode = new ConstNode(c - '0'); // constant node
        }
        // for all other cases.
        else
        {
            throw new NotImplementedException();
        }

        return newNode;
    }

    public Node OpNodeFactory(char op)
    {
        return OperatorDict[op].Invoke();
    }
}