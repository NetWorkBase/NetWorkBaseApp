using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace System
{
    /// <summary>
    /// 核心程序基类，提供基础服务
    /// </summary>
    public class CoreBase : IDisposable
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CoreBase() { }
        /// <summary>
        /// 表示一个全局字符串变量，用于保存在线的用户信息
        /// </summary>
        public const String OnLineUser = "OLUsers";
        /// <summary>
        /// 获取一个值，该值表示当前的Web应用程序上下文
        /// </summary>
        protected virtual HttpContext WebContext
        {
            get
            {
                return HttpContext.Current;
            }
        }
        /// <summary>
        /// 获取一个值，该值表示当前Http相应的HttpSessionState对象
        /// </summary>
        public virtual HttpSessionState Session
        {
            get
            {
                return WebContext.Session;
            }
        }
        /// <summary>
        /// 获取一个值，该值表示当前Http相应的HttpServerUtility对象
        /// </summary>
        public virtual HttpServerUtility Server
        {
            get
            {
                return WebContext.Server;
            }
        }
        /// <summary>
        /// 获取一个值，该值表示当前Http相应的HttpResponse对象
        /// </summary>
        public virtual HttpResponse Response
        {
            get
            {
                return WebContext.Response;
            }
        }
        /// <summary>
        /// 获取一个值，该值表示当前Http相应的HttpRequest对象
        /// </summary>
        public virtual HttpRequest Request
        {
            get
            {
                return WebContext.Request;
            }
        }
        /// <summary>
        /// 获取一个值，该值表示当前Http相应的HttpApplicationState对象
        /// </summary>
        public virtual HttpApplicationState Application
        {
            get
            {
                return WebContext.Application;
            }
        }
        private ResultData _dynamicResultDataDictionary = null;
        private Dictionary<String, Object> inner = new Dictionary<string, object>();
        /// <summary>
        /// 表示数据库执行完成之后向前台输出的键值对返回值。
        /// </summary>
        public dynamic Result
        {
            get
            {
                Func<Dictionary<String, Object>> resultDataThunk = null;
                if (this._dynamicResultDataDictionary == null)
                {
                    if (resultDataThunk == null)
                    {
                        resultDataThunk = () => this.inner;
                    }
                    this._dynamicResultDataDictionary = new ResultData(resultDataThunk);
                }
                return this._dynamicResultDataDictionary;
            }
            private set
            {
                _dynamicResultDataDictionary = value;
            }
        }
        /// <summary>
        /// 设置返回值
        /// </summary>
        /// <typeparam name="T">任意类型数据</typeparam>
        /// <param name="obj">返回值数据值</param>
        protected virtual void SetReturnValue<T>(T obj)
        {
            this.Result.ReturnValue = obj;
        }
        /// <summary>
        /// 释放已经使用的程序资源以释放内存
        /// </summary>
        public void Dispose()
        {
            if (this.Result != null)
            {
                IDisposable i = this.Result;
                i.Dispose();
            }
            GC.ReRegisterForFinalize(this);
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
