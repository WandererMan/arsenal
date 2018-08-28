﻿using System;
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
            DBLinkList<int> dlink = new DBLinkList<int>();// 创建双向链表
            Console.WriteLine("将 10 插入到表头之后");
            dlink.Append(0, 10);
            dlink.ShowAll();
            Console.WriteLine("将 30 插入到表头之后");
            dlink.Append(1, 30);
            dlink.ShowAll();
            Console.WriteLine("将 40 插入到表头之前");
            dlink.Insert(0, 40);
            dlink.ShowAll();
            Console.WriteLine("将 20 插入到第一个位置之前");
            dlink.Insert(1, 20);
            dlink.ShowAll();
            dlink.ReversLinkList(dlink);
            Console.WriteLine("将顺序倒置");
            dlink.ShowAll();

            //var l= LinkList<int>.CreateListHead();
            // l.ReversLinkList(l);
            // l.PrintAllItem();
            Console.ReadLine();
        }

    }
}
