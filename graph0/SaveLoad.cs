using System.IO;
using System.Text.Json;

namespace graph0
{
    public static class SaveLoad
    {
        public static void SaveGraphToFile(Graph graph, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(graph, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static Graph LoadGraphFromFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Graph>(jsonString);
        }

        public static void SaveStringToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}