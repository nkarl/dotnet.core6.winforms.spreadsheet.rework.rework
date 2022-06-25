// <copyright file="OpAssociativity.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators.EnumAttributes;

/// <summary>
/// The associativity of a operator.
/// </summary>
public enum OpAssociativity
{
    /// <summary>
    /// Right to Left associative.
    /// </summary>
    Rightward = -1,

    /// <summary>
    /// Left to Right associative.
    /// </summary>
    Leftward = 1,
}