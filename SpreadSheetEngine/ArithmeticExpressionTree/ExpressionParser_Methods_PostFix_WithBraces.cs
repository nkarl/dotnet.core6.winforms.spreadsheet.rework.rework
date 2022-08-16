// <copyright file="ExpressionParser_Methods_PostFix_WithBraces.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
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
        /// <param name="infix">the infix as list of nodes.</param>
        /// <returns>new postfix as list of nodes.</returns>
        public static IEnumerable<Node> MakePostfixWithBraces(IEnumerable<Node> infix)
        {
            var stack = new Stack<Node>();
            var postfix = new List<Node>();
            var leftbraces = "{[(";
            var rightbraces = ")]}";
            var braces = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' },
            };

            foreach (Node node in infix)
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
                    /*
                     * Description:
                     *      1. whenever the symbol is any left brace, push it to the stack.
                     *      2. whenever the symbol is any right brace, pop the stack until
                     *          found its matching left. Then discard both.
                     *
                     * TODO: Implement the logic for parsing with braces.
                     *      1. Parse an expression with correct brace order.
                     *      2. Handle when expression has incorrect brace order.
                     */
                    postfix.Add(node);
                }
            }

            for (; stack.Count > 0;)
            {
                postfix.Add(stack.Pop());
            }

            return postfix;
        }
    }
}