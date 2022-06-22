// <copyright file="ExpressionTree.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpressionTreeTests")]
[assembly: InternalsVisibleTo("ExpressionTreeConsole")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;

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

    /// <summary>
    /// The data structure for arithmetic expressions.
    /// </summary>
    internal class ExpressionTree : ExpressionParser
    {
        /*
            TODO:
                - Implement the class ExpressionTree from IExpressionParser.
         */

        public string? _expression;
        public List<string> _blocks;
        public ArrayList _nodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression.</param>
        public ExpressionTree(string? expression)
        {
            this._expression = expression;
            
            /*
                TODO: Implement the constructor.
             */
            ((ExpressionParser)this).Parse(expression);
        }

        /// <summary>
        /// Sets the variable in the expression tree.
        /// </summary>
        /// <param name="varName">name of the variable.</param>
        /// <param name="varValue">value of the variable.</param>
        public void SetVariable(string varName, double varValue)
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
        public double Evaluate()
        {
            /*
                TODO: Provides implementation for tree evaluation.
             */
            throw new NotImplementedException();
        }
    }
}
