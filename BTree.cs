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

                //Reference initial and first Leaf
                FirstIndex.LeafList.Add(new Leaf(NodeSize));
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
                Leaf LeafToFill = FindLeaf(value);
                INSERT response = LeafToFill.Insert(value);
                if (response == INSERT.DUPLICATE)
                {
                    //Do nothing since you need a unique new value
                    return false;
                }
                else if(response == INSERT.NEEDSPLIT)
                {
                    SplitLeaf(LeafToFill);
                    return true;
                }
                else
                {
                    //Success!
                    return true;
                }
            }

            //WriteLine($"FirstIndex:\n{FirstIndex}\n" + 
            //          $"FirstLeaf:\n{FirstLeaf}\n" + 
            //          $"Root:\n{Root}\n");
        }

        #endregion

        #region Finding Nodes on Tree Methods

        public Leaf FindLeaf(int value)
        {
            //Initialize starting point
            Index SearchIndex = new Index(Root);
            Leaf LeafToInsert = new Leaf(NodeSize);

            //Find Deepest Index
            bool foundLeaf = false;
            while (foundLeaf == true)
            {
                if (SearchIndex.IndexList.Count == 0)
                {
                    //Exit once found
                    foundLeaf = true;
                }
                else
                {
                    //Find the next Index to go to
                    SearchIndex = FindIndex(SearchIndex, value);
                }
            }

            //Find Leaf needed to insert into
            for (int i = 1; i < SearchIndex.Items.Count; i++)
            {
                if (value < SearchIndex.Items[i])
                {
                    return SearchIndex.LeafList[i];
                }
            }

            //Add Index if needed
            if (SearchIndex.Items.Count < NodeSize)
            {
                SearchIndex.Items.Add(value);
                SearchIndex.LeafList.Add(LeafToInsert);
                return LeafToInsert;
            }
            else
            {
                //Return last leaf in index
                return SearchIndex.LeafList[NodeSize];
            }
        }

        public Index FindIndex(Index SearchIndex, int value)
        {
            for (int i = 1; i < SearchIndex.IndexList.Count; i++)
            {
                if (value < SearchIndex.Items[i])
                {
                    //Return the previous index
                    return SearchIndex.IndexList[i - 1];
                }
            }

            //If value is larger than all put it
            //in the last Index
            return SearchIndex.IndexList[NodeSize - 1];
        }

        #endregion

        #region Splitting Nodes on Tree Methods

        public void SplitLeaf(Leaf FullLeaf)
        {
            int half = FullLeaf.Items.Count / 2;
        }

        #endregion
    }
}
