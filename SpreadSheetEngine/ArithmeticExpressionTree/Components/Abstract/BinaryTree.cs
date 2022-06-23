// <copyright file="BinaryTree.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

/// <summary>
/// The Binary Tree to hold all nodes in a expression tree.
/// </summary>
public abstract class BinaryTree
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryTree"/> class.
    /// </summary>
    /// <param name="expression">the expression as a list of nodes.</param>
    protected BinaryTree(string? expression)
    {
        var nodes = ExpressionParser.Parse(expression);
        /*
         * TODO: Implement the construction logic for the tree for.
         *
         * TODO: Look up how to construct the tree from a expression stacks.
         *
         */
    }

    /// <summary>
    /// Gets or sets the root node of this tree.
    /// </summary>
    protected OpNode? Root { get; set; }
}