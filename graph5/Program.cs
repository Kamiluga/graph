using System;
using System.IO;
using graph0;

namespace graph5
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
            

            var aStar = new AStar(graph);
            
            var result = aStar.FindShortestPath("A", "O");
            
            Console.WriteLine("Enter file path to save result: ");
            Console.Write(projectDirectory);
            
            var resultPath = Console.ReadLine();
            
            Console.WriteLine(result);
            SaveLoad.SaveStringToFile(projectDirectory + resultPath, result);
        }
    }
}