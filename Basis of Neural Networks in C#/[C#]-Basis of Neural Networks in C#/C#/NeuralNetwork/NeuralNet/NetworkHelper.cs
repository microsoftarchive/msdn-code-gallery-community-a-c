using NeuralNet.NeuralNet;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNet
{
    public static class NetworkHelper
    {
        public static void ToTreeView(TreeView t, NeuralNetwork nn)
        {
            t.Nodes.Clear();

            TreeNode root = new TreeNode("NeuralNetwork");

            nn.Layers.ForEach((layer) =>
            {
                TreeNode lnode = new TreeNode("Layer");

                layer.Neurons.ForEach((neuron) =>
                {
                    TreeNode nnode = new TreeNode("Neuron");
                    nnode.Nodes.Add("Bias: " + neuron.Bias.ToString());
                    nnode.Nodes.Add("Delta: " + neuron.Delta.ToString());
                    nnode.Nodes.Add("Value: " + neuron.Value.ToString());

                    neuron.Dendrites.ForEach((dendrite) =>
                    {
                        TreeNode dnode = new TreeNode("Dendrite");
                        dnode.Nodes.Add("Weight: " + dendrite.Weight.ToString());

                        nnode.Nodes.Add(dnode);
                    });

                    lnode.Nodes.Add(nnode);
                });

                root.Nodes.Add(lnode);
            });

            //root.ExpandAll();
            t.Nodes.Add(root);
        }

        public static void ToPictureBox(PictureBox p, NeuralNetwork nn, int X, int Y)
        {
            int neuronWidth    = 30;
            int neuronDistance = 50;
            int layerDistance  = 50;
            int fontSize       = 8;

            Bitmap b = new Bitmap(p.Width, p.Height);
            Graphics g = Graphics.FromImage(b);

            g.FillRectangle(Brushes.White, g.ClipBounds);

            int y = Y;

            for(int l = 0; l < nn.Layers.Count; l++)
            {
                Layer layer = nn.Layers[l];

                int x = X - (neuronDistance * (layer.Neurons.Count / 2)) ;

                for (int n = 0; n < layer.Neurons.Count; n++)
                {
                    Neuron neuron = layer.Neurons[n];

                    for (int d = 0; d < neuron.Dendrites.Count; d++)
                    {
                        // TO DO: optionally draw dendrites between neurons
                    };

                    g.FillEllipse(Brushes.WhiteSmoke, x, y, neuronWidth, neuronWidth);
                    g.DrawEllipse(Pens.Gray, x, y, neuronWidth, neuronWidth);
                    g.DrawString(neuron.Value.ToString("0.00"), new Font("Arial", fontSize), Brushes.Black, x + 2, y + (neuronWidth / 2) - 5);

                    x += neuronDistance;
                };

                y += layerDistance;
            };

            p.Image = b;
        }

    }
}
