// <copyright file="ExpressionParser_Methods_PostFix.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
    using System.Runtime.CompilerServices;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     Contains methods only.
    ///     This is a static class. It takes an input expression as string and process that into a node-based
    ///     version ready to be consumed by the Expression Tree's constructor.
    /// </summary>
    internal static partial class ExpressionParser
    {
        /// <summary>
        /// Public API to prepare the expression for the Expression Tree.
        /// </summary>
        /// <param name="expression">the input expression.</param>
        /// <returns>the list of nodes in postfix style.</returns>
        public static IEnumerable<Node>? MakePostfix(string expression)
        {
            var strings = ParseInfix(expression);
            return MakePostfixNodes(strings);
        }

        /// <summary>
        ///     Make a postfix from an infix as list of strings.
        /// </summary>
        /// <param name="infix">the infix as list of strings.</param>
        /// <returns>new postfix as list of nodes.</returns>
        private static IEnumerable<Node>? MakePostfixNodes(IEnumerable<string> infix)
        {
            var stack = new Stack<Node>();
            var postfix = new List<Node>();

            foreach (var block in infix)
            {
                Console.WriteLine(block);

                Node newNode;
                if (block.Length > 1)
                {
                    if (IsValidVarName(block))
                    {
                        newNode = NodeFromStr(block);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    newNode = NodeFromChar(block[0]);
                }

                if (newNode is OpNode incoming)
                {
                    if ("()".Contains(incoming.Symbol))
                    {
                        if (incoming is OpNodeLeftBrace)
                        {
                            stack.Push(incoming);
                        }
                        else
                        {
                            while (stack.Count > 0 && stack.Peek() is not OpNodeLeftBrace)
                            {
                                postfix.Add(stack.Pop());
                            }

                            if (stack.Count == 0)
                            {
                                return null;
                            }

                            stack.Pop();
                        }
                    }
                    else
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
                }
                else
                {
                    postfix.Add(newNode);
                }
            }

            for (; stack.Count > 0;)
            {
                postfix.Add(stack.Pop());
            }

            return postfix.ToImmutableList();
        }

        /*
        public static IEnumerable<Node> MakePostfixOld(IEnumerable<Node> infix)
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
    */
    }
}