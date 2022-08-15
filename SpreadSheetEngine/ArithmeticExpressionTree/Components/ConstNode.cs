// <copyright file="ConstNode.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components
{
    using System.Diagnostics.CodeAnalysis;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     Holds a constant value.
    /// </summary>
    public class ConstNode : Node
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstNode" /> class.
        /// </summary>
        /// <param name="value">the constant value.</param>
        public ConstNode(double value = 0.0)
        {
            this.Value = value;
        }

        /// <summary>
        ///     Gets the value of this constant node.
        /// </summary>
        public double Value { get; }
    }
}