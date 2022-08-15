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
        /// <param name="variable">the variable to be set.</param>
        internal void SetVariable((string? Name, double Value) variable)
        {
            /*
                TODO: Sets the value of a variable in the expression tree.
             */
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Checks if var name is in tree.
        /// </summary>
        /// <param name="name">name of variable.</param>
        /// <returns>true or false.</returns>
        internal bool IsInTree(string name)
        {
            /*
             * TODO: this is used on the client side.
             */
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Looks up a variable in the tree by its name.
        /// </summary>
        /// <param name="name">the name of the var.</param>
        /// <param name="node">the var node to look up.</param>
        /// <returns>the VarNode.</returns>
        internal VarNode? LookUpVar(string name, Node? node)
        {
            if (node is VarNode v && v.Name == name)
            {
                return v;
            }

            VarNode? res = null;
            if (node is OpNode op)
            {
                var vl = this.LookUpVar(name, op.Left);
                var vr = this.LookUpVar(name, op.Right);
                res =
                    vl != null && vl.Name == name ? vl :
                    vr != null && vr.Name == name ? vr : null;
            }

            return res;
        }
    }
}