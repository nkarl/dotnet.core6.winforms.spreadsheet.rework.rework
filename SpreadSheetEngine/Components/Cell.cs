// <copyright file="Cell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SpreadSheetEngine.Abstract;

    /// <summary>
    /// Implements the abstract base class BaseCell.
    /// </summary>
    internal class Cell : BaseCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIndex">the cell's row coordinate.</param>
        /// <param name="columnIndex">the cell's column coordinate.</param>
        public Cell(int rowIndex, int columnIndex)
            : base(rowIndex, columnIndex)
        {
        }
    }
}
