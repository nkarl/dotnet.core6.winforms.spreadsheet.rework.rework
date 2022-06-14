// <copyright file="DataGridSource.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetEngine
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The source data for DataGrid.
    /// </summary>
    public class Cell : INotifyPropertyChanged
    {
        private string text = string.Empty;
        private string value = string.Empty;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets or sets the text content of the cell.
        /// </summary>
        public string Text
        {
            get => this.text;
            set
            {
                if (this.text == value || value == null)
                {
                    return;
                }
                else
                {
                    this.text = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the evaluated content of the cell.
        /// </summary>
        public string Value
        {
            get => this.value;
            set
            {
                string? newExpression = value;
                if (newExpression is null)
                {
                    return;
                }
                else
                {
                    if (newExpression[0] != '=')
                    {
                        this.text = newExpression;
                    }
                    else
                    {
                        /*
                            TODO: code to evaluate the expression.
                         */
                    }

                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Notifies the handler PropertyChanged.
        /// </summary>
        /// <param name="name">name of the caller.</param>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            Console.WriteLine($"This is the name of the caller: {name}.");
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(this.Text));
        }
    }
}