using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public abstract class OpNode : Node
{
    protected static char _op;
    protected static int _precedence;
    // protected static int _associativity;

    protected OpNode()
    {
        this.Left = this.Right = null;
    }

    public static char Op => _op;
    public static int Precedence => _precedence;
    // public static int Associativity => _associativity;
    protected Node? Left { get; set; }
    protected Node? Right { get; set; }
}