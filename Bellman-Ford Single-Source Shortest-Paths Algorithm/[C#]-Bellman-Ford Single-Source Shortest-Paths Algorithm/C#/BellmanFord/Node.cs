using System;
using System.Collections.Generic;

namespace BellmanFord
{
    class Node
    {
        int distance, id;
        string name;
        List<int> weights;
        List<Node> adjacency;

        public Node(int distance, int id, string name)
        {
            this.distance = distance;
            this.id = id;
            this.name = name;
            weights = new List<int>();
            adjacency = new List<Node>();
        }

        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public List<Node> Adjacency
        {
            get
            {
                return adjacency;
            }
            set
            {
                adjacency = value;
            }
        }

        public List<int> Weights
        {
            get
            {
                return weights;
            }
            set
            {
                weights = value;
            }
        }
    }
}
