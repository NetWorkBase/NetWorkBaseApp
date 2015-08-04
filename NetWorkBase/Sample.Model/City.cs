using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School.Models
{
	/// <summary>
	/// 表示MS_City类
	/// </summary>
	[Table(Name = "MS_City")]
	public class City
	{
		/// <summary>
		/// 获取或者设置一个值，该值表示City_ID
		/// </summary>
		[Display(Name = "City_ID")]
		[Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
		public Int32 City_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示Province_ID
		/// </summary>
		[Display(Name = "Province_ID")]
		[Column]
		public Int32 Province_ID { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示City_Name
		/// </summary>
		[Display(Name = "City_Name")]
		[Column]
		public String City_Name { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示City_IsCheck
		/// </summary>
		[Display(Name = "City_IsCheck")]
		[Column]
		public Int32 City_IsCheck { get; set; }
		/// <summary>
		/// 获取或者设置一个值，该值表示City_Order
		/// </summary>
		[Display(Name = "City_Order")]
		[Column]
		public Int32 City_Order { get; set; }

		private EntityRef<Province> _Province_ID_Province_ID;
		/// <summary>
		/// 获取或者设置一个值，该值表示MS_Province类
		/// </summary>
		[System.Data.Linq.Mapping.Association(Name = "Province_ID_Province_ID", Storage = "_Province_ID_Province_ID", ThisKey = "Province_ID", OtherKey = "Province_ID", IsForeignKey = true)]
		public Province TheProvince_ID { get { return _Province_ID_Province_ID.Entity; } }
	}
}
