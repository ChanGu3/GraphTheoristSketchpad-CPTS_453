using GTS_Controls;
using GTS_GraphEngine;
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
    public partial class ShortestPath: Form
    {
        public ShortestPath(Dictionary<VertexGTS<VertexUserControl>, (VertexGTS<VertexUserControl>?, float)> shortestInformation, string vertexNameFrom)
        {
            InitializeComponent();

            this.Text = $"Shortest Path From {vertexNameFrom}";

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            this.dataGridView1.Columns.Add("Last Vertex", "Last Vertex");
            this.dataGridView1.Columns.Add("Shortest Distance", "Shortest Distance");

            int i = 0;
            foreach((VertexGTS<VertexUserControl>?, float) shortest in shortestInformation.Values)
            {
                this.dataGridView1.Rows.Add();

                this.dataGridView1.Rows[i].HeaderCell.Value = $"V{i}";

                int j = 0;
                foreach (VertexGTS<VertexUserControl> vertex in shortestInformation.Keys)
                {
                    if (shortest.Item1 is null)
                    {
                        this.dataGridView1.Rows[i].Cells[0].Value = "N/A";
                        break;
                    }

                    if (vertex?.VertexID == shortest.Item1?.VertexID)
                    {
                        this.dataGridView1.Rows[i].Cells[0].Value = $"V{j}";
                        break;
                    }

                    j++;
                }
                this.dataGridView1.Rows[i].Cells[1].Value = shortest.Item2.ToString();

                i++;
            }
        }
    }
}
