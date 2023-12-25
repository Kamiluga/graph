using graph0;

namespace graph2
{
    public class EccentricityVertexInfo
    {
        public Vertex Vertex { get; set; }
        public double Eccentricity { get; set; }

        public EccentricityVertexInfo(Vertex vertex)
        {
            Vertex = vertex;
            Eccentricity = double.MinValue;
        }

        public override string ToString() =>
            $"Vertex: {Vertex.Name}, Weight: {Eccentricity}";
    }
}