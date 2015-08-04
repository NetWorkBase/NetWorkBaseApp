using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetWorkGroup.Mvc
{
    /// <summary>
    /// 表示需要用户登录才可以使用的特性
    /// <para>如果不需要处理用户登录，则请指定AllowAnonymousAttribute属性</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class NeedLoginAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public NeedLoginAttribute()
        {
            this._LoginUrl = "/";
        }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="loginUrl">表示没有登录跳转的登录地址</param>
        public NeedLoginAttribute(String loginUrl)
            : this()
        {
            this._LoginUrl = loginUrl;
        }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="loginUrl">表示没有登录跳转的登录地址</param>
        /// <param name="sessionName">表示登录所用的Session名称</param>
        public NeedLoginAttribute(String loginUrl, String sessionName)
            : this(loginUrl)
        {
            this._LoginSessionName = sessionName;
        }
        private String _LoginSessionName = "OLUsers";
        /// <summary>
        /// 获取或者设置一个值，改值表示登录Session名称
        /// <para>如果web.config中未定义NeedLoginSessionName的值，则默认为LoginedUser</para>
        /// </summary>
        public String LoginSessionName
        {
            get { return _LoginSessionName.Trim(); }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("登录Session名称不能为空！");
                }
                else
                {
                    this._LoginSessionName = value.Trim();
                }
            }
        }
        private String _LoginUrl = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，改值表示登录地址
        /// <para>如果web.config中未定义NeedLoginUrl的值，则默认为/User/Login</para>
        /// </summary>
        public String LoginUrl
        {
            get { return _LoginUrl.Trim(); }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("登录地址不能为空！");
                }
                else
                {
                    _LoginUrl = value.Trim();
                }
            }
        }

        /// <summary>
        /// 处理用户登录
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext == null)
            {
                throw new Exception("此特性只适合于Web应用程序使用！");
            }
            else if (filterContext.HttpContext.Session == null)
            {
                throw new Exception("服务器Session不可用！");
            }
            else if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                if (filterContext.HttpContext.Session[_LoginSessionName] == null)
                {
                    string returnUrl = filterContext.HttpContext.Request.Url.ToString();
                    _LoginUrl += (_LoginUrl.Contains("?") ? "&" : "?") + "ref=" + returnUrl;
                    filterContext.Result = new RedirectResult(_LoginUrl, true);
                }
            }
        }
    }
}
