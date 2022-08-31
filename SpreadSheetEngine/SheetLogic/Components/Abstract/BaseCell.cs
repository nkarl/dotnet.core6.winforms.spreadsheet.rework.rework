// <copyright file="BaseCell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.SheetLogic.Components.Abstract
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     The abstract base class for a single cell.
    /// </summary>
    public abstract class BaseCell : INotifyPropertyChanged
    {
        private string text = string.Empty;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseCell" /> class.
        /// </summary>
        /// <param name="rowIndex">the cell's row index.</param>
        /// <param name="columnIndex">the cell's column index.</param>
        protected BaseCell(int rowIndex, int columnIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        ///     Gets the row index of the cell.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        ///     Gets the column index of the cell.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        ///     Gets or sets the text of the cell.
        /// </summary>
        public string Text
        {
            get => this.text;

            set
            {
                if (value == this.text)
                {
                    return;
                }

                this.text = value;
                this.NotifyOnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the value of the cell.
        /// </summary>
        internal string Value { get; private set; } = string.Empty;

        /// <summary>
        ///     Evaluates and sets the Text property of this cell. Not accessible to the outside world.
        /// </summary>
        /// <param name="expression">the new string text to be evaluated.</param>
        protected void SetValue(string expression) // either protected or internal
        {
            // If the expression starts with '=', evaluates it. Otherwise, it is just the Text content.
            this.Value = expression;
            this.Text = this.Value;
        }

        /// <summary>
        ///     Should be raised the event whenever a property is changed.
        /// </summary>
        /// <param name="name">the name of caller method.</param>
        private void NotifyOnPropertyChanged([CallerMemberName] string? name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}