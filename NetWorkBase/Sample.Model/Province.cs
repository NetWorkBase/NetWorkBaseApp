using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_Province类
	/// </summary>
	[Table(Name = "MS_Province")]
	public class Province
	{
		/// <summary>
		/// 获取或者设置一个值，该值表示Province_ID
		/// </summary>
		[Display(Name = "Province_ID")]
		[Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
		public Int32 Province_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Province_Name
		/// </summary>
		[Display(Name = "Province_Name")]
		[Column]
		public String Province_Name { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Province_IsCheck
		/// </summary>
		[Display(Name = "Province_IsCheck")]
		[Column]
		public Int32 Province_IsCheck { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Province_Order
		/// </summary>
		[Display(Name = "Province_Order")]
		[Column]
		public Int32 Province_Order { get; set; }
	}
}
