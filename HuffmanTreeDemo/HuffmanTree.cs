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
        /// 手动输入权值值创建哈夫曼树
        /// </summary>
        public void PrintValueCreateTree()
        {
            //输入N个叶子结点的权值
            for (int i = 0; i < this.LeafNum; i++)
            {
                Console.WriteLine($"第{i + 1}个结点的权值:");
                Data[i] = new Node();
                Data[i].Weight = Convert.ToInt32(Console.ReadLine());
            }
            ConstructHuffmanTree();
        }
        /// <summary>
        /// 构造哈夫曼树
        /// </summary>
        public void ConstructHuffmanTree()
        {
            int min1;//最小权值数
            int min2;//次小权值数
            int tmp1;//最小数数组中位置
            int tmp2;//次小22数数组中位置 

            for (int i = 0; i < this.LeafNum - 1; i++)
            {
                min1 = min2 = Int32.MaxValue;
                tmp1 = tmp2 = 0;

                ///this.LeafNum+1因为每次数组中都会新添加一个节点
                for (int j = 0; j < this.LeafNum + i; j++)
                {
                    if (Data[j].Weight < min1 && Data[j].Parent == -1)
                    {
                        min2 = min1;
                        tmp2 = tmp1;
                        tmp1 = j;
                        min1 = Data[j].Weight;
                    }
                    else if (Data[j].Weight < min2 && Data[j].Parent == -1)
                    {
                        min2 = Data[j].Weight;
                        tmp2 = j;
                    }
                }
                //添加新的节点到数组中
                Data[this.LeafNum + i] = new Node();
                //将最小权值节点的双亲节点设置为当前叶子结点+i
                Data[tmp1].Parent = this.LeafNum + i;
                //将次小权值结点的双亲节点设置为当前叶子结点+1
                Data[tmp2].Parent = this.LeafNum + i;
                //新结点的权值为最小和次小结点的权值和
                Data[this.LeafNum + i].Weight = Data[tmp1].Weight + Data[tmp2].Weight;

                //分配新结点的左右孩子
                Data[this.LeafNum + i].LChild = tmp1;
                Data[this.LeafNum + i].RChild = tmp2;
            }
        }


        /// <summary>
        /// 哈夫曼编码
        /// </summary>
        /// <returns></returns>
        public string HumffmanEncoding(string str)
        {
            // char[] strArry = str.ToCharArray();
            Dictionary<char, int> dic = new Dictionary<char, int>();

            //构造字符与字符对应的权值
            foreach (var item in str)
            {
                //字典中包含字符，则对应的value+1
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    //将新的字符串添加到字典中
                    dic.Add(item, 1);
                }
            }

            HuffmanTree huffmanTree = new HuffmanTree(dic.Count);
            int j = 0;
            foreach (var item in dic)
            {
                huffmanTree.Data[j] = new Node(item.Value, -1, -1, -1);
                j++;
            }
            huffmanTree.ConstructHuffmanTree();

            string[] huffmanCode = new string[huffmanTree.LeafNum];
            for (int i = 0; i < huffmanTree.LeafNum; i++)
            {
                huffmanTree.Data[i].Parent
            }
            return null;

        }



    }
}
