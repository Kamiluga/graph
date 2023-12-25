using System;

namespace graph0
{
    public class Edge: IComparable<Edge>
    {
        public string Name => IncidentVertices.FirstVertex.Name + IncidentVertices.SecondVertex.Name;
        public ConnectedVertices IncidentVertices { get; set; }
        public double Weight { get; set; }
        public Direction Direction { get; set; }

        public Edge(double weight, ConnectedVertices incidentVertices, 
            Direction direction = Direction.Bidirectional)
        {
            IncidentVertices = incidentVertices;
            Weight = weight;
            Direction = direction;
        }

        public override string ToString() =>
            Name;

        public bool CheckDirection(Vertex startVertex, Vertex endVertex)
        {
            if (Direction == Direction.Bidirectional)
                return true;

            var isFirst = startVertex.Name == IncidentVertices.FirstVertex.Name;

            if (isFirst)
                return Direction == Direction.FromFirstToSecond;
            else
                return Direction == Direction.FromSecondToFirst;
        }

        public int CompareTo(Edge other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Weight.CompareTo(other.Weight);
        }
    }
}