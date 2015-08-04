using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_Article类
	/// </summary>
	[Table(Name = "MS_Article")]
	public class Article<TType>
	{
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_ID
		/// </summary>
		[Display(Name = "Article_ID")]
		[Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
		public Int32 Article_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示ArticleType_ID
		/// </summary>
		[Display(Name = "ArticleType_ID")]
		[Column]
		public Int32 ArticleType_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_Title
		/// </summary>
		[Display(Name = "Article_Title")]
		[Column]
		public String Article_Title { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_Keyword
		/// </summary>
		[Display(Name = "Article_Keyword")]
		[Column]
		public String Article_Keyword { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示文章来源
		/// </summary>
		[Display(Name = "文章来源")]
		[Column]
		public String Article_Source { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示封面图
		/// </summary>
		[Display(Name = "封面图")]
		[Column]
		public String Article_ImgUrl { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_Content
		/// </summary>
		[Display(Name = "Article_Content")]
		[Column]
		public String Article_Content { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_IsCheck
		/// </summary>
		[Display(Name = "Article_IsCheck")]
		[Column]
		public Int32 Article_IsCheck { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示是否置顶  0  不置顶  1 置顶
		/// </summary>
		[Display(Name = "是否置顶  0  不置顶  1 置顶")]
		[Column]
		public Int32 Article_IsTop { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示是否推荐到首页
		/// </summary>
		[Display(Name = "是否推荐到首页")]
		[Column]
		public Int32 Article_IsRecommend { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示排序
		/// </summary>
		[Display(Name = "排序")]
		[Column]
		public Int32 Article_Order { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_ID
		/// </summary>
		[Display(Name = "Admin_ID")]
		[Column]
		public Int32 Admin_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示User_ID
		/// </summary>
		[Display(Name = "User_ID")]
		[Column]
		public Int32 User_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_ClickRate
		/// </summary>
		[Display(Name = "Article_ClickRate")]
		[Column]
		public Int32 Article_ClickRate { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_IsDeL
		/// </summary>
		[Display(Name = "Article_IsDeL")]
		[Column]
		public Int32 Article_IsDeL { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Article_Datetime
		/// </summary>
		[Display(Name = "Article_Datetime")]
		[Column]
		public DateTime Article_Datetime { get; set; }

		private EntityRef<Admin> _Admin_ID_Admin_ID;
		/// <summary>
		/// 获取或者设置一个值，该值表示MS_Admin类
		/// </summary>
		[System.Data.Linq.Mapping.Association(Name = "Admin_ID_Admin_ID", Storage = "_Admin_ID_Admin_ID", ThisKey = "Admin_ID", OtherKey = "Admin_ID", IsForeignKey = true)]
		public Admin TheAdmin_ID { get { return _Admin_ID_Admin_ID.Entity; } }

		private EntityRef<User> _User_ID_User_ID;
		/// <summary>
		/// 获取或者设置一个值，该值表示MS_User类
		/// </summary>
		[System.Data.Linq.Mapping.Association(Name = "User_ID_User_ID", Storage = "_User_ID_User_ID", ThisKey = "User_ID", OtherKey = "User_ID", IsForeignKey = true)]
		public User TheUser_ID { get { return _User_ID_User_ID.Entity; } }

		private EntityRef<ArticleType<TType>> _ArticleType_ID_ArticleType_ID;
		/// <summary>
		/// 获取或者设置一个值，该值表示MS_ArticleType类
		/// </summary>
		[System.Data.Linq.Mapping.Association(Name = "ArticleType_ID_ArticleType_ID", Storage = "_ArticleType_ID_ArticleType_ID", ThisKey = "ArticleType_ID", OtherKey = "ArticleType_ID", IsForeignKey = true)]
		public ArticleType<TType> TheArticleType_ID { get { return _ArticleType_ID_ArticleType_ID.Entity; } }
	}
}
