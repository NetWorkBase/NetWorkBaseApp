using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq;
using System.Web.Mvc;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_Retentions类
    /// </summary>
    [Table(Name = "TB_Retentions")]
    public class Retention : IModelID<Int64>, IModelName
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示顺序号
        /// </summary>
        [Display(Name = "顺序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示保管期限代码
        /// </summary>
        [Display(Name = "保管期限代码"), /*CheckRepeat(ErrorMessage: "存在相同的保管期限代码，请检查！")*/]
        [Column]
        [Required]
        public String DM { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示保管期限名称
        /// </summary>
        [Display(Name = "保管期限名称"), /*CheckRepeat(ErrorMessage: "存在相同的保管期限名称，请检查！")*/]
        [Column]
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// 获取一个值，该值表示下拉框需要的保管期限数据
        /// </summary>
        public static IEnumerable<SelectListItem> InitRetention
        {
            get
            {
                var query = from x in new NetWorkGroup.Entity.DefaultEntity<Retention>().Show().AsEnumerable()
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
