using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web.Mvc;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_Agencies类
    /// </summary>
    [Table(Name = "TB_Agencies")]
    public class Agencie : IModelID<Int64>, IModelName
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示序号
        /// </summary>
        [Display(Name = "序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示机构问题代码
        /// </summary>
        [Display(Name = "机构问题代码"),/*CheckRepeat(ErrorMessage:"存在相同的机构问题代码，增加失败！")*/]
        [Column]
        [Required]
        public String DM { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示机构问题名称
        /// </summary>
        [Display(Name = "机构问题名称"),/*CheckRepeat(ErrorMessage:"存在相同的机构问题名称，增加失败！")*/]
        [Column]
        [Required]
        public String Name { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        [Column]
        [Required]
        public Boolean IsEnabled { get; set; }
        /// <summary>
        /// 获取一个值，该值表示下拉框需要的机构问题数据
        /// </summary>
        public static IEnumerable<SelectListItem> InitAgencies
        {
            get
            {
                var query = from x in new NetWorkGroup.Entity.DefaultEntity<Agencie>().Show().AsEnumerable()
                            select new SelectListItem
                            {
                                Text = $"{x.Name.ToStringTrim()}({x.DM})",
                                Value = x.DM.Trim()
                            };
                return query;
            }
        }
    }
}
