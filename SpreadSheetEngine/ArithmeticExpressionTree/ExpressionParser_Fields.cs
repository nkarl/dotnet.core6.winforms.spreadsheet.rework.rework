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
    }
}