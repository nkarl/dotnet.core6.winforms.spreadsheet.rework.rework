// <copyright file="Program.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using SpreadSheetEngine.ArithmeticExpressionTree;

string menuOption;
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
        menuOption = Console.ReadLine() ?? string.Empty;
        switch (menuOption)
        {
            case "1": // Asks user to enter an expression.
                tree = null;
                while (tree is null)
                {
                    Console.Write("\tEnter an expression: ");
                    currentExpression = Console.ReadLine() ?? string.Empty;
                    tree = new ExpressionTree(currentExpression);
                    if (tree.IsEmpty())
                    {
                        Console.WriteLine("\tInvalid variable name. Enter the expression again.");
                        tree = null;
                    }
                }

                break;

            case "2": // Sets a variable in the expression tree.
                Console.WriteLine("\tSetting a variable . . .");
                /*
                    TODO: Implement the option for setting a variable in the ExpressionTree.
                 */
                break;

            case "3": // Evaluates the expression tree.
                /*
                 * TODO: Clean up the logic of this case.
                 */
                Console.WriteLine("\tEvaluating the expression . . .");
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