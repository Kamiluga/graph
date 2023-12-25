using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using graph0;
using graph1;

namespace graph2
{
    internal class Program
    {
        public static void Main()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName + @"\";

            Console.WriteLine("Enter file path: ");
            Console.Write(projectDirectory);
            var path = Console.ReadLine();

            var graph = SaveLoad.LoadGraphFromFile(projectDirectory + path);
            
            var graphEccentricity = CalculateEccentricity(graph);
            
            Console.WriteLine("Enter file path to save result: ");
            Console.Write(projectDirectory);
            
            var resultPath = Console.ReadLine();
            
            Console.WriteLine(graphEccentricity);
            SaveGraphEccentricityToFile(graphEccentricity, projectDirectory + resultPath);
        }

        public static GraphEccentricity CalculateEccentricity(Graph graph)
        {
            var graphEccentricity = new GraphEccentricity(graph);
            var dijkstra = new Dijkstra(graph);
            
            foreach (var eccentricityVertexInfo in graphEccentricity.EccentricityVertexInfos)
            {
                var weight = double.MinValue;
                
                for (int i = 0; i < graph.Vertices.Count; i++)
                {
                    if(eccentricityVertexInfo.Vertex.Name == graph.Vertices[i].Name)
                        continue;
                    
                    var currentWeight = dijkstra.FindShortestWeight(eccentricityVertexInfo.Vertex, graph.Vertices[i]);
                    if (weight < currentWeight)
                        weight = currentWeight;
                }

                eccentricityVertexInfo.Eccentricity = weight;
            }

            graphEccentricity.Diameter = CalculateDiameter(graphEccentricity);
            graphEccentricity.Radius = CalculateRadius(graphEccentricity);
            graphEccentricity.Center = graphEccentricity.Radius.Vertex;

            return graphEccentricity;
        }

        private static EccentricityVertexInfo CalculateRadius(GraphEccentricity graphEccentricity)
        {
            EccentricityVertexInfo radius = graphEccentricity.EccentricityVertexInfos[0];

            for (int i = 1; i < graphEccentricity.EccentricityVertexInfos.Count; i++)
            {
                var current = graphEccentricity.EccentricityVertexInfos[i];
                if (radius.Eccentricity > current.Eccentricity)
                    radius = current;
            }

            return radius;
        }

        private static EccentricityVertexInfo CalculateDiameter(GraphEccentricity graphEccentricity)
        {
            EccentricityVertexInfo diameter = graphEccentricity.EccentricityVertexInfos[0];

            for (int i = 1; i < graphEccentricity.EccentricityVertexInfos.Count; i++)
            {
                var current = graphEccentricity.EccentricityVertexInfos[i];
                if (diameter.Eccentricity < current.Eccentricity)
                    diameter = current;
            }

            return diameter;
        }
        
        public static void SaveGraphEccentricityToFile(GraphEccentricity graphEccentricity, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(graphEccentricity, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}