using ILinear;
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
    public class DBLinkList<T> : IListDS<T>
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
        /// 判断单链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => (head == null);

        public DBLinkList()
        {
            Head = new DbNode<T>();
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
            if (index > _size || index < 0)
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
        public void Append(T item,int index)
        { 
            DbNode<T> p; 

            if (index == 0)
            {
                p = Head;
            }
            else
            {
                if (index<0)
                {
                    Console.WriteLine("位置不存在");
                }
                p = GetNode(index-1);
            }
            DbNode<T> tnode = new DbNode<T>(item,p,p.Next);
            p.Next.Prev = tnode;
            p.Next = tnode;
            _size++; 
        }

        /// <summary>
        /// 将节点插入到第index位置之前
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

            if (i == 0)
            {
                Append(item,_size);
                DbNode<T> q = new DbNode<T>(item);
                q.Next = head;
                head = q;
                return;
            }
            else
            {
                DbNode<T> inode = GetNode(i);
                DbNode<T> tnode = new DbNode<T>(item,inode.Prev,inode);
                inode.Prev.Next = tnode;
                inode.Prev = tnode;
                _size++;

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
        public static void ReversLinkList(LinkList<int> H)
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
    }
}
