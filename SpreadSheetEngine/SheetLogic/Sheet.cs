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
    using ArithmeticExpressionTree;
    using SpreadSheetEngine.SheetLogic.Components;

    /// <summary>
    ///     The data source controller for the 2D array of cells.
    /// </summary>
    internal sealed class Sheet : INotifyPropertyChanged
    {
        /*
         * TODO: IMPLEMENT THE EVENT HANDLER LOGIC FOR COMMUNICATION BETWEEN DataGridView AND LOGIC ENGINE.
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

        /*
         * public event PropertyChangedEventHandler PropertyChanged;
         */

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
            var cell = this.table[rowIndex, columnIndex];

            if (cell != null)
            {
                return cell;
            }

            cell = Cell.CreateInstance(rowIndex, columnIndex);
            this.table[rowIndex, columnIndex] = cell;

            return cell;
        }

        /// <summary>
        ///     Sets the content of a cell of given coordinates.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        /// <param name="expression">the text content of the cell.</param>
        internal void SetCell(int rowIndex, int columnIndex, string expression)
        {
            var cell = this.GetCell(rowIndex, columnIndex);

            string content = expression[0] == '='
                ? this.Evaluate(expression[1..])
                : expression;

            cell.SetValue(content);
            this.OnPropertyChanged();
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
             * Supports:
             *  - Pulling the value from another cell. The remaining part after '='
             *    is name of the cell to pull value from.
             *  [DONE] Supports arithmetic operations. Implements the logic for the Expression Tree.
             */
            var tree = new ExpressionTree(expression);
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