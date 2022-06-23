// <copyright file="Program.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using SpreadSheetEngine.ArithmeticExpressionTree;

string option;
string currentExpression;

void DisplayMenu()
{
    Console.WriteLine(@"
    EXPRESSION TREE CONSOLE MENU
    ----------------------------
        1. Enter an expression
        2. Set a variable
        3. Evaluate expression
        4. Quit
");
}

void ExecuteConsoleApp(bool appIsRunning)
{
    while (appIsRunning)
    {
        Console.Write($"\tEnter a menu option: ");
        option = Console.ReadLine() ?? string.Empty;
        switch (option)
        {
            case "1": // Asks user to enter an expression.
                Console.Write("Enter an expression: ");
                currentExpression = Console.ReadLine() ?? string.Empty;
                /*
                    TODO: Implement the class instantiation of the class ExpressionTree.
                 */

                ExpressionParser parser = new ExpressionParser();
                var blocks = ExpressionParser.StrToBlockExpression(currentExpression);
                /*
                foreach (var b in blocks) Console.WriteLine(b);
                */
                var nodes = ExpressionParser.BlockToNodeExpression(blocks);
                /*
                foreach (var n in nodes) Console.WriteLine(n.Type);
                */
                break;

            case "2": // Sets a variable in the expression tree.
                Console.WriteLine("Setting a variable");
                /*
                    TODO: Implement the option for setting a variable in the ExpressionTree.
                 */
                break;

            case "3": // Evaluates the expression tree.
                Console.WriteLine("Evaluating the expression");
                /*
                    TODO: Implement the option to evaluate the ExpressionTree.
                 */
                break;

            case "4": // Quits the app.
                appIsRunning = false;
                break;

            default:
                Console.WriteLine("option not implemented.");
                break;
        }
    }
}

DisplayMenu();
ExecuteConsoleApp(true);