using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDemo
{
    /// <summary>
    /// 树的结构体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct PNode<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 双亲位置
        /// </summary>
        public int PPos { get; set; }
    }
    /// <summary>
    /// 树类
    /// </summary>
    public class PTre<T>
    {
       public PNode<T>[] Nodes { get; set; }
    }
}
