using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_ArticleType类
	/// </summary>
    [Table(Name = "MS_ArticleType")]
    public class ArticleType<TType> : IModelParentID<TType>, IModelDropDown<TType>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示文章类型ID
        /// </summary>
        [Display(Name = "文章类型ID")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false, Name = "ArticleType_ID")]
        public TType ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示类型父类ID
        /// </summary>
        [Display(Name = "类型父类ID")]
        [Column(Name = "ArticleType_ParentID")]
        public TType PID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示ArticleType_Name
        /// </summary>
        [Display(Name = "ArticleType_Name")]
        [Column(Name = "ArticleType_Name")]
        public String Name { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示ArticleType_IsCheck
        /// </summary>
        [Display(Name = "ArticleType_IsCheck")]
        [Column]
        public Int32 ArticleType_IsCheck { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示排序
        /// </summary>
        [Display(Name = "排序")]
        [Column]
        public Int32 ArticleType_Order { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示备注
        /// </summary>
        [Display(Name = "备注")]
        [Column]
        public String ArticleType_Mark { get; set; }
    }
}
