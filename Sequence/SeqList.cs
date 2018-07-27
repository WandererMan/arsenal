using ILinear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    /// <summary>
    /// 顺序表（线性顺序表）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqList<T> : IListDS<T>
    {
        /// <summary>
        /// 顺序表的容量
        /// </summary>
        private int maxsize;

        /// <summary>
        /// 数组，用于存储顺序表中的数据元素
        /// </summary>
        private T[] data;

        /// <summary>
        /// 指示顺序表最后一个元素的位置
        /// </summary>
        private int last;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        /// <summary>
        /// 最后一个数据元素位置属性
        /// </summary>
        public int Last
        {
            get{ return last; }
        }

        /// <summary>
        /// 容量属性
        /// </summary>
        public int Maxsize
        {
            get{ return maxsize; }
            set{ maxsize = value; }
        }

        public SeqList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }

        public void Append(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T Delete(int i)
        {
            throw new NotImplementedException();
        }

        public T GetElm(int i)
        {
            throw new NotImplementedException();
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public void Insert(T item, int i)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public int Locate(T value)
        {
            throw new NotImplementedException();
        }
    }
    
}
