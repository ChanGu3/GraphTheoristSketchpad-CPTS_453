using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class VertexGTS<Type> //: IEquatable<VertexGTS<Type>>
    {
        private int vertexID;

        Type data;

        /// <summary>
        /// all vertexes pointing towards this vertex with the corresponding edge.
        /// </summary>
        /// string = Edge Name
        /// Type = Vertex Name
        private Dictionary<EdgeGTS<Type>, VertexGTS<Type>> neighborsIn = new();

        /// <summary>
        /// all vertexes this vertex is pointing to with the corresponding edge.
        /// </summary>
        /// string = Edge Name
        /// Type = Vertex Name
        private Dictionary<EdgeGTS<Type>, VertexGTS<Type>> neighborsOut = new();

        public VertexGTS(int vertexID, Type data = default!) 
        { 
            this.data = data;
            this.vertexID = vertexID;
        }

        public int VertexID
        {
            get => vertexID;
        }

        public Type Data
        {
            get => data;
            set => data = value;
        }

        public int DegreeCount
        {
            get => this.neighborsIn.Count() + neighborsOut.Count();
        }

        public Dictionary<EdgeGTS<Type>, VertexGTS<Type>> NeighborsIn
        {
            get => neighborsIn;
        }

        public Dictionary<EdgeGTS<Type>, VertexGTS<Type>> NeighborsOut
        {
            get => neighborsOut;
        }

        public List<EdgeGTS<Type>> Edges
        {
            get
            {
                HashSet<EdgeGTS<Type>> values = new();
                foreach (EdgeGTS<Type> edge in this.NeighborsOut.Keys.Union(this.NeighborsIn.Keys))
                {
                    values.Add(edge);
                }

                return values.AsEnumerable().ToList();
            }
        }

        public void AddNeighborEdgeIn(EdgeGTS<Type> edge, VertexGTS<Type> vertexFrom)
        {
            neighborsIn.Add(edge, vertexFrom);
        }

        public void AddNeighborEdgeOut(EdgeGTS<Type> edge, VertexGTS<Type> vertexTo)
        {
            neighborsOut.Add(edge, vertexTo);
        }

        public void RemoveNeighborEdgeIn(EdgeGTS<Type> edge) 
        {
            neighborsIn.Remove(edge);
        }

        public void RemoveNeighborEdgeOut(EdgeGTS<Type> edge)
        {
            neighborsOut.Remove(edge);
        }

        /*
        public bool Equals(VertexGTS<Type>? other)
        {
            return other != null && EqualityComparer<int>.Default.Equals(this.vertexID, other.vertexID);
        }

        public override bool Equals(object? obj)
        {
            return obj is VertexGTS<Type> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<int>.Default.GetHashCode(this.vertexID);
        }
        */
    }
}
