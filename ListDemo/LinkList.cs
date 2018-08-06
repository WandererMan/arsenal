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

        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
