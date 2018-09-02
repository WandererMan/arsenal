using ILinear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    /// <summary>
    /// 结点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 引用域
        /// </summary>
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> next)
        {
            Data = value;
            Next = next;
        }
    }

    /// <summary>
    /// 链队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkQueue<T> : IQueue<T>
    {
        /// <summary>
        /// 链队列队头结点
        /// </summary>
        public Node<T> Front { get; set; }

        /// <summary>
        /// 链队列队尾结点
        /// </summary>
        public Node<T> Rear { get; set; }

        /// <summary>
        /// 链队列元素个数
        /// </summary>
        public int Num { get; set; } = 0;

        public LinkQueue()
        {
            Front = Rear = null;
        }

        /// <summary>
        /// 清空队列
        /// </summary>
        public void Clear()
        {
            Front = Rear = null;
            Num = 0;
        }

        /// <summary>
        /// 是否为空队列
        /// </summary>
        public bool IsEmpty()
        {
            if ((Front == Rear) && (Num == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取队头元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("当前链队列为空");
            }
            return Front.Data;
        }

        /// <summary>
        /// 链队列的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength() => Num;

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void In(T item)
        {
            Node<T> iNode = new Node<T>(item, null);
            if (Rear == null)
            {
              Front=  Rear = iNode;
            }
            else
            {
                Rear.Next = iNode;
                Rear = iNode;
            }
            Num++;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Out()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列为空");
                return default(T);
            }

            Node<T> value = Front;
            Front = Front.Next;

            if (Front == null)
            {
                Rear = null;
            }
            Num--;
            return value.Data;
        }
        public void ShowAllQueue()
        {
            Node<T> value = Front;
            for (int i = 0; i < Num; i++)
            {
                Console.WriteLine(i + "=" + value.Data);
                value = value.Next;
            }
            Console.WriteLine("***********************完毕******************");
        }
    }
}
