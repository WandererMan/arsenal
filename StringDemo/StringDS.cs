using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDemo
{
    /// <summary>
    /// 串
    /// </summary>
    public class StringDS
    {
        /// <summary>
        /// 字符数组
        /// </summary>
        public char[] Data { get; set; }
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index]
        {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

        public StringDS(char[] arr)
        {
            Data = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Data[i] = arr[i];
            }
        }

        public StringDS(StringDS s)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = s[i];
            }

        }

        public StringDS(int len)
        {
            char[] arr = new char[len];
            Data = arr;
        }

        /// <summary>
        /// 串长
        /// </summary>
        /// <returns></returns>
        public int GetLength() => Data.Length;

        /// <summary>
        /// 串比较
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Compare(StringDS s)
        {
            int len = (this.GetLength() <= s.GetLength() ? this.GetLength() : s.GetLength());

            int i = 0;
            for (i = 0; i < len; i++)
            {
                if (this[i] != s[i])
                {
                    break;
                }
            }
            if (i <= len)
            {
                if (this[i] < s[i])
                {
                    return -1;
                }
                else if (this[i] > s[i])
                {
                    return 1;
                }
            }

            else if (this.GetLength() == s.GetLength())
            {
                return 0;
            }
            else if (this.GetLength() < s.GetLength())
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 求子串
        /// </summary>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public string SubString(int index, int len)
        {
            if ((index < 0) || (index > this.GetLength() - 1) || (len < 0) || (len > this.GetLength() - index))
            {
                Console.WriteLine("当前所以选的位置有误");
                return null;
            }
            string s = string.Empty;
            for (int i = 0; i < len; i++)
            {
                s += this[i + index - 1];
            }
            return s;
        }

        //串连接        
        public StringDS Concat(StringDS s)
        {
            StringDS s1 = new StringDS(this.GetLength() + s.GetLength());

            for (int i = 0; i < this.GetLength(); ++i)
            {
                s1.Data[i] = this[i];
            }

            for (int j = 0; j < s.GetLength(); ++j)
            {
                s1.Data[this.GetLength() + j] = s[j];
            }

            return s1;
        }

        //串插入        
        public StringDS Insert(int index, StringDS s)
        {
            int len = s.GetLength();//获取要插入串的长度
            int len2 = len + this.GetLength();//计算插入串之后的总长度
            StringDS s1 = new StringDS(len2);//新实例化一个新的串

            //索引有误
            if (index < 0 || index > this.GetLength() - 1)
            {
                Console.WriteLine("Position is error!");
                return null;
            }
            //将index之前的原有串中的字符插入到新的串中
            for (int i = 0; i < index; ++i)
            {
                s1[i] = this[i];
            }

            //将要插入的串添加到新串的尾端
            for (int i = index; i < index + len; ++i)
            {
                s1[i] = s[i - index];
            }
            //将原字符串后面的所有字符插入到新串的后面中
            for (int i = index + len; i < len2; ++i)
            {
                s1[i] = this[i - len];
            }

            return s1;
        }

        //串删除         
        public StringDS Delete(int index, int len)
        {
            if ((index < 0) || (index > this.GetLength() - 1) || (len < 0) || (len > this.GetLength() - index)) { Console.WriteLine("Position or Length is error!"); return null; }

            StringDS s = new StringDS(this.GetLength() - len);

            for (int i = 0; i < index; ++i) { s[i] = this[i]; }

            for (int i = index + len; i < this.GetLength(); ++i) { s[i] = this[i]; }

            return s;
        }

        //串定位         
        public int Index(StringDS s)
        {
            if (this.GetLength() < s.GetLength()) { Console.WriteLine("There is not string s!"); return -1; }

            int i = 0; int len = this.GetLength() - s.GetLength(); while (i < len)
            {
                if (this.Compare(s) == 0)
                {
                    break;
                }
            }

            if (i <= len) { return i; }

            return -1;
        }
    }

}

