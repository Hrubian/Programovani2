using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapoctak
{
    public static class Kruskal
    {
        public static (int, int, int)[] FindMinimalSpan(GraphRepresentation Graph)
        {
            if (Graph.EdgeCount == 0)
                return new (int, int, int)[0];
            (int, int, int)[] edges = ExtractEdges(Graph);
            Dictionary<int, int> Components = new Dictionary<int, int>();
            foreach (int i in Graph.Vertices.Keys)
            {
                Components.Add(i, i);
            }

            (int, int, int)[] result = new (int, int, int)[Graph.VertexCount -1];
            int k = 0;
            foreach ((int, int, int) edge in edges)
            {
                if (Components[edge.Item2] != Components[edge.Item3])
                {
                    result[k] = edge;
                    ++k;
                }
                int OldID = Components[edge.Item2], NewID = Components[edge.Item3];
                foreach (int l in Components.Keys.ToList())
                {
                    if (Components[l] == OldID)
                        Components[l] = NewID;
                }
            }
            return result;
        }

        private static (int, int, int)[] ExtractEdges(GraphRepresentation Graph)
        {
            (int, int, int)[] edges = new (int, int, int)[Graph.EdgeCount];
            int i = 0;
            foreach (Vertex v in Graph.Vertices.Values)
            {
                foreach ((int, int) e in v.Edges)
                {
                    edges[i] = (e.Item2, v.VertexNumber, e.Item1);
                    ++i;
                }
            }
            Array.Sort(edges);
            (int, int, int)[] FinalEdges = new (int, int, int)[Graph.EdgeCount / 2];
            i = 0;
            foreach ((int, int, int) edge1 in edges)
            {
                if (!FinalEdges.Contains((edge1.Item1, edge1.Item3, edge1.Item2)))
                {
                    FinalEdges[i] = edge1;
                    i++;
                }
            }
            return FinalEdges;
            /*
            (int, int, int)[] FinalEdges = new (int, int, int)[Graph.EdgeCount / 2];
            for (int j = 0; j < FinalEdges.Length; ++j)
            {
                FinalEdges[j] = edges[2 * j];
            }
            return FinalEdges;
            */
        }
    }
}
