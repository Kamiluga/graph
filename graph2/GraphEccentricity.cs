using System.Collections.Generic;
using graph0;

namespace graph2
{
    public class GraphEccentricity
    {
        public List<EccentricityVertexInfo> EccentricityVertexInfos { get; set; }
        public EccentricityVertexInfo Diameter { get; set; }
        public Vertex Center { get; set; }
        public EccentricityVertexInfo Radius { get; set; }

        public GraphEccentricity(Graph graph)
        {
            InitializeEccentricityVertexInfos(graph);
            Diameter = null;
            Center = null;
            Radius = null;
        }

        private void InitializeEccentricityVertexInfos(Graph graph)
        {
            EccentricityVertexInfos = new List<EccentricityVertexInfo>();
            foreach (var vertex in graph.Vertices)
            {
                EccentricityVertexInfos.Add(new EccentricityVertexInfo(vertex));
            }
        }
        
        public override string ToString()
        {
            return $"{{graph: vertices = [{string.Join(", ", EccentricityVertexInfos)}], Diameter: {Diameter}, Center: {Center}, Radius: {Radius}";
        }
    }
}