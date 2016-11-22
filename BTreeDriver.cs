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

            List<int> tempList = new List<int>();
            for (int i = 1; i < 20; i++) //20 = 500
            {
                tempList.Add(rand.Next(51)); //0 - 9999
            }
        }
    }
}
