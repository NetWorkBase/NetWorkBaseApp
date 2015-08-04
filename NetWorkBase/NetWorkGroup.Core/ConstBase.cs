using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 静态公用类，包含制度字串和全局字串
    /// </summary>
    public abstract class ConstBase
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ConstBase() { }
        /// <summary>
        /// 表示一个全局字符串变量，用于保存在线的用户信息
        /// </summary>
        public const String OnLineUser = "OLUsers";
    }
}
