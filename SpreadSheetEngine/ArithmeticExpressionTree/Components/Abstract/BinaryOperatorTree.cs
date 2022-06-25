// <copyright file="BinaryOperatorTree.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

/// <summary>
/// The abstract class for the core tree structure.
/// </summary>
public abstract class BinaryOperatorTree
{
    /// <summary>
    /// The dictionary for casting from OpNode to specialized operator.
    /// </summary>
    protected static readonly Dictionary<char, Func<OpNode, OpNode>> OperatorCastDict = new ()
    {
        { '+', (x) => (OpNodeAdd)x },
        { '-', (x) => (OpNodeSub)x },
        { '*', (x) => (OpNodeMul)x },
        { '/', (x) => (OpNodeDiv)x },
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryOperatorTree"/> class.
    /// </summary>
    /// <param name="expression">the input expression.</param>
    internal BinaryOperatorTree(string expression)
    {
        var nodes = ExpressionParser.Parse(expression);
        var postfix = ExpressionParser.MakePostfix(nodes);
        this.Root = this.MakeTree(postfix);
    }

    /// <summary>
    /// Gets or sets the root node of this tree.
    /// </summary>
    private Node? Root { get; set; }

    /// <summary>
    /// Sets the variable in the expression tree.
    /// </summary>
    /// <param name="varName">name of the variable.</param>
    /// <param name="varValue">value of the variable.</param>
    protected void SetVariable(string varName, double varValue)
    {
        /*
            TODO: Sets a new variable into the expression tree.
         */
        throw new NotImplementedException();
    }

    /// <summary>
    /// Evaluates the expression tree to yield a double value.
    /// </summary>
    /// <returns>final result of type double.</returns>
    protected double Evaluate()
    {
        /*
            TODO: Provides implementation for tree evaluation.
         */
        throw new NotImplementedException();
    }

    /// <summary>
    /// Makes a new tree from a postfix list.
    /// </summary>
    /// <param name="postfix">the postfix.</param>
    /// <returns>the new root node of the tree.</returns>
    private Node MakeTree(IEnumerable<Node> postfix)
    {
        var stack = new Stack<Node>();

        foreach (var node in postfix)
        {
            if (node is OpNode op)
            {
                // op = OperatorCastDict[op.Symbol].Invoke(op);
                op.Right = stack.Pop();
                op.Left = stack.Pop();
                stack.Push(op);
            }
            else
            {
                stack.Push(node);
            }
        }

        this.Root = stack.Pop(); // finally pop the tree root from the stack.
        return this.Root;
    }

    /*
     * REQUIREMENTS FOR THE TREE:
     *  - Supports operators +, -, *, /
     *  - Supports:
     *      - parsing of user-entered expression.
     *      - building an expression tree out of that input.
     *
     * SPECIFICATIONS:
     *  - Each node in the tree must be one of the three types:
     *      + ConstantNode (NO CHILDREN)
     *      + VariableNode (NO CHILDREN)
     *      + BinaryOperatorNode

     *  - Supports multichar values like "A2"
     *
     *  - Requirements for variables:
     *      + will start with an alphabet char,
     *      + upper or lower-case,
     *      + followed by any number of alphabet chars and decimal digits (0-9)
     *
     *  - Creating new expression clears the old expression.
     *
     *  - Has a default expression, such as "A1+B1+C1", so that the user has something to work with.
     *
     *  - If variable is not set, they can be default to 0.
     *
     */
}