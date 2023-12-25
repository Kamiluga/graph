using System.Collections.Generic;
using graph0;
using graph1;

namespace graph5
{
    public class AStar
    {
        private Graph _graph;
        private List<VertexInfo> _vertexInfos;
        private List<VertexPathInfo> _pathVertexInfos;

        public AStar(Graph graph) =>
            _graph = graph;   
        
        
        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(_graph.FindVertexByName(startName), _graph.FindVertexByName(finishName));
        }

        public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
        {
            InitInfo();
            
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            _pathVertexInfos.Add(new VertexPathInfo(startVertex, 0));
            while (_pathVertexInfos.Count != 0)
            {
                _pathVertexInfos.Sort();
                var current = GetVertexInfo(_pathVertexInfos[_pathVertexInfos.Count - 1].Vertex);
                _pathVertexInfos.RemoveAt(_pathVertexInfos.Count - 1);
                
                if(current.Vertex == finishVertex)
                    break;

                foreach (var e in _graph.GetVertexEdges(current.Vertex))
                {
                    var anotherVertex = e.IncidentVertices.GetAnotherVertex(current.Vertex);
                    if(!e.CheckDirection(current.Vertex, anotherVertex))
                        continue;
                    
                    var sum = current.EdgesWeightSum + e.Weight;
                    var nextInfo = GetVertexInfo(anotherVertex);
                    if (sum < nextInfo.EdgesWeightSum)
                    {
                        nextInfo.EdgesWeightSum = sum;
                        nextInfo.PreviousVertex = current.Vertex;
                        _pathVertexInfos.Add(new VertexPathInfo(nextInfo.Vertex, sum + Heuristic(current, GetVertexInfo(finishVertex))));
                    }
                }
            }
            
            return GetPath(startVertex, finishVertex);
        }

        private double Heuristic(VertexInfo start, VertexInfo end)
        {
            return 0;
        }
        
        private void InitInfo()
        {
            _vertexInfos = new List<VertexInfo>();
            _pathVertexInfos = new List<VertexPathInfo>();
            foreach (var v in _graph.Vertices)
            {
                _vertexInfos.Add(new VertexInfo(v));
            }
        }
        
        private VertexInfo GetVertexInfo(Vertex v)
        {
            foreach (var i in _vertexInfos)
            {
                if (i.Vertex.Name == v.Name)
                {
                    return i;
                }
            }

            return null;
        }
        
        private string GetPath(Vertex startVertex, Vertex endVertex)
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetVertexInfo(endVertex).PreviousVertex;
                path = endVertex + path;
            }

            return path;
        }
    }
}