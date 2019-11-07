using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BellmanFord
{
    public partial class MainForm : Form
    {
        private const int Infinity = int.MaxValue;
        private bool val;
        private int n, x, y, x1, y1, x2, y2;
        private int[] pi;
        private Algorithm algo;
        private List<int> S;
        private List<Node> nodeList;

        public MainForm()
        {
            InitializeComponent();
            CreateGraph();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        void CreateGraph()
        {
            Node nodeA = new Node(Infinity, 0, "a");
            Node nodeB = new Node(Infinity, 1, "b");
            Node nodeC = new Node(Infinity, 2, "c");
            Node nodeD = new Node(Infinity, 3, "d");
            Node nodeE = new Node(Infinity, 4, "e");

            List<int> weightsA = new List<int>();
            List<int> weightsB = new List<int>();
            List<int> weightsC = new List<int>();
            List<int> weightsD = new List<int>();
            List<int> weightsE = new List<int>();

            List<Node> edgesA = new List<Node>();
            List<Node> edgesB = new List<Node>();
            List<Node> edgesC = new List<Node>();
            List<Node> edgesD = new List<Node>();
            List<Node> edgesE = new List<Node>();

            weightsA.Add(6);
            weightsA.Add(7);
            edgesA.Add(nodeB);
            edgesA.Add(nodeE);

            weightsB.Add(5);
            weightsB.Add(-4);
            weightsB.Add(8);
            edgesB.Add(nodeC);
            edgesB.Add(nodeD);
            edgesB.Add(nodeE);

            weightsC.Add(-2);
            edgesC.Add(nodeB);

            weightsD.Add(7);
            edgesD.Add(nodeC);

            weightsE.Add(-3);
            weightsE.Add(9);
            edgesE.Add(nodeC);
            edgesE.Add(nodeD);

            nodeA.Adjacency = edgesA;
            nodeA.Weights = weightsA;

            nodeB.Adjacency = edgesB;
            nodeB.Weights = weightsB;

            nodeC.Adjacency = edgesC;
            nodeC.Weights = weightsC;

            nodeD.Adjacency = edgesD;
            nodeD.Weights = weightsD;

            nodeE.Adjacency = edgesE;
            nodeE.Weights = weightsE;

            nodeList = new List<Node>();

            nodeList.Add(nodeA);
            nodeList.Add(nodeB);
            nodeList.Add(nodeC);
            nodeList.Add(nodeD);
            nodeList.Add(nodeE);
            n = nodeList.Count;

            algo = new Algorithm();
            val = algo.BellmanFord(ref pi, ref nodeList, 0);
        }

        private void calculateXY(int id)
        {
            int Width = panel1.Width;
            int Height = panel1.Height;

            x = Width / 2 + (int)(Width * Math.Cos(2 * id * Math.PI / n) / 4.0);
            y = Height / 2 + (int)(Width * Math.Sin(2 * id * Math.PI / n) / 4.0);
        }

        private void draw(Graphics g)
        {
            for (int i = 0; i < n; i++)
            {
                if (pi[i] != -1)
                {
                    int Width = panel1.Width;
                    int Height = panel1.Height;
                    Font font = new Font("Courier New", 12f, FontStyle.Bold);
                    Node nodeI = nodeList[i];
                    Node nodeJ = nodeList[pi[i]];
                    Pen pen = new Pen(Color.Black);
                    SolidBrush textBrush = new SolidBrush(Color.White);

                    calculateXY(nodeI.Id);
                    x1 = x + (Width / 2) / n / 2;
                    y1 = y + (Width / 2) / n / 2;
                    calculateXY(nodeJ.Id);
                    x2 = x + (Width / 2) / n / 2;
                    y2 = y + (Width / 2) / n / 2;
                    g.DrawLine(pen, x1, y1, x2, y2);

                    SolidBrush brush = new SolidBrush(Color.Blue);

                    calculateXY(nodeI.Id);
                    g.FillEllipse(brush, x, y, (Width / 2) / n, (Width / 2) / n);
                    g.DrawString(nodeI.Name, font,
                        textBrush, (float)(x + (Width / 2) / n / 2) - 12f,
                        (float)(y + (Width / 2) / n / 2) - 12f);
                    calculateXY(nodeJ.Id);
                    g.FillEllipse(brush, x, y, (Width / 2) / n, (Width / 2) / n);
                    g.DrawString(nodeJ.Name, font,
                        textBrush, (float)(x + (Width / 2) / n / 2) - 12f,
                        (float)(y + (Width / 2) / n / 2) - 12f);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs pea)
        {
            draw(pea.Graphics);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(ClientSize.Width, ClientSize.Height);
            panel1.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(ClientSize.Width, ClientSize.Height);
            panel1.Invalidate();
        }
    }
}
