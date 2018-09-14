using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanTreeDemo
{
    public class Node
    {
        /// <summary>
        /// 结点的权值
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 左孩子结点（在数组中的序号）
        /// </summary>
        public int LChild { get; set; }

        /// <summary>
        /// 右孩子结点（在数组中的序号）
        /// </summary>
        public int RChild { get; set; }

        /// <summary>
        /// 父节点（在数组中的序号）
        /// </summary>
        public int Parent { get; set; }

        public Node(int weight, int lchild, int rchild, int parent)
        {
            Weight = weight;
            LChild = lchild;
            RChild = RChild;
            Parent = Parent;
        }
        public Node()
        {
            Weight = 0;
            LChild = -1;
            RChild = -1;
            Parent = -1;
        }
    }

    /// <summary>
    /// 哈夫曼树
    /// </summary>
    public class HuffmanTree
    {
        /// <summary>
        /// 结点数组
        /// </summary>
        public Node[] Data { get; set; }

        /// <summary>
        /// 叶子结点的数目
        /// </summary>
        public int LeafNum { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Node this[int index]
        {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">n个叶子结点</param>
        public HuffmanTree(int n)
        {
            Data = new Node[2 * n - 1];
            LeafNum = n;
        }

        /// <summary>
        /// 创建哈夫曼树
        /// </summary>
        public void Create()
        {
            int max1;//最大权值数
            int max2;//次之权值最大数
            int tmp1;//最大数数组中位置
            int tmp2;//次大数数组中位置

            //输入N个叶子结点的权值
            for (int i = 0; i < this.LeafNum; i++)
            {
                Data[i] = new Node ();
                Data[i].Weight =Convert.ToInt32( Console.ReadLine());
            }

            for (int i = 0; i < this.LeafNum - 1; i++)
            {
                max1 = max2 = Int32.MaxValue;
               tmp1 = tmp2 = 0;

                ///this.LeafNum+1因为每次数组中都会新添加一个节点
                for (int j = 0; j < this.LeafNum+1; j++)
                {
                    if (Data[i].Weight < max1 && Data[i].Parent == -1)
                    {
                        max2 = max1;
                        tmp2 = tmp1;
                        tmp1 = j;
                        max1 = Data[j].Weight;

                    }
                    else if (Data[i].Weight < max2 && Data[i].Parent == -1)
                    {
                        max2 = Data[j].Weight;
                        tmp2 = j;
                    }
                }
                //添加新的节点到数组中
                Data[this.LeafNum + i] = new Node();
                //将最小权值节点的双亲节点设置为当前叶子结点+i
                Data[tmp1].Parent = this.LeafNum + i;
                //新结点的权值为最小和次小结点的权值和
                Data[this.LeafNum + i].Weight = Data[tmp1].Weight + Data[tmp2].Weight;

                //分配新结点的左右孩子

                Data[this.LeafNum + i].LChild = tmp1;
                Data[this.LeafNum + i].RChild = tmp2;
            }
        }



    }
}
