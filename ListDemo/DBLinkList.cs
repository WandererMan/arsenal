﻿using ILinear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDemo
{
    /// <summary>
    /// 双链表
    /// </summary>
    public class DBLinkList<T>
    {
        private DbNode<T> head;

        /// <summary>
        /// 头引用
        /// </summary>
        public DbNode<T> Head { get { return head; } set { head = value; } }

        //节点个数
        private int _size;
        /// <summary>
        /// 求双链表的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength() => _size;

        /// <summary>
        /// 判断双链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => (_size == 0);

        public DBLinkList()
        {
            Head = new DbNode<T>(default(T), null, null);
            Head.Prev = Head;
            Head.Next = Head;
            _size = 0;
        }

        /// <summary>
        /// 通过索引查找
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        private DbNode<T> GetNode(int index)
        {
            if (index >= _size || index < 0)
            {
                Console.WriteLine("索引溢出或者链表为空");
                return null;
            }

            //正向查找
            if (index < _size / 2)
            {
                DbNode<T> node = Head.Next;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                return node;
            }
            //反向查找
            DbNode<T> rnode = Head.Prev;
            for (int i = 0; i < _size - index - 1; i++)
            {
                rnode = rnode.Prev;
            }
            return rnode;
        }

        /// <summary>
        /// 获取指定索引的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index) => GetNode(index).Data;

        /// <summary>
        /// 获首个元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetFirst() => GetNode(0).Data;

        /// <summary>
        /// 获取最后一个元素
        /// </summary>
        /// <returns></returns>
        public T GetLast() => GetNode(_size - 1).Data;

        /// <summary>
        /// 追加到index位置之后
        /// </summary>
        /// <param name="item"></param>
        public void Append(int index, T item)
        {
            DbNode<T> p;

            if (index == 0)
            {
                p = Head;
            }
            else
            {
                if (index < 0)
                {
                    Console.WriteLine("位置不存在");
                }
                p = GetNode(index - 1);
            }
            DbNode<T> tnode = new DbNode<T>(item, p, p.Next);
            p.Next.Prev = tnode;
            p.Next = tnode;
            _size++;
        }

        /// <summary>
        /// 将节点插入到第index位置之前
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void Insert(int i, T item)
        {
            if (i >= _size || i < 0)
            {
                Console.WriteLine("链表是空的或插入位置有误");
                return;
            }

            if (i == 0)
            {
                Append(_size, item);
            }
            else
            {
                DbNode<T> inode = GetNode(i);
                DbNode<T> tnode = new DbNode<T>(item, inode.Prev, inode);
                inode.Prev.Next = tnode;
                inode.Prev = tnode;
                _size++;

            }
        }

        /// <summary>
        /// 删除双链表的第i个结点
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void Delete(int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("链表是空的或删除位置有误");
            }
            DbNode<T> inode = GetNode(i - 1);
            inode.Prev.Next = inode.Next;
            inode.Next.Prev = inode.Prev;
            _size--;
        }

        /// <summary>
        /// 清空单链表
        /// </summary>
        public void Clear() => head.Next = null;


        /// <summary>
        /// 将双链表倒置
        /// </summary>
        public void ReversLinkList(DBLinkList<int> H)
        {

            //    DBLinkList<T> newLinkList = new DBLinkList<T>();
            //    for (int i = _size-1; i >= 0; i--)
            //    { 
            //        newLinkList.Append(newLinkList._size, Get(i));
            //    }
            //    this.Head = newLinkList.Head;

            DbNode<int> p = H.Head.Next;
            DbNode<int> q = new DbNode<int>(0, null, null);
            H.Head.Next = null;
            H.head.Prev = p;

            //该双链表为循环链表不可以使用while循环语句
            //while (p.Next != null)
            //{
            //    q = p;
            //    p = p.Next;
            //    q.Prev = q.Next;
            //    q.Next = H.Head.Next;
            //    H.Head.Next = q;
            //}

            for (int i = 0; i < _size; i++)
            {
                q = p;
                p = p.Next;
                q.Prev = q.Next;
                q.Next = H.Head.Next;
                H.Head.Next = q;
            }


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
        public void ShowAll()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine("(" + i + ")=" + Get(i));
            }
            Console.WriteLine("******************* 链表数据展示完毕 *******************\n");
        }
    }
}
