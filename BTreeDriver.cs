using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class BTreeDriver
    {
        private static Random rand = new Random();
        static void Main()
        {
            //Welcome message

            //Main Menu

            //Set arity and create B-Tree
            //User set arity
            int arity = 3;
            BTree userTree = new BTree(arity);

            bool getNextValue = false;
            for (int i = 1; i < 20; i++) //20 = 500
            {
                while (getNextValue == false)
                {
                    getNextValue = userTree.AddValue(rand.Next(100)); //0 - 9999
                }
                getNextValue = false;
            }
        }
    }
}
