// <copyright file="VarNode.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components
{
    using System.Diagnostics.CodeAnalysis;
    using Abstract;

    /// <summary>
    ///     The Variable Node.
    /// </summary>
    public class VarNode : Node
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VarNode" /> class.
        /// </summary>
        /// <param name="name">name of this variable.</param>
        public VarNode(string name)
        {
            this.Name = name;
        }

        /// <summary>
        ///     Gets the name of this variable node.
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "Disabled Until Tree Implementation.")]
        public string Name { get; }
    }
}