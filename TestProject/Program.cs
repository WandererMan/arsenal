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
            //LinkList<int> linkList = new LinkList<int>();

            //var l = LinkList<int>.CreateListTail();
            //l.插入元素X到单链表中的合适位置(l, 2);

            //var p = l.Head;
            //while (p!=null)
            //{
            //    Console.WriteLine(p.Data);
            //    p = p.Next;
            //}

            SeqList<int> sl = new SeqList<int>(11);
            sl.Append(20);
            sl.Append(54);
            sl.Append(88);
            sl.Append(1);
            sl.Append(10);
            sl.Append(28);
            sl.Append(7);
            sl.Append(55);
            sl.Append(55);
            sl.Append(69);
            sl.Append(555);
            var s=  sl.GetMinValue(sl);
            Console.WriteLine(s);

            Console.ReadLine();
        }

    }
}
