// See https://aka.ms/new-console-template for more information

using SpreadSheetEngine.ArithmeticExpressionTree;

Console.WriteLine("Hello, World!");

var exp1 = "(A1+B2)+C3";
var exp2 = "20-22+30";
var exp3 = "1.1+2+3";
var exp4 = "1.1+2.2+3.3";
var exp = exp3;
// ExpressionParser.ParseInfixWithBraces(exp1);
var tree = new ExpressionTree(exp);
tree.Show();
var result = tree.Evaluate();
Console.WriteLine($"result = {result}");
