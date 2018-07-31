using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject 
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            for ( i = 0; i < 5; i++)
            {
                Test();
            } 

            Console.WriteLine(i);
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
