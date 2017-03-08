using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_Categors类
    /// </summary>
    [Table(Name = "TB_Categors")]
    /*[DataRangeLimit(DataRangeTypeValue.Catagory)]*/
    public class Category : IModelDropDown<Int64>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示序号
        /// </summary>
        [Display(Name = "序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示父类目
        /// </summary>
        [Display(Name = "父类目")]
        [Column]
        public Int64 PID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示类目名称
        /// </summary>
        [Display(Name = "类目名称")]
        [Column]
        [Required]
        public String Name { get; set; }
    }
}
