// <copyright file="ExpressionTree_Manipulation.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpressionTreeTests")]
[assembly: InternalsVisibleTo("ExpressionTreeConsole")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    // using Components.Operators.EnumAttributes;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        /// <summary>
        ///     Sets the variable in the expression tree.
        /// </summary>
        /// <param name="variable">the variable to be set.</param>
        internal void SetVariable((string? Name, double Value) variable)
        {
            /*
                TODO: Sets the value of a variable in the expression tree.
             */
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Checks if var name is in tree.
        /// </summary>
        /// <param name="name">name of variable.</param>
        /// <returns>true or false.</returns>
        internal bool IsInTree(string name)
        {
            return false;
        }

        /// <summary>
        ///     Evaluates the expression tree to yield a double value.
        /// </summary>
        /// <returns>final result of type double.</returns>
        internal double Evaluate()
        {
            return this.Eval(this.Root);
        }

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

        /// <summary>
        ///     traverse and eval the tree.
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
            return evaluate(left, right);
        }

        /// <summary>
        ///     Looks up a variable in the tree by its name.
        /// </summary>
        /// <param name="name">the name of the var.</param>
        /// <returns>the VarNode.</returns>
        private Node LookUpVar(string name)
        {
            /*
             * TODO: implement recursive look up in the tree.
             */
            throw new NotImplementedException();
        }
    }
}