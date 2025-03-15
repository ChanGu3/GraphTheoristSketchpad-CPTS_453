using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTS_GraphEngine
{
    public class EdgeGTS<Type> //: IEquatable<EdgeGTS<Type>>
    {
        private int edgeID;

        private int weight;
        private bool isDirected;

        private VertexGTS<Type> vertexFrom;
        private VertexGTS<Type> vertexTo;

        /// <summary>
        /// When not directed From and To act as just point A and point B since edge goes both ways. 
        /// </summary>
        /// <param name="vertexFrom"> when directed this is where the arrow comes from. </param>
        /// <param name="vertexTo"> when directed this is where the arrow goes to. </param>
        /// <param name="isDirected"> directed edge or not. </param>
        /// <param name="weight"> wieght of edge. </param>
        public EdgeGTS(int edgeID, VertexGTS<Type> vertexFrom, VertexGTS<Type> vertexTo, bool isDirected, int weight = 1)
        {
            this.edgeID = edgeID;
            this.isDirected = isDirected;
            this.vertexFrom = vertexFrom;
            this.vertexTo = vertexTo;
            this.weight = weight;
        }

        public int EdgeID
        {
            get => edgeID;
        }

        public int Weight
        {
            get => weight;
        }
        public bool IsDirected
        {
            get => isDirected;
        }
        public VertexGTS<Type> VertexFrom
        {
            get => vertexFrom;
        }
        public VertexGTS<Type> VertexTo
        {
            get => vertexTo;
        }

        /*
        public bool Equals(EdgeGTS<Type>? other)
        {
            return other != null && EqualityComparer<int>.Default.Equals(this.edgeID, other.edgeID);
        }

        public override bool Equals(object? obj)
        {
            return obj is EdgeGTS<Type> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<int>.Default.GetHashCode(this.edgeID);
        }
        */
    }
}
