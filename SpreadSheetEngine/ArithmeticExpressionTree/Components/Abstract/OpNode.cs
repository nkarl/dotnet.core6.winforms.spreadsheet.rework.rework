using System.Diagnostics.CodeAnalysis;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public abstract class OpNode : Node
{
    [SuppressMessage("ReSharper", "InconsistentNaming")] protected static char _op;
    [SuppressMessage("ReSharper", "InconsistentNaming")] protected static int _precedence;
    // protected static int _associativity;

    protected OpNode()
    {
        this.Left = this.Right = null;
    }

    public static char Op => _op;
    public static int Precedence => _precedence;
    // public static int Associativity => _associativity;
    internal Node? Left { get; set; }
    internal Node? Right { get; set; }
}