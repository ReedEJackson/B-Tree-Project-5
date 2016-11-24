using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project5
{
    class BTree
    {
        #region Properties

        public int NodeCount { get; set; }

        public int IndexCount { get; set; }

        public int LeafCount { get; set; }

        public int NodeSize { get; set; }

        public Index Root { get; set; }

        public List<Index> IndexList { get; set; }

        public Stack<Node> MainStack { get; set; }

        public bool Trace { get; set; }

        #endregion

        #region Constructors

        public BTree(int arity)
        {
            NodeSize = arity;
            Root = new Index();
            IndexList = new List<Index>();

            //Initialize counts
            NodeCount = 0;
            IndexCount = 0;
            LeafCount = 0;
        }

        public bool AddedValue(int value)
        {
            #region Initialize first value and Root

            if (NodeCount == 0)
            {
                Index FirstIndex = new Index(NodeSize);
                Leaf FirstLeaf = new Leaf(NodeSize);

                //Add value to the first Index and Leaf
                FirstIndex.Items.Add(value);
                FirstLeaf.Items.Add(value);

                //Reference first Leaf
                FirstIndex.LeafList.Add(FirstLeaf);

                //Add index to IndexList and Root
                Root = new Index(FirstIndex);
                IndexList.Add(Root);

                //Increment Counts
                NodeCount++;
                IndexCount++;
                LeafCount++;
                return true;
            }

            #endregion

            else
            {
                //Find Leaf to insert value
                Leaf FilledLeaf = FindLeaf(value);
            }
            return true;

            //WriteLine($"FirstIndex:\n{FirstIndex}\n" + 
            //          $"FirstLeaf:\n{FirstLeaf}\n" + 
            //          $"Root:\n{Root}\n");
        }

        #endregion

        #region Find Leaf

        public Leaf FindLeaf(int value)
        {
            //Initialize starting point
            Index SearchIndex = new Index(Root);

            //Find Deepest Index
            bool foundLeaf = false;
            while (foundLeaf == true)
            {
                if (SearchIndex.IndexList.Count == 0)
                {
                    foundLeaf = true;
                }
                else
                {

                }
            }

            //Find Leaf

            return new Leaf(NodeSize);
        }

        #endregion
    }
}
