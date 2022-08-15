// <copyright file="ExpressionTree_Fields.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

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

        // ReSharper disable once InconsistentNaming
        private readonly Dictionary<string, VarNode> varDict;

        /*
        /// <summary>
        ///     Dictionary for casting from the general OpNode to specialized operator node.
        /// </summary>
        private static readonly Dictionary<char, Func<OpNode, OpNode>> CastOperator = new()
        {
            { '+', op => (OpNodeAdd)op },
            { '-', op => (OpNodeSub)op },
            { '*', op => (OpNodeMul)op },
            { '/', op => (OpNodeDiv)op },
        };
        */

        /// <summary>
        ///     Gets the expression of this tree.
        /// </summary>
        public string Expression { get; }

        /// <summary>
        ///     Gets or sets the root node of this tree.
        /// </summary>
        private Node? Root { get; set; }
    }
}