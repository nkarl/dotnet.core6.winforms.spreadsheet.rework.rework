// <copyright file="ExpressionTree_Methods_SetVar.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpressionTreeTests")]
[assembly: InternalsVisibleTo("ExpressionTreeConsole")]

namespace SpreadSheetEngine.ArithmeticExpressionTree
{
    using SpreadSheetEngine.ArithmeticExpressionTree.Components;
    using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

    /// <summary>
    ///     The Binary Tree to hold all nodes in an arithmetic expression tree.
    /// </summary>
    internal partial class ExpressionTree
    {
        /// <summary>
        ///     Sets the variable in the expression tree.
        /// </summary>
        /// <param name="var">the variable to be set.</param>
        internal void SetVariable((string? Name, double Value) @var)
        {
            if (var.Name != null)
            {
                var node = this.varDict[@var.Name];
                node.Value = @var.Value;
            }
        }

        /// <summary>
        ///     Checks if var name is in tree.
        /// </summary>
        /// <param name="name">name of variable.</param>
        /// <returns>true or false.</returns>
        internal bool HasVariable(string name)
        {
            return this.varDict.ContainsKey(name);
        }

        /// <summary>
        ///     Looks up a variable in the tree by its name.
        /// </summary>
        /// <param name="name">the name of the var.</param>
        /// <returns>the VarNode.</returns>
        internal VarNode? LookUpVar(string name)
        {
            this.varDict.TryGetValue(name, out var varNode);
            return varNode;
        }
    }
}