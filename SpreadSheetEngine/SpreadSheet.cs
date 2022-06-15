// <copyright file="SpreadSheet.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadSheetEngine.Components;

    /// <summary>
    /// The data source controller for the 2D array of cells.
    /// </summary>
    internal class SpreadSheet
    {
        private Cell[,] sheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadSheet"/> class.
        /// </summary>
        /// <param name="numRows">the number of rows in this sheet.</param>
        /// <param name="numColumns">the number of columns in this sheet.</param>
        public SpreadSheet(int numRows, int numColumns)
        {
            this.sheet = new Cell[numRows, numColumns];

            // Iterates and instantiates all cells in the sheet.
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    this.sheet[i, j] = new Cell(i, j);
                }
            }
        }

        /// <summary>
        /// This Event Handler allows the outside world (the GUI) to subscribe and listen for any property changes in any cells.
        /// </summary>
        public event EventHandler CellPropertyChanged = (sender, e) => { };
        /*
            TODO: Flesh and desgin a scheme for this Event Handler.
         */
    }
}
