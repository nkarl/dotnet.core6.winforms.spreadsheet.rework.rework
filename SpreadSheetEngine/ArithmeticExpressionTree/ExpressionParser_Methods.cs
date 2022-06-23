// <copyright file="ExpressionParser_Methods.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree;

using System.Text;
using SpreadSheetEngine.ArithmeticExpressionTree.Components;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

/// <summary>
/// Contains the methods of the Parser.
/// </summary>
internal partial class ExpressionParser
{
    /// <summary>
    /// Parses a given string into a list of nodes.
    /// </summary>
    /// <param name="expression">the string expression to be parsed.</param>
    /// <returns>an ArrayList of Nodes.</returns>
    public static List<Node> Parse(string? expression)
    {
        if (expression is null)
        {
            return null!;
        }

        var blocks = ExpressionParser.StrToBlockExpression(expression);
        var nodes = ExpressionParser.BlockToNodeExpression(blocks);
        return nodes;
    }

    /// <summary>
    /// Converts the string expression into a list of string blocks.
    /// </summary>
    /// <param name="expression">the original string expression.</param>
    /// <returns>a list of string blocks.</returns>
    internal static List<string> StrToBlockExpression(string expression)
    {
        // From an expression string, iterate through each character and try to build up blocks of operands and operators.
        //  the block resets at either the next operator or the end of expression.
        List<string> allBlocks = new List<string>();
        StringBuilder block = new StringBuilder();
        foreach (var c in expression!)
        {
            if (OperatorDict.ContainsKey(c))
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

    /// <summary>
    /// Converts the block expression into a node expression.
    /// </summary>
    /// <param name="expression">the expression previously converted into blocks.</param>
    /// <returns>the expression as nodes.</returns>
    internal static List<Node> BlockToNodeExpression(List<string> expression)
    {
        List<Node> nodeExpr = new List<Node>();

        foreach (var block in expression)
        {
            Node newNode;

            // when block's length is 1.
            if (block.Length == 1)
            {
                var c = block[0];
                newNode = ExpressionParser.NodeFromChar(c);
            }

            // otherwise, when block's length is larger than 1.
            else
            {
                newNode = ExpressionParser.NodeFromStr(block);
            }

            nodeExpr.Add(newNode);
        }

        return nodeExpr;
    }

    /// <summary>
    /// Factory for creating new operator node.
    /// </summary>
    /// <param name="op">char denoting the supported operator.</param>
    /// <returns>a new specialized operator node.</returns>
    internal static Node OpNodeFactory(char op)
    {
        if (OperatorDict.ContainsKey(op))
        {
            return OperatorDict[op].Invoke();
        }
        else
        {
            throw new NotImplementedException("This operator is not supported.");
        }
    }

    /// <summary>
    /// Creates a new node from a single char.
    /// </summary>
    /// <param name="c">the single character.</param>
    /// <returns>newly created node.</returns>
    private static Node NodeFromChar(char c)
    {
        Node newNode;
        var alphabet = UpperCase;
        var numerical = Digits;
        if (OperatorDict.ContainsKey(c))
        {
            newNode = OpNodeFactory(c); // operator node: DONE
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

    /// <summary>
    /// Creates a new node from a block of string.
    /// </summary>
    /// <param name="block">a block of string previously parsed.</param>
    /// <returns>a newly created node.</returns>
    private static Node NodeFromStr(string block)
    {
        Node newNode;
        try
        {
            int constant = int.Parse(block);
            newNode = new ConstNode(constant);
        }
        catch (FormatException)
        {
            newNode = new VarNode(block);
        }
        catch (Exception ex2)
        {
            Console.WriteLine(ex2);
            throw new NotImplementedException("Exception in NodeFromStr.");
        }

        return newNode;
    }
}