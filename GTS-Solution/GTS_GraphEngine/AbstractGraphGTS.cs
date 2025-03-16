using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GTS_GraphEngine
{
    public abstract class AbstractGraphGTS<Type>
    {
        /// int = ID of vertex
        /// VertexGTS<Type> = The Vertex
        protected Dictionary<int, VertexGTS<Type>> vertexes = new();
        private int vertexIDCount = 0;
        private Stack<int> vertexIDSRemoved = new Stack<int>();

        /// string = Edge Name
        /// EdgeGTS<Type> = The Edge
        protected Dictionary<int, EdgeGTS<Type>> edges = new();
        private int edgeIDCount = 0;
        private Stack<int> edgeIDSRemoved = new Stack<int>();

        public Dictionary<int, EdgeGTS<Type>> Edges
        {
            get => edges;
        }

        public Dictionary<int, VertexGTS<Type>> Vertexes
        {
            get => vertexes;
        }

        public int ComponentCount
        {
            get => GetComponentCount();
        }

        /// <summary>
        /// add a vertex to the graph with a type.
        /// </summary>
        public int AddVertex(Type data = default!)
        {
            int vertexID = GetNewVertexID();

            vertexes.Add(vertexID, new VertexGTS<Type>(vertexID, data));

            return vertexID;
        }

        /// <summary>
        /// try to remove node.
        /// </summary>
        /// <param name="vertexID"> ID of vertex you want to remove. </param>
        /// <returns> true if vertex removed false if not. </returns>
        public bool TryRemoveVertex(int vertexID)
        {
            bool vertexExists = this.vertexes.ContainsKey(vertexID);

            if (vertexExists) 
            {
                // remove all edges its connected to
                foreach (EdgeGTS<Type> edge in this.vertexes[vertexID].Edges)
                {
                    if (edge.VertexFrom == edge.VertexTo)
                    {
                        RemoveLoop(edge.EdgeID);
                    }
                    else
                    {
                        RemoveEdge(edge.EdgeID);
                    }
                }

                this.vertexes.Remove(vertexID);
                this.vertexIDSRemoved.Push(vertexID); 
            }

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

        public int EdgeCountBetweenVertices(int vertexA, int vertexB)
        {
            return EdgesBetweenVertices(vertexA, vertexB).Count();
        }

        public IEnumerable<EdgeGTS<Type>> EdgesBetweenVertices(int vertexA, int vertexB)
        {
            IEnumerable<EdgeGTS<Type>> vertexAOutToB = this.vertexes[vertexA].NeighborsOut.Keys.Intersect(this.vertexes[vertexB].NeighborsIn.Keys);
            IEnumerable<EdgeGTS<Type>> vertexBOutToA = this.vertexes[vertexB].NeighborsOut.Keys.Intersect(this.vertexes[vertexA].NeighborsIn.Keys);

            HashSet<EdgeGTS<Type>> values = new();
            foreach (EdgeGTS<Type> edge in vertexAOutToB.Union(vertexBOutToA))
            {
                values.Add(edge);
            }

            return values.AsEnumerable().ToList();
        }

        public int EdgeCountLoopVertex(int vertexID)
        {
            return this.vertexes[vertexID].NeighborsOut.Keys.Where((edge) => edge.VertexFrom.VertexID == edge.VertexTo.VertexID).Count();
        }

        public IEnumerable<EdgeGTS<Type>> EdgesInLoopVertex(int vertexID)
        {
            return this.vertexes[vertexID].NeighborsOut.Keys.Where((edge) => edge.VertexFrom.VertexID == edge.VertexTo.VertexID);
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

        private int GetComponentCount()
        {
            Dictionary<int, VertexGTS<Type>> vertexGTs = new Dictionary<int, VertexGTS<Type>>(this.vertexes);
            
            Stack<VertexGTS<Type>> visited = new Stack<VertexGTS<Type>>();
            List<VertexGTS<Type>> visit = new List<VertexGTS<Type>>();

            int componenet = 0;

            while (vertexGTs.Count != 0 || visit.Count != 0)
            {
                // find a weak component
                if (visit.Count == 0)
                {
                    visit.Add(vertexGTs[vertexGTs.Keys.First()]);
                    componenet++;
                }

                VertexGTS<Type> vertexVisiting = visit[0];
                visit.RemoveAt(0);

                // Get all neighbors regardless of direction
                HashSet<EdgeGTS<Type>> values = new();
                foreach (EdgeGTS<Type> edge in this.vertexes[vertexVisiting.VertexID].NeighborsOut.Keys.Union(this.vertexes[vertexVisiting.VertexID].NeighborsIn.Keys))
                {
                    values.Add(edge);
                }

                // add all vertexes not visited and not in visit 
                foreach (EdgeGTS<Type> edge in values.AsEnumerable())
                {
                    if (edge.VertexFrom != vertexVisiting || edge.VertexTo != vertexVisiting) // loop dont check
                    {
                        if (edge.VertexFrom == vertexVisiting)
                        {
                            if (!visited.Contains(edge.VertexTo))
                            {
                                visit.Add(edge.VertexTo);
                            }
                        }
                        else
                        {
                            if (!visited.Contains(edge.VertexFrom))
                            {
                                visit.Add(edge.VertexFrom);
                            }

                        }
                    }
                }

                visited.Push(vertexVisiting);
                visit.Remove(vertexVisiting);
                vertexGTs.Remove(vertexVisiting.VertexID);
            }

            return componenet;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns> A list of edges of bridges in the graph </returns>
        public List<EdgeGTS<Type>> GetBridgesTarjan()
        {
            List<EdgeGTS<Type>> bridges = new List<EdgeGTS<Type>>();

            int time = 0;
            List<VertexGTS<Type>> visited = new List<VertexGTS<Type>>();
            Dictionary<VertexGTS<Type>, int> disc = new Dictionary<VertexGTS<Type>, int>();
            Dictionary<VertexGTS<Type>, int> low = new Dictionary<VertexGTS<Type>, int>();
            Dictionary<VertexGTS<Type>, VertexGTS<Type>> parent = new Dictionary<VertexGTS<Type>, VertexGTS<Type>>();

            foreach (VertexGTS<Type> vertex in this.vertexes.Values)
            {
                if(!visited.Contains(vertex))
                {
                    this.GetBridgesHelper(ref time, vertex, ref visited, ref disc, ref low, ref parent, ref bridges);
                }
            }


            return bridges;
        }

        private void GetBridgesHelper(ref int time, VertexGTS<Type> currentVertex, ref List<VertexGTS<Type>> visited, ref Dictionary<VertexGTS<Type>, int> disc, ref Dictionary<VertexGTS<Type>, int> low, ref  Dictionary<VertexGTS<Type>, VertexGTS<Type>> parent, ref List<EdgeGTS<Type>> bridges)
        {
            if (!visited.Contains(currentVertex))
            {
                visited.Add(currentVertex);
            }

            if(!disc.ContainsKey(currentVertex) && !low.ContainsKey(currentVertex))
            {
                disc.Add(currentVertex, time);
                low.Add(currentVertex, time);
            }
            else
            {
                disc[currentVertex] = time;
                low[currentVertex] = time;
            }
            time++;

            foreach(EdgeGTS<Type> edge in currentVertex.NeighborsOut.Keys)
            {
                if(edge.VertexFrom != edge.VertexTo)
                { 
                    // fixing edge with both directions
                    VertexGTS<Type> trueNeighbor;
                    if (edge.VertexTo == currentVertex)
                    {
                        trueNeighbor = edge.VertexFrom;
                    }
                    else
                    {
                        trueNeighbor = edge.VertexTo;
                    }

                    parent.TryGetValue(currentVertex, out VertexGTS<Type>? currentVertexParent);



                    if(!visited.Contains(trueNeighbor))
                    {
                        if (!parent.ContainsKey(currentVertex))
                        {
                            parent.Add(currentVertex, trueNeighbor);
                        }
                        else
                        {
                            parent[currentVertex] = trueNeighbor;
                        }

                        GetBridgesHelper(ref time, trueNeighbor, ref visited, ref disc, ref low, ref parent, ref bridges);

                        // update if recursion vertex was lower meaning SCC with more than one vertex has been detected otherwise low time stays the same
                        // for currentvertex
                        low[currentVertex] = Math.Min(low[currentVertex], low[trueNeighbor]);

                        // when the nieghbor previously updated vertex has a value lower or equal to the original time of the currentvertex
                        // this means its connected somehow and the current vertex low was updated as well lower or equal to its own time.
                        // if its greater that means the time wasn't updated meaning this vertex isn't part of the SCC of currentvertex.
                        if (low[trueNeighbor] > disc[currentVertex])
                        {
                            if(currentVertex.NeighborsOut.Keys.Where((key) => key.VertexTo == trueNeighbor).Count() == 1)
                            {
                                bridges.Add(edge);
                            }
                        }
                    }
                    else if(trueNeighbor != currentVertexParent) // When the neighbor checking is not previous recursion currentvertex and its been checked previously using parents must be part of the same SCC
                    {
                        low[currentVertex] = Math.Min(low[currentVertex], disc[trueNeighbor]);
                    }
                }
            }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <returns> A list of edges of bridges in the graph </returns>
        public List<EdgeGTS<Type>> GetBridges()
        {
            List<EdgeGTS<Type>> bridges = new();
            int originalComponentCount = this.GetComponentCount();
            
            foreach(EdgeGTS<Type> edge in this.edges.Values.ToList())
            { 
                if(edge.VertexFrom != edge.VertexTo && edge.IsDirected)
                {
                    int vertexA = edge.VertexFrom.VertexID;
                    int vertexB = edge.VertexTo.VertexID;
                    bool isDirected = edge.IsDirected;
                    int weight = edge.Weight;

                    this.RemoveEdge(edge.EdgeID);

                    if (originalComponentCount < this.GetComponentCount())
                    {
                        bridges.Add(edge);
                    }

                    this.AddEdge(vertexA, vertexB,isDirected, weight);
                }
            }

            return bridges;
        }

        /// <summary>
        /// using the left side of the matrix compares with every other column vertex to check for adjaceny
        /// </summary>
        /// <returns>
        /// bool = "true" when bipartite, "false" when not
        /// (List<VertexGTS<Type>>, List<VertexGTS<Type>>) = contains the vertexes that are in seperate partite sets, when false only the ones up to the same color connected.
        /// </returns>
        public (bool, (List<VertexGTS<Type>>, List<VertexGTS<Type>>)?) IsBipartite()
        {
            List<VertexGTS<Type>> partiteSet1 = new List<VertexGTS<Type>>();
            List<VertexGTS<Type>> partiteSet2 = new List<VertexGTS<Type>>();

            Dictionary<int, VertexGTS<Type>> vertexGTs = new Dictionary<int, VertexGTS<Type>>(this.vertexes);

            List<VertexGTS<Type>> visited = new List<VertexGTS<Type>>();
            List<VertexGTS<Type>> visit = new List<VertexGTS<Type>>();

            while (vertexGTs.Count != 0 || visit.Count != 0)
            {
                // if another component redo algorithm on that component
                if (visit.Count == 0)
                {
                    visit.Add(vertexGTs[vertexGTs.Keys.First()]);
                    partiteSet1.Add(vertexGTs[vertexGTs.Keys.First()]);
                }

                VertexGTS<Type> vertexVisiting = visit[0];
                visit.RemoveAt(0);

                // add all vertexes not visited and not in visit 
                foreach (EdgeGTS<Type> edge in this.vertexes[vertexVisiting.VertexID].NeighborsOut.Keys)
                {
                    
                    VertexGTS<Type> vertexTo;
                    
                    // When edge is not directed this means a vertex as VertexTo in edge is also a VertexFrom in the same edge object
                    // same with vertexFrom is also a vertexTo so we need to check the opposite if vertexVisiting is a vertexTo.
                    if (vertexVisiting == edge.VertexTo)
                    {
                        vertexTo = edge.VertexFrom;
                    }
                    else
                    {
                        vertexTo = edge.VertexTo;
                    }

                    if (!visited.Contains(vertexTo) && !visited.Contains(vertexTo))
                    {
                        visit.Add(vertexTo);
                        vertexGTs.Remove(vertexTo.VertexID);

                        if (partiteSet1.Contains(vertexVisiting))
                        {
                            if (!visited.Contains(vertexTo))
                            {
                                if(partiteSet1.Contains(vertexTo))
                                {
                                    return (false, (partiteSet1, partiteSet2));
                                }

                                partiteSet2.Add(vertexTo);
                            }

                            if (visited.Intersect(vertexTo.NeighborsOut.Values).Intersect(partiteSet2).Count() > 0)
                            {
                                return (false, (partiteSet1, partiteSet2));
                            }
                        }
                        else
                        {
                            if (!visited.Contains(vertexTo))
                            {
                                if (partiteSet2.Contains(vertexTo))
                                {
                                    return (false, (partiteSet1, partiteSet2));
                                }

                                partiteSet1.Add(vertexTo);
                            }

                            if (visited.Intersect(vertexTo.NeighborsOut.Values).Intersect(partiteSet1).Count() > 0)
                            {
                                return (false, (partiteSet1, partiteSet2));
                            }
                        }
                    }
                }

                visited.Add(vertexVisiting);
                visit.Remove(vertexVisiting);
                vertexGTs.Remove(vertexVisiting.VertexID);
            }

            return (true, (partiteSet1, partiteSet2));
        }

        /// <summary>
        /// int = vertexID in order
        /// 
        /// list<int>[][] = adjmatrix 
        /// </summary>
        /// <returns></returns>
        public (List<int>, List<List<int>>) GetAdjacenyMatrix()
        {
            List<List<int>> adjacenyMatrix = new();

            List<int> vertexList = this.vertexes.Keys.ToList();

            for (int i = 0; i < this.vertexes.Keys.Count; i++)
            {
                adjacenyMatrix.Add(new List<int>());
                for (int j = 0; j < this.vertexes.Keys.Count; j++)
                {
                    adjacenyMatrix[i].Add(vertexes[vertexList[i]].NeighborsOut.Values.Where((vertex) => vertex == vertexes[vertexList[j]]).Count());
                }
            }

            return (vertexList, adjacenyMatrix);
        }

        public abstract int AddLoop(int vertexID, bool isDirected, int weight = 1);

        public abstract int AddEdge(int vertexID_A, int vertexID_B, bool isDirected, int weight = 1);
    }
}
