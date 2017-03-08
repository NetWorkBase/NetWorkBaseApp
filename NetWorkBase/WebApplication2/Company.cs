using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using FileManager;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_Companys类
    /// </summary>
    [Table(Name = "TB_Companys"),Serializable]
    public class Company : IModelID<Int64>, IModelName
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示单位序号
        /// </summary>
        [Display(Name = "单位序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示单位代码
        /// </summary>
        [Display(Name = "单位代码")]
        [Column]
        [Required]
        //[CheckRepeat("系统中已存在您填写的单位代码，请重新填写！")]
        public String CompanyNo { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示单位名称
        /// </summary>
        [Display(Name = "单位名称")]
        [Column]
        [Required]
        //[CheckRepeat("系统中已存在您填写的单位名称，请重新填写！")]
        public String CompanyName { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示联系人
        /// </summary>
        [Display(Name = "联系人")]
        [Column]
        [Required]
        public String Contact { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        [Column]
        [Required]
        public String Telephone { get; set; }

        public String Name
        {
            get
            {
                return this.CompanyName;
            }
            set
            {
                this.CompanyName = value;
            }
        }
    }
}
