using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkGroup.Data
{
    /// <summary>
    /// 表示数据库处理层出现的异常
    /// </summary>
    public class DBaseException : Exception
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DBaseException() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Msg">异常信息</param>
        /// <param name="_ErrorNumber">错误代码</param>
        public DBaseException(String Msg, String _ErrorNumber)
            : base(Msg)
        {
            this.ErrorNumber = _ErrorNumber;
        }
        /// <summary>
        /// 获取一个值，该值表示异常错误代码
        /// </summary>
        public String ErrorNumber { get; private set; }
    }
}
