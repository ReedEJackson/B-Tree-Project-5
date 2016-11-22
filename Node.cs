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

            for (int i = 0; i < NodeSize; i++)
            {
                Items.Add(rand.Next(51)); //0 - 9999
            }
            InsertionSort(Items);
        }

        public Node(int nodeSize)
        {
            NodeSize = nodeSize;

            for (int i = 0; i < NodeSize; i++)
            {
                Items.Add(rand.Next(51)); //0 - 9999
            }
            InsertionSort(Items);
        }

        #endregion

        #region Insertion Sort

        /// <summary>
        /// Used to sort a list of int values using
        /// Insertion Sort
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>sorted int list</returns>
        private static List<int> InsertionSort(List<int> list)
        {
            int temp, j;
            for (int i = 1; i < list.Count; i++)
            {
                //Value to insert
                temp = list[i];

                //Position temp to the smallest place it 
                //can go
                for (j = i; (j > 0 && temp < list[j - 1]); j--)
                {
                    list[j] = list[j - 1];
                }

                //Insert temp to the selected position
                list[j] = temp;
            }
            return list;
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
