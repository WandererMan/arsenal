using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sequence;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SeqList<int> la = new SeqList<int>(5);
            SeqList<int> lb = new SeqList<int>(5);

            la.Append(5);
            la.Append(8);
            la.Append(5);
            la.Append(8);
            la.Append(18);


            //lb.Append(1);
            //lb.Append(3);
            //lb.Append(4);
            //lb.Append(7);
            //lb.Append(9);

            SeqList<int> lc = SeqList<int>.Purge(la);

            //int i = 0;
            //int j = 0;
            //for ( i = 0; i < 5; i++)
            //{
            //    Test();
            //} 

            //Console.WriteLine(j);

            Console.ReadLine();
        }

        static int last = 0;
        public static void Test()
        {
            ++last;
            //last++;
        }
    }
}
