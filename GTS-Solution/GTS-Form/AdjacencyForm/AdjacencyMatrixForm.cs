using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTS_Form
{
    public partial class AdjacencyMatrix : Form
    {
        public AdjacencyMatrix((List<int>, List<List<int>>) adjInformation)
        {
            InitializeComponent();

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            int i = 0;
            foreach(int vertexID in adjInformation.Item1)
            {
                this.dataGridView1.Columns.Add($"V{i}", $"V{i}");

                i++;
            }

            i = 0;
            foreach(List<int> adjList in adjInformation.Item2)
            {
                this.dataGridView1.Rows.Add();

                this.dataGridView1.Rows[i].HeaderCell.Value = $"V{i}";

                for (int j = 0; j < adjList.Count; j++)
                {
                    this.dataGridView1.Rows[i].Cells[j].Value = adjList[j];
                }

                i++;
            }
        }
    }
}
