using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_Counties类
	/// </summary>
	[Table(Name = "MS_Counties")]
	public class Countie
	{
		/// <summary>
		/// 获取或者设置一个值，该值表示Counties_ID
		/// </summary>
		[Display(Name = "Counties_ID")]
		[Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
		public Int32 Counties_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示City_ID
		/// </summary>
		[Display(Name = "City_ID")]
		[Column]
		public Int32 City_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Counties_Name
		/// </summary>
		[Display(Name = "Counties_Name")]
		[Column]
		public String Counties_Name { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Counties_IsCheck
		/// </summary>
		[Display(Name = "Counties_IsCheck")]
		[Column]
		public Int32 Counties_IsCheck { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Counties_Order
		/// </summary>
		[Display(Name = "Counties_Order")]
		[Column]
		public Int32 Counties_Order { get; set; }

		private EntityRef<City> _City_ID_City_ID;
		/// <summary>
		/// 获取或者设置一个值，该值表示MS_City类
		/// </summary>
		[System.Data.Linq.Mapping.Association(Name = "City_ID_City_ID", Storage = "_City_ID_City_ID", ThisKey = "City_ID", OtherKey = "City_ID", IsForeignKey = true)]
		public City TheCity_ID { get { return _City_ID_City_ID.Entity; } }
	}
}
