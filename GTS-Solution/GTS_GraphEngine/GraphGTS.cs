﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class GraphGTS : AbstractGraphGTS
    {
        /// <summary>
        /// adds a edge of a loop onto the vertex.
        /// </summary>
        /// <param name="vertexID"> verted ID of loop. </param>
        /// <param name="isDirected"> true makes a directed edge. </param>
        /// <returns> edge ID created. </returns>
        /// <exception cref="Exception"> if trying to add an edge to a vertex that doesn't exist. </exception>
        public int AddLoop(int vertexID, bool isDirected) 
        {
            if (!this.DoesVertexExist(vertexID)) { throw new Exception($"Vertex (vertexID: {vertexID}) Does Not Exist"); }

            int edgeID = this.GetNewEdgeID();

            EdgeGTS edge = new EdgeGTS(vertexes[vertexID], vertexes[vertexID], isDirected, weight: 1);
            this.edges.Add(edgeID, edge);

            vertexes[vertexID].AddNeighborEdgeIn(edge, vertexes[vertexID]);
            vertexes[vertexID].AddNeighborEdgeOut(edge, vertexes[vertexID]);

            return edgeID;
        }

        /// <summary>
        /// edge added to two vertices in a graph.
        ///     directed edge means it goes out from A and goes in to B.
        /// </summary>
        /// <param name="vertexID_A"></param>
        /// <param name="vertexID_B"></param>
        /// <param name="isDirected"> true makes a directed edge. </param>
        /// <returns> edge ID created. </returns>
        /// <exception cref="Exception"> if trying to add an edge to a vertex that doesn't exist. </exception>
        public int AddEdge(int vertexID_A, int vertexID_B, bool isDirected)
        {
            if (!this.DoesVertexExist(vertexID_A)) { throw new Exception($"Vertex (vertexID: {vertexID_A}) Does Not Exist"); }
            if (!this.DoesVertexExist(vertexID_B)) { throw new Exception($"Vertex (vertexID: {vertexID_B}) Does Not Exist"); }

            int edgeID = this.GetNewEdgeID();

            EdgeGTS edge = new EdgeGTS(vertexes[vertexID_A], vertexes[vertexID_B], isDirected, weight: 1);
            this.edges.Add(edgeID, edge);

            if (isDirected) 
            {
                vertexes[vertexID_A].AddNeighborEdgeOut(edge, vertexes[vertexID_B]);
                vertexes[vertexID_B].AddNeighborEdgeIn(edge, vertexes[vertexID_A]);
            }
            else
            {
                vertexes[vertexID_A].AddNeighborEdgeOut(edge, vertexes[vertexID_B]);
                vertexes[vertexID_B].AddNeighborEdgeIn(edge, vertexes[vertexID_A]);

                vertexes[vertexID_A].AddNeighborEdgeIn(edge, vertexes[vertexID_B]);
                vertexes[vertexID_B].AddNeighborEdgeOut(edge, vertexes[vertexID_A]);
            }

            return edgeID;
        }

    }
}
