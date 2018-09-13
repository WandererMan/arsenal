using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    public class CSNode<T>
    {
        /// <summary>
        /// 首孩子结点
        /// </summary>
        public CSNode<T> FirstNode { get; set; }

        /// <summary>
        /// 下一个兄弟结点
        /// </summary>
        public CSNode<T> NextSibling { get; set; }
    }
    /// <summary>
    /// 二叉树表示法
    /// </summary>
    public class CSTree<T>
    {
        /// <summary>
        /// 头引用
        /// </summary>
        public CSNode<T> Head { get; set; }
    }
}
