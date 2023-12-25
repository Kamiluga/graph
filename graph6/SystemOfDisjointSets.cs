using System.Collections.Generic;
using graph0;

namespace graph6
{
    public class SystemOfDisjointSets
    {
        public List<Set> Sets;

        public SystemOfDisjointSets()
        {
            Sets = new List<Set>();
        }

        public void AddEdgeInSet(Edge edge)
        {
            Set setA = Find(edge.IncidentVertices.FirstVertex);
            Set setB = Find(edge.IncidentVertices.SecondVertex);

            if (setA != null && setB == null)
            {
                setA.AddEdge(edge);
            }
            else if (setA == null && setB != null)
            {
                setB.AddEdge(edge);
            }
            else if (setA == null)
            {
                Set set = new Set(edge);
                Sets.Add(set);
            }
            else
            {
                if (setA != setB)
                {
                    setA.Union(setB, edge);
                    Sets.Remove(setB);
                }
            }
        }

        public Set Find(Vertex vertex)
        {
            foreach (Set set in Sets)
            {
                if (set.Contains(vertex)) return set;
            }
            return null;
        }
    }
}