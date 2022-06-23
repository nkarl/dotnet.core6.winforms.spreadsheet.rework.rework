// <copyright file="OpNode.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// The Operator Node.
/// </summary>
public abstract class OpNode : Node
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Disabled Until Tree Implementation.")]
    protected static char op;
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Disabled Until Tree Implementation.")]
    protected static int precedence;

    // protected static int _associativity;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpNode"/> class.
    /// The Operator Node.
    /// </summary>
    protected OpNode()
    {
        this.Left = this.Right = null;
    }

    /// <summary>
    /// Gets the character denoting this operator.
    /// </summary>
    public static char Op => op;

    /// <summary>
    /// Gets the precedence of this operator.
    /// </summary>
    public static int Precedence => precedence;

    // public static int Associativity => _associativity;

    /// <summary>
    /// Gets or sets the left child-node.
    /// </summary>
    internal Node? Left { get; set; }

    /// <summary>
    /// Gets or sets the right child-node.
    /// </summary>
    internal Node? Right { get; set; }
}