// <copyright file="ExpressionTree_Fields.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

/// <summary>
/// The Binary Tree to hold all nodes in a expression tree.
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
    /// Gets the root node of this tree.
    /// </summary>
    internal Node? Root { get; private set; }
}