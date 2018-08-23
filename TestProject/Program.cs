using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListDemo;
using Sequence;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList<int> linkList = new LinkList<int>();

            var l = LinkList<int>.CreateListTail();
            l.插入元素X到单链表中的合适位置(l, 2);

            var p = l.Head;
            while (p!=null)
            {
                Console.WriteLine(p.Data);
                p = p.Next;
            }

            Console.ReadLine();
        }

    }
}
