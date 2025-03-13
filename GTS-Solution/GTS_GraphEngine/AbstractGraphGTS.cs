using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class AbstractGraphGTS
    {
        /// int = ID of vertex
        /// VertexGTS<Type> = The Vertex
        protected Dictionary<int, VertexGTS> vertexes = new();
        private int vertexIDCount = 0;
        private Stack<int> vertexIDSRemoved = new Stack<int>();

        /// string = Edge Name
        /// EdgeGTS<Type> = The Edge
        protected Dictionary<int, EdgeGTS> edges = new();
        private int edgeIDCount = 0;
        private Stack<int> edgeIDSRemoved = new Stack<int>();

        /// <summary>
        /// add a vertex to the graph with a type.
        /// </summary>
        public int AddVertex()
        {
            int vertexID = GetNewVertexID();

            vertexes.Add(vertexID, new VertexGTS(vertexID));

            return vertexID;
        }

        /// <summary>
        /// try to remove node.
        /// </summary>
        /// <param name="vertexID"> ID of vertex you want to remove. </param>
        /// <returns> true if vertex removed false if not. </returns>
        public bool TryRemoveVertex(int vertexID)
        {
            bool vertexExists = this.vertexes.Remove(vertexID, out VertexGTS? removedNode);

            if (vertexExists) { this.vertexIDSRemoved.Push(vertexID); }

            return vertexExists;
        }

        public void RemoveLoop(int edgeID)
        {
            if (!this.DoesEdgeExist(edgeID)) { throw new Exception($"Edge (edgeID: {edgeID}) Does Not Exist"); }

            if (this.edges[edgeID].VertexFrom != this.edges[edgeID].VertexTo) { throw new Exception($"Edge (edgeID: {edgeID}) Is Not A Loop, use edge removal"); }

            this.edges[edgeID].VertexTo.RemoveNeighborEdgeIn(this.edges[edgeID]);
            this.edges[edgeID].VertexFrom.RemoveNeighborEdgeOut(this.edges[edgeID]);

            this.edges.Remove(edgeID);
            this.edgeIDSRemoved.Push(edgeID);
        }

        public void RemoveEdge(int edgeID)
        {
            if (!this.DoesEdgeExist(edgeID)) { throw new Exception($"Vertex (vertexID: {edgeID}) Does Not Exist"); }

            if (this.edges[edgeID].VertexFrom == this.edges[edgeID].VertexTo) { throw new Exception($"Edge (edgeID: {edgeID}) Is A Loop, use loop removal"); }

            if (this.edges[edgeID].IsDirected)
            {
                this.edges[edgeID].VertexFrom.RemoveNeighborEdgeOut(this.edges[edgeID]);
                this.edges[edgeID].VertexTo.RemoveNeighborEdgeIn(this.edges[edgeID]);

            }
            else
            {
                this.edges[edgeID].VertexFrom.RemoveNeighborEdgeOut(this.edges[edgeID]);
                this.edges[edgeID].VertexTo.RemoveNeighborEdgeIn(this.edges[edgeID]);

                this.edges[edgeID].VertexFrom.RemoveNeighborEdgeIn(this.edges[edgeID]);
                this.edges[edgeID].VertexTo.RemoveNeighborEdgeOut(this.edges[edgeID]);
            }

            this.edges.Remove(edgeID);
            this.edgeIDSRemoved.Push(edgeID);
        }

        protected int GetNewVertexID()
        {
            if (vertexIDSRemoved.Count != 0) { return vertexIDSRemoved.Pop(); }
            else { return vertexIDCount++; }
        }

        protected int GetNewEdgeID()
        {
            if (edgeIDSRemoved.Count != 0) { return edgeIDSRemoved.Pop(); }
            else { return edgeIDCount++; }
        }

        protected bool DoesVertexExist(int vertexID)
        {
            return vertexes.TryGetValue(vertexID ,out _);
        }

        protected bool DoesEdgeExist(int edgeID)
        {
            return edges.TryGetValue(edgeID, out _);
        }
    }
}
