using System;
using System.Collections.Generic;
using graph0;

namespace graph5
{
    public class VertexPathInfo: IComparer<VertexPathInfo>, IComparable<VertexPathInfo>
    {
        public Vertex Vertex { get; set; }
        public double Weight { get; set; }

        public VertexPathInfo(Vertex vertex, double weight)
        {
            Vertex = vertex;
            Weight = weight;
        }

        public int Compare(VertexPathInfo x, VertexPathInfo y)
        {
            return x.Weight.CompareTo(y.Weight);
        }

        public int CompareTo(VertexPathInfo other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Weight.CompareTo(other.Weight);
        }
    }
}