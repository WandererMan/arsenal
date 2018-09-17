﻿using ILinear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDemo
{
    /// <summary>
    /// 单链表
    /// </summary>
    public class LinkList<T> : IListDS<T>
    {
        /// <summary>
        /// 单链表的头引用
        /// </summary>
        private Node<T> head;

        /// <summary>
        /// 头引用属性
        /// </summary>
        public Node<T> Head { get { return head; } set { head = value; } }

        public LinkList()
        {
            head = null;
        }

        /// <summary>
        /// 求单链表的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            Node<T> p = head;

            int len = 0;
            while (p != null)
            {
                len++;
                p = p.Next;
            }
            return len;
        }

        /// <summary>
        /// 判断单链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 在单链表的末尾添加新元素
        /// </summary>
        /// <param name="item"></param>
        public void Append(T item)
        {
            Node<T> q = new Node<T>(item);
            Node<T> p;//= new Node<T>();

            if (head == null)
            {
                head = q;
                return;
            }
            p = head;

            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = q;
        }

        /// <summary>
        /// 在单链表的第i个结点的位置前插入一个值为item的结点
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void Insert(T item, int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("链表是空的或插入位置有误");
                return;
            }

            if (i == 1)
            {
                Node<T> q = new Node<T>(item);
                q.Next = head;
                head = q;
                return;
            }

            Node<T> p = head;
            Node<T> r = new Node<T>();
            int j = 1;
            while (p.Next != null && j < i)
            {
                r = p;
                p = p.Next;
                j++;
            }

            if (j == i)
            {
                Node<T> q = new Node<T>(item);
                q.Next = p;
                r.Next = q;
            }
        }

        /// <summary>
        /// 删除单链表的第i个结点
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Delete(int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("链表是空的或删除位置有误");
                return default(T);
            }

            Node<T> q = new Node<T>();

            if (i == 1)
            {
                q = head;
                head = head.Next;
                return q.Data;
            }

            Node<T> p = head;
            int j = 1;

            while (p.Next != null && j < i)
            {
                j++;
                q = p;
                p = p.Next;
            }

            if (j == i)
            {
                q.Next = p.Next;
                return p.Data;
            }
            else
            {
                Console.WriteLine("第i个节点不存在");
                return default(T);
            }
        }

        /// <summary>
        /// 清空单链表
        /// </summary>
        public void Clear()
        {
            head = null;
        }

        /// <summary>
        /// 获取单链表的第i个数据元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElm(int i)
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空");
                return default(T);
            }

            Node<T> p = head;
            int j = 1;
            while (p.Next != null && j < i)
            {
                j++;
                p = p.Next;
            }

            if (j == i)
            {
                return p.Data;
            }
            else
            {
                Console.WriteLine("第i个节点不存在");
                return default(T);
            }
        }

        /// <summary>
        /// 在单链表中查找值为Value的结点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空");
                return -1;
            }

            Node<T> p = new Node<T>();
            p = head;
            int i = 1;
            while (!p.Data.Equals(value) && p.Next != null)
            {
                p = p.Next;
                i++;
            }
            return i;
        }

        /// <summary>
        /// 将单链表倒置
        /// </summary>
        public void ReversLinkList(LinkList<int> H)
        {
            Node<int> p = H.Head.Next;
            Node<int> q = new Node<int>();
            H.Head.Next = null;
            while (p != null)
            {
                q = p;
                p = p.Next;
                q.Next = H.Head.Next;
                H.Head.Next = q;
            }
        }

        /// <summary>
        /// 在单链表的头部添加新的节点建立单链表的算法
        /// <para>-1是输入数据的结束标志，但输入的数为-1时表示结束</para>
        /// </summary>
        /// <returns></returns>
        public static LinkList<int> CreateListHead()
        {
            int d;
            LinkList<int> L = new LinkList<int>();
            d = Int32.Parse(Console.ReadLine());//读取用户输入的数字

            while (d != -1)
            {
                Node<int> p = new Node<int>(d);//创建一个节点
                p.Next = L.Head;//每次将新添加的节点下一个指针指向链表的头部
                L.Head = p;//链表的新头部为添加的节点
                d = Int32.Parse(Console.ReadLine());//再次输入新的参数
            }
            return L;
        }

        /// <summary>
        /// 在尾部插入结点建立单链表
        /// </summary>
        /// <returns></returns>
        public static LinkList<int> CreateListTail()
        {
            int d;

            Node<int> R = new Node<int>();//指向最后一个节点
            LinkList<int> L = new LinkList<int>();

            R = L.Head;
            d = Int32.Parse(Console.ReadLine());//读取用户输入的数字

            while (d != -1)
            {
                Node<int> p = new Node<int>(d);//创建一个节点

                if (L.Head == null)
                {
                    L.Head = p;
                }
                else
                {
                    R.Next = p;
                }
                R = p;//当前p的引用会在下次循环中使用上
                d = Int32.Parse(Console.ReadLine());//再次输入新的参数
            }
            if (R != null)
            {
                R.Next = null;
            }
            return L;
        }

        /// <summary>
        /// 将两个顺序排列好的单链表进行顺序合并到一个单链表中0
        /// </summary>
        /// <param name="Ha"></param>
        /// <param name="Hb"></param>
        /// <returns></returns>
        public static LinkList<int> Merge(LinkList<int> Ha, LinkList<int> Hb)
        {
            LinkList<int> Hc = new LinkList<int>();
            Node<int> aNext = Ha.Head;
            Node<int> bNext = Hb.Head;
            Node<int> numNode = new Node<int>();//数量节点

            //Hc使用Ha的头结点
            Hc = Ha;
            Hc.Head.Next = null;

            while (aNext != null && bNext != null)
            {
                if (aNext.Data < bNext.Data)
                {
                    numNode = aNext;
                    aNext = aNext.Next;
                }
                else
                {
                    numNode = bNext;
                    bNext = bNext.Next;
                }
                numNode.Next = Hc.Head.Next;
                Hc.Head.Next = numNode;
                //Hc.Append(numNode.Data);
            }

            if (aNext == null)
            {
                aNext = bNext;
            }

            while (aNext != null)
            {
                //Hc.Append(aNext.Data);
                //aNext = aNext.Next;

                //在尾部插入方法
                numNode = aNext;
                aNext = aNext.Next;
                numNode.Next = Hc.Head.Next;
                Hc.Head.Next = numNode;
            }

            return Hc;
        }

        /// <summary>
        /// 去掉Ha中的重复数据
        /// </summary>
        /// <param name="Ha"></param>
        /// <returns></returns>
        public LinkList<int> Purge(LinkList<int> Ha)
        {
            LinkList<int> Hb = new LinkList<int>();
            Node<int> p = Ha.Head.Next;
            Node<int> q = new Node<int>();
            Node<int> s = new Node<int>();

            s = p;//将s设置为Ha链表中你的第一个结点
            p = p.Next;
            s.Next = null;//将s结点的引用域设置为空
            Hb.Head.Next = s;//Hb单链表的头结点的引用域指向Ha的第一个结点

            while (p != null)
            {
                s = p;
                p = p.Next;
                q = Hb.Head.Next;
                while (q != null && q.Data != s.Data)
                {
                    q = q.Next;
                }
                if (q == null)
                {
                    s.Next = Hb.Head.Next;
                    Hb.Head.Next = s;
                }
            }
            return Hb;
        }

        /// <summary>
        /// 顺序表（单链表）中的元素值递增有序。写一算法，将元素 x 插入到表中适当的位置，并保持顺序表（单链表）的有序性
        /// </summary>
        public void 插入元素X到单链表中的合适位置(LinkList<int> l, int x)
        {
            Node<int> p = l.Head;

            int index = 1;
            while (p != null)
            {
                //如果当前结点值大于X则插入到当前节点前方
                if (p.Data > x)
                {
                    l.Insert(x, index);
                    break;
                }
                index++;
                p = p.Next;
            }
        }

        /// <summary>
        /// 打印全部数据
        /// </summary>
        public void PrintAllItem()
        {
            var p = this.Head;
            while (p != null)
            {
                Console.WriteLine(p.Data);
                p = p.Next;
            }
        }

        /// <summary>
        /// 判断是否有环
        /// </summary>
        /// <returns></returns>
        public bool HasCircle()
        {
            bool result = false;
            Node<T> slowNode = Head;//慢指针
            Node<T> fastNode = Head;//快指针
            int count = 0;
            int step = 0;

            while (slowNode.Next != null && fastNode.Next.Next != null)
            {
                try
                {
                    slowNode = slowNode.Next;//慢指针指向下一个
                    fastNode = fastNode.Next.Next;//快指针指向下一个节点下一个节点
                }
                catch (NullReferenceException)
                {
                    result = false;
                    break;
                }
                if (slowNode == fastNode && slowNode != Head && slowNode != Head)
                {
                    result = true;
                    Console.WriteLine($"当前节点的数据是{slowNode.Data}");
                    count++;
                }

                if (count == 1)//第一次相遇
                {
                    step++;//计步，获取环长
                }
                if (count == 2)//第二次相遇
                {
                    Console.WriteLine($"环长是{step}");
                    break;
                }
            }
            GetPoint(step);
            return result;
        }

        /// <summary>
        /// 获取相交点
        /// </summary>
        /// <param name="circleLength">环长</param>
        /// <returns></returns>
        public Node<T> GetPoint(int circleLength)
        {
            int lineLength = GetLength() - circleLength;
            int num = 1;
            Node<T> currentNode = Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                num++;
                if (num == lineLength)
                {
                    break;
                }
            }
            Console.WriteLine($"环相交点是{currentNode.Data}");
            return currentNode;
        }
    }
}
