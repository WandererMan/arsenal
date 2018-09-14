using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    /// <summary>
    /// 孩子链结点
    /// </summary>
    public class ChildNode
    {
        /// <summary>
        /// 所在一维数组中的索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 下一个孩子结点的地址
        /// </summary>
        public ChildNode NextChild { get; set; }
    }

    /// <summary>
    /// 孩子链
    /// </summary>
    public class CLNode<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 首个孩子结点
        /// </summary>
        public ChildNode FirstNode { get; set; }

    }

    /// <summary>
    /// 孩子链表示法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CLTree<T>
    {
        /// <summary>
        /// 孩子链一维数组
        /// </summary>
        public CLNode<T>[] Nodes { get; set; }
    }



}
