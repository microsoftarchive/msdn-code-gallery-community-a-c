using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huffman
{
    public struct CharFreq
    {
        public char ch;
        public int freq;
    }

    public class PriorityQueue
    {
        int heapSize;
        List<BinaryTreeNode<CharFreq>> nodeList;

        public List<BinaryTreeNode<CharFreq>> NodeList
        {
            get
            {
                return nodeList;
            }
        }

        public PriorityQueue()
        {
            nodeList = new List<BinaryTreeNode<CharFreq>>();
        }

        public PriorityQueue(List<BinaryTreeNode<CharFreq>> nl)
        {
            heapSize = nl.Count;
            nodeList = new List<BinaryTreeNode<CharFreq>>();

            for (int i = 0; i < nl.Count; i++)
                nodeList.Add(nl[i]);
        }

        public void exchange(int i, int j)
        {
            BinaryTreeNode<CharFreq> temp = nodeList[i];

            nodeList[i] = nodeList[j];
            nodeList[j] = temp;
        }

        public void heapify(int i)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int largest = -1;

            if (l < heapSize && nodeList[l].Value.ch > nodeList[i].Value.ch)
                largest = l;
            else
                largest = i;
            if (r < heapSize && nodeList[r].Value.ch > nodeList[largest].Value.ch)
                largest = r;
            if (largest != i)
            {
                exchange(i, largest);
                heapify(largest);
            }
        }

        public void buildHeap()
        {
            for (int i = heapSize / 2; i >= 0; i--)
                heapify(i);
        }

        public int size()
        {
            return heapSize;
        }

        public BinaryTreeNode<CharFreq> elementAt(int i)
        {
            return nodeList[i];
        }

        public void heapSort()
        {
            int temp = heapSize;

            buildHeap();

            for (int i = heapSize - 1; i >= 1; i--)
            {
                exchange(0, i);
                heapSize--;
                heapify(0);
            }

            heapSize = temp;
        }

        public BinaryTreeNode<CharFreq> extractMin()
        {
            if (heapSize < 1)
                return null;

            heapSort();

            exchange(0, heapSize - 1);
            heapSize--;

            BinaryTreeNode<CharFreq> node = nodeList[heapSize];

            nodeList.RemoveAt(heapSize);
            heapSize = nodeList.Count;
            return node;
        }

        public void insert(BinaryTreeNode<CharFreq> node)
        {
            nodeList.Add(node);
            heapSize = nodeList.Count;
            buildHeap();
        }
    }
}