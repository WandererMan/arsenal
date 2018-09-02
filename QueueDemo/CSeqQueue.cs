using ILinear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    /// <summary>
    /// 循环顺序队
    /// </summary>
    public class CSeqQueue<T> : IQueue<T>
    {
        /// <summary>
        /// 队列中的数据元素
        /// </summary>
        public T[] Data { get; set; }

        /// <summary>
        /// 循环顺序队列的容量
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// 队头
        /// </summary>
        public int Front { get; set; }

        /// <summary>
        /// 队尾
        /// </summary>
        public int Rear { get; set; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

        public CSeqQueue(int maxSize)
        {
            Data = new T[maxSize];
            MaxSize = maxSize;
            Front = Rear = 0;
        }

        /// <summary>
        /// 清空循环顺序队列
        /// </summary>
        public void Clear() => Front = Rear = 0;

        /// <summary>
        /// 获取队头数据元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            return Data[Front + 1];
        }

        /// <summary>
        /// 获取队列的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength() => (Rear - Front + MaxSize) % MaxSize;

        /// <summary>
        /// 判断循环顺序队列是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if ((Rear + 1) % MaxSize == Front)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void In(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("队满");
                return;
            }
            Data[Rear] = item;
            Rear = (Rear + 1) % MaxSize;
        }

        /// <summary>
        /// 判断循环队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Front == Rear;

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Out()
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("队为空");
                return tmp;
            }
            tmp = Data[Front];
            Front = (Front + 1) % MaxSize;
            return tmp;

        }
        public void ShowAllQueue()
        {
            for (int i = 0; i < MaxSize; i++)
            {
                Console.WriteLine(i + "=" + Data[i]);
            }
            Console.WriteLine("***********************完毕******************");
        }
    }
}
