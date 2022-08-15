// <copyright file="ExpressionParser_Methods_StackingOpOverloads.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
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
        private static void StackingAdd(OpNodeAdd incomingOp, Stack<Node> stack, List<Node> postfix)
        {
                    if (stack.Count > 0)
                    {
                        if (incomingOp.Precedence == ((OpNodeAdd)stack.Peek()).Precedence)
                        {
                            if (incomingOp.Associativity == OpAssociativity.Leftward)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                        else if (incomingOp.Precedence < ((OpNodeAdd)stack.Peek()).Precedence)
                        {
                            // pop stack and add to postfix, and then continue the same test on the new top.
                            for (; stack.Count > 0 && incomingOp.Precedence < ((OpNodeAdd)stack.Peek()).Precedence;)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                    }

                    stack.Push(incomingOp);
        }

        private static void StackingSub(OpNodeSub incomingOp, Stack<Node> stack, List<Node> postfix)
        {
                    if (stack.Count > 0)
                    {
                        if (incomingOp.Precedence == ((OpNodeSub)stack.Peek()).Precedence)
                        {
                            if (incomingOp.Associativity == OpAssociativity.Leftward)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                        else if (incomingOp.Precedence < ((OpNodeSub)stack.Peek()).Precedence)
                        {
                            // pop stack and add to postfix, and then continue the same test on the new top.
                            for (; stack.Count > 0 && incomingOp.Precedence < ((OpNodeSub)stack.Peek()).Precedence;)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                    }

                    stack.Push(incomingOp);
        }

        private static void StackingMul(OpNodeMul incomingOp, Stack<Node> stack, List<Node> postfix)
        {
                    if (stack.Count > 0)
                    {
                        if (incomingOp.Precedence == ((OpNodeMul)stack.Peek()).Precedence)
                        {
                            if (incomingOp.Associativity == OpAssociativity.Leftward)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                        else if (incomingOp.Precedence < ((OpNodeMul)stack.Peek()).Precedence)
                        {
                            // pop stack and add to postfix, and then continue the same test on the new top.
                            for (; stack.Count > 0 && incomingOp.Precedence < ((OpNodeMul)stack.Peek()).Precedence;)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                    }

                    stack.Push(incomingOp);
        }

        private static void StackingDiv(OpNodeDiv incomingOp, Stack<Node> stack, List<Node> postfix)
        {
                    if (stack.Count > 0)
                    {
                        if (incomingOp.Precedence == ((OpNodeDiv)stack.Peek()).Precedence)
                        {
                            if (incomingOp.Associativity == OpAssociativity.Leftward)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                        else if (incomingOp.Precedence < ((OpNodeMul)stack.Peek()).Precedence)
                        {
                            // pop stack and add to postfix, and then continue the same test on the new top.
                            for (; stack.Count > 0 && incomingOp.Precedence < ((OpNodeDiv)stack.Peek()).Precedence;)
                            {
                                postfix.Add(stack.Pop());
                            }
                        }
                    }

                    stack.Push(incomingOp);
        }
    }
}