// <copyright file="Sheet.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadSheetEngine.Components;

/// <summary>
/// The data source controller for the 2D array of cells.
/// </summary>
internal class Sheet
{
    /*
     * TODO: IMPLEMENT THE EVENT HANDLER LOGIC.
     */

    private Cell[,] table;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sheet"/> class.
    /// </summary>
    /// <param name="numRows">the number of rows in this sheet.</param>
    /// <param name="numColumns">the number of columns in this sheet.</param>
    public Sheet(int numRows, int numColumns)
    {
        this.table = new Cell[numRows, numColumns];

        // Iterates and instantiates all cells in the sheet.
        /*
        for (int r = 0; r < numRows; r++)
        {
            for (int c = 0; c < numColumns; c++)
            {
                this.table[r, c] = new Cell(r, c);
            }
        }
        */

        /*
         * Might not need to instantiate all cells at construction. I can do that for first input, as in
         * doing this whenever a cell is focused, then check if that cell is null. If it is null then
         * create a new cell and assign new text to it.
         */
    }

    /// <summary>
    /// This Event Handler allows the outside world (the GUI) to subscribe and listen for any property changes in any cells.
    /// </summary>
    public event EventHandler CellPropertyChanged = (sender, e) => { };
    /*
        TODO: Flesh and desgin a scheme for this Event Handler.
     */

    /// <summary>
    /// Gets the row count of the sheet.
    /// </summary>
    public int RowCount => this.table.GetLength(0);

    /// <summary>
    /// Gets the column count of the sheet.
    /// </summary>
    public int ColumnCount => this.table.GetLength(1);

    /// <summary>
    /// Returns the reference to the cell at the given coordinates.
    /// </summary>
    /// <param name="rowIndex">the row index of the cell.</param>
    /// <param name="columnIndex">the column index of the cell.</param>
    /// <returns>the cell if found.</returns>
    public Cell? GetCell(int rowIndex, int columnIndex)
    {
        return this.table[rowIndex, columnIndex] ?? null;
    }

    /// <summary>
    /// Sets the content of a cell of given coordinates.
    /// </summary>
    /// <param name="rowIndex">the cell's row index.</param>
    /// <param name="columnIndex">the cell's column index.</param>
    /// <param name="text">the text content of the cell.</param>
    public void SetCell(int rowIndex, int columnIndex, string text)
    {
        if (this.table[rowIndex, columnIndex] is null)
        {
            this.table[rowIndex, columnIndex] = new Cell(rowIndex, columnIndex);
        }

        Cell cell = this.GetCell(rowIndex, columnIndex) !;

        /*
         * TODO: IMPLEMENT FUNCTION TO SET CONTENT OF CELL.
         * Make cell.Value a getter only, and add logic to the getter of cell.Text.
         * This way, there is no need to have a backing field for Value.
         */
        cell.SetValue(text);
    }
}
