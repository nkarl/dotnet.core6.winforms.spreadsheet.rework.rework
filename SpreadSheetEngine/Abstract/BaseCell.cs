// <copyright file="BaseCell.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine.Abstract;

using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// The abstract base class for a single cell.
/// </summary>
internal abstract class BaseCell : INotifyPropertyChanged
{
    private string text = string.Empty;
    private string value = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCell"/> class.
    /// </summary>
    /// <param name="rowIndex">the cell's row index.</param>
    /// <param name="columnIndex">the cell's column index.</param>
    protected BaseCell(int rowIndex, int columnIndex)
    {
        this.RowIndex = rowIndex;
        this.ColumnIndex = columnIndex;
    }

    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Gets the row index of the cell.
    /// </summary>
    public int RowIndex { get; }

    /// <summary>
    /// Gets the column index of the cell.
    /// </summary>
    public int ColumnIndex { get; }

    /// <summary>
    /// Gets or sets the text of the cell.
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
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the value of the cell.
    /// </summary>
    public string Value => this.value;

    /// <summary>
    /// Evaluates and sets the Text property of this cell. Not accessible to the outside world.
    /// </summary>
    /// <param name="text">the new string text to be evaluated.</param>
    internal void SetValue(string text) // either protected or internal
    {
        var expBody = this.text;
        if (expBody[0] != '=')
        {
            this.value = expBody;
        }
        else
        {
            /*
                TODO: Implement the evaluating function for expressions that starts with '='.
             */
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}