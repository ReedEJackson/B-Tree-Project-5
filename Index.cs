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

        public List<Node> IndexList { get; set; }

        #endregion

        #region Constructors

        public Index()
        {
            NodeSize = base.NodeSize;
            Items = base.Items;
        }

        public Index(int nodeSize)
        {
            NodeSize = nodeSize;
            Items = base.Items;
        }

        #endregion

        #region Insertion Methods

        public INSERT Insert(int value)
        {
            //Initial Values
            int i;
            Items.Add(value);

            //Position temp to the smallest place it 
            //can go
            for (i = Items.Count - 1; (i > 0 && value <= Items[i - 1]); i--)
            {
                //This prevents duplicates from being added
                if (Items[i - 1] == value)
                {
                    //Undo changes to Items List
                    for (int j = i; j < Items.Count - 2; j++)
                    {
                        Items[i + 1] = Items[i + 2];
                    }

                    //Remove top value
                    Items.RemoveAt(Items.Count - 1);
                    return INSERT.DUPLICATE;
                }
                else
                {
                    Items[i] = Items[i - 1];
                }
            }

            //Insert the value to the selected position
            Items[i] = value;

            //Set return message
            if (Items.Count > NodeSize)
            {
                return INSERT.NEEDSPLIT;
            }
            else
            {
                return INSERT.SUCCESS;
            }
        }

        //private bool DuplicatesExist(int index)
        //{
        //    for (int i = 0; i < Items.Count; i++)
        //    {
        //        if (i == index)
        //        {
        //            //Do Nothing since the values are the same
        //        }
        //        else if (Items[i] == Items[index])
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

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
