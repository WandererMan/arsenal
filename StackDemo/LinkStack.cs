using ILinear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo
{
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
    /// 链栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkStack<T> : IStack<T>
    {
        /// <summary>
        /// 栈顶指示器
        /// </summary>
        public Node<T> Top { get; set; }

        /// <summary>
        /// 栈中结点个数
        /// </summary>
        public int Num { get; set; } = 0;

        public LinkStack()
        {
            Top = null;
        }

        /// <summary>
        /// 清空链栈
        /// </summary>
        public void Clear()
        {
            Top = null;
            Num = 0;
        }

        /// <summary>
        /// 链栈的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength() => Num;

        /// <summary>
        /// 获取栈顶的结点值
        /// </summary>
        /// <returns></returns>
        public T GetTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈为空");
                return default(T);
            }
            else
            {
                return Top.Data;
            }
        }

        /// <summary>
        /// 判断链栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => (Top == null || Num == 0);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈为空");
                return default(T);
            }

            Node<T> q = Top;

            Top = Top.Next;
            Num--;

            return q.Data;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            Node<T> value = new Node<T>(item, null);

            if (Top == null)
            {
                Top = value;
            }
            else
            {
                value.Next = Top;
                Top = value;
            }
            Num++;
        }

        /// <summary>
        /// 括号匹配
        /// </summary>
        /// <param name="charlist"></param>
        /// <returns></returns>
        public bool MatchBracket(char[] charlist)
        {
            SeqStack<char> s = new SeqStack<char>(50);
            int len = charlist.Length;
            for (int i = 0; i < len; ++i)
            {
                if (s.IsEmpty())
                {
                    s.Push(charlist[i]);
                }
                else if ((((s.GetTop() == '(') && (charlist[i] == ')'))) || (s.GetTop() == '[' && charlist[i] == ']'))
                {
                    s.Pop();
                }
                else
                {
                    s.Push(charlist[i]);
                }
            }
            if (s.IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
