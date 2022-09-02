﻿// <copyright file="ExpressionTree_Fields.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        private static readonly Dictionary<char, Func<double, double, double>> InvokeOperator = new()
        {
            { '+', (a, b) => a + b },
            { '-', (a, b) => a - b },
            { '*', (a, b) => a * b },
            { '/', (a, b) => a / b },
        };

        /// <summary>
        /// Gets the variable in the expression tree.
        /// </summary>
        internal Dictionary<string, VarNode> VarDictionary { get; } = new ();

        /*
        /// <summary>
        ///     Gets the expression of this tree.
        /// </summary>
        private string Expression { get; }
        */

        /// <summary>
        ///     Gets or sets the root node of this tree.
        /// </summary>
        private Node? Root { get; set; }
    }
}