using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 分页选项
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagerOptions<T>
    {
        /// <summary>
        /// 需要分页的内容
        /// </summary>
        public IEnumerable<T> ItemCollection { get; set; }

        /// <summary>
        /// 获取或者设置一个值，该值表示最大记录数
        /// </summary>
        public Int32 MaxRecord { get; set; }

        private Int32 pageSize = 10;
        /// <summary>
        /// 每页记录条数，默认10页
        /// </summary>
        public Int32 PageSize { get { return pageSize; } set { pageSize = value; } }

        private Int32 morePage = 10;
        /// <summary>
        /// 获取或者设置一个值，该值表示最多显示几页
        /// </summary>
        public Int32 MorePage
        {
            get { return morePage; }
            set
            {
                if (value > 0)
                {
                    morePage = value;
                }
            }
        }
        private String pagerCssClass = "Pager";
        /// <summary>
        /// 获取或者设置一个值，该值表示Pager CSS 类名
        /// </summary>
        public String PagerCssClass { get { return pagerCssClass; } set { pagerCssClass = value; } }
    }
}
