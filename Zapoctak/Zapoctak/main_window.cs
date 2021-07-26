using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zapoctak
{
    public partial class main_window : Form
    {
        public enum ProgramStates
        {
            Normal,
            NewVertex,
            NewEdge1,
            NewEdge2,
            RmEdge1,
            RmEdge2,
            RmVertex,
            Dijkstra1,
            Dijkstra2
        }
        ProgramStates State;
        GraphRepresentation Graph;
        private bool ShowControls = true;
        Graphics g;
        Bitmap bmp;

        public main_window(string Filename)
        {
            InitializeComponent();
            buttonEllipse1_Click(null, null);
            Graph = new GraphRepresentation();
            Graph.GraphFromFile(Filename);
            bmp = new Bitmap(2000, 2000);
            g = Graphics.FromImage(bmp);
            Board.BackgroundImage = bmp;
            DisplayGraph();
            State = ProgramStates.Normal;
            Text = "Graph Editor | " + Filename;
            if (Graph.Type == GraphRepresentation.GraphType.DN || Graph.Type == GraphRepresentation.GraphType.DW)
            {
                buttonEllipse2.BackgroundImage = Bitmap.FromFile("span_neactiv.png");
                buttonEllipse2.Enabled = false;
            }
            else
            {
                DijkstraButton.BackgroundImage = Bitmap.FromFile("path_neactiv.png");
                DijkstraButton.Enabled = false;
            }
        }

        public main_window(GraphRepresentation.GraphType Type, string Filename)
        {
            InitializeComponent();
            buttonEllipse1_Click(null, null);
            Graph = new GraphRepresentation();
            Graph.NewGraph(Type, Filename);
            bmp = new Bitmap(2000, 2000);
            g = Graphics.FromImage(bmp);
            Board.BackgroundImage = bmp;
            DisplayGraph();
            State = ProgramStates.Normal;
            Text = "Graph Editor | " + Filename;
            if (Graph.Type == GraphRepresentation.GraphType.DN || Graph.Type == GraphRepresentation.GraphType.DW)
            {
                buttonEllipse2.BackgroundImage = Bitmap.FromFile("span_neactiv.png");
                buttonEllipse2.Enabled = false;
            }
            else
            {
                DijkstraButton.BackgroundImage = Bitmap.FromFile("path_neactiv.png");
                DijkstraButton.Enabled = false;
            }
        }

        private void DisplayGraph()
        {
            DisplayVertices();
            DisplayEdges();
        }

        private Control activeControl;
        private Point PreviousPosition;
        private void DisplayVertices()
        {
            Board.Controls.Clear();
           foreach (Vertex v in Graph.Vertices.Values)
            {
                v.vtb = MakeVertex(v);
                v.vtb.BackColor = Graph.vcolor;
                v.vtb.MouseDown += new MouseEventHandler(vtb_MouseDown);
                v.vtb.MouseUp += new MouseEventHandler(vtb_MouseUp);
                v.vtb.MouseMove += new MouseEventHandler(vtb_MouseMove);
                v.vtb.MouseLeave += new EventHandler(vtb_MouseLeave);
                Board.Controls.Add(v.vtb);
            }
        }
        private void vtb_MouseLeave(object sender, EventArgs a)
        {
            
            InfoPanel.Text = " ";
            InfoPanel.Refresh();
        }

        private void vtb_MouseDown(object sender, MouseEventArgs e)
        {
            InfoPanel.Text = (sender as VertexButton).v.Name;
            if (State == ProgramStates.Normal)
            {
                activeControl = sender as Control;
                PreviousPosition = e.Location;
                Cursor = Cursors.Hand;
            }
            else if (State == ProgramStates.NewEdge1 )
            {
                EdgeHead = (sender as VertexButton).v;
                State = ProgramStates.NewEdge2;
                InfoPanel.Text = "Choose second vertex.";
            }
            else if (State == ProgramStates.NewEdge2)
            {
                EdgeTail = (sender as VertexButton).v;
                State = ProgramStates.Normal;
                MakeEdge();
                InfoPanel.Text = "";

            }
            else if (State == ProgramStates.RmEdge1)
            {
                EdgeHead = (sender as VertexButton).v;
                State = ProgramStates.RmEdge2;
                InfoPanel.Text = "Choose second vertex";
            }
            else if (State == ProgramStates.RmEdge2)
            {
                EdgeTail = (sender as VertexButton).v;
                State = ProgramStates.Normal;
                RmEdge();
                InfoPanel.Text = "";
            }
            else if (State == ProgramStates.Dijkstra1)
            {
                EdgeHead = (sender as VertexButton).v;
                State = ProgramStates.Dijkstra2;
                InfoPanel.Text = "Choose end point.";
            }
            else if (State == ProgramStates.Dijkstra2)
            {
                EdgeTail = (sender as VertexButton).v;
                DrawPath(Dijkstra.FindShortestPath(Graph, EdgeHead, EdgeTail));
                State = ProgramStates.Normal;
            }
            else if (State == ProgramStates.RmVertex)
            {
                Vertex RemovedVertex = (sender as VertexButton).v;
                foreach (Vertex v in Graph.Vertices.Values)
                {
                    foreach ((int, int) edge in v.Edges)
                    {
                        if (edge.Item1 == RemovedVertex.VertexNumber)
                        {
                            v.Edges.Remove(edge);
                            --Graph.EdgeCount;
                            break;
                        }
                    }
                }
                Graph.EdgeCount -= RemovedVertex.Edges.Count;
                Graph.Vertices.Remove(RemovedVertex.VertexNumber);
                --Graph.VertexCount;
                DisplayGraph();
                Board.Refresh();
                State = ProgramStates.Normal;
                InfoPanel.Text = "";
            }
        }


        private void vtb_MouseUp(object sender, MouseEventArgs e)
        {

            activeControl = null;
            Cursor = Cursors.Default;
        }

        private void vtb_MouseMove(object sender, MouseEventArgs e)
        {
            Vertex v = (sender as VertexButton).v;
            if (activeControl == null || activeControl != sender)
            {
                return;
            }
            var location = activeControl.Location;
            location.Offset(e.Location.X - PreviousPosition.X, e.Location.Y - PreviousPosition.Y);
            activeControl.Location = location;
            v.Coordinates = location;
            DisplayEdges();
        }
        private VertexButton MakeVertex(Vertex v)
        {
            var Vertex = new VertexButton(v.Coordinates, v);
            return Vertex;
        }


        private void DisplayEdges()
        {
            g.Clear(Graph.bgcolor);
            BackColor = Graph.bgcolor;
            foreach (int v in Graph.Vertices.Keys)
            {
                foreach ((int, int) w in Graph.Vertices[v].Edges)
                {
                    int x1 = Graph.Vertices[v].Coordinates.X;
                    int y1 = Graph.Vertices[v].Coordinates.Y;
                    int x2 = Graph.Vertices[w.Item1].Coordinates.X;
                    int y2 = Graph.Vertices[w.Item1].Coordinates.Y;
                    int weight = w.Item2;
                    Pen NormalPen = new Pen(Graph.ecolor, 3);
                    System.Drawing.Drawing2D.AdjustableArrowCap Arrow = new System.Drawing.Drawing2D.AdjustableArrowCap(7, 20);
                    Pen ArrowPen = new Pen(Graph.ecolor, 3);
                    ArrowPen.CustomEndCap = Arrow;
                            
                    switch (Graph.Type)
                    {
                        case GraphRepresentation.GraphType.NN:
                            g.DrawLine(NormalPen, x1 + 10, y1 + 10, x2 + 10, y2 + 10);
                            break;
                        case GraphRepresentation.GraphType.NW:
                            g.DrawLine(NormalPen, x1 + 10, y1 + 10, x2 + 10, y2 + 10);
                            g.DrawString(weight.ToString(), Control.DefaultFont, new SolidBrush(Graph.textcolor), (x1+x2)/2, (y1+y2)/2);
                            break;
                        case GraphRepresentation.GraphType.DN:
                            g.DrawLine(ArrowPen, x1 + 10, y1 + 10, x2 + 10, y2 + 10);
                            break;
                        case GraphRepresentation.GraphType.DW:
                            g.DrawLine(ArrowPen, x1 + 10, y1 + 10, x2 + 10, y2 + 10);
                            g.DrawString(weight.ToString(), Control.DefaultFont, new SolidBrush(Graph.textcolor), (x1+x2)/2, (y1+y2)/2);
                            break;
                    }
                }
            }
            Board.Refresh();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEllipse1_Click(object sender, EventArgs e)
        {
            ShowControls = !ShowControls;
            AddVertex.Visible = ShowControls;
            AddEdge.Visible = ShowControls;
            RemoveVertex.Visible = ShowControls;
            RemoveEdge.Visible = ShowControls;
            buttonEllipse2.Visible = ShowControls;
            DijkstraButton.Visible = ShowControls;
            Settings.Visible = ShowControls;
            Save.Visible = ShowControls;
        }


        private void main_window_Load(object sender, EventArgs e)
        {

        }

        private void AddVertex_Click(object sender, EventArgs e)
        {
            State = ProgramStates.NewVertex;
        }

        private void Board_Click(object sender, EventArgs e)
        {
            Point MouseLocation = Board.PointToClient(Cursor.Position);
            if (State == ProgramStates.NewVertex)
            {
                var VertexInfo = new NewVertex();
                if (VertexInfo.ShowDialog() == DialogResult.OK)
                {
                    Graph.AddVertex(MouseLocation, VertexInfo.VertexName);
                    DisplayGraph();
                }
                State = ProgramStates.Normal;
            }
        }

        private Vertex EdgeHead;
        private Vertex EdgeTail;

        private void AddEdge_Click(object sender, EventArgs e)
        {
            State = ProgramStates.NewEdge1;
            InfoPanel.Text = "Choose fisrt vertex.";
        }

        private void MakeEdge()
        {
            switch (Graph.Type)
            {
                case GraphRepresentation.GraphType.NN:
                    EdgeHead.Edges.Add((EdgeTail.VertexNumber, 1));
                    EdgeTail.Edges.Add((EdgeHead.VertexNumber, 1));
                    Graph.EdgeCount += 2;
                    break;
                case GraphRepresentation.GraphType.NW:
                    var EdgeInfo = new NewEdge();
                    if (EdgeInfo.ShowDialog() == DialogResult.OK)
                    {
                        EdgeHead.Edges.Add((EdgeTail.VertexNumber, EdgeInfo.Weight));
                        EdgeTail.Edges.Add((EdgeHead.VertexNumber, EdgeInfo.Weight));
                        Graph.EdgeCount += 2;
                    }
                    break;
                case GraphRepresentation.GraphType.DN:
                    EdgeHead.Edges.Add((EdgeTail.VertexNumber, 1));
                    ++Graph.EdgeCount;
                    break;
                case GraphRepresentation.GraphType.DW:
                    var EdgeInfo1 = new NewEdge();
                    if (EdgeInfo1.ShowDialog() == DialogResult.OK)
                    {
                        EdgeHead.Edges.Add((EdgeTail.VertexNumber, EdgeInfo1.Weight));
                        ++Graph.EdgeCount;
                    }
                    break;
            }
            DisplayEdges();
            Board.Refresh();
        }

        private void RemoveEdge_Click(object sender, EventArgs e)
        {
            State = ProgramStates.RmEdge1;
            InfoPanel.Text = "Choose fisrt vertex.";
        }
        private void RmEdge()
        {
            foreach ((int, int) Edge in EdgeHead.Edges)
            {
                if (Edge.Item1 == EdgeTail.VertexNumber)
                {
                    EdgeHead.Edges.Remove(Edge);
                    --Graph.EdgeCount;
                    break;
                }
            }
            foreach ((int, int) Edge in EdgeTail.Edges)
            {
                if (Edge.Item1 == EdgeHead.VertexNumber)
                {
                    EdgeTail.Edges.Remove(Edge);
                    --Graph.EdgeCount;
                    break;
                }
            }
            DisplayEdges();
            Board.Refresh();
        }

        private void RemoveVertex_Click(object sender, EventArgs e)
        {
            State = ProgramStates.RmVertex;
            InfoPanel.Text = "Choose vertex to remove.";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Graph.SaveGraph();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings SettingsDialog = new Settings(Graph.bgcolor, Graph.vcolor, Graph.ecolor, Graph.textcolor);
            if (SettingsDialog.ShowDialog() == DialogResult.OK)
            {
                Graph.bgcolor = SettingsDialog.bgcolor;
                Graph.vcolor = SettingsDialog.vcolor;
                Graph.ecolor = SettingsDialog.ecolor;
                Graph.textcolor = SettingsDialog.textcolor;
                DisplayGraph();
                Board.Refresh();
            }
        }

        private void buttonEllipse2_Click(object sender, EventArgs e)
        {
            var span = Kruskal.FindMinimalSpan(Graph);
            Pen SpanPen = new Pen(Color.FromArgb(128, Color.Orange), 5);
            foreach ((int, int, int) edge in span)
            {
                Point StartPoint = Graph.Vertices[edge.Item2].Coordinates;
                StartPoint.Offset(10, 10);
                Point EndPoint = Graph.Vertices[edge.Item3].Coordinates;
                StartPoint.Offset(10, 10);
                g.DrawLine(Pens.Red, StartPoint, EndPoint);
            }
            Board.Refresh();
        }

        private void DijkstraButton_Click(object sender, EventArgs e)
        {
            State = ProgramStates.Dijkstra1;
            InfoPanel.Text = "Choose start point";
        }
        private void DrawPath((int, int)[] path)
        {
            string Info = "";
            Pen PathPen = new Pen(Color.FromArgb(128, Color.Red), 5);
            foreach ((int, int) edge in path)
            {
                Point StartPoint = Graph.Vertices[edge.Item1].Coordinates;
                StartPoint.Offset(10, 10);
                Point EndPoint = Graph.Vertices[edge.Item2].Coordinates;
                EndPoint.Offset(10, 10);
                g.DrawLine(PathPen, StartPoint, EndPoint);
                Info = Graph.Vertices[edge.Item1].Name + " -> " + Info;
            }
            InfoPanel.Text = Info;
            Board.Refresh();
        }

        private void ShowMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ShowMenu.BackgroundImage = Bitmap.FromFile("menu_zm.png");
        }

        private void ShowMenu_MouseUp(object sender, MouseEventArgs e)
        {
            ShowMenu.BackgroundImage = Bitmap.FromFile("menu.png");
        }

        private void AddVertex_MouseDown(object sender, MouseEventArgs e)
        {
            AddVertex.BackgroundImage = Bitmap.FromFile("v+_zm.png");
        }

        private void AddVertex_MouseUp(object sender, MouseEventArgs e)
        {
            AddVertex.BackgroundImage = Bitmap.FromFile("v+.png");
        }

        private void AddEdge_MouseDown(object sender, MouseEventArgs e)
        {
            AddEdge.BackgroundImage = Bitmap.FromFile("e+_zm.png");
        }

        private void AddEdge_MouseUp(object sender, MouseEventArgs e)
        {
            AddEdge.BackgroundImage = Bitmap.FromFile("e+.png");
        }

        private void RemoveVertex_MouseDown(object sender, MouseEventArgs e)
        {
            RemoveVertex.BackgroundImage = Bitmap.FromFile("v-_zm.png");
        }

        private void RemoveVertex_MouseUp(object sender, MouseEventArgs e)
        {
            RemoveVertex.BackgroundImage = Bitmap.FromFile("v-.png");
        }

        private void RemoveEdge_MouseDown(object sender, MouseEventArgs e)
        {
            RemoveEdge.BackgroundImage = Bitmap.FromFile("e-_zm.png"); 
        }

        private void RemoveEdge_MouseUp(object sender, MouseEventArgs e)
        {
            RemoveEdge.BackgroundImage = Bitmap.FromFile("e-.png");
        }

        private void buttonEllipse2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Graph.Type == GraphRepresentation.GraphType.NN || Graph.Type == GraphRepresentation.GraphType.NW)
                buttonEllipse2.BackgroundImage = Bitmap.FromFile("span_zm.png");
        }

        private void buttonEllipse2_MouseUp(object sender, MouseEventArgs e)
        {
            if (Graph.Type == GraphRepresentation.GraphType.NN || Graph.Type == GraphRepresentation.GraphType.NW)
                buttonEllipse2.BackgroundImage = Bitmap.FromFile("span.png");
        }

        private void DijkstraButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (Graph.Type == GraphRepresentation.GraphType.DN || Graph.Type == GraphRepresentation.GraphType.DW)
                DijkstraButton.BackgroundImage = Bitmap.FromFile("path_zm.png");
        }

        private void DijkstraButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (Graph.Type == GraphRepresentation.GraphType.DN || Graph.Type == GraphRepresentation.GraphType.DW)
                DijkstraButton.BackgroundImage = Bitmap.FromFile("path.png");
        }

        private void Save_MouseDown(object sender, MouseEventArgs e)
        {
            Save.BackgroundImage = Bitmap.FromFile("save_zm.png");
        }

        private void Save_MouseUp(object sender, MouseEventArgs e)
        {
            Save.BackgroundImage = Bitmap.FromFile("save.png");
        }

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            Settings.BackgroundImage = Bitmap.FromFile("sett_zm.png");
        }

        private void Settings_MouseUp(object sender, MouseEventArgs e)
        {
            Settings.BackgroundImage = Bitmap.FromFile("sett.png");
        }
    }
}
