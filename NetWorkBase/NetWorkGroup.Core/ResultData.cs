using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 表示向前台返回的数据返回值到包装器
    /// </summary>
    internal class ResultData : DynamicObject,IDisposable
    {
        private readonly Func<Dictionary<String,object>> _viewDataThunk;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="viewDataThunk">得到一个字典的返回值对象</param>
        public ResultData(Func<Dictionary<String, object>> viewDataThunk)
        {
            this._viewDataThunk = viewDataThunk;
        }
        /// <summary>
        /// 迭代所有的KEY
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.Data.Keys;
        }
        /// <summary>
        /// 尝试得到当前名称的值
        /// </summary>
        /// <param name="binder">动态的名称</param>
        /// <param name="result">返回值</param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name.ToLower() == "count")
            {
                result = this.Count;
            }
            else
            {
                result = this.Data[binder.Name];
            }
            return true;
        }
        /// <summary>
        /// 尝试设置值
        /// </summary>
        /// <param name="binder">动态的名称</param>
        /// <param name="value">需要设置的值</param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.Data[binder.Name] = value;
            return true;
        }
        /// <summary>
        /// 内部成员，用户指定保存数据的字典
        /// </summary>
        private Dictionary<String, object> Data
        {
            get
            {
                return this._viewDataThunk();
            }
        }
        /// <summary>
        /// 获取一个值，该值表示当前动态对象包含的元素个数
        /// </summary>
        public Int32 Count
        {
            get
            {
                return Data.Count;
            }
        }
        /// <summary>
        /// 获取一个值，根据当前的索引
        /// </summary>
        /// <param name="Index">当前的索引</param>
        /// <returns>得到的值</returns>
        public object this[Int32 Index]
        {
            get
            {
                return Data.ToList()[Index].Value;
            }
        }

        public void Dispose()
        {
            if (this.Count > 0)
            {
                this.Data.Clear();
                GC.ReRegisterForFinalize(this);
                GC.Collect();
            }
        }
    }
}
