using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using graph0;

namespace graph6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent?.Parent?.FullName + @"\";

            Console.WriteLine("Enter file path: ");
            Console.Write(projectDirectory);
            var path = Console.ReadLine();
            
            var graph = SaveLoad.LoadGraphFromFile(projectDirectory + path);
            
            var result = AlgorithmByPrim(graph);
            
            Console.WriteLine("Enter file path to save result: ");
            Console.Write(projectDirectory);
            
            var resultPath = Console.ReadLine();
            
            Console.WriteLine(result);
            SaveLoad.SaveGraphToFile(result, projectDirectory + resultPath);
        }
        
        public static Graph FindMinimumSpanningTree(Graph target)
        {
            target = target.Sort();
            
            var disjointSets = new SystemOfDisjointSets();
            foreach (var edge in target.Edges)
            {
                disjointSets.AddEdgeInSet(edge);
            }
        
            return disjointSets.Sets.Last().SetGraph;
        }
        
        public static Graph AlgorithmByPrim(Graph graph)
        {
            List<Edge> notUsedE = graph.Edges;
            List<Vertex> usedV = new List<Vertex>();
            List<Vertex> notUsedV = graph.Vertices;

            var result = new List<Edge>();
            
            Console.WriteLine(graph.Vertices.IndexOf(graph.Edges[2].IncidentVertices.FirstVertex));
            
            Random rand = new Random();
            usedV.Add(graph.Vertices[rand.Next(0, graph.Vertices.Count)]);
            notUsedV.Remove(usedV[0]);
            while (notUsedV.Count > 0)
            {
                int minE = -1;
                for (int i = 0; i < notUsedE.Count; i++)
                {
                    if (((usedV.IndexOf(notUsedE[i].IncidentVertices.FirstVertex) != -1) &&
                         (notUsedV.IndexOf(notUsedE[i].IncidentVertices.SecondVertex) != -1)) ||
                        ((usedV.IndexOf(notUsedE[i].IncidentVertices.SecondVertex) != -1) &&
                         (notUsedV.IndexOf(notUsedE[i].IncidentVertices.FirstVertex) != -1)))
                    {
                        if (minE != -1)
                        {
                            if (notUsedE[i].Weight < notUsedE[minE].Weight)
                                minE = i;
                        }
                        else
                            minE = i;
                    }
                }
                
                if (usedV.IndexOf(notUsedE[minE].IncidentVertices.FirstVertex) != -1)
                {
                    usedV.Add(notUsedE[minE].IncidentVertices.SecondVertex);
                    notUsedV.Remove(notUsedE[minE].IncidentVertices.SecondVertex);
                }
                else
                {
                    usedV.Add(notUsedE[minE].IncidentVertices.FirstVertex);
                    notUsedV.Remove(notUsedE[minE].IncidentVertices.FirstVertex);
                }

                result.Add(notUsedE[minE]);
                notUsedE.RemoveAt(minE);
            }

            var resGraph = new Graph {Edges = result};
            
            foreach (var edge in result)
            {
                resGraph.AddVertex(edge.IncidentVertices.FirstVertex);
                resGraph.AddVertex(edge.IncidentVertices.SecondVertex);
            }

            return resGraph;
        }
    }
}