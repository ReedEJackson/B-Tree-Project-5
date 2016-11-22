using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Node
    {
        #region Local Values

        private Random rand = new Random();

        #endregion

        #region Properites

        public int NodeSize { get; set; }

        public List<int> Items { get; set; }

        #endregion

        #region Constructors

        public Node()
        {
            NodeSize = 5;
        }

        public Node(int nodeSize)
        {
            NodeSize = nodeSize;
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            string result = "";
            result += $"Node Size: {Items.Count} out of {NodeSize}\n" + 
                      $"Item List:\n";
            for (int i = 0; i < Items.Count; i++)
            {
                result += $"{Items[i]} ";
            }
            return result;
        }

        #endregion
    }
}
