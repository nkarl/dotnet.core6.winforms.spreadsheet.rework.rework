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
        private Cell[,] cellTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.cellTable = new Cell[2, 2];

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
            var colA = new DataGridViewTextBoxColumn();
            colA.HeaderText = 'A'.ToString();
            this.dataGridView1.Columns.Add(colA);

            var colB = new DataGridViewTextBoxColumn();
            colB.HeaderText = 'B'.ToString();
            this.dataGridView1.Columns.Add(colB);

            var row = new DataGridViewRow();
            row.HeaderCell.Value = 0.ToString();
            this.dataGridView1.Rows.Add(row);

            var row2 = new DataGridViewRow();
            row2.HeaderCell.Value = 1.ToString();
            this.dataGridView1.Rows.Add(row2);

            var cell = this.dataGridView1[0, 0];
            cell.Value = "Hello";
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellMouseEventArgs e)
        {
            //this.dataGridView1.CurrentCell.Selected = true;
            this.dataGridView1.CurrentCell.Value = this.dataGridView1[0, 0].Value;
            //MessageBox.Show(this.dataGridView1.CurrentCell.ToString());
        }
    }
}
