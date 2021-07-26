using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapoctak
{
    public static class Dijkstra
    {
        class Heap
        {

            private List<Vertex> BinaryHeap = new List<Vertex>();
            private int parent(int x) => (x - 1) / 2;
            private int leftChild(int x) => 2 * x + 1;
            private int rightChild(int x) => 2 * x + 2;
            public void Insert(Vertex v)
            {
                BinaryHeap.Add(v);
                v.DijkstraHeapPosition = BinaryHeap.Count - 1;
                RepairNewNode();
                
            }
            private void RepairNewNode()
            {
                int position = BinaryHeap.Count - 1;
                while (parent(position) >= 0 && BinaryHeap[parent(position)].DijkstraDistance > BinaryHeap[position].DijkstraDistance)
                {
                    (BinaryHeap[position].DijkstraHeapPosition, BinaryHeap[parent(position)].DijkstraHeapPosition) =
                        (BinaryHeap[parent(position)].DijkstraDistance, BinaryHeap[position].DijkstraDistance);
                    (BinaryHeap[parent(position)], BinaryHeap[position]) = (BinaryHeap[position], BinaryHeap[parent(position)]);
                    position = parent(position);
                }
            }
            public Vertex ExtractMin ()
            {
                Vertex v = BinaryHeap[0];
                BinaryHeap[0] = BinaryHeap[BinaryHeap.Count - 1];
                BinaryHeap.RemoveAt(BinaryHeap.Count - 1);
                if (BinaryHeap.Count > 0) 
                    BinaryHeap[0].DijkstraHeapPosition = 0;
                RepairRoot();
                return v;
            }
            private void RepairRoot()
            {
                int position = 0;
                while (leftChild(position) < BinaryHeap.Count)
                {
                    int change = position;
                    if (BinaryHeap[leftChild(position)].DijkstraDistance < BinaryHeap[position].DijkstraDistance)
                        change = leftChild(position);
                    if (rightChild(position) < BinaryHeap.Count && BinaryHeap[rightChild(position)].DijkstraDistance < BinaryHeap[change].DijkstraDistance)
                        change = rightChild(position);
                    if (change != position)
                    {
                        (BinaryHeap[position].DijkstraDistance, BinaryHeap[change].DijkstraDistance) =
                            (BinaryHeap[change].DijkstraDistance, BinaryHeap[position].DijkstraDistance);
                        (BinaryHeap[position], BinaryHeap[change]) = (BinaryHeap[change], BinaryHeap[position]);
                        position = change;
                    }
                    else return;
                }
            }

            public void Decrease (Vertex v)
            {
                int position = v.DijkstraHeapPosition;
                while (parent(position) >= 0 && BinaryHeap[parent(position)].DijkstraDistance > BinaryHeap[position].DijkstraDistance)
                {
                    (BinaryHeap[position].DijkstraHeapPosition, BinaryHeap[parent(position)].DijkstraHeapPosition) =
                        (BinaryHeap[parent(position)].DijkstraDistance, BinaryHeap[position].DijkstraDistance);
                    (BinaryHeap[parent(position)], BinaryHeap[position]) = (BinaryHeap[position], BinaryHeap[parent(position)]);
                    position = parent(position);
                }
            }

            public bool IsEmpty ()
            {
                if (BinaryHeap.Count == 0)
                    return true;
                return false;
            }
        }
        public static (int, int)[] FindShortestPath (GraphRepresentation Graph, Vertex v1, Vertex v2)
        {
            foreach (Vertex v in Graph.Vertices.Values)
            {
                v.DijkstraState = Vertex.DS.unknown;
                v.DijkstraDistance = int.MaxValue;
                v.DijkstraAncestor = null;
            }
            v1.DijkstraState = Vertex.DS.open;
            v1.DijkstraDistance = 0;
            v1.DijkstraAncestor = v1;
            Heap VertexHeap = new Heap();
            VertexHeap.Insert(v1);
            while (!VertexHeap.IsEmpty())
            {
                Vertex v = VertexHeap.ExtractMin();
                foreach ((int, int) edge in v.Edges)
                {
                    if (Graph.Vertices[edge.Item1].DijkstraDistance > v.DijkstraDistance + edge.Item2)
                    {
                        Graph.Vertices[edge.Item1].DijkstraDistance = v.DijkstraDistance + edge.Item2;
                        if (Graph.Vertices[edge.Item1].DijkstraState == Vertex.DS.open)
                            VertexHeap.Decrease(Graph.Vertices[edge.Item1]);
                        else
                        {
                            VertexHeap.Insert(Graph.Vertices[edge.Item1]);
                            Graph.Vertices[edge.Item1].DijkstraState = Vertex.DS.open;
                        }
                        Graph.Vertices[edge.Item1].DijkstraAncestor = v;
                    }
                }
                v.DijkstraState = Vertex.DS.closed;
            }
            return ReconstructPath(Graph, v1, v2);
        }

        private static (int, int)[] ReconstructPath(GraphRepresentation Graph, Vertex v1, Vertex v2)
        {
            (int, int)[] result = new (int, int)[Graph.VertexCount];
            int i = 0;
            Vertex v = v2;
            Vertex u = v2.DijkstraAncestor;
            if (v2.DijkstraAncestor == null)
                return new (int, int)[0];
            while (v1.VertexNumber != u.VertexNumber)
            {
                result[i] = (u.VertexNumber, v.VertexNumber);
                (u, v) = (u.DijkstraAncestor, u);
                ++i;
            }
            ++i;
            result[i] = (u.VertexNumber, v.VertexNumber);
            return result;
        }

    }
}
