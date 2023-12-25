using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using graph0;

namespace graph9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName + @"\";

            
            var degrees = new [] {3, 4, 8, 1, 0, 2, 5, 3, 2, 1, 4, 5, 3, 1, 2, 0, 2, 3, 2, 1, 2};

            Console.WriteLine(degrees.Sum());
            
            var result = ReconstructGraph(degrees.ToList());
            
            Console.WriteLine("Enter file path to save result: ");
            Console.Write(projectDirectory);
            
            var resultPath = Console.ReadLine();
            
            Console.WriteLine(result);
            SaveLoad.SaveGraphToFile(result, projectDirectory + resultPath);
        }

        public static Graph ReconstructGraph(List<int> degrees)
        {
            int n = degrees.Count;
            int sumOfDegrees = 0;

            foreach (int degree in degrees)
            {
                sumOfDegrees += degree;
            }

            if (sumOfDegrees % 2 != 0)
            {
                throw new ArgumentException("Invalid degrees vector");
            }
            

            Graph graph = new Graph();

            for (int i = 0; i < n; i++)
            {
                graph.AddVertex(new Vertex(((char) (i+65)).ToString()));
            }

            for (int i = 0; i < n; i++)
            {
                while (degrees[i] > 0)
                {
                    int maxDegreeVertex = -1;
                    int maxDegree = -1;

                    for (int j = 0; j < n; j++)
                    {
                        if (degrees[j] > maxDegree)
                        {
                            maxDegree = degrees[j];
                            maxDegreeVertex = j;
                        }
                    }

                    if (maxDegreeVertex == -1)
                    {
                        throw new ArgumentException("Invalid degrees vector");
                    }

                    graph.AddEdge(new Edge(0,
                        new ConnectedVertices(graph.FindVertexByName(((char) (i+65)).ToString()),
                            graph.FindVertexByName(((char) (maxDegreeVertex+65)).ToString()))));

                    degrees[i]--;
                    degrees[maxDegreeVertex]--;
                }
            }

            return graph;
        }
    }
}