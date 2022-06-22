using System.Runtime.CompilerServices;

namespace SpreadSheetEngine.ArithmeticExpressionTree.Components.Operators;

using SpreadSheetEngine.ArithmeticExpressionTree.Components.Abstract;

public class Divide : OpNode
{
   static Divide()
   {
      _op = '/';
      _precedence = 11;
   }
}