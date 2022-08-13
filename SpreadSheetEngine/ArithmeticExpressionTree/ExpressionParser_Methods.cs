// <copyright file="ExpressionParser_Methods.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
    using System.Text;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     Contains methods only.
    ///     This is a static class. It takes an input expression as string and process that into a node-based
    ///     version ready to be consumed by the Expression Tree's constructor.
    /// </summary>
    internal static partial class ExpressionParser
    {
        /// <summary>
        ///     Make a postfix from an infix as list of nodes.
        /// </summary>
        /// <param name="infix">the infix as list of nodes.</param>
        /// <returns>new postfix as list of nodes.</returns>
        public static IEnumerable<Node> MakePostfix(IEnumerable<Node> infix)
        {
            var stack = new Stack<Node>();
            var postfix = new List<Node>();

            foreach (var node in infix)
            {
                if (node is OpNode incoming)
                {
                    if (stack.Count > 0)
                    {
                        if (incoming.Precedence == ((OpNode)stack.Peek()).Precedence)
                        {
                            if (incoming.Associativity == OpAssociativity.Leftward)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                        else if (incoming.Precedence < ((OpNode)stack.Peek()).Precedence)
                        {
                            // pop stack and add to postfix, and then continue the same test on the new top.
                            for (; stack.Count > 0 && incoming.Precedence < ((OpNode)stack.Peek()).Precedence;)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                    }

                    stack.Push(incoming);
                }
                else
                {
                    postfix.Add(node);
                }
            }

            for (; stack.Count > 0;)
            {
                postfix.Add(stack.Pop());
            }

            return postfix;
        }

        /// <summary>
        ///     Parses a given string into a list of nodes.
        /// </summary>
        /// <param name="infix">the input expression to be parsed.</param>
        /// <returns>an ArrayList of Nodes.</returns>
        public static IEnumerable<Node> ParseInfix(string infix)
        {
            var blocks = FromInfixToBlocks(infix);
            var nodes = FromBlocksToNodes(blocks);
            return nodes;
        }

        /// <summary>
        ///     Converts the string expression into a list of strings.
        /// </summary>
        /// <param name="infix">the original string expression.</param>
        /// <returns>a list of strings.</returns>
        internal static IEnumerable<string> FromInfixToBlocks(string infix)
        {
            // From an expression string, iterate through each character and try to build up blocks of operands and operators.
            //  the block resets at either the next operator or the end of expression.
            var blockExpression = new List<string>();
            var block = new StringBuilder();
            foreach (var c in infix)
            {
                if (OperatorDict.ContainsKey(c))
                {
                    blockExpression.Add(block.ToString()); // adds the operand as new block.
                    blockExpression.Add(c.ToString()); // adds the detected operator as new block.
                    block = new StringBuilder(); // resets the block.
                }
                else
                {
                    block.Append(c); // otherwise, continue appending the character to the block.
                }
            }

            blockExpression.Add(block.ToString()); // adds the final block.
            return blockExpression;
        }

        /// <summary>
        ///     Parse expression with braces accounted for.
        /// </summary>
        /// <param name="infix">the original expression.</param>
        internal static void ParseWithBraces(string infix)
        {
            // TODO: IMPLEMENT THE DECOMPOSING LOGIC FOR PARENTHESES.
            // var expression = "(A1+B2)+C3";
            var braces = "{[()]}"; // the braces should probably be put into a dict as key-value pair.

            Dictionary<char, char> localBraceDict = new ()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' },
            };

            Dictionary<char, Func<char>> localOperatorDict = new ()
            {
                { '+', () => '+' },
                { '-', () => '-' },
                { '*', () => '*' },
                { '/', () => '/' },
            };

            var operatorList = (
                from op in localOperatorDict
                select op.Key).ToArray();

            // var operatorList = opList.ToArray();

            // first, parse only operators from the expression.
            var operators = (
                from c in infix
                where operatorList.Contains(c)
                select string.Empty + c
            ).ToArray();

            // then, parse only operands by splitting it by operators.
            var operands = infix.Split(operatorList);

            foreach (var block in operands)
            {
                if (block[0] is var openB && braces.Contains(openB))
                {
                    Console.WriteLine(openB);
                    Console.WriteLine(block[1..]);
                }
                else if (block[^1] is var closeB && braces.Contains(closeB))
                {
                    Console.WriteLine(block[..^1]);
                    Console.WriteLine(closeB);
                }
                else
                {
                    Console.WriteLine(block);
                }
            }
        }

        /// <summary>
        ///     Converts block expression into node expression.
        /// </summary>
        /// <param name="blocks">expression as blocks of string.</param>
        /// <returns>expression as nodes.</returns>
        internal static IEnumerable<Node> FromBlocksToNodes(IEnumerable<string> blocks)
        {
            return (
                from block in blocks
                select block.Length == 1
                    ? NodeFromChar(block[0])
                    : NodeFromStr(block)
            ).ToImmutableList();
        }

        /// <summary>
        ///     Factory method to create a new operator node.
        /// </summary>
        /// <param name="op">char symbol for the supported operator.</param>
        /// <returns>a new node of specialized operator.</returns>
        internal static Node OpNodeFactory(char op)
        {
            return OperatorDict.ContainsKey(op)
                ? OperatorDict[op].Invoke()
                : throw new NotImplementedException("This operator is not supported.");
        }

        /// <summary>
        ///     Creates a new node from a single char.
        /// </summary>
        /// <param name="c">a single parsed character.</param>
        /// <returns>newly created node.</returns>
        private static Node NodeFromChar(char c)
        {
            return c switch
            {
                _ when OperatorDict.ContainsKey(c) => OpNodeFactory(c),
                _ when UpperCase.Contains(c) => new VarNode($"{c}"),
                _ when LowerCase.Contains(c) => new VarNode($"{c}"),
                _ when Digits.Contains(c) => new ConstNode(c - '0'),
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        ///     Creates a new node from a block of string.
        /// </summary>
        /// <param name="block">a parsed block of string.</param>
        /// <returns>a newly created node.</returns>
        private static Node NodeFromStr(string block)
        {
            try
            {
                var constant = int.Parse(block);
                return new ConstNode(constant);
            }
            catch (FormatException)
            {
                Console.WriteLine("Safely caught the parsed string as int.");
                return new VarNode(block);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new NotImplementedException("Unable to parse string into int.");
            }
        }
    }
}