using System;
using System.Collections.Generic;

namespace graph0
{
    [Serializable]
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public Vertex FindVertexByName(string vertexName) =>
            Vertices.Find(v => v.Name == vertexName);

        public Edge FindEdgeByName(string graphName) =>
            Edges.Find(e => e.Name == graphName);

        public int EdgesCount =>
            Edges.Count;

        public int VerticesCount =>
            Vertices.Count;

        public void AddGraph(Graph graph)
        {
            foreach (var edge in graph.Edges)
            {
                AddEdge(edge);
            }

            foreach (var vertex in graph.Vertices)
            {
                AddVertex(vertex);
            }
        }

        public Graph Sort()
        {
            Edges.Sort();
            return this;
        }
        
        public List<Edge> GetVertexEdges(Vertex vertex)
        {
            var edges = new List<Edge>();

            foreach (var edge in Edges)
            {
                if (edge.IncidentVertices.Contains(vertex))
                    edges.Add(edge);
            }

            return edges;
        }

        public void AddVertex(Vertex vertexToAdd)
        {
            if (Vertices.Contains(vertexToAdd))
                return;

            Vertices.Add(vertexToAdd);
        }

        public void RemoveVertex(Vertex vertex)
        {
            Vertices.Remove(vertex);
            Edges.RemoveAll(e => e.IncidentVertices.FirstVertex.Name == vertex.Name);
        }

        public void AddEdge(Edge edgeToAdd)
        {
            if (Edges.Contains(edgeToAdd))
                throw new Exception("Edge is already exists");

            Edges.Add(edgeToAdd);
        }

        public void RemoveEdge(string edgeName)
        {
            var targetEdge = FindEdgeByName(edgeName);

            var incidentVertices = targetEdge.IncidentVertices;

            Edges.Remove(targetEdge);

            foreach (var incidentVertex in incidentVertices.AsList())
            {
                var isUsed = false;

                foreach (var edge in Edges)
                {
                    if (edge.IncidentVertices.Contains(incidentVertex))
                    {
                        isUsed = true;
                        break;
                    }
                }

                if (!isUsed)
                {
                    Vertices.Remove(incidentVertex);
                }
            }
        }

        public override string ToString()
        {
            return $"{{graph: vertices = [{string.Join(", ", Vertices)}], edges = [{string.Join(", ", Edges)}]}}";
        }
    }
}