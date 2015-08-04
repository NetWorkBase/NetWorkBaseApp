using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_School类
	/// </summary>
	[Table(Name = "MS_School")]
	public class School
	{
		/// <summary>
		/// 获取或者设置一个值，该值表示School_ID
		/// </summary>
		[Display(Name = "School_ID")]
		[Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
		public Int32 School_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Counties_ID
		/// </summary>
		[Display(Name = "Counties_ID")]
		[Column]
		public Int32 Counties_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示School_Name
		/// </summary>
		[Display(Name = "School_Name")]
		[Column]
		public String School_Name { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示School_IsCheck
		/// </summary>
		[Display(Name = "School_IsCheck")]
		[Column]
		public Int32 School_IsCheck { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示学校分组：1 小学  2 初中  3 高中  4 大学
		/// </summary>
		[Display(Name = "学校分组：1 小学  2 初中  3 高中  4 大学")]
		[Column]
		public Int32 School_Flag { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示School_Order
		/// </summary>
		[Display(Name = "School_Order")]
		[Column]
		public Int32 School_Order { get; set; }

		private EntityRef<Countie> _Counties_ID_Counties_ID;
		/// <summary>
		/// 获取或者设置一个值，该值表示MS_Counties类
		/// </summary>
		[System.Data.Linq.Mapping.Association(Name = "Counties_ID_Counties_ID", Storage = "_Counties_ID_Counties_ID", ThisKey = "Counties_ID", OtherKey = "Counties_ID", IsForeignKey = true)]
		public Countie TheCounties_ID { get { return _Counties_ID_Counties_ID.Entity; } }
	}
}
