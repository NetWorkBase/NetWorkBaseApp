using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using FileManager;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_Users类
    /// </summary>
    [Table(Name = "TB_Users")]
    public class User : IModelID<Int64>, IModelName
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示序号
        /// </summary>
        [Display(Name = "序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示所属单位
        /// </summary>
        [Display(Name = "所属单位")]
        [Column]
        [Required]
        public Int64 CompanyID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示登录账号
        /// </summary>
        //[Display(Name = "登录账号"), CheckRepeat(ErrorMessage: "存在相同登录账号的信息，增加失败！")]
        [Column]
        [Required]
        public String UserID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示登录密码
        /// </summary>
        [Display(Name = "登录密码")]
        [Column]
        [Required]
        //[MD5Password]
        public String Password { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示用户姓名
        /// </summary>
        [Display(Name = "用户姓名")]
        [Column]
        [Required]
        public String UserName { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示是否档案员
        /// </summary>
        [Display(Name = "是否档案员")]
        [Column]
        [Required]
        public Boolean IsManager { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示能否显示附件
        /// </summary>
        [Display(Name = "能否显示附件")]
        [Column]
        [Required]
        public Boolean CanListAnnes { get; set; }
        private EntityRef<Company> _CompanyID_ID;
        /// <summary>
        /// 获取或者设置一个值，该值表示TB_Companys类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "CompanyID_ID", Storage = "_CompanyID_ID", ThisKey = "CompanyID", OtherKey = "ID", IsForeignKey = true)]
        public Company TheCompanyID { get { return _CompanyID_ID.Entity; } }

        public String Name
        {
            get
            {
                return this.UserName;
            }
            set
            {
                this.UserName = value;
            }
        }
    }
}
