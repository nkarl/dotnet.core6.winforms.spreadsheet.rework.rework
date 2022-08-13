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
    /// Contains methods only.
    ///
    /// This is a static class. It takes an input expression as string and process that into a node-based
    /// version ready to be consumed by the Expression Tree's constructor.
    ///
    /// </summary>
    internal static partial class ExpressionParser
    {
        /// <summary>
        /// Make a postfix from an infix list of nodes.
        /// </summary>
        /// <param name="infix">the infix list of nodes.</param>
        /// <returns>a postfix list of nodes.</returns>
        public static IEnumerable<Node> MakePostfix(IEnumerable<Node> infix)
        {
            var stack = new Stack<Node>();
            var postfix = new List<Node>();

            foreach (var node in infix)
            {
                // if node is not an operator, add it to postfix.
                if (node is not OpNode incoming)
                {
                    postfix.Add(node);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                    }
                    else
                    {
                        if (incoming.Precedence > ((OpNode)stack.Peek()).Precedence)
                        {
                        }
                        else if (incoming.Precedence == ((OpNode)stack.Peek()).Precedence)
                        {
                            var top = (OpNode)stack.Peek();
                            Console.WriteLine($"stacktop: {top.Type} {top.Precedence}");
                            if (incoming.Associativity == OpAssociativity.Leftward)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                        else
                        {
                            // Otherwise, if precedence of incoming is lower, pop stack and add to postfix,
                            // and then continue the same test on the new top.
                            for (; stack.Count > 0 && incoming.Precedence < ((OpNode)stack.Peek()).Precedence;)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                    }

                    stack.Push(incoming);
                }
            }

            for (; stack.Count > 0;)
            {
                postfix.Add(stack.Pop());
            }

            /* foreach (var op in postfix) Console.WriteLine(op.Type); */
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
            var blockExpression = new List<string>();
            var block = new StringBuilder();
            foreach (var c in expression)
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

        public static void TestBraces(string expression)
        {
            // TODO: IMPLEMENT THE DECOMPOSING LOGIC FOR PARENTHESES.
            // var expression = "(A1+B2)+C3";
            var braces = "{[()]}";  // the braces should probably be put into a dict as key-value pair.

            Dictionary<char, char> BraceDict = new ()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' },
            };

            Dictionary<char, Func<char>> OperatorDict = new ()
            {
              { '+', () => '+' },
              { '-', () => '-' },
              { '*', () => '*' },
              { '/', () => '/' },
            };

            var operatorList = (
                from op in OperatorDict
                select op.Key).ToArray();


            // var operatorList = opList.ToArray();

            // first, parse only operators from the expression.
            var operators = (
                from c in expression
                where operatorList.Contains(c)
                select string.Empty + c
            ).ToArray();

            // then, parse only operands by splitting it by operators.
            var operands = expression.Split(operatorList);

            foreach (var block in operands)
            {
                if (block[0] is char openB && braces.Contains(openB))
                {
                    Console.WriteLine(openB);
                    Console.WriteLine(block[1..]);
                }
                else if (block[^1] is char closeB && braces.Contains(closeB))
                {
                    Console.WriteLine(block[0..^1]);
                    Console.WriteLine(closeB);
                }
                else
                {
                    Console.WriteLine(block);
                }
            }
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
                // Console.WriteLine(e);
                throw new NotImplementedException("Unable to parse string into int.");
            }

            return newNode;
        }
    }
}