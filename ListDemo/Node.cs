using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDemo
{
    /// <summary>
    /// 单链表结点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        private T data;

        /// <summary>
        /// 引用域
        /// </summary>
        private Node<T> next;

        public Node(T val, Node<T> p)
        {
            data = val;
            next = p;
        }

        public Node(Node<T> p)
        {
            next = p;
        }

        public Node(T val)
        {
            data = val;
        }

        public Node()
        {
            data = default(T);
            next = null;
        }

        /// <summary>
        /// 数据域属性
        /// </summary>
        public T Data { get { return data; } set { data = value; } }

        /// <summary>
        /// 引用域属性
        /// </summary>
        public Node<T> Next { get { return next; } set { next = value; } }
        
    }
}
