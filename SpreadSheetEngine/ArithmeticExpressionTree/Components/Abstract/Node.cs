// <copyright file="Node.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract
{
    /// <summary>
    /// The abstract base class for any and all tree node.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Gets the type of this Node.
        /// </summary>
        public string Type => this.GetType().Name;
    }
}
