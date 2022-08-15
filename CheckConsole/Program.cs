// See https://aka.ms/new-console-template for more information

using SpreadSheetEngine.ArithmeticExpressionTree;

Console.WriteLine("Hello, World!");

var exp1 = "(A1+B2)+C3";
var exp2 = "20-22+30";
var exp = exp2;
// ExpressionParser.ParseInfixWithBraces(exp1);
var tree = new ExpressionTree(exp);
tree.Show();
