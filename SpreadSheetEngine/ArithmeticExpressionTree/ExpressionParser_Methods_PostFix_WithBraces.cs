// <copyright file="ExpressionParser_Methods_PostFix_WithBraces.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
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
        /*
         * TODO: Implement support for braces for postfix construction.
         *  - Maybe, implement BraceNode with precedence gradient.
         *  - The order is:
         *      { > [ > (
         *    and vice versa for their counterparts.
         */

        /// <summary>
        ///     Make a postfix from an infix as list of nodes.
        /// </summary>
        /// <param name="expression">the string expression.</param>
        /// <returns>new postfix as list of nodes.</returns>
        internal static IEnumerable<Node>? MakePostFix2(string expression)
        {
            var blocks = FromInfixToBlocks(expression);
            var postfix = FromBlocksToPostfixNodes(blocks);
            return postfix;
        }

        /// <summary>
        ///     Converts blocks of string to postfix nodes.
        /// </summary>
        /// <param name="infix">infix expression as list of string.</param>
        /// <returns>postfix as list of nodes.</returns>
        internal static IEnumerable<Node>? FromBlocksToPostfixNodes(IEnumerable<string> infix)
        {
            /*
             * TODO: Audit this and see if it's possible to combine this with the PostFix maker.
             */
            var stack = new Stack<Node>();
            var postfix = new List<Node>();

            foreach (string block in infix)
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
                        /*
                         * TODO: Implement Left and Right brace operators.
                         */
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
    }
}