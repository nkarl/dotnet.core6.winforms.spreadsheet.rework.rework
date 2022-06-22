// <copyright file="ConstantNode.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    /// Holds a constant value.
    /// </summary>
    public class ConstNode : Node
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstNode(double value = 0.0)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value of this node.
        /// </summary>
        public double Value { get; }
    }
}
