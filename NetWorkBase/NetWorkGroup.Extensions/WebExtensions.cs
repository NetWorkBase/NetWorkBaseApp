using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace System.Web.UI.Extensions
{
    /// <summary>
    /// 应用程序扩展，加入对WebForm的支持
    /// </summary>
    public static class WebExtensions
    {
        static int deep1 = 1;
        /// <summary>
        /// 递归生成树状DropDownList
        /// </summary>
        /// <typeparam name="T">需要显示的相关数据的集合，任意类型但需要实现IQueryable接口</typeparam>
        /// <typeparam name="TType">实现的类型在IDropDown接口中用于指定标识列的数据类型</typeparam>
        /// <param name="Data">需要显示的相关数据的集合，任意类型但需要实现IQueryable接口</param>
        /// <param name="EmptyItemDisplayText">空数据中显示的数据(要显示此数据需将IsAppendEmptyItem置为True)</param>
        /// <param name="EmptyValue">添加的空数据行中的数据(要使用此数据需将IsAppendEmptyItem置为True)</param>
        /// <param name="IsAppendEmptyItem">是否添加一个空行</param>
        /// <param name="DropDownList">绑定的DropDownList</param>
        public static void ShowDropDownListItemByTreeWebFrom<T, TType>(this IQueryable<T> Data, DropDownList DropDownList, String EmptyItemDisplayText = "【请选择】", String EmptyValue = "0", Boolean IsAppendEmptyItem = false) where T : IModelDropDown<TType>
        {
            ListItemCollection list = new ListItemCollection();
            if (IsAppendEmptyItem) list.Add(new ListItem(EmptyItemDisplayText, EmptyValue));
            foreach (var item in Data.Where(p => p.PID.Equals(0) || p == null))
            {
                list.Add(new ListItem() { Text = item.Name.Trim(), Value = item.ID.ToStringTrim() });
                ShowInnerListItemWebFrom(Data, item.ID, list);
            }
            DropDownList.Items.AddRange(list.AsArray<ListItem>());
        }

        private static void ShowInnerListItemWebFrom<T, TType>(IQueryable<T> data, TType ParID, ListItemCollection parent)
            where T : IModelDropDown<TType>
        {
            foreach (var item in data.Where(p => p.PID.Equals(ParID)))
            {
                parent.Add(new ListItem() { Text = (deep1++).MakeBlank() + item.Name, Value = item.ID.ToStringTrim() });
                ShowInnerListItemWebFrom(data, item.ID, parent);
            }
            if (deep1 > 1)
            {
                deep1--;
            }
        }
        #region [分页相关]
        /// <summary>
        /// 分页扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <param name="pagerOptions"></param>
        /// <returns></returns>
        public static HtmlString HtmlPager<T>(this object helper, PagerOptions<T> pagerOptions)
        {
            Int32 maxPage = (pagerOptions.MaxRecord % pagerOptions.PageSize > 0 ? pagerOptions.MaxRecord / pagerOptions.PageSize + 1 : pagerOptions.MaxRecord / pagerOptions.PageSize);
            Int32 page = 1;
            String requestPage = HttpContext.Current.Request["page"];
            String currentPageUrl = HttpContext.Current.Request.Url.PathAndQuery.ToLower();
            Regex regexPage = new Regex(@"page=(\d+)", RegexOptions.IgnoreCase);
            if (regexPage.IsMatch(currentPageUrl))
            {
                Match match = regexPage.Matches(currentPageUrl)[0];
                currentPageUrl = currentPageUrl.Replace("?" + match.Groups[0].Value, String.Empty).Replace("&" + match.Groups[0].Value, String.Empty);
            }
            String spliter = "?";
            if (currentPageUrl.Contains("?"))
            {
                spliter = "&";
            }
            if (requestPage != null)
            {
                try
                {
                    page = Convert.ToInt32(requestPage);
                }
                catch { page = 1; }
                page = page > maxPage ? maxPage : (page <= 0 ? 1 : page);
            }
            StringBuilder sbReturn = new StringBuilder();
            StringBuilder sbPager = new StringBuilder("<div class=\"" + pagerOptions.PagerCssClass + "\">");
            if (pagerOptions.MaxRecord > pagerOptions.PageSize)
            {
                sbPager.Append("<a" + (page == 1 ? " href=\"javascript:;\"  class=\"disabled\"" : " href=\"" + currentPageUrl + "\"") + ">首页</a>");
                if (page - 1 > 0)
                {
                    sbPager.Append("<a href=\"" + currentPageUrl + spliter + "Page=" + (page - 1) + "\">上一页</a>");
                }
                if (page + pagerOptions.MorePage <= maxPage)
                {
                    for (long i = page; i <= page + pagerOptions.MorePage; i++)
                    {
                        if (i < maxPage)
                        {
                            sbPager.Append("<a href=\"" + currentPageUrl + spliter + "Page=" + i + "\" class=\"" + (i == page ? "on" : "") + "\">" + i + "</a>");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (maxPage >= pagerOptions.MorePage)
                    {
                        for (long i = maxPage - pagerOptions.MorePage + 1; i < maxPage; i++)
                        {
                            sbPager.Append("<a href=\"" + currentPageUrl + spliter + "Page=" + i + "\" class=\"" + (i == page ? "on" : "") + "\">" + i + "</a>");
                        }
                    }
                    else
                    {
                        for (long i = 1; i <= maxPage; i++)
                        {
                            sbPager.Append("<a href=\"" + currentPageUrl + spliter + "Page=" + i + "\" class=\"" + (i == page ? "on" : "") + "\">" + i + "</a>");
                        }
                    }
                }
                if (page + 1 <= maxPage)
                {
                    sbPager.Append("<a" + (page >= maxPage ? " href=\"javascript:;\"  class=\"disabled\"" : " href=\"" + currentPageUrl + spliter + "Page=" + (page + 1) + "\"") + ">下一页</a>");
                }
                sbPager.Append("<a" + (page >= maxPage ? " href=\"javascript:;\"  class=\"disabled\"" : " href=\"" + currentPageUrl + spliter + "Page=" + maxPage + "\"") + ">末页</a>");
                sbPager.Append("&nbsp;共" + maxPage + "页&nbsp;" + pagerOptions.MaxRecord + "条记录&nbsp;");
                sbPager.Append("<input type=\"text\" id=\"Pages\" class=\"inputNum\" /><input type=\"button\" class=\"btnGo\" onclick='if($(\"#Pages\").val()==\"\"){alert(\"请输入页码！\");}else{if(isNaN($(\"#Pages\").val())){alert(\"页码必须输入数字！\");}else{if(!($(\"#Pages\").val()>" + maxPage + ")){location.href=\"" + currentPageUrl + spliter + "Page=\"+$(\"#Pages\").val();}else{alert(\"输入的页数不能大于总页数！\");}}}' value=\"跳转\" />");
            }
            sbPager.Append("</div>");

            sbReturn.AppendLine(sbPager.ToString());
            return new HtmlString(sbReturn.ToString().Trim());
        }
        #endregion
        #region[ASP.NET WEBForm相关]
        /// <summary>
        /// 想页面输出window.Alert对话框，并在输出完毕后执行扩展Script方法
        /// </summary>
        /// <typeparam name="T">输出的客户端类型</typeparam>
        /// <param name="Msg">对话框中显示的消息</param>
        /// <param name="obj">使用注册的客户端</param>
        /// <param name="InnerScript">对话框弹出后需要执行的Script代码</param>
        /// <param name="IsCreateOnlyKey">是否创建唯一的Key</param>
        /// <param name="IsAddScriptTag">是否添加Script脚本标签</param>
        public static void Alert<T>(this String Msg, T obj, String InnerScript = "", bool IsCreateOnlyKey = true, bool IsAddScriptTag = true)
        {
            if (typeof(T).Equals(typeof(System.Web.UI.UpdatePanel)))
            {
                if (IsCreateOnlyKey)
                {
                    ScriptManager.RegisterStartupScript(obj.As<UpdatePanel>(), obj.GetType(), "", "alert(\"" + Msg + "\");" + InnerScript + ";", IsAddScriptTag);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(obj.As<UpdatePanel>(), obj.GetType(), Guid.NewGuid().ToStringTrim(), "alert(\"" + Msg + "\");" + InnerScript + ";", IsAddScriptTag);
                }
            }
            else if (typeof(T).BaseType==typeof(System.Web.UI.Page))
            {
                if (IsCreateOnlyKey)
                {
                    obj.As<Page>().ClientScript.RegisterClientScriptBlock(obj.GetType(), "ScriptBlocks", "alert(\"" + Msg + "\");" + InnerScript + ";", IsAddScriptTag);
                }
                else
                {
                    obj.As<Page>().ClientScript.RegisterClientScriptBlock(obj.GetType(), Guid.NewGuid().ToStringTrim(), "alert(\"" + Msg + "\");" + InnerScript + ";", IsAddScriptTag);
                }
            }
            else if (typeof(T).Equals(typeof(MRHNull)))
            {
                HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert(\"" + Msg + "\");" + InnerScript + ";</script>");
            }
            else
            {
                throw new Exception("不支持选定的类型输出JavaScript方法！");
            }
        }
        /// <summary>
        /// 想页面输出window.confirm对话框，当点击确定按钮后执行指定的js方法
        /// </summary>
        /// <typeparam name="T">输出的客户端类型</typeparam>
        /// <param name="Msg">对话框中显示的消息</param>
        /// <param name="obj">使用注册的客户端</param>
        /// <param name="InnerScript">对话框弹出后需要执行的Script代码</param>
        /// <param name="IsCreateOnlyKey">是否创建唯一的Key</param>
        /// <param name="IsAddScriptTag">是否添加Script脚本标签</param>
        public static void Confirm<T>(this String Msg, T obj, String InnerScript, bool IsCreateOnlyKey = true, bool IsAddScriptTag = true)
        {
            if (string.IsNullOrEmpty(InnerScript))
            {
                throw new Exception("未填写点击确定后用户需要执行的js函数");
            }
            else
            {
                if (typeof(T).Equals(typeof(System.Web.UI.UpdatePanel)))
                {
                    if (IsCreateOnlyKey)
                    {
                        ScriptManager.RegisterStartupScript(obj.As<UpdatePanel>(), obj.GetType(), "ScriptBlocks", "if(confirm(\"" + Msg + "\")){" + InnerScript + ";}", IsAddScriptTag);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(obj.As<UpdatePanel>(), obj.GetType(), Guid.NewGuid().ToStringTrim(), "if(confirm(\"" + Msg + "\")){" + InnerScript + ";}", IsAddScriptTag);
                    }
                }
                else if (typeof(T).BaseType == typeof(System.Web.UI.Page))
                {
                    if (IsCreateOnlyKey)
                    {
                        obj.As<Page>().ClientScript.RegisterClientScriptBlock(obj.GetType(), "ScriptBlocks", "if(confirm(\"" + Msg + "\")){" + InnerScript + ";}", IsAddScriptTag);
                    }
                    else
                    {
                        obj.As<Page>().ClientScript.RegisterClientScriptBlock(obj.GetType(), Guid.NewGuid().ToStringTrim(), "if(confirm(\"" + Msg + "\")){" + InnerScript + ";}", IsAddScriptTag);
                    }
                }
                else if (typeof(T).Equals(typeof(MRHNull)))
                {
                    HttpContext.Current.Response.Write("<script type=\"text/javascript\">if(confirm(\"" + Msg + "\")){" + InnerScript + ";}</script>");
                }
                else
                {
                    throw new Exception("不支持选定的类型输出JavaScript方法！");
                }
            }
        }
        /// <summary>
        /// 在页面中执行window.location方法，将页面跳转至指定的页面
        /// </summary>
        /// <typeparam name="T">输出的客户端类型</typeparam>
        /// <param name="Url">跳转的目标地址</param>
        /// <param name="UrlKind">URL类型</param>
        /// <param name="obj">使用注册的客户端</param>
        /// <param name="ParentName">指定页面跳转时的框架，可选</param>
        /// <param name="IsAddScriptTag">是否在页面中创建Script标签，可选</param>
        public static void LocationHref<T>(this String Url, UriKind UrlKind, T obj, String ParentName = "", bool IsAddScriptTag = true)
        {
            String NewUrl = String.Empty;
            switch (UrlKind)
            {
                case UriKind.Absolute:
                    NewUrl = Url;
                    break;
                case UriKind.Relative:
                    NewUrl = Url.ResolveUrl();
                    break;
                case UriKind.RelativeOrAbsolute:
                    throw new Exception("请选择您输入的地址为一个相对地址或者是一个绝对地址！");
            }
            if (typeof(T).Equals(typeof(System.Web.UI.UpdatePanel)))
            {
                ScriptManager.RegisterStartupScript(obj.As<UpdatePanel>(), obj.GetType(), "ScriptBlocks", (string.IsNullOrEmpty(ParentName)) ? "location.href=(\"" + NewUrl + "\");" : "" + ParentName + ".location.href=(\"" + NewUrl + "\");", IsAddScriptTag);
            }
            else if (typeof(T).BaseType == typeof(System.Web.UI.Page))
            {
                obj.As<Page>().ClientScript.RegisterClientScriptBlock(obj.GetType(), "ScriptBlocks", (string.IsNullOrEmpty(ParentName)) ? "location.href=(\"" + NewUrl + "\");" : "" + ParentName + ".location.href=(\"" + NewUrl + "\");", IsAddScriptTag);
            }
            else if (typeof(T).Equals(typeof(MRHNull)))
            {
                HttpContext.Current.Response.Write(String.Format("<script type=\"text/javascript\">{0}</script>", (string.IsNullOrEmpty(ParentName)) ? "location.href=(\"" + NewUrl + "\");" : "" + ParentName + ".location.href=(\"" + NewUrl + "\");"));
            }
            else
            {
                throw new Exception("不支持选定的类型输出JavaScript方法！");
            }
        }
        /// <summary>
        /// 向页面中输出执行JS脚本的方法
        /// </summary>
        /// <typeparam name="T">输出的客户端类型</typeparam>
        /// <param name="js">需要执行的JS代码</param>
        /// <param name="obj">使用注册的客户端</param>
        /// <param name="IsCreateOnlyKey">指定页面跳转时的框架，可选</param>
        /// <param name="IsAddScriptTag">是否在页面中创建Script标签，可选</param>
        public static void InvokeJs<T>(this String js, T obj, bool IsCreateOnlyKey = true, bool IsAddScriptTag = true)
        {
            if (typeof(T).Equals(typeof(System.Web.UI.UpdatePanel)))
            {
                ScriptManager.RegisterStartupScript(obj.As<UpdatePanel>(), obj.GetType(), "ScriptBlocks", js, IsAddScriptTag);
            }
            else if (typeof(T).BaseType == typeof(System.Web.UI.Page))
            {
                obj.As<Page>().ClientScript.RegisterClientScriptBlock(obj.GetType(), "ScriptBlocks", js, IsAddScriptTag);
            }
            else if (typeof(T).Equals(typeof(MRHNull)))
            {
                HttpContext.Current.Response.Write(String.Format("<script type=\"text/javascript\">{0}</script>", js));
            }
            else
            {
                throw new Exception("不支持选定的类型输出JavaScript方法！");
            }
        }
        /// <summary>
        /// 将相对URL进行转换
        /// </summary>
        /// <param name="relativeUrl">相对URL</param>
        /// <returns>绝对URL</returns>
        public static string ResolveUrl(this string relativeUrl)
        {
            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' ||
                relativeUrl[0] == '\\') return relativeUrl;

            int idxOfScheme =
              relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

            // found question mark already? query string, do not touch!
            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1
                && relativeUrl[0] == '~'
                && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else foundSlash = false;
            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash) continue;
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else if (foundSlash) foundSlash = false;
                    }
                }
                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }
        /// <summary>
        /// 增加一个空行至ListControl中
        /// </summary>
        /// <param name="control">ListControl</param>
        /// <param name="DisplayText">空行显示文本</param>
        /// <param name="DataValue">空行值</param>
        public static void AppendEmptyRowToDropDownList(this ListControl control, String DisplayText = "【请选择】", String DataValue = "0")
        {
            ListItem item = new ListItem(DisplayText, DataValue);
            control.Items.Add(item);
            control.SelectedValue = DataValue;
        }
        #endregion
    }
}
