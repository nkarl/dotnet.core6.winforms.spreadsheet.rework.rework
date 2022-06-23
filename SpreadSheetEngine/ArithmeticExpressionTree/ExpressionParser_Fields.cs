// <copyright file="ExpressionParser_Fields.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpressionParserTests")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

    /*
     * ASSUMPTIONS ABOUT EXPRESSIONS:
     *  - Will NOT have any parentheses.
     *  - Will have a SINGLE TYPE OF OPERATOR.
     *  - Will have any number of instances of that operator.
     *      Example 1: "A+B+C1+Hello+6"
     *      Example 2: "C2-9-B2-27"
     *      Example 3: "X+Y-Z" is not allowed.
     *
     * ADDITIONAL ASSUMPTIONS ABOUT THE OPERANDS:
     *  - a constant is a purely numerical value.
     *  - a variable is anything but the above, meaning 'A1' is also a var, but can be used to look up
     *      in the Sheet later.
     * - another type of var is the kind that is to be set in the expression tree.
     *
     * DESIGN:
     *  - The parser should create an ArrayList of Node type for each parsed string unit.
     *  - Each unit in the ArrayList will be tagged with a type for later specialization during tree construction.
     *  - This way, the parsing step is decoupled from the tree construction stepped.
     *
     */

    /// <summary>
    /// Contains the fields of the Parser.
    /// </summary>
    internal partial class ExpressionParser
    {
        /*
            TODO:
                - Read guidelines on how to write an interface in C#.
                - Decide and design the interface methods/functions.
         */

        /// <summary>
        /// Lookup set for natural decimal digits.
        /// </summary>
        private static readonly string Digits = "0123456789"; // digit map

        /// <summary>
        /// Lookup set for uppercase letters.
        /// </summary>
        private static readonly string UpperCase = string.Concat(( // uppercase map
            from c in Enumerable.Range('A', 'Z' - 'A' + 1)
            select (char)c).ToArray());

        /// <summary>
        /// Look up set for lowercase letters.
        /// </summary>
        private static readonly string LowerCase = string.Concat(( // lowercase map
            from c in Enumerable.Range('a', 'z' - 'a' + 1)
            select (char)c).ToArray());

        /// <summary>
        /// Used by by OpNodeFactory to create new operator node.
        /// </summary>
        private static readonly Dictionary<char, Func<OpNode>> OperatorDict = new ()
        {
            { '+', () => new OpNodeAdd() },
            { '-', () => new OpNodeSub() },
            { '*', () => new OpNodeMul() },
            { '/', () => new OpNodeDiv() },
        };

        /// <summary>
        /// Parses a given string into a list of nodes.
        /// </summary>
        /// <param name="expression">the string expression to be parsed.</param>
        /// <returns>an ArrayList of Nodes.</returns>
        public ArrayList? Parse(string? expression)
        {
            /*
                TODO: Implement the logic of parsing.

                DESIGN:
                - The parsing is a filtering process.
                - There are 3 possible categories of nodes a new string unit can be captured: operator, constant, variable
                    + The operator type is the trivial case, where
                        * the length of string is 1 and the char must be one of 4 cases: +, -, *, /
                    + The remaining two categories are: constant and variable, where
                        * the length of string > 1, or the char not one of (+, -, *, /)

                - How to handle the remaining 2 cases:
                    + Use a StringBuilder to build a possible unit, where
                        * the terminating condition is the next operator.
                    + Once the unit has been captured, the unit then is filtered into the remaining two cases.
                        * a possible solution is to build a tuple of three, where
                            the map contains 3 categories: col, row, extra
                        * then, each tuple will be checked for qualifications.
                        * the scenarios are as follows:
                            i.   length > 0 in col, length > 0 in row, length == 0 in extra: possible cell coordinates.
                            ii.  length > 0 in col, length > 0 in row, length > 0 in extra: guaranteed variable.
                            iii. length == 0, length > 0 in row, any in extra: error.
                            iv.  else, variable.

                        * mapping for each tuple:
                            if i,
                                check if tuple.1 is in alphabet
                                check if tuple.2 is in range [0, 50]
                                check if tuple.3 is empty
                                if all true, is cell coordinates.
                            else,
                                variable

                DO NOT FORGET TO CHANGE THE RETURN TYPE.
             */
            if (expression is null)
            {
                return null;
            }

            return new ArrayList();
        }
    }
}