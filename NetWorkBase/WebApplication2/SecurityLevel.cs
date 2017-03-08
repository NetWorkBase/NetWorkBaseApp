using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web.Mvc;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_SecurityLevels类
    /// </summary>
    [Table(Name = "TB_SecurityLevels")]
    public class SecurityLevel : IModelID<Int64>, IModelName
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示序号
        /// </summary>
        [Display(Name = "序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示密级名称
        /// </summary>
        [Display(Name = "密级名称")]
        [Column]
        [Required]
        public String Name { get; set; }
        /// <summary>
        /// 获取一个值，该值表示下拉框需要的密级数据
        /// </summary>
        public static IEnumerable<SelectListItem> InitSecurityLevel
        {
            get
            {
                var query = from x in new NetWorkGroup.Entity.DefaultEntity<SecurityLevel>().Show().AsEnumerable()
                            select new SelectListItem
                            {
                                Text = $"{x.Name.ToStringTrim()}",
                                Value = x.ID.ToStringTrim()
                            };
                return query;
            }
        }
    }
}
