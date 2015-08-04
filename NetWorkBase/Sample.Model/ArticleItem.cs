using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Sample.Model
{
	/// <summary>
	/// 表示TB_ArticleItem类
	/// </summary>
    [Table(Name = "TB_ArticleItem")]
    public class ArticleItem : IModelDropDown<Int64?>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示文章类别ID
        /// </summary>
        [Display(Name = "文章类别ID")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64? ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示文章类别名称
        /// </summary>
        [Display(Name = "文章类别名称")]
        [Column]
        [Required]
        public String Name { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示类别关键字
        /// </summary>
        [Display(Name = "类别关键字")]
        [Column]
        public String KeyWords { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示类别简介
        /// </summary>
        [Display(Name = "类别简介")]
        [Column]
        public String Description { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示外链地址
        /// </summary>
        [Display(Name = "外链地址")]
        [Column]
        public String OutUrl { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示是否外链
        /// </summary>
        [Display(Name = "是否外链")]
        [Column]
        [Required]
        public Boolean IsOutableItem { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        [Column]
        [Required]
        public Boolean IsEnabled { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示排序次序
        /// </summary>
        [Display(Name = "排序次序")]
        [Column]
        [Required]
        public Int32 ShortIndex { get; set; }
        private Int64 _PID = 0;
        /// <summary>
        /// 获取或者设置一个值，该值表示PID
        /// </summary>
        [Display(Name = "父类别")]
        [Column]
        public Int64? PID
        {
            get { return this._PID; }
            set
            {
                if (value.HasValue)
                {
                    this._PID = value.Value;
                }
                else
                {
                    this._PID = 0;
                }
            }
        }
        /// <summary>
        /// 获取或者设置一个值，该值表示是否图片列表显示文章
        /// </summary>
        [Display(Name = "是否图片列表显示文章")]
        [Column]
        [Required]
        public Boolean IsImageShowItem { get; set; }
    }
}
