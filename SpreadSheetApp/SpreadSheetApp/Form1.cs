// <copyright file="Form1.cs" company="Charles Nguyen -- 011606177">
// Copyright (c) Charles Nguyen -- 011606177. All rights reserved.
// </copyright>

namespace SpreadSheetApp
{
    using System.ComponentModel;
    using SpreadSheetApp.Form1_Properties;
    using SpreadSheetEngine;

    /// <summary>
    /// Controls the display of the data grid cells.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly Cell[,] cellTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.cellTable = new Cell[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    this.cellTable[i, j] = new Cell();
                }
            }

            /*
             * I NEED TO CONSTRUCT EACH CELL IN THE ARRAY.
             */

            this.InitializeComponent();
            this.Initialize_AppState();

            // this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.DataGridView1_CellClick !);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.DataGridView1_CellEdited !);

            // var dataCell = this.cellTable[0, 0];
            // dataCell.Text = "Hello";

            // dataCell.PropertyChanged += this.DataCell_PropertyChanged(dataCell, new PropertyChangedEventArgs("Name"));
        }

        // private PropertyChangedEventHandler DataCell_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        // {
        //    // throw new NotImplementedException();
        //    return (sender1, e1) => { };
        // }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Initializes the app startup state. Cell[0,0] contains string 'Hello'.
        /// </summary>
        private void Initialize_AppState()
        {
            var colA = new DataGridViewTextBoxColumn
            {
                HeaderText = 'A'.ToString(),
            };
            this.dataGridView1.Columns.Add(colA);

            var colB = new DataGridViewTextBoxColumn
            {
                HeaderText = 'B'.ToString(),
            };
            this.dataGridView1.Columns.Add(colB);

            var row = new DataGridViewRow();
            row.HeaderCell.Value = 0.ToString();
            this.dataGridView1.Rows.Add(row);

            var row2 = new DataGridViewRow();
            row2.HeaderCell.Value = 1.ToString();
            this.dataGridView1.Rows.Add(row2);

            var cell = this.dataGridView1[0, 0];
            cell.Value = this.cellTable[0, 0].Text;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.dataGridView1.CurrentCell.Selected = true;
            this.dataGridView1.CurrentCell.Value = this.dataGridView1[0, 0].Value;

            // MessageBox.Show(this.dataGridView1.CurrentCell.ToString());
        }

        private void DataGridView1_CellEdited(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.dataGridView1.CurrentCell;
            int rowIndex = cell.RowIndex;
            int colIndex = cell.ColumnIndex;

            this.cellTable[rowIndex, colIndex].Text = cell.Value.ToString() !;

            var targetCell = this.dataGridView1[0, 0];
            targetCell.Value = $"{this.cellTable[rowIndex, colIndex].Text} from [{this.dataGridView1.CurrentRow.HeaderCell.Value}, {this.dataGridView1.Columns[colIndex].HeaderText}]";
        }
    }
}
