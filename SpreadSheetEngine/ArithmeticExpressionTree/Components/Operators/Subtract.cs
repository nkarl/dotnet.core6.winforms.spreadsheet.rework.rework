using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class Subtract : OpNode
{
   static Subtract()
   {
      _op = '-';
      _precedence = 10;
   }
}