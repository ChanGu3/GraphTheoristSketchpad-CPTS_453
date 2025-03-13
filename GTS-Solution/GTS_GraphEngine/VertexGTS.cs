using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class VertexGTS
    {
        private int vertexID;

        /// <summary>
        /// all vertexes pointing towards this vertex with the corresponding edge.
        /// </summary>
        /// string = Edge Name
        /// Type = Vertex Name
        private Dictionary<EdgeGTS, VertexGTS> neighborsIn = new();

        /// <summary>
        /// all vertexes this vertex is pointing to with the corresponding edge.
        /// </summary>
        /// string = Edge Name
        /// Type = Vertex Name
        private Dictionary<EdgeGTS, VertexGTS> neighborsOut = new();

        public VertexGTS(int vertexID) 
        { 
            this.vertexID = vertexID;
        }

        public int VertexID
        {
            get => vertexID;
        }

        public Dictionary<EdgeGTS, VertexGTS> NeighborsIn
        {
            get => neighborsIn;
        }

        public Dictionary<EdgeGTS, VertexGTS> NeighborsOut
        {
            get => neighborsOut;
        }

        public void AddNeighborEdgeIn(EdgeGTS edge, VertexGTS vertexFrom)
        {
            neighborsIn.Add(edge, vertexFrom);
        }

        public void AddNeighborEdgeOut(EdgeGTS edge, VertexGTS vertexTo)
        {
            neighborsOut.Add(edge, vertexTo);
        }

        public void RemoveNeighborEdgeIn(EdgeGTS edge) 
        {
            neighborsIn.Remove(edge);
        }

        public void RemoveNeighborEdgeOut(EdgeGTS edge)
        {
            neighborsOut.Remove(edge);
        }
    }
}
