using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_User类
	/// </summary>
    [Table(Name = "MS_User")]
    public class User : IModelID<Int32>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示User_ID
        /// </summary>
        [Display(Name = "User_ID")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int32 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_Account
        /// </summary>
        [Display(Name = "User_Account")]
        [Column]
        public String User_Account { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示登录密码
        /// </summary>
        [Display(Name = "登录密码")]
        [Column]
        public String User_PassWord { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Column]
        public String User_Name { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示昵称
        /// </summary>
        [Display(Name = "昵称")]
        [Column]
        public String User_Nick { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示职位名称
        /// </summary>
        [Display(Name = "职位名称")]
        [Column]
        public String User_PostName { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_ImgUrl
        /// </summary>
        [Display(Name = "User_ImgUrl")]
        [Column]
        public String User_ImgUrl { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示性别
        /// </summary>
        [Display(Name = "性别")]
        [Column]
        public char User_Sex { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示手机
        /// </summary>
        [Display(Name = "手机")]
        [Column]
        public String User_Mobile { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_Phone
        /// </summary>
        [Display(Name = "User_Phone")]
        [Column]
        public String User_Phone { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示电子邮件
        /// </summary>
        [Display(Name = "电子邮件")]
        [Column]
        public String User_Email { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        [Column]
        public DateTime User_Birthday { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示通信地址
        /// </summary>
        [Display(Name = "通信地址")]
        [Column]
        public String User_Address { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示用户积分
        /// </summary>
        [Display(Name = "用户积分")]
        [Column]
        public Int32 User_Integral { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示用户金币
        /// </summary>
        [Display(Name = "用户金币")]
        [Column]
        public Int32 User_Gold { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示账户余额
        /// </summary>
        [Display(Name = "账户余额")]
        [Column]
        public decimal User_Balance { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_Interest
        /// </summary>
        [Display(Name = "User_Interest")]
        [Column]
        public String User_Interest { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_School
        /// </summary>
        [Display(Name = "User_School")]
        [Column]
        public String User_School { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_grade
        /// </summary>
        [Display(Name = "User_grade")]
        [Column]
        public String User_grade { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_IsCheck
        /// </summary>
        [Display(Name = "User_IsCheck")]
        [Column]
        public Int32 User_IsCheck { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示1  学生   2  家长    3  教师
        /// </summary>
        [Display(Name = "1  学生   2  家长    3  教师")]
        [Column]
        public Int32 User_Type { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示学校ID
        /// </summary>
        [Display(Name = "学校ID")]
        [Column]
        public Int32 School_ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示Admin_User_ID
        /// </summary>
        [Display(Name = "Admin_User_ID")]
        [Column]
        public Int32 Admin_User_ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示年级ID
        /// </summary>
        [Display(Name = "年级ID")]
        [Column]
        public Int32 Grade_ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示想说的话
        /// </summary>
        [Display(Name = "想说的话")]
        [Column]
        public String User_Word { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示关系
        /// </summary>
        [Display(Name = "关系")]
        [Column]
        public String User_Relationship { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示学生账号
        /// </summary>
        [Display(Name = "学生账号")]
        [Column]
        public String User_StudentAccount { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_RegDate
        /// </summary>
        [Display(Name = "User_RegDate")]
        [Column]
        public DateTime User_RegDate { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示User_IsDel
        /// </summary>
        [Display(Name = "User_IsDel")]
        [Column]
        public Int32 User_IsDel { get; set; }

        private EntityRef<School> _School_ID_School_ID;
        /// <summary>
        /// 获取或者设置一个值，该值表示MS_School类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "School_ID_School_ID", Storage = "_School_ID_School_ID", ThisKey = "School_ID", OtherKey = "School_ID", IsForeignKey = true)]
        public School TheSchool_ID { get { return _School_ID_School_ID.Entity; } }
    }
}
