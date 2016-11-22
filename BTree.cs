using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class BTree
    {
        #region Properties

        public int NodeCount { get; set; }

        public int IndexCount { get; set; }

        public int LeafCount { get; set; }

        public int NodeSize { get; set; }

        public Node Root { get; set; }

        public Stack<Node> MainStack { get; set; }

        public bool Trace { get; set; }

        #endregion

        #region Constructors

        public BTree(int arity)
        {
            NodeSize = arity;

            //Initialize counts
            NodeCount = 0;
            IndexCount = 0;
            LeafCount = 0;
        }

        public bool AddValue(int value)
        {
            if (NodeCount == 0)
            {
                Root = new Node(NodeSize);
                NodeCount++;
            }
            return true;
        }

        #endregion
    }
}
