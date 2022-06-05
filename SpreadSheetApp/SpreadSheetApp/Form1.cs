// <copyright file="Form1.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp
{
    using SpreadSheetApp.Form1_Properties;
    using SpreadSheetEngine;

    /// <summary>
    /// Controls the display of the data grid cells.
    /// </summary>
    public partial class Form1 : Form
    {
        private DataGridSource[,] dataGridSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.Initialize_AppState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Initializes the app startup state. Cell[0,0] contains string 'Hello'.
        /// </summary>
        private void Initialize_AppState()
        {
            var col = new DataGridViewTextBoxColumn();
            col.HeaderText = 'A'.ToString();
            this.dataGridView1.Columns.Add(col);
            var row = new DataGridViewRow();
            row.HeaderCell.Value = 0.ToString();
            this.dataGridView1.Rows.Add(row);

            this.dataGridView1.DataSource = this.dataGridSource;
            /*
                Thanks to the existence of the Text property in the DataGridSource class, dataGridView1 can get and display
                the content of DataSource.Text directly.

                This is a nice abstraction provided by Microsoft. This means that I do not have to worry about event handling
                at the shell. I just need to take care of the stage at the source, i.e. checking and evaluating the new text
                expression.
             */

            var cell = this.dataGridView1[0, 0];
            cell.Value = "Hello";
        }
    }
}
