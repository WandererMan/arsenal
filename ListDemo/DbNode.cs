using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDemo
{
    /// <summary>
    /// 双向链表的结点
    /// </summary>
    public class DbNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        private T data;

        /// <summary>
        /// 前驱引用域
        /// </summary>
        private DbNode<T> prev;

        /// <summary>
        /// 后继引用域
        /// </summary>
        private DbNode<T> next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">数据域</param>
        /// <param name="p">后继引用域</param>
        public DbNode(T val, DbNode<T> p)
        {
            data = val;
            next = p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">后继引用域</param>
        public DbNode(DbNode<T> p)
        {
            next = p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">数据域</param>
        public DbNode(T val)
        {
            data = val;
            next = null;
        }

        public DbNode()
        {
            data = default(T);
            next = null;
        }

        /// <summary>
        /// 数据域属性
        /// </summary>
        public T Data { get { return data; } set { data = value; } }

        /// <summary>
        /// 前驱引用域属性
        /// </summary>
        public DbNode<T> Prev { get { return prev; } set { prev = value; } }

        /// <summary>
        /// 后继引用域属性
        /// </summary>
        public DbNode<T> Next { get { return next; } set { next = value; } }


    }
}
