using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class Multiply : OpNode
{
   static Multiply()
   {
      _op = '*';
      _precedence = 11;
   }
}