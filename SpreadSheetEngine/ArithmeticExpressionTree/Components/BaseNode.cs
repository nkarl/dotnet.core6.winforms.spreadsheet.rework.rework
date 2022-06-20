// <copyright file="BaseNode.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The astract base class for a tree node.
    /// </summary>
    public abstract class BaseNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNode"/> class.
        /// </summary>
        /// <param name="type">the type of the node.</param>
        public BaseNode(string? type)
        {
            this.Type = type;
        }

          /// <summary>
        /// Gets or sets or gets the type of the Node.
        /// </summary>
        public string? Type { get; set; }
    }
}
