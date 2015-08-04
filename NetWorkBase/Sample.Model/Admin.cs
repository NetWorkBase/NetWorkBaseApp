using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_Admin类
	/// </summary>
	[Table(Name = "MS_Admin")]
	public class Admin
	{
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_ID
		/// </summary>
		[Display(Name = "Admin_ID")]
		[Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
		public Int32 Admin_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Account
		/// </summary>
		[Display(Name = "Admin_Account")]
		[Column]
		public String Admin_Account { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_PassWord
		/// </summary>
		[Display(Name = "Admin_PassWord")]
		[Column]
		public String Admin_PassWord { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Name
		/// </summary>
		[Display(Name = "Admin_Name")]
		[Column]
		public String Admin_Name { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Email
		/// </summary>
		[Display(Name = "Admin_Email")]
		[Column]
		public String Admin_Email { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Mobilie
		/// </summary>
		[Display(Name = "Admin_Mobilie")]
		[Column]
		public String Admin_Mobilie { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Sex
		/// </summary>
		[Display(Name = "Admin_Sex")]
		[Column]
		public char Admin_Sex { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Department_ID
		/// </summary>
		[Display(Name = "Department_ID")]
		[Column]
		public Int32 Department_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Hiden
		/// </summary>
		[Display(Name = "Admin_Hiden")]
		[Column]
		public Int32 Admin_Hiden { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Status
		/// </summary>
		[Display(Name = "Admin_Status")]
		[Column]
		public Int32 Admin_Status { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Order
		/// </summary>
		[Display(Name = "Admin_Order")]
		[Column]
		public Int32 Admin_Order { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Address
		/// </summary>
		[Display(Name = "Admin_Address")]
		[Column]
		public String Admin_Address { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_RegDate
		/// </summary>
		[Display(Name = "Admin_RegDate")]
		[Column]
		public DateTime Admin_RegDate { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Admin_Post
		/// </summary>
		[Display(Name = "Admin_Post")]
		[Column]
		public String Admin_Post { get; set; }
	}
}
