using System.Collections.Generic;
using graph0;

namespace graph6
{
    public class Set
    {
        public Graph SetGraph;
        public List<Vertex> Vertices;

        public Set(Edge edge)
        {
            SetGraph = new Graph();
            SetGraph.AddEdge(edge);
            Vertices = new List<Vertex>();
            Vertices.Add(edge.IncidentVertices.FirstVertex);
            Vertices.Add(edge.IncidentVertices.SecondVertex);
        }

        public void Union(Set set, Edge connectingEdge)
        {
            SetGraph.AddGraph(set.SetGraph);
            Vertices.AddRange(set.Vertices);
            SetGraph.AddEdge(connectingEdge);
            SetGraph.AddVertex(connectingEdge.IncidentVertices.FirstVertex);
            SetGraph.AddVertex(connectingEdge.IncidentVertices.SecondVertex);
        }

        public void AddEdge(Edge edge)
        {
            SetGraph.AddEdge(edge);
            Vertices.Add(edge.IncidentVertices.FirstVertex);
            Vertices.Add(edge.IncidentVertices.SecondVertex);
        }

        public bool Contains(Vertex vertex)
        {
            return Vertices.Contains(vertex);
        }
    }
}