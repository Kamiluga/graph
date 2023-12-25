using System;
using System.Collections.Generic;
using System.IO;

namespace graph0
{
    public class Program
    {
        public static void Main()
        {
            Graph graph = CreateGraph();

            Console.WriteLine(graph.ToString());
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName + @"\graph.txt";

            Console.WriteLine(projectDirectory);
            SaveLoad.SaveGraphToFile(graph, projectDirectory);

            Graph restoredGraph = SaveLoad.LoadGraphFromFile(projectDirectory);

            Console.WriteLine(restoredGraph.ToString());
        }

        private static Graph CreateGraph()
        {
            List<Vertex> vertices = new List<Vertex>()
            {
                new Vertex("A"),
                new Vertex("B"),
                new Vertex("C"),
                new Vertex("D"),
                new Vertex("E"),
                new Vertex("F"),
                new Vertex("G"),
                new Vertex("H"),
                new Vertex("I"),
                new Vertex("J"),
                new Vertex("K"),
                new Vertex("L"),
                new Vertex("M"),
                new Vertex("N"),
                new Vertex("O"),
                new Vertex("P"),
                new Vertex("Q"),
                new Vertex("R"),
                new Vertex("S"),
                new Vertex("T"),
                new Vertex("U"),
                new Vertex("V"),
                new Vertex("W"),
                new Vertex("X"),
                new Vertex("Y"),
                new Vertex("Z"),
            };

            List<Edge> edges = new List<Edge>()
            {
                new Edge(10, new ConnectedVertices(vertices[0], vertices[1]), Direction.Bidirectional),
                new Edge(15, new ConnectedVertices(vertices[0], vertices[2]), Direction.FromFirstToSecond),
                new Edge(20, new ConnectedVertices(vertices[0], vertices[3]), Direction.Bidirectional),
                new Edge(25, new ConnectedVertices(vertices[1], vertices[4]), Direction.Bidirectional),
                new Edge(30, new ConnectedVertices(vertices[1], vertices[5]), Direction.FromFirstToSecond),
                new Edge(35, new ConnectedVertices(vertices[2], vertices[6]), Direction.Bidirectional),
                new Edge(40, new ConnectedVertices(vertices[2], vertices[7]), Direction.Bidirectional),
                new Edge(45, new ConnectedVertices(vertices[3], vertices[8]), Direction.FromFirstToSecond),
                new Edge(50, new ConnectedVertices(vertices[3], vertices[9]), Direction.Bidirectional),
                new Edge(55, new ConnectedVertices(vertices[4], vertices[10]), Direction.Bidirectional),
                new Edge(60, new ConnectedVertices(vertices[4], vertices[11]), Direction.FromFirstToSecond),
                new Edge(65, new ConnectedVertices(vertices[5], vertices[12]), Direction.FromFirstToSecond),
                new Edge(70, new ConnectedVertices(vertices[5], vertices[13]), Direction.Bidirectional),
                new Edge(75, new ConnectedVertices(vertices[6], vertices[14]), Direction.FromFirstToSecond),
                new Edge(80, new ConnectedVertices(vertices[6], vertices[15]), Direction.Bidirectional),
                new Edge(85, new ConnectedVertices(vertices[7], vertices[16]), Direction.Bidirectional),
                new Edge(90, new ConnectedVertices(vertices[7], vertices[17]), Direction.FromFirstToSecond),
                new Edge(95, new ConnectedVertices(vertices[8], vertices[18]), Direction.Bidirectional),
                new Edge(100, new ConnectedVertices(vertices[8], vertices[19]), Direction.FromFirstToSecond),
                new Edge(105, new ConnectedVertices(vertices[9], vertices[20]), Direction.Bidirectional),
                new Edge(95, new ConnectedVertices(vertices[10], vertices[11]), Direction.Bidirectional),
                new Edge(60, new ConnectedVertices(vertices[11], vertices[12]), Direction.FromFirstToSecond),
                new Edge(105, new ConnectedVertices(vertices[12], vertices[14]), Direction.FromFirstToSecond),
                new Edge(70, new ConnectedVertices(vertices[13], vertices[14]), Direction.Bidirectional),
                new Edge(50, new ConnectedVertices(vertices[14], vertices[15]), Direction.FromFirstToSecond),
                new Edge(80, new ConnectedVertices(vertices[15], vertices[16]), Direction.Bidirectional),
                new Edge(90, new ConnectedVertices(vertices[16], vertices[17]), Direction.FromFirstToSecond),
                new Edge(50, new ConnectedVertices(vertices[17], vertices[20]), Direction.FromFirstToSecond),
                new Edge(30, new ConnectedVertices(vertices[20], vertices[19]), Direction.Bidirectional),
                new Edge(10, new ConnectedVertices(vertices[19], vertices[18]), Direction.Bidirectional),
                new Edge(110, new ConnectedVertices(vertices[20], vertices[21]), Direction.Bidirectional),
                new Edge(115, new ConnectedVertices(vertices[21], vertices[22]), Direction.Bidirectional),
                new Edge(120, new ConnectedVertices(vertices[21], vertices[23]), Direction.Bidirectional),
                new Edge(130, new ConnectedVertices(vertices[22], vertices[23]), Direction.Bidirectional),
                new Edge(135, new ConnectedVertices(vertices[22], vertices[24]), Direction.Bidirectional),
                new Edge(140, new ConnectedVertices(vertices[23], vertices[25]), Direction.Bidirectional),
                new Edge(145, new ConnectedVertices(vertices[24], vertices[25]), Direction.Bidirectional),
            };

            return new Graph(vertices, edges);
        }
    }
}