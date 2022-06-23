using System.Diagnostics.CodeAnalysis;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class VarNode : Node
{
    public VarNode(string name) => this.Name = name;

    /// <summary>
    /// Gets the name of this variable node.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public string Name { get; }
}