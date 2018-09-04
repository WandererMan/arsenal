using QueueDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDemo
{
    /// <summary>
    /// 二叉树链表
    /// </summary>
    public class BiTree<T>
    {
        /// <summary>
        /// 头引用
        /// </summary>
        public Node<T> Head { get; set; }

        public BiTree()
        {
            Head = null;
        }

        public BiTree(T value)
        {
            Node<T> vNode = new Node<T>(value, null, null);
            Head = vNode;
        }

        public BiTree(T value, Node<T> rc, Node<T> lc)
        {
            Node<T> vNode = new Node<T>(value, lc, rc);
            Head = vNode;
        }

        /// <summary>
        /// 判断是否为空二叉树
        /// </summary>
        public bool IsEmpty { get { return Head == null; } }

        /// <summary>
        /// 获取根节点
        /// </summary>
        public Node<T> Root { get { return Head; } }

        /// <summary>
        /// 获取结点的左孩子结点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetLChild(Node<T> p)
        {
            return p.LChild;
        }

        /// <summary>
        /// 获取结点的右孩子结点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetRChild(Node<T> p)
        {
            return p.RChild;
        }

        /// <summary>
        /// 将结点p的左子树插入值为value的新结点
        /// 原来左子树成为新结点的左子树
        /// </summary>
        /// <param name="value"></param>
        /// <param name="p"></param>
        public void InsertL(T value, Node<T> p)
        {
            Node<T> vNode = new Node<T>(value, p.LChild, null);
            p.LChild = vNode;
        }

        /// <summary>
        /// 将结点p的右子树插入值为value的新结点
        /// 原来右子树成为新结点的右子树
        /// </summary>
        /// <param name="value"></param>
        /// <param name="p"></param>
        public void InsertR(T value, Node<T> p)
        {
            Node<T> vNode = new Node<T>(value, null, p.RChild);
            p.RChild = vNode;
        }

        /// <summary>
        /// 若P结点不为空结点，删除p的左子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> DeleteL(Node<T> p)
        {
            if (p == null || p.LChild == null)
            {
                return null;
            }
            var tmp = p.LChild;
            p.LChild = null;
            return tmp;
        }

        /// <summary>
        /// 若P结点不为空结点，删除p的右子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> DeleteR(Node<T> p)
        {
            if (p == null || p.RChild == null)
            {
                return null;
            }
            var tmp = p.RChild;
            p.RChild = null;
            return tmp;
        }

        /// <summary>
        /// 判断是否为叶子结点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsLeaf(Node<T> p)
        {
            if (p != null && p.RChild == null && p.LChild == null)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 先序遍历（DLR）
        /// 先序遍历的基本思想是：首先访问根结点，然后先序遍历其左子树，后先 序遍历其右子树。
        /// </summary>
        /// <param name="root"></param>
        public void PreOrder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            //处理根节点
            Console.WriteLine($"{root.Data}");

            //先序遍历左子树
            PreOrder(root.LChild);

            //先序遍历右子树
            PreOrder(root.RChild);
        }

        /// <summary>
        /// 中序遍历（LDR）
        /// 中序遍历的基本思想是：首先中序遍历根结点的左子树，然后访问根结点， 后中序遍历其右子树。
        /// </summary>
        /// <param name="root"></param>
        public void InOrder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            //先序遍历左子树
            PreOrder(root.LChild);
            //处理根节点左子树
            Console.WriteLine($"{root.Data}");

            //先序遍历右子树
            PreOrder(root.RChild);
        }

        /// <summary>
        /// 后序遍历（LRD)
        /// 后序遍历的基本思想是：首先后序遍历根结点的左子树，然后后序遍历根结 点的右子树，后访问根结点。
        /// </summary>
        /// <param name="root"></param>
        public void PostOrder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            //先序遍历左子树
            PreOrder(root.LChild);

            //先序遍历右子树
            PreOrder(root.RChild);
            //处理根节点左子树
            Console.WriteLine($"{root.Data}");
        }

        /// <summary>
        /// 层序遍历(level order)
        /// 层序遍历的基本思想是：由于层序遍历结点的顺序是先遇到的结点先访问， 与队列操作的顺序相同
        /// 在进行层序遍历时，设置一个队列,将根结点引 用入队，当队列非空时，循环执行以下三步： （1） 从队列中取出一个结点引用，并访问该结点； （2） 若该结点的左子树非空，将该结点的左子树引用入队； （3） 若该结点的右子树非空，将该结点的右子树引用入队
        /// </summary>
        /// <param name="root"></param>
        public void LevelOrder(Node<T> root)
        {
            if (root == null)
            {
                return;
            }

            //设置一个队列保持层序遍历的结点
            CSeqQueue<Node<T>> queue = new CSeqQueue<Node<T>>(50);

            queue.In(root);

            while (!queue.IsEmpty())
            {
                var tmpNode = queue.Out();
                //处理当前结点输出值
                Console.WriteLine(tmpNode.Data);

                if (tmpNode.LChild != null)
                {
                    queue.In(tmpNode.LChild);
                }
                if (tmpNode.RChild != null)
                {
                    queue.In(tmpNode.RChild);
                }
            }

        }

    }
}
