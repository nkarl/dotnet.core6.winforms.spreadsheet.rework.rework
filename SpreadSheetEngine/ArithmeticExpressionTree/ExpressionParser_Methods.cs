// <copyright file="ExpressionParser_Methods.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

namespace SpreadSheetEngine.ArithmeticExpressionTree;

using System.Text;
using SpreadSheetEngine.ArithmeticExpressionTree.Components;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
using System.Collections.Immutable;

/// <summary>
/// Contains the methods of the Parser.
/// </summary>
internal static partial class ExpressionParser
{
    /*
     * TODO: IMPLEMENT THE POSTFIX CONVERSION FOR THE NODES.
     *
     */

    /// <summary>
    /// Make a postfix from an infix list of nodes.
    /// </summary>
    /// <param name="infix">the infix list of nodes.</param>
    /// <returns>a postfix list of nodes.</returns>
    public static IEnumerable<Node> MakePostfix(IEnumerable<Node> infix)
    {
        var opStack = new Stack<Node>();
        var postfix = new List<Node>();

        foreach (var node in infix)
        {
            // if node is not an operator node, add it to postfix.
            if (node is not OpNode incomingOp)
            {
                postfix.Add(node);
            }

            // otherwise, check operator's conditions.
            else
            {
                // If stack is empty, push the incoming operator on the stack.
                var top = (opStack.Peek() is OpNode t) ? t : null;
                if (top is null)
                {
                    opStack.Push(incomingOp);
                    continue;
                }

                // compare precedence between stackTop and incomingOp.
                // If precedence of incoming is higher, push incoming to stack.
                // on the stack.
                if (incomingOp.Precedence > top.Precedence)
                {
                    opStack.Push(incomingOp);
                    continue;
                }

                if (top.Precedence == incomingOp.Precedence)
                {
                    if (incomingOp.Associativity == OpAssociativity.LTR)
                    {
                        postfix.Add(opStack.Pop());
                    }

                    opStack.Push(incomingOp);
                    continue;
                }

                // Otherwise, if precedence of incoming is lower, pop stack and add to postfix,
                // and then continue testing the new top.
                while (top != null && incomingOp.Precedence < top.Precedence)
                {
                    postfix.Add(opStack.Pop());
                    top = opStack.Peek() is OpNode t1 ? t1 : null;
                }

                opStack.Push(incomingOp);
            }
        }

        return postfix;
    }

    /// <summary>
    /// Parses a given string into a list of nodes.
    /// </summary>
    /// <param name="expression">the string expression to be parsed.</param>
    /// <returns>an ArrayList of Nodes.</returns>
    public static IEnumerable<Node> Parse(string expression)
    {
        var blocks = FromStrToBlocks(expression);
        /* foreach (var b in blocks) Console.WriteLine(b); */
        var nodes = FromBlocksToNodes(blocks);
        /* foreach (var n in nodes) Console.WriteLine(n.Type); */
        return nodes;
    }

    /// <summary>
    /// Converts the string expression into a list of string blocks.
    /// </summary>
    /// <param name="expression">the original string expression.</param>
    /// <returns>a list of string blocks.</returns>
    internal static IEnumerable<string> FromStrToBlocks(string expression)
    {
        // From an expression string, iterate through each character and try to build up blocks of operands and operators.
        //  the block resets at either the next operator or the end of expression.
        var blocks = new List<string>();
        var block = new StringBuilder();
        foreach (var c in expression)
        {
            if (OperatorDict.ContainsKey(c))
            {
                blocks.Add(block.ToString());
                blocks.Add(c.ToString());
                block = new StringBuilder();
            }
            else
            {
                block.Append(c);
            }
        }

        blocks.Add(block.ToString()); // adds the final block.
        return blocks;

        /*
        // TODO: IMPLEMENT THE DECOMPOSING LOGIC FOR PARENTHESES.
        var expression = "(A1+B2)+C3";
        var paren = "{[()]}";

        public static readonly Dictionary<char, Func<int>> OperatorDict = new ()
        {
          { '+', () => '+' },
          { '-', () => '-' },
          { '*', () => '*' },
          { '/', () => '/' },
        };

        var operatorList = (
            from op in OperatorDict
            select op.Key).ToArray();

        var operators = (
            from c in expression
            where operatorList.Contains(c)
            select string.Empty + c
        ).ToArray();

        var operands = expression.Split(operatorList);

        foreach(var block in operands)
        {
            if(block[0] is char c && paren.Contains(c))
            {
                Console.WriteLine(c);
                Console.WriteLine(block[1..]);
            }
            else if (block[^1] is char d && paren.Contains(d))
            {
                Console.WriteLine(block[0..^1]);
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine(block);
            }
        }
        */
    }

    /// <summary>
    /// Converts the block expression into a node expression.
    /// </summary>
    /// <param name="blocks">the expression previously converted into blocks.</param>
    /// <returns>the expression as nodes.</returns>
    internal static IEnumerable<Node> FromBlocksToNodes(IEnumerable<string> blocks)
    {
        var nodes = (
            from block in blocks
            select (block.Length == 1)
                ? NodeFromChar(block[0])
                : NodeFromStr(block)
        ).ToImmutableList();
        return nodes;
    }

    /// <summary>
    /// Factory for creating new operator node.
    /// </summary>
    /// <param name="op">char denoting the supported operator.</param>
    /// <returns>a new specialized operator node.</returns>
    internal static Node OpNodeFactory(char op)
    {
        return OperatorDict.ContainsKey(op)
            ? OperatorDict[op].Invoke()
            : throw new NotImplementedException("This operator is not supported.");
    }

    /// <summary>
    /// Creates a new node from a single char.
    /// </summary>
    /// <param name="c">the single character.</param>
    /// <returns>newly created node.</returns>
    private static Node NodeFromChar(char c)
    {
        Node newNode;
        if (OperatorDict.ContainsKey(c))
        {
            newNode = OpNodeFactory(c); // operator node: DONE
        }
        else if (UpperCase.Contains(c))
        {
            newNode = new VarNode("var"); // var node
        }
        else if (Digits.Contains(c))
        {
            newNode = new ConstNode(c - '0'); // constant node
        }
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
            var constant = int.Parse(block);
            newNode = new ConstNode(constant);
        }
        catch (FormatException)
        {
            newNode = new VarNode(block);
            Console.WriteLine("Safely caught the parsed string as int.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new NotImplementedException("Unable to parse string into int.");
        }

        return newNode;
    }
}