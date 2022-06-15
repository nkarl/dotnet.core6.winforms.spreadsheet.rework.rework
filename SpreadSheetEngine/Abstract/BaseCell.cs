// <copyright file="BaseCell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.Abstract
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The abstract base classs for a single cell.
    /// </summary>
    public abstract class BaseCell : INotifyPropertyChanged
    {
        private readonly int rowIndex;
        private readonly int columnIndex;
        private string text = string.Empty;
        private string value = string.Empty;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCell"/> class.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        public BaseCell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }


        /// <summary>
        /// Gets the row index of the cell.
        /// </summary>
        public int RowIndex => this.rowIndex;

        /// <summary>
        /// Gets the column index of the cell.
        /// </summary>
        public int ColumnIndex => this.columnIndex;

        /// <summary>
        /// Gets or sets the text of the cell.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the value of the cell.
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}