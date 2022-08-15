// <copyright file="ExpressionTree_Manipulation.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpressionTreeTests")]
[assembly: InternalsVisibleTo("ExpressionTreeConsole")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        /// <summary>
        ///     Shows the entire tree.
        /// </summary>
        internal void Show()
        {
            this.ShowPostfix(this.Root);
        }

        private void ShowPostfix(Node? node)
        {
            if (node is not OpNode op)
            {
                if (node is ConstNode c)
                {
                    Console.WriteLine($"const: \t{c.Value}");
                }
                else if (node is VarNode v)
                {
                    Console.WriteLine($"<{v.Name}: \t{v.Value}>");
                }
            }
            else
            {
                this.ShowPostfix(op.Left);
                this.ShowPostfix(op.Right);
                Console.WriteLine(op.Symbol);
            }
        }
    }
}