// <copyright file="ExpressionParser_Methods_PostFix.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections.Immutable;
    using System.Text;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

    /*
     * TODO: Handle the exception when the first parsed block is a negative value.
     */

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