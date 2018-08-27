﻿using ILinear;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo
{
    /// <summary>
    /// 顺序栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqStack<T> : IStack<T>
    {
        /// <summary>
        /// 顺序栈的容量
        /// </summary>
        private int maxsize;

        /// <summary>
        /// 存储顺序栈中的数据元素
        /// </summary>
        private T[] data;

        /// <summary>
        /// 表示顺序栈的栈顶
        /// </summary>
        private int top;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        /// <summary>
        /// 容量属性
        /// </summary>
        public int Maxsize
        {
            get
            {
                return maxsize;
            }
            set
            {
                maxsize = value;
            }
        }

        /// <summary>
        /// 栈顶属性
        /// </summary>
        public int Top
        {
            get
            {
                return top;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">长度</param>
        public SeqStack(int size)
        {
            maxsize = size;
            top = -1;
            data = new T[size];
        }

        /// <summary>
        /// 清空顺序栈
        /// </summary>
        public void Clear()
        {
            top = -1;
        }

        /// <summary>
        /// 求栈的长度
        /// </summary>
        public int GetLength()
        {
            return top + 1;
        }

        /// <summary>
        /// 获取栈顶数据元素
        /// </summary>
        /// <returns></returns>
        public T GetTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("当前栈为空");
                return default(T);
            }
            return data[top];
        }

        /// <summary>
        /// 判断顺序栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => (top == -1);

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("当前栈为空");
                return default(T);
            } 
            return data[top--];
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("栈满");
                return;
            }
            data[++top] = item;
        }

        public bool IsFull() => (top == maxsize - 1);
    }
}
