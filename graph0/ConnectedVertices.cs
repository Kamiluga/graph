using System;
using System.Collections.Generic;

namespace graph0
{
    public class ConnectedVertices
    {
        public Vertex FirstVertex { get; set; }
        public Vertex SecondVertex { get; set; }

        public ConnectedVertices(Vertex firstVertex, Vertex secondVertex)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
        }

        public Vertex Find(string vertexName)
        {
            if (FirstVertex.Name == vertexName)
                return FirstVertex;
            if (SecondVertex.Name == vertexName)
                return SecondVertex;

            throw new Exception("This vertex is not exists");
        }

        public Vertex GetAnotherVertex(Vertex firstVertex)
        {
            if (firstVertex.Name == FirstVertex.Name)
                return SecondVertex;

            if (firstVertex.Name == SecondVertex.Name)
                return FirstVertex;

            throw new Exception("This vertex is not exists");
        }

        public List<Vertex> AsList() =>
            new List<Vertex>() {FirstVertex, SecondVertex};

        public bool Contains(Vertex vertex) =>
            vertex.Name == FirstVertex.Name || vertex.Name == SecondVertex.Name;
    }
}