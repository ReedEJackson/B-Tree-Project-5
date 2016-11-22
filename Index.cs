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

        public INSERT Insert(int index)
        {
            //Initial Values
            int temp = Items[index];
            int j;

            //Position temp to the smallest place it 
            //can go
            for (j = index; (j > 0 && temp < Items[j - 1]); j--)
            {
                Items[j] = Items[j - 1];
                if (Items[j] == Items[index])
                {
                    return INSERT.DUPLICATE;
                }
            }

            //Insert temp to the selected position
            Items[j] = temp;

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

        //private bool DuplicatesExist(int index, int value)
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
    }
}
