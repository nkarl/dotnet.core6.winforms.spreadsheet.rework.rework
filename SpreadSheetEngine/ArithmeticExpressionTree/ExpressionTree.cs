// <copyright file="ExpressionTree_Methods.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpressionTreeTests")]
[assembly: InternalsVisibleTo("ExpressionTreeConsole")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /*
     * ASSUMPTIONS:
     *  - THAT: the input expression is in correct format and parser works.
     *
     * TREE STRUCTURE:
     *  - OPERATORS ARE INTERNAL NODES.
     *  - OPERANDS ARE LEAF NODES.
     *
     */

    /*
     * TODO: MOVE THE CORE CONSTRUCTION TO AN ABSTRACT CLASS, BinaryOperatorTree.
     */

    /// <summary>
    /// The data structure for arithmetic expressions.
    /// </summary>
    internal class ExpressionTree : BinaryOperatorTree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression as input string.</param>
        public ExpressionTree(string expression = "A1+B2+C3")
            : base(expression)
        {
        }
    }
}