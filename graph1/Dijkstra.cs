using System;
using System.Collections.Generic;
using graph0;

namespace graph1
{
    public class Dijkstra
    {
        private Graph _graph;
        private List<VertexInfo> _vertexInfos;

        public Dijkstra(Graph graph) =>
            _graph = graph;

        private void InitInfo()
        {
            _vertexInfos = new List<VertexInfo>();
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

        public VertexInfo FindUnvisitedVertexWithMinSum()
        {
            var minValue = double.MaxValue;
            VertexInfo minVertexInfo = null;
            foreach (var i in _vertexInfos)
            {
                if (i.IsUnvisited && i.EdgesWeightSum < minValue)
                {
                    minVertexInfo = i;
                    minValue = i.EdgesWeightSum;
                }
            }

            return minVertexInfo;
        }

        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(_graph.FindVertexByName(startName), _graph.FindVertexByName(finishName));
        }

        public string FindShortestPath(Vertex startVertex, Vertex finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }
            
            return GetPath(startVertex, finishVertex);
        }
        
        public double FindShortestWeight(Vertex startVertex, Vertex finishVertex)
        {
            InitInfo();
            var first = GetVertexInfo(startVertex);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindUnvisitedVertexWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetVertexInfo(finishVertex).EdgesWeightSum;
        }

        private void SetSumToNextVertex(VertexInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in _graph.GetVertexEdges(info.Vertex))
            {
                var anotherVertex = e.IncidentVertices.GetAnotherVertex(info.Vertex);
                if(!e.CheckDirection(info.Vertex, anotherVertex))
                    continue;
                var nextInfo = GetVertexInfo(anotherVertex);
                var sum = info.EdgesWeightSum + e.Weight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousVertex = info.Vertex;
                }
            }
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