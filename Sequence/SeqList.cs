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

        public SeqList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }

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
            get { return last; }
        }

        /// <summary>
        /// 容量属性
        /// </summary>
        public int Maxsize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }


        /// <summary>
        /// 获取顺序表的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return last + 1;
        }

        /// <summary>
        /// 判断顺序表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (last == -1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断顺序表是否为满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if (last == maxsize - 1)
                return true;
            else
                return false;
        }

        #region 增 
        /// <summary>
        /// 在顺序表的第i个数据元素的位置插入一个数据元素
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i">此位置按照从1开始数起，切勿理解为数组中的索引位置</param>
        public void Insert(T item, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("顺序表已满");
                return;
            }
            if (i < 1 || i > last + 2)
            {
                Console.WriteLine($"插入位置{i.ToString()}有误");
                return;
            }
            if (i == last + 2)
            {
                data[last + 1] = item;
            }
            else
            {
                //j=last从最后一位参数开始集体向后移动一位
                for (int j = last; j >= i - 1; j--)
                {
                    data[j + 1] = data[j];
                }
                data[i - 1] = item;
            }
            //书中使用++last，last++也可以
            //++last;
            last++;
        }

        /// <summary>
        /// 在顺序表的末尾添加新元素
        /// </summary>
        /// <param name="item"></param>
        public void Append(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("顺序表已满");
                return;
            }
            //使用++last，先将last的值+1在使用
            data[++last] = item;
        }
        #endregion

        #region 删 
        /// <summary>
        /// 删除顺序表中的第i个元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Delete(int i)
        {
            T tmp = default(T);
            if (IsFull())
            {
                Console.WriteLine("顺序表已满");
                return tmp;
            }
            if (i < 1 || i > last + 1)
            {
                Console.WriteLine($"删除位置{i.ToString()}有误");
                return tmp;
            }
            if (i == last + 1)
            {
                tmp = data[last--];
                return tmp;
            }
            else
            {
                tmp = data[i - 1];
                for (int j = i; j <= last; j++)
                {
                    data[j] = data[j + 1];
                }
            }
            last--;
            return tmp;
        }

        /// <summary>
        /// 清空顺序表
        /// </summary>
        public void Clear()
        {
            last = -1;
        }
        #endregion

        #region 改

        #endregion

        #region 查 
        /// <summary>
        /// 获取顺序表的第i个数据元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElm(int i)
        {
            if (IsEmpty() || i < 1 || i > last + 1)
            {
                Console.WriteLine("顺序表为空，或查询位置有误");
                return default(T);
            }
            return data[i - 1];
        }

        /// <summary>
        /// 顺序表中查找值为value的数据元素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("顺序表为空");
                return -1;
            }
            int i = 0;
            for (i = 0; i <= last; i++)
            {
                if (value.Equals(data[i]))
                {
                    break;
                }
            }

            if (i > last)
            {
                return -1;
            }
            return i;
        }
        #endregion

        #region 操作 
        /// <summary>
        /// 倒置顺序表
        /// </summary>
        public void Reverse()
        {
            T tmp = default(T);
            int len = GetLength();
            for (int i = 0; i < len / 2; i++)
            {
                tmp = data[i];
                data[i] = data[len - i];
                data[len - i] = tmp;
            }
        }

        /// <summary>
        /// 合并两个表中的数据
        /// <para>有数据类型为整型的顺序表 La 和 Lb，其数据元素均按从小到大的升序排列，编写一个算法将它们合并成一个表 Lc，要求 Lc 中数据元素也按升序排数据结构</para>
        /// </summary>
        /// <param name="la"></param>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static SeqList<int> Merge(SeqList<int> la, SeqList<int> lb)
        {
            SeqList<int> lc = new SeqList<int>(la.GetLength() + lb.GetLength());

            int a = 0;
            int b = 0;

            while ((a < la.GetLength()) && (b < lb.GetLength()))
            {
                if (la[a] < lb[b])
                {
                    lc.Append(la[a++]);
                }
                else
                {
                    lc.Append(lb[b++]);
                }
            }

            //a表中还有数据元素 
            while (a < la.GetLength())
            {
                lc.Append(la[a++]);
            }

            //b表中还有数据元素
            while (b < lb.GetLength())
            {
                lc.Append(lb[b++]);
            }

            return lc;
        }

        /// <summary>
        /// 已知一个存储整数的顺序表 La，试构造顺序表 Lb，要求顺序表 Lb 中只包含顺序表 La 中所有值不相同的数据元素
        /// </summary>
        /// <param name="la"></param>
        /// <returns></returns>
        public static SeqList<int> Purge(SeqList<int> la)
        {
            SeqList<int> lb = new SeqList<int>(la.GetLength());
            lb.Append(la[0]);
            int a = 0;
            int b = 0;

            for (a = 0; a < la.GetLength(); a++)
            {
                for (b = 0; b < lb.GetLength(); b++)
                {
                    if (lb[b] == la[a])
                    {
                        break;
                    }
                }
                if (b == lb.GetLength())
                {
                    lb.Append(la[a]);
                }
            }
            return lb;
        }
        #endregion
    }

}
