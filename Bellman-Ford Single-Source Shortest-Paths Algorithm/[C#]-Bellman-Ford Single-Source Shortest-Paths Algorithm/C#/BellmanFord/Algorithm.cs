using System;
using System.Collections.Generic;

namespace BellmanFord
{
    class Algorithm
    {
        public bool BellmanFord(ref int[] pi, ref List<Node> G, int s)
        {
            InitializeSingleSource(ref pi, ref G, s);

            for (int i = 0; i < G.Count - 1; i++)
            {
                Node u = G[i];

                for (int j = 0; j < u.Adjacency.Count; j++)
                {
                    Node v = u.Adjacency[j];
                    int w = u.Weights[j];

                    Relax(ref pi, u, ref v, w);

                    for (int k = 0; k < v.Adjacency.Count; k++)
                    {
                        Node x = v.Adjacency[k];

                        w = v.Weights[k];
                        Relax(ref pi, v, ref x, w);
                    }
                }
            }

            for (int i = 0; i < G.Count; i++)
            {
                Node u = G[i];

                for (int j = 0; j < u.Adjacency.Count; j++)
                {
                    Node v = u.Adjacency[j];
                    int w = u.Weights[j];

                    if (v.Distance > u.Distance + w)
                        return false;
                }
            }

            return true;
        }

        private void InitializeSingleSource(ref int[] pi, ref List<Node> nodeList, int s)
        {
            pi = new int[nodeList.Count];

            for (int i = 0; i < pi.Length; i++)
                pi[i] = -1;

            nodeList[s].Distance = 0;
        }

        private void Relax(ref int[] pi, Node u, ref Node v, int w)
        {
            if (v.Distance > u.Distance + w)
            {
                v.Distance = u.Distance + w;
                pi[v.Id] = u.Id;
            }
        }
    }
}
