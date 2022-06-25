// <copyright file="ExpressionTree_Fields.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

    /// <summary>
    /// The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
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
        /// Dictionary for casting from the general OpNode to specialized operator node.
        /// </summary>
        private static readonly Dictionary<char, Func<OpNode, OpNode>> OperatorCastDict = new ()
        {
            { '+', (x) => (OpNodeAdd)x },
            { '-', (x) => (OpNodeSub)x },
            { '*', (x) => (OpNodeMul)x },
            { '/', (x) => (OpNodeDiv)x },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">the arithmetic expression as input string.</param>
        public ExpressionTree(string expression = "A1+B2+C3")
        {
            var nodes = ExpressionParser.Parse(expression);
            var postfix = ExpressionParser.MakePostfix(nodes);
            this.Root = this.MakeTree(postfix);
        }

        /// <summary>
        /// Gets or sets the root node of this tree.
        /// </summary>
        private Node? Root { get; set; }
    }
}