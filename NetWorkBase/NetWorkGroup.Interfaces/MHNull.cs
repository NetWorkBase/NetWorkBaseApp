using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 表示没有任何数据的空类型,此类型为值类型，不能继承此类
    /// </summary>
    public struct MRHNull
    {
        /// <summary>
        /// 表示没有任何数据的空类型的实例
        /// </summary>
        public static readonly MRHNull Empty = new MRHNull();
        /// <summary>
        /// 返回相关类型说明
        /// </summary>
        /// <returns>类型说明</returns>
        public override string ToString()
        {
            return "这是一个表示没有任何数据的空类";
        }
    }
}
