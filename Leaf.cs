using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Leaf : Node
    {
        #region Constructors

        public Leaf()
        {
            NodeSize = base.NodeSize;
            Items = base.Items;
        }

        public Leaf(int nodeSize)
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
    }
}
