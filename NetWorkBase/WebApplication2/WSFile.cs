using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace FileManager.Models
{
    /// <summary>
    /// 表示TB_WSFiles类
    /// </summary>
    [Table(Name = "TB_WSFiles")]
    public class WSFile : IModelID<Int64>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示序号
        /// </summary>
        [Display(Name = "序号")]
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public Int64 ID { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示档案类型
        /// </summary>
        [Display(Name = "档案门类代码")]
        [Column]
        [Required]
        public string DAML { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示档案类型
        /// </summary>
        [Display(Name = "档案类型")]
        [Column]
        [Required]
        public string DALX { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示档号
        /// </summary>
        [Display(Name = "档号")]
        [Column]
        [Required]
        public String DH { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示年度
        /// </summary>
        [Display(Name = "年度")]
        [Column]
        [Required]
        public Int32 ND { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示件号
        /// </summary>
        [Display(Name = "件号")]
        [Column]
        [Required]
        public Int64 JH { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示机构问题
        /// </summary>
        [Display(Name = "机构问题")]
        [Column]
        [Required]
        public String JGWT { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示文件题名
        /// </summary>
        [Display(Name = "文件题名")]
        [Column]
        [Required]
        public String WJTM { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示责任者
        /// </summary>
        [Display(Name = "责任者")]
        [Column]
        [Required]
        public String ZRZ { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示成文日期
        /// </summary>
        [Display(Name = "成文日期")]
        [Column]
        [Required]
        public DateTime CWRQ { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示文件编号
        /// </summary>
        [Display(Name = "文件编号")]
        [Column]
        [Required]
        public String WJBH { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示保管期限
        /// </summary>
        [Display(Name = "保管期限")]
        [Column]
        [Required]
        public String BGQX { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示页数
        /// </summary>
        [Display(Name = "页数")]
        [Column]
        [Required]
        public Int32 YS { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示密级
        /// </summary>
        [Display(Name = "密级")]
        [Column]
        public Int64 MJ { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示人名
        /// </summary>
        [Display(Name = "人名")]
        [Column]
        public String RM { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示盒号
        /// </summary>
        [Display(Name = "盒号")]
        [Column]
        public String HH { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示文本项
        /// </summary>
        [Display(Name = "文本项")]
        [Column]
        public String WBX { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示主题词
        /// </summary>
        [Display(Name = "主题词")]
        [Column]
        public String ZTC { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示分类号
        /// </summary>
        [Display(Name = "分类号")]
        [Column]
        public String FLH { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示载体类型
        /// </summary>
        [Display(Name = "载体类型")]
        [Column]
        public String ZTLX { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示载体形态
        /// </summary>
        [Display(Name = "载体形态")]
        [Column]
        public String ZTXT { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示附注
        /// </summary>
        [Display(Name = "附注")]
        [Column]
        public String FZ { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示全文标识
        /// </summary>
        [Display(Name = "全文标识")]
        [Column]
        public String QWBS { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示添加人
        /// </summary>
        [Display(Name = "添加人")]
        [Column]
        [Required]
        public String AppendUser { get; set; }
        /// <summary>
        /// 获取或者设置一个值，该值表示添加时间
        /// </summary>
        [Display(Name = "添加时间")]
        [Column]
        [Required]
        public DateTime AppendTime { get; set; }

        /// <summary>
        /// 获取或者设置一个值，该值表示CategorID
        /// </summary>
        [Display(Name = "档案类型")]
        [Column]
        [Required]
        public Int64 CategorID { get; set; }

        private EntityRef<Category> _CategorID_ID;
        /// <summary>
        /// 获取或者设置一个值，该值表示TB_Categors类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "CategorID_ID", Storage = "_CategorID_ID", ThisKey = "CategorID", OtherKey = "ID", IsForeignKey = true)]
        public Category TheCategorID { get { return _CategorID_ID.Entity; } }

        private EntityRef<User> _AppendUser_UserID;
        /// <summary>
        /// 获取或者设置一个值，该值表示TB_Users类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "AppendUser_UserID", Storage = "_AppendUser_UserID", ThisKey = "AppendUser", OtherKey = "UserID", IsForeignKey = true)]
        public User TheAppendUser { get { return _AppendUser_UserID.Entity; } }

        private EntityRef<Agencie> _JGWT_DM;
        /// <summary>
        /// 获取或者设置一个值，该值表示TB_Agencies类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "JGWT_DM", Storage = "_JGWT_DM", ThisKey = "JGWT", OtherKey = "DM", IsForeignKey = true)]
        public Agencie TheJGWT { get { return _JGWT_DM.Entity; } }

        private EntityRef<SecurityLevel> _MJ_ID;
        /// <summary>
        /// 获取或者设置一个值，该值表示TB_SecurityLevels类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "MJ_ID", Storage = "_MJ_ID", ThisKey = "MJ", OtherKey = "ID", IsForeignKey = true)]
        public SecurityLevel TheMJ { get { return _MJ_ID.Entity; } }

        private EntityRef<Retention> _BGQX_DM;
        /// <summary>
        /// 获取或者设置一个值，该值表示TB_Retentions类
        /// </summary>
        [System.Data.Linq.Mapping.Association(Name = "BGQX_DM", Storage = "_BGQX_DM", ThisKey = "BGQX", OtherKey = "DM", IsForeignKey = true)]
        public Retention TheBGQX { get { return _BGQX_DM.Entity; } }
    }
}
