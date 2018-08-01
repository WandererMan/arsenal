using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILinear
{
    /// <summary>
    /// 线性表的接口定义
    /// </summary>
    public interface IListDS<T>
    {
        /// <summary>
        /// 获取长度
        /// <para>初始条件：线性表存在；</para>
        /// <para>操作结果：返回线性表中所有数据元素的个数。</para> 
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// 判断是否为空
        /// <para>初始条件：线性表存在；</para>
        /// <para>操作结果：如果线性表为空返回 true，否则返回 false。 </para> 
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 附加操作
        /// <para>初始条件：线性表存在且未满；</para>
        /// <para>操作结果：将值为 item 的新元素添加到表的末尾。  </para>
        /// </summary>
        /// <returns></returns>
        void Append(T item);

        /// <summary>
        /// 插入操作
        /// <para>初始条件：线性表存在，插入位置正确；</para>
        /// <para>操作结果：在线性表的第 i 个位置上插入一个值为 item 的新元素，这样使得原序号为 i, i+1,…, n 的数据元素的序号变为 i+1, i+2,…, n+1，插入后表长=原表长+1。</para>
        /// </summary>
        /// <returns></returns>
        void Insert(T item, int i);

        /// <summary>
        /// 删除操作
        /// <para>初始条件：线性表存在且不为空，删除位置正确；</para>
        /// <para>操作结果：在线性表中删除序号为 i 的数据元素，返回删除后的数据元素。删除后使原序号为 i+1, i+2,…, n 的数据元素的序号变为 i, i+1,…, n-1，删除后表长 = 原表长 - 1。</para>
        /// </summary>
        /// <returns></returns>
        T Delete(int i);

        /// <summary>
        /// 清空操作
        /// <para>初始条件：线性表存在且有数据元素；</para>
        /// <para>操作结果：从线性表中清除所有数据元素，线性表为空。 </para>
        /// </summary>
        /// <returns></returns>
        void Clear();

        /// <summary>
        /// 获取表中的元素
        /// <para>初始条件：线性表存在，所取数据元素位置正确；</para>
        /// <para>操作结果：返回线性表中第 i 个数据元素。 </para> 
        /// </summary>
        /// <returns></returns>
        T GetElm(int i);

        /// <summary>
        /// 按值查找
        /// <para>初始条件：线性表存在；</para>
        /// <para>操作结果：在线性表中查找值为 value 的数据元素，其结果返回在线性表中首次出现的值为 value 的数据元素的序号，称为查找成功；否则，在线性表中未找到值为 value 的数据元素，返回一个特殊值表示查找失败。</para> 
        /// </summary>
        /// <returns></returns>
        int Locate(T value);

        /// <summary>
        /// 将顺序表倒置
        /// </summary>
        void Reverse();

    }
}
