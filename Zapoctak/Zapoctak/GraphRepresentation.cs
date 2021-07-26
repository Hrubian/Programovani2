using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Zapoctak
{
    public class GraphRepresentation
    {
        public enum GraphType
        {
            NN,
            NW,
            DN,
            DW
        }
        public GraphType Type;
        public int VertexCount;
        public int EdgeCount;
        public Color bgcolor;
        public Color vcolor;
        public Color ecolor;
        public Color textcolor;
        string Filename;
        public Dictionary<int, Vertex> Vertices;

        public void NewGraph(GraphType Type, string Filename)
        {
            bgcolor = System.Drawing.Color.White;
            vcolor = Color.Black;
            ecolor = ColorTranslator.FromHtml("#07a4d9");
            textcolor = Color.Blue;
            this.Type = Type;
            VertexCount = 0;
            EdgeCount = 0;
            Vertices = new Dictionary<int, Vertex>(VertexCount);
            this.Filename = Filename;
        }
        public void GraphFromFile(string Filename)
        {
            this.Filename = Filename;
            GraphRepresentation MyGraph = new GraphRepresentation();
            using (StreamReader file = new StreamReader(Filename))
            {
                string[] ColorSettings = file.ReadLine().Split();
                bgcolor = System.Drawing.ColorTranslator.FromHtml(ColorSettings[0]);
                vcolor = System.Drawing.ColorTranslator.FromHtml(ColorSettings[1]);
                ecolor = System.Drawing.ColorTranslator.FromHtml(ColorSettings[2]);
                textcolor = System.Drawing.ColorTranslator.FromHtml(ColorSettings[3]);
                Type = (GraphType)int.Parse(file.ReadLine());
                string[] counts = file.ReadLine().Split();
                VertexCount = int.Parse(counts[0]);
                Vertices = new Dictionary<int, Vertex>(VertexCount);
                EdgeCount = int.Parse(counts[1]);
                for (int i = 0; i < VertexCount; ++i)
                {
                    string[] Vertex = file.ReadLine().Split(':');
                    List<(int, int)> Edges = new List<(int, int)>();
                    for (int j = 4; j < Vertex.Length; j += 2)
                    {
                        Edges.Add((int.Parse(Vertex[j]), int.Parse(Vertex[j + 1])));
                    }
                    Vertices.Add(int.Parse(Vertex[0]), new Vertex(Vertex[1], int.Parse(Vertex[0]), int.Parse(Vertex[2]), int.Parse(Vertex[3]), Edges ));
                }

            }

        }

        public void SaveGraph()
        {
            using (StreamWriter file = new StreamWriter(Filename))
            {
                file.WriteLine(ColorTranslator.ToHtml(bgcolor) + " " + ColorTranslator.ToHtml(vcolor) + " " + ColorTranslator.ToHtml(ecolor) + " " + ColorTranslator.ToHtml(textcolor));
                file.WriteLine((int)Type);
                file.WriteLine(VertexCount.ToString() + " " + EdgeCount.ToString());
                foreach (int v in Vertices.Keys)
                {
                    file.Write(Vertices[v].VertexNumber + ":" + Vertices[v].Name + ":" + Vertices[v].Coordinates.X.ToString() + ":" + Vertices[v].Coordinates.Y.ToString());
                    foreach ( (int, int) edge in Vertices[v].Edges)
                    {
                        file.Write(":" + edge.Item1.ToString() + ":" + edge.Item2.ToString());
                    }
                    file.Write('\n');
                }
            }
        }

        public void AddVertex(Point MouseLocation, string Name)
        {
            int NewVertexNumber = -1;
            foreach (int x in Vertices.Keys)
            {
                if (x > NewVertexNumber)
                    NewVertexNumber = x;
            }
            ++NewVertexNumber;
            var v = new Vertex(Name, NewVertexNumber, MouseLocation.X, MouseLocation.Y, new List<(int, int)>());
            Vertices.Add(NewVertexNumber, v);
            ++VertexCount;
        }
    }

    public class Vertex
    {
        public string Name;
        public int VertexNumber;
        public Point Coordinates;
        public List<(int, int)> Edges;
        public VertexButton vtb;

        public enum DS
        {
            unknown,
            open,
            closed
        }
        public DS DijkstraState;

        public int DijkstraDistance;
        public int DijkstraHeapPosition;
        public Vertex DijkstraAncestor;
        public Vertex(string Name, int VertexNumber, int xcoord, int ycoord, List<(int, int)> Edges)
        {
            this.Name = Name;
            this.VertexNumber = VertexNumber;
            this.Edges = Edges;
            Coordinates = new Point(xcoord, ycoord);
        }
    }
}
