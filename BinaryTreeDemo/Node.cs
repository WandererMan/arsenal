using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDemo
{
    /// <summary>
    /// 二叉链表的节点
    /// </summary>
    public class Node<T>
    {
        public T Data { get; set; }
        /// <summary>
        /// 右孩子
        /// </summary>
        public Node<T> RChild { get; set; }

        /// <summary>
        /// 左孩子
        /// </summary>
        public Node<T> LChild { get; set; }

        public Node(T value, Node<T> lc, Node<T> rc)
        {
            Data = value;
            RChild = rc;
            LChild = lc;
        }



    }
}
