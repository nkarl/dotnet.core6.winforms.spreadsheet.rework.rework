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
    ExpressionTree? tree = null;

    while (appIsRunning)
    {
        Console.Write("\tEnter a menu option: ");
        option = Console.ReadLine() ?? string.Empty;
        switch (option)
        {
            case "1": // Asks user to enter an expression.
                /*
                 * TODO: Clean up the logic of this case.
                 */
                Console.Write("Enter an expression: ");
                currentExpression = Console.ReadLine() ?? string.Empty;
                tree = new ExpressionTree(currentExpression);
                /*
                var nodes = ExpressionParser.Parse(currentExpression);
                var postfix = ExpressionParser.MakePostfix(nodes);
                */
                break;

            case "2": // Sets a variable in the expression tree.
                Console.WriteLine("Setting a variable");
                /*
                    TODO: Implement the option for setting a variable in the ExpressionTree.
                 */
                break;

            case "3": // Evaluates the expression tree.
                /*
                 * TODO: Clean up the logic of this case.
                 */
                Console.WriteLine("Evaluating the expression");
                tree ??= new ExpressionTree();
                tree.Evaluate();
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