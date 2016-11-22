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

        #region Sorting Methods

        #region Start Sort

        public void RunSort()
        {
            if (NodeSize <= 20)
                InsertionSort();
            else
                ShellSort();
        } 

        #endregion

        #region Insertion Sort

        /// <summary>
        /// Used to sort a list of int values using
        /// Insertion Sort
        /// </summary>
        private void InsertionSort()
        {
            int temp, j;
            for (int i = 1; i < Items.Count; i++)
            {
                //Value to insert
                temp = Items[i];

                //Position temp to the smallest place it 
                //can go
                for (j = i; (j > 0 && temp < Items[j - 1]); j--)
                {
                    Items[j] = Items[j - 1];
                }

                //Insert temp to the selected position
                Items[j] = temp;
            }
        }

        #endregion

        #region Shell Sort

        /// <summary>
        /// Used to sort a list of int values using
        /// Shell Sort
        /// </summary>
        private void ShellSort()
        {
            for (int gap = this.Items.Count / 2; gap > 0;
                 gap = (gap == 2 ? 1 : (int)(gap / 2.2)))
            {
                int temp, j;
                for (int i = gap; i < this.Items.Count; i++)
                {
                    temp = Items[i];
                    for (j = i; j >= gap && temp < Items[j - gap]; j -= gap)
                    {
                        Items[j] = Items[j - gap];
                    }
                    Items[j] = temp;
                }
            }
        }

        #endregion 
        
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
