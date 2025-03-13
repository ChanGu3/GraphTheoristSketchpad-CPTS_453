using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class EdgeGTS
    {
        private int edgeID;

        private int weight;
        private bool isDirected;

        private VertexGTS vertexFrom;
        private VertexGTS vertexTo;

        /// <summary>
        /// When not directed From and To act as just point A and point B since edge goes both ways. 
        /// </summary>
        /// <param name="vertexFrom"> when directed this is where the arrow comes from. </param>
        /// <param name="vertexTo"> when directed this is where the arrow goes to. </param>
        /// <param name="isDirected"> directed edge or not. </param>
        /// <param name="weight"> wieght of edge. </param>
        public EdgeGTS(VertexGTS vertexFrom, VertexGTS vertexTo, bool isDirected, int weight = 1)
        {
            this.isDirected = isDirected;
            this.vertexFrom = vertexFrom;
            this.vertexTo = vertexTo;
            this.weight = weight;
        }

        public int Weight
        {
            get => weight;
        }
        public bool IsDirected
        {
            get => isDirected;
        }
        public VertexGTS VertexFrom
        {
            get => vertexFrom;
        }
        public VertexGTS VertexTo
        {
            get => vertexTo;
        }
    }
}
