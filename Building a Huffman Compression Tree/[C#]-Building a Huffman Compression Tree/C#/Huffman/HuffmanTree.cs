using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huffman
{
    public class HuffmanTree
    {
        public BinaryTreeNode<CharFreq> Build(List<CharFreq> charFreq, int n)
        {
            PriorityQueue Q = new PriorityQueue();

            for (int i = 0; i < n; i++)
            {
                BinaryTreeNode<CharFreq> z = new BinaryTreeNode<CharFreq>(charFreq[i]);

                Q.insert(z);
            }

            Q.buildHeap();

            for (int i = 0; i < n - 1; i++)
            {
                BinaryTreeNode<CharFreq> x = Q.extractMin();
                BinaryTreeNode<CharFreq> y = Q.extractMin();
                CharFreq chFreq = new CharFreq();

                chFreq.ch = (char)((int)x.Value.ch + (int)y.Value.ch);
                chFreq.freq = x.Value.freq + y.Value.freq;

                BinaryTreeNode<CharFreq> z = new BinaryTreeNode<CharFreq>(chFreq);

                z.Left = x;
                z.Right = y;
                Q.insert(z);
            }

            return Q.extractMin();
        }
    }
}