// <copyright file="ExpressionTree.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The data structure for arithmetic expressions.
    /// </summary>
    internal class ExpressionTree : IExpressionParser
    {
        /*
            TODO:
                - Implements the class ExpressionTree from IExpressionParser.
         */

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression.</param>
        public ExpressionTree(string expression)
        {
        }

        /// <summary>
        /// Sets the variable in the expression tree.
        /// </summary>
        /// <param name="varName">name of the variable.</param>
        /// <param name="varValue">value of the variable.</param>
        public void SetVariable(string varName, double varValue)
        {
        }

        /// <summary>
        /// Evaluates the expression tree to yield a double value.
        /// </summary>
        /// <returns>final result of type double.</returns>
        public double Evaluate()
        {
            /*
                TODO: Provides implementation for tree evaluation.
             */

            return 0;
        }
    }
}
