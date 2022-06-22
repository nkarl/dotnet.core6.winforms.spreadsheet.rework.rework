// <copyright file="IExpressionParser.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;

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
    public class ExpressionParser
    {
        /*
            TODO:
                - Read guidelines on how to write an interface in C#.
                - Decide and design the interface methods/functions.
         */

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

            /*
            foreach (char c in expression)
            {
                block += c;
                if (block.Length == 1 && operatorList.Contains(block[0]))
                {
                    nodeExpr.Add(this.StrToNode("op"));
                    block = string.Empty;
                }
                else
                {
                }
            }
            */

            return new ArrayList();
        }

        /// <summary>
        /// Converts the string expression to block expression.
        /// </summary>
        /// <param name="expression">the original expression as string.</param>
        /// <returns>List of operand and operator string blocks.</returns>
        public List<string> StrToBlockExpression(string expression)
        {
            // From an expression string, iterate through each character and try to build up blocks of operands and operators.
            //  the block resets at either the next operator or the end of expression.
            List<string> allBlocks = new List<string>();
            StringBuilder block = new StringBuilder();
            string opList = "+-*/";
            foreach (var c in expression)
            {
                if (opList.Contains(c))
                {
                    allBlocks.Add(block.ToString());
                    allBlocks.Add(c.ToString());
                    block = new StringBuilder();
                    continue;
                }

                block.Append(c);
            }

            allBlocks.Add(block.ToString());
            return allBlocks;
        }

        /// <summary>
        /// Converts the block expression into a node expression.
        /// </summary>
        /// <param name="expression">the expression converted into blocks.</param>
        /// <returns>the expression as nodes.</returns>
        public ArrayList BlockToNodeExpression(List<string> expression)
        {
            ArrayList nodeExpr = new ArrayList();
            string opList = "+-*/";
            foreach (var block in expression)
            {
                if (block.Length == 1 && opList.Contains(block[0]))
                {
                    nodeExpr.Add(new Node("op"));
                }
            }

            return nodeExpr;
        }

        /// <summary>
        /// Converts the parsed string to Node.
        /// </summary>
        /// <param name="type">the unit of parsed string.</param>
        /// <returns>a new Node.</returns>
        public Node StrToNode(string type)
        {
            return new Node(type);
        }
    }
}
