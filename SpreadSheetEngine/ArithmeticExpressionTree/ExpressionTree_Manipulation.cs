// <copyright file="ExpressionTree_Manipulation.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;
using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

[assembly: InternalsVisibleTo("ExpressionTreeTests")]
[assembly: InternalsVisibleTo("ExpressionTreeConsole")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System;

    /// <summary>
    /// The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        /// <summary>
        /// Sets the variable in the expression tree.
        /// </summary>
        /// <param name="varName">name of the variable.</param>
        /// <param name="varValue">value of the variable.</param>
        internal void SetVariable(string varName, double varValue)
        {
            /*
                TODO: Sets a new variable into the expression tree.
             */
            throw new NotImplementedException();
        }

        /// <summary>
        /// Evaluates the expression tree to yield a double value.
        /// </summary>
        /// <returns>final result of type double.</returns>
        internal double Evaluate()
        {
            /*
                TODO: Provides implementation for tree evaluation.
             */
            throw new NotImplementedException();
        }

        /// <summary>
        /// traverse and eval the tree.
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
                /*
                 * TODO: Implement the logic for extracting value from VarNode or ConstNode.
                 */
            }
            else
            {
                double leftValue = this.Eval(op.Left);
                double rightValue = this.Eval(op.Right);

                return UseOperator[op.Symbol].Invoke(leftValue, rightValue);
            }
        }

        /*
         * REQUIREMENTS FOR THE TREE:
         *  - Supports operators +, -, *, /
         *  - Supports:
         *      - parsing of user-entered expression.
         *      - building an expression tree out of that input.
         *
         * SPECIFICATIONS:
         *  - Each node in the tree must be one of the three types:
         *      + ConstantNode (NO CHILDREN)
         *      + VariableNode (NO CHILDREN)
         *      + BinaryOperatorNode
         *
         *  - Supports multichar values like "A2"
         *
         *  - Requirements for variables:
         *      + will start with an alphabet char,
         *      + upper or lower-case,
         *      + followed by any number of alphabet chars and decimal digits (0-9)
         *
         *  - Creating new expression clears the old expression.
         *
         *  - Has a default expression, such as "A1+B1+C1", so that the user has something to work with.
         *
         *  - If variable is not set, they can be default to 0.
         *
         */
    }
}