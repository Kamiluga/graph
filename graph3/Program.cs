using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using graph0;

namespace graph3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName + @"\";

            Console.WriteLine("Enter file path: ");
            Console.Write(projectDirectory);
            var path = Console.ReadLine();
            
            var graph = SaveLoad.LoadGraphFromFile(projectDirectory + path);
            
            var bridges = FindBridges(graph);
            var articulation = FindArticulationPoints(graph);

            var bridgesStr = $"Bridges (Count: {bridges.Count}): {string.Join(", ", bridges)}";
            var articulationStr = $"ArticulationPoints (Count: {articulation.Count}): {string.Join(", ", articulation)}";

            var resultStr = bridgesStr + "\n" + articulationStr; 
            
            
            Console.WriteLine("Enter file path to save result: ");
            Console.Write(projectDirectory);
            
            var resultPath = Console.ReadLine();
            SaveLoad.SaveStringToFile(projectDirectory + resultPath, resultStr);
        }

        public static List<List<Vertex>> FindConnectedComponents(Graph graph)
        {
            var visited = new HashSet<Vertex>();
            var components = new List<List<Vertex>>();

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    var component = DepthFirstSearch(graph, vertex, visited);
                    components.Add(component);
                }
            }

            return components;
        }

        private static List<Vertex> DepthFirstSearch(Graph graph, Vertex start, HashSet<Vertex> visited)
        {
            //hashset used to insure the uniq of data
            //stack used for DFS
            //at each iteration, the algorithm pops a vertex from the stack, adds it to the connected component
            //and adds its unvisited neighbors to the stack.
            var component = new List<Vertex>();
            var stack = new Stack<Vertex>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    component.Add(current);

                    var neighbors = graph.GetVertexEdges(current)
                        .SelectMany(e => e.IncidentVertices.AsList())
                        .Distinct()
                        .Where(v => !visited.Contains(v));
                    foreach (var neighbor in neighbors)
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return component;
        }

        //method searches for vertices in a graph that, if removed, lead to an increase in the number of
        //connected components. The graph goes through each vertex, removes it, and looks for connected components.
        //If the number of components is greater than 1, the vertex is considered an articulatory point
        //and is added to the list.
        public static List<Vertex> FindArticulationPoints(Graph graph)
        {
            var articulationPoints = new List<Vertex>();
            var visited = new HashSet<Vertex>();

            foreach (var vertex in graph.Vertices)
            {
                if (!visited.Contains(vertex))
                {
                    var withoutVertex = new Graph(graph.Vertices.ToList(), graph.Edges.ToList());
                    withoutVertex.RemoveVertex(vertex);
                    var components = FindConnectedComponents(withoutVertex);

                    if (components.Count > 1)
                    {
                        articulationPoints.Add(vertex);
                    }
                }
            }

            return articulationPoints;
        }

        //same as Arti points, but for edges
        public static List<Edge> FindBridges(Graph graph)
        {
            var bridges = new List<Edge>();

            foreach (var edge in graph.Edges)
            {
                var withoutEdge = new Graph(graph.Vertices, graph.Edges.Where(e => e != edge).ToList());
                var components = FindConnectedComponents(withoutEdge);

                if (components.Count > 1)
                {
                    bridges.Add(edge);
                }
            }

            return bridges;
        }
    }
}