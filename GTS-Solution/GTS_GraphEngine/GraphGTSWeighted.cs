using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class GraphGTSWeighted<Type> : AbstractGraphGTS<Type>
    {
        /// <summary>
        /// adds a edge of a loop onto the vertex.
        /// </summary>
        /// <param name="vertexID"> verted ID of loop. </param>
        /// <param name="isDirected"> true makes a directed edge. </param>
        /// <returns> edge ID created. </returns>
        /// <exception cref="Exception"> if trying to add an edge to a vertex that doesn't exist. </exception>
        public override int AddLoop(int vertexID, bool isDirected, int weight = 1)
        {
            if (!this.DoesVertexExist(vertexID)) { throw new Exception($"Vertex (vertexID: {vertexID}) Does Not Exist"); }

            int edgeID = this.GetNewEdgeID();

            EdgeGTS<Type> edge = new EdgeGTS<Type>(edgeID, vertexes[vertexID], vertexes[vertexID], isDirected, weight);
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
        public override int AddEdge(int vertexID_A, int vertexID_B, bool isDirected, int weight = 1)
        {
            if (!this.DoesVertexExist(vertexID_A)) { throw new Exception($"Vertex (vertexID: {vertexID_A}) Does Not Exist"); }
            if (!this.DoesVertexExist(vertexID_B)) { throw new Exception($"Vertex (vertexID: {vertexID_B}) Does Not Exist"); }

            int edgeID = this.GetNewEdgeID();

            EdgeGTS<Type> edge = new EdgeGTS<Type>(edgeID, vertexes[vertexID_A], vertexes[vertexID_B], isDirected, weight);
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

        /// <summary>
        /// (TheVertex, fromVertex, weightDistance)
        /// </summary>
        /// <returns> shortest path information. </returns>
        public Dictionary<VertexGTS<Type>, (VertexGTS<Type>?, float)> GetShortestPaths(int vertexID)
        {
            Dictionary<VertexGTS<Type>, (VertexGTS<Type>?, float)> shortestPaths = new();

            shortestPaths.Add(vertexes[vertexID], (vertexes[vertexID], 0));

            foreach (VertexGTS<Type> vertex in this.vertexes.Values)
            {
                if(vertex.VertexID != vertexID)
                { 
                    shortestPaths.Add(vertex, (null, float.PositiveInfinity));
                }
            }

            Stack<VertexGTS<Type>> visited = new Stack<VertexGTS<Type>>();
            List<VertexGTS<Type>> visit = new List<VertexGTS<Type>>();

            visit.Add(this.vertexes[vertexID]);

            while (visit.Count != 0)
            {
                int vertexIDInVisit = 0;
                float smallestWeightDistance = float.PositiveInfinity;
                foreach(VertexGTS<Type> vertex in visit)
                {
                    if (shortestPaths[vertex].Item2 < smallestWeightDistance)
                    {
                        vertexIDInVisit = vertex.VertexID;
                        smallestWeightDistance = shortestPaths[vertex].Item2;
                    }
                }
                VertexGTS<Type> vertexVisiting = this.vertexes[vertexIDInVisit];
                visit.Remove(this.vertexes[vertexIDInVisit]);


                foreach (EdgeGTS<Type> edge in vertexVisiting.NeighborsOut.Keys)
                {
                    if (edge.VertexFrom != vertexVisiting || edge.VertexTo != vertexVisiting) // loop dont check
                    {
                        if (edge.VertexFrom == vertexVisiting)
                        {
                            if (!visited.Contains(edge.VertexTo))
                            {

                                if (vertexVisiting.VertexID == vertexID)
                                {
                                    shortestPaths[edge.VertexTo] = (vertexVisiting, edge.Weight);
                                }
                                else
                                {
                                    if(shortestPaths[vertexVisiting].Item2 + edge.Weight < shortestPaths[edge.VertexTo].Item2)
                                    {
                                        shortestPaths[edge.VertexTo] = (vertexVisiting, shortestPaths[vertexVisiting].Item2 + edge.Weight);
                                    }
                                }

                                visit.Add(edge.VertexTo);
                            }
                        }
                        else
                        {
                            if (vertexVisiting.VertexID == vertexID)
                            {
                                shortestPaths[edge.VertexFrom] = (vertexVisiting, edge.Weight);
                            }
                            else
                            {
                                if (shortestPaths[vertexVisiting].Item2 + edge.Weight < shortestPaths[edge.VertexFrom].Item2)
                                {
                                    shortestPaths[edge.VertexFrom] = (vertexVisiting, shortestPaths[vertexVisiting].Item2 + edge.Weight);
                                }
                            }

                            if (!visited.Contains(edge.VertexFrom))
                            {
                                visit.Add(edge.VertexFrom);
                            }
                        }
                    }
                }

                visited.Push(vertexVisiting);
                visit.Remove(vertexVisiting);
            }

            return shortestPaths;
        }
    }
}
