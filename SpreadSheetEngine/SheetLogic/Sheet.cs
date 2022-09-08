// <copyright file="Sheet.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SpreadSheetApp")]
[assembly: InternalsVisibleTo("SpreadSheetEngineTests")]

namespace SpreadSheetEngine.SheetLogic
{
    using System.ComponentModel;
    using System.Globalization;
    using SpreadSheetEngine.ArithmeticExpressionTree;
    using SpreadSheetEngine.SheetLogic.Components;

    /// <summary>
    ///     The data source controller for the 2D array of cells.
    /// </summary>
    internal sealed class Sheet : INotifyPropertyChanged
    {
        /*
         * TODO: IMPLEMENT THE EVENT HANDLER LOGIC FOR COMMUNICATION BETWEEN DataGridView AND LOGIC ENGINE.
         *  - The DataGridView will be the source of the event.
         *  - The event will be handled by the Sheet class.
         *  - The Sheet class will then update the cell's value and notify the DataGridView of the change.
         *  - The DataGridView will then update the cell's value.
         *  - The DataGridView will also notify the Sheet class of the change.
         *  - The Sheet class will then update the cell's value and notify the DataGridView of the change.
         */

        // ReSharper disable once InconsistentNaming
        private readonly Cell?[,] table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sheet" /> class.
        /// </summary>
        /// <param name="numRows">the number of rows in this sheet.</param>
        /// <param name="numColumns">the number of columns in this sheet.</param>
        public Sheet(int numRows, int numColumns)
        {
            this.table = new Cell[numRows, numColumns];
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Gets the row count of the sheet.
        /// </summary>
        public int RowCount => this.table.GetLength(0);

        /// <summary>
        ///     Gets the column count of the sheet.
        /// </summary>
        public int ColumnCount => this.table.GetLength(1);

        /// <summary>
        ///     Returns the reference to the cell at the given coordinates.
        /// </summary>
        /// <param name="rowIndex">the row index of the cell.</param>
        /// <param name="columnIndex">the column index of the cell.</param>
        /// <returns>the cell if found.</returns>
        internal Cell GetCell(int rowIndex, int columnIndex)
        {
            return this.table[rowIndex, columnIndex] ??= Cell.CreateInstance(rowIndex, columnIndex);
        }

        /// <summary>
        ///     Sets the content of a cell of given coordinates.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        /// <param name="input">the text content of the cell.</param>
        internal void SetCell(int rowIndex, int columnIndex, string input)
        {
            var cell = this.GetCell(rowIndex, columnIndex);

            string newContent = input[0] != '='
                ? input
                : this.Evaluate(input[1..]);

            cell.SetContent(newContent);
            this.OnPropertyChanged();
        }

        /// <summary>
        /// Sets the variables if the expression contains variables.
        /// </summary>
        /// <param name="tree">the current expression tree.</param>
        private void SetCellValues(ExpressionTree tree)
        {
            /*
             * For key in tree.variables, use key to get the cell value from the sheet.
             * They key should be transformed into a cell coordinates.
             */
            foreach (var entry in tree.VarDictionary)
            {
                /*
                 * TODO: Translate key to cell coordinates.
                 * The first character of the key is the column index.
                 * The rest of the key is the row index.
                 * Also need to check if the expression actually contains variables. This can be done with checking the size of dictionary.
                 */
                var columnIndex = entry.Key[0] - 'A';
                try
                {
                    int rowIndex = int.Parse(entry.Key[1..]) - 1;
                    double value = double.Parse(this.GetCell(rowIndex, columnIndex).Value);
                    tree.VarDictionary[entry.Key].Value = value;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// Trigger the the expression evaluation.
        /// </summary>
        /// <param name="expression">the input expression.</param>
        /// <returns>the value evaluated as string.</returns>
        private string Evaluate(string expression)
        {
            /*
             * TODO:  provides implementation for content that is not cell coordinates.
             *  - Fixes the edge cases where 'A' - 'A'.
             *  - Supports pulling the value from another cell.
             *  [DONE] Supports arithmetic operations. Implements the logic for the Expression Tree.
             */
            var tree = new ExpressionTree(expression);
            if (!tree.IsEmptyVarDict())
            {
                this.SetCellValues(tree);
            }

            var value = tree.Evaluate();
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Should raise a notifying event whenever a property is changed.
        /// </summary>
        /// <param name="propertyName">the name of the caller member method.</param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}