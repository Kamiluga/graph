using System;
using graph0;

namespace graph1
{
    public class VertexInfo
    {
        public Vertex Vertex { get; set; }
        public bool IsUnvisited { get; set; }
        public double EdgesWeightSum { get; set; }
        public Vertex PreviousVertex { get; set; }

        public VertexInfo(Vertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesWeightSum = double.MaxValue;
            PreviousVertex = null;
        }
    }
}