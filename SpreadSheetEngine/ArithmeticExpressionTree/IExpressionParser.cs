// <copyright file="IExpressionParser.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /*
     * ASSUMPTIONS ABOUT EXPRESSIONS:
     *  - Will NOT have any parentheses.
     *  - Will have a SINGLE TYPE OF OPERATOR.
     *  - Will have any number of instances of that operator.
     *      Example 1: "A+B+C1+Hello+6"
     *      Example 2: "C2-9-B2-27"
     *      Example 3: "X+Y-Z" is not allowed.
     *
     * DESIGN:
     *  - The parser should create an ArrayList of Node type for each parsed string unit.
     *  - Each unit in the ArrayList will be tagged with a type for later specialization during tree construction.
     *  - This way, the parsing step is decoupled from the tree construction stepped.
     *
     */

    /// <summary>
    /// The parser interface that helps build a tree from an arithmetic expression.
    /// </summary>
    internal interface IExpressionParser
    {
        /*
            TODO:
                - Read guidelines on how to write an interface in C#.
                - Decide and design the interface methods/functions.
         */

        /// <summary>
        /// Parses and returns an ArrayList of legal tree units.
        /// </summary>
        /// <param name="expression">the string expression to be parsed.</param>
        public void Parse(string expression)
        {
            /*
                TODO: Implement the logic of parsing.

                DO NOT FORGET TO CHANGE THE RETURN TYPE.
             */
            throw new NotImplementedException();
        }
    }
}
