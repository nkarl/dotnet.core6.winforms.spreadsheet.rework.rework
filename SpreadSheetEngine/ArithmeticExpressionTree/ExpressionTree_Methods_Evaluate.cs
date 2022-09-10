// <copyright file="ExpressionTree_Methods_Evaluate.cs" company="Charles Nguyen -- 011606177">
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
        ///     Evaluates the expression tree to yield a double value.
        /// </summary>
        /// <returns>final result of type double.</returns>
        internal double Evaluate()
        {
            return this.Eval(this.Root);
        }

        /// <summary>
        ///     Traverses and evaluates the tree.
        /// </summary>
        /// <param name="node">the current node in the tree.</param>
        /// <returns>a double value (evaluated).</returns>
        private double Eval(Node? node)
        {
            if (node is null)
            {
                return 0;
            }

            if (node is not OpNode op)
            {
                double result = 0;
                if (node is ConstNode c)
                {
                    result = c.Value;
                }
                else if (node is VarNode v)
                {
                    result = v.Value;
                }

                return result;
            }

            var evaluate = InvokeOperator[op.Symbol];
            var right = this.Eval(op.Right);
            var left = this.Eval(op.Left);
            try
            {
                return evaluate(left, right);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return double.NaN;
            }
        }
    }
}