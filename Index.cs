//	Project:		Project 5 - BTree
//	File Name:		Index.cs
//	Description:	
//	Course:			CSCI 2210-001 - Data Structures
//	Authors:		Reed Jackson, reedejackson@gmail.com, jacksonre@etsu.edu
//                  Other Author
//                  Other Author
//	Created:		11/23/2016
//	Copyright:		Reed Jackson, Author, Author, 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Index : Node
    {
        #region Properties

        public List<Index> IndexList { get; set; }

        public List<Leaf> LeafList { get; set; }

        #endregion

        #region Constructors

        public Index()
        {
            IndexList = new List<Index>(base.NodeSize);
            LeafList = new List<Leaf>(base.NodeSize);
            Items.Add(-1);
        }

        public Index(int nodeSize)
        {
            NodeSize = nodeSize;
            IndexList = new List<Index>(NodeSize);
            LeafList = new List<Leaf>(NodeSize);
            Items.Add(-1);
        }

        public Index(Index CopyIndex)
        {
            NodeSize = CopyIndex.NodeSize;
            IndexList = CopyIndex.IndexList;
            LeafList = CopyIndex.LeafList;
            Items = new List<int>(CopyIndex.Items);
        }

        #endregion

        #region Insertion Methods

        public void Insert(int value, Index LeftIndex, Index RightIndex)
        {
            //Initial Values
            int i;
            Items.Add(value);

            //Position temp to the smallest place it 
            //can go
            for (i = Items.Count - 1; (i > 0 && value <= Items[i - 1]); i--)
            {
                Items[i] = Items[i - 1];
            }

            //Insert the value to the selected position
            Items[i] = value;

            //Set Index References
            IndexList.RemoveAt(i - 1);
            IndexList.RemoveAt(i);
            IndexList.Insert(i - 1, LeftIndex);
            IndexList.Insert(i, RightIndex);
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
    }
}
