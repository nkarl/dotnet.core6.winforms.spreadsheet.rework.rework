// <copyright file="ExpressionParser_Methods_PostFix.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /// <summary>
    ///     This is a static class. It takes an input expression as string and process that into a node-based
    ///     postfix ready to be consumed by the Expression Tree's constructor.
    /// </summary>
    internal static partial class ExpressionParser
    {
        /// <summary>
        ///     Public API to prepare the expression for the Expression Tree.
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

            /*
             * 1. Scan the infix expression from left to right.
             */
            foreach (var block in infix)
            {
                /*
                 * 2. Check if the block has a valid name, and manufacture a new node from it.
                 */
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
                    /*
                     * 3. If the block is an operator, push it to the stack.
                     */
                    if ("()".Contains(incoming.Symbol))
                    {
                        /*
                         * If the incoming operator is a left parenthesis, push it to the stack.
                         * If the incoming operator is a right parenthesis, pop the stack and add operators to the postfix
                         * until you see a left parenthesis. Discard the pair of parentheses.
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
                                /*
                                 * If the incoming operator has the same precedence as the top of the stack, check if it is
                                 * left associative. If it is, pop the stack and add it to the postfix.
                                 */
                                if (incoming.Associativity == OpAssociativity.Leftward)
                                {
                                    postfix.Add(stack.Pop());
                                }
                            }
                            else if (incoming.Precedence < ((OpNode)stack.Peek()).Precedence)
                            {
                                /*
                                 * If the incoming operator has lower precedence than the top of the stack, keep popping the
                                 * stack and add it to the postfix until that no longer true.
                                 */
                                for (; stack.Count > 0 && incoming.Precedence < ((OpNode)stack.Peek()).Precedence;)
                                {
                                    postfix.Add(stack.Pop());
                                }
                            }

                            /*
                             * There is nothing to do if the incoming operator has higher precedence than the top of the stack.
                             */
                        }

                        /*
                         * Push the incoming operator to the stack.
                         */
                        stack.Push(incoming);
                    }
                }
                else
                {
                    /*
                     * 4. If the block is an operand, add it to the postfix.
                     */
                    postfix.Add(newNode);
                }
            }

            /*
             * 5. Pop the stack and add all the operators to the postfix.
             */
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