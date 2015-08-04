using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace System
{
    /// <summary>
    /// 模型类接口，在类中实现时包含一个签名为ID的公用自增量属性
    /// </summary>
    public interface IModelID<T>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示自增量ID
        /// </summary>
        T ID { get; set; }
    }
    /// <summary>
    /// 模型类接口，在类中实现时用于指定该类拥有一个名称为：Name的字段
    /// </summary>
    public interface IModelName
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示名称
        /// </summary>
        String Name { get; set; }
    }
    /// <summary>
    /// 模型类接口，在类中实现时用于指定该类拥有一个名称为：ImageUrl的字段
    /// </summary>
    public interface IModelImageUrl
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示图片路径
        /// </summary>
        String ImageUrl { get; set; }
    }
    /// <summary>
    /// 模型类接口，在类中实现时用于指定一个父ID属性
    /// </summary>
    /// <typeparam name="T">表示在主要接口中的名称为ID的字段类型和其父ID的类型</typeparam>
    public interface IModelParentID<T> : IModelID<T>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示父ID
        /// </summary>
        T PID { get; set; }
    }
    /// <summary>
    /// 模型类接口，在类中实现时用于指定一个类别ID属性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelItemID<T>
    {
        /// <summary>
        /// 获取或者设置一个值，该值表示类别ID
        /// </summary>
        T ItemID { get; set; }
    }
    /// <summary>
    /// 描述性接口，该接口指定如果使用扩展类实现生成树形下拉表，则该类型必须实现此接口
    /// </summary>
    /// <typeparam name="T">表示在主要接口中的名称为ID的字段类型</typeparam>
    public interface IModelDropDown<T> :  IModelName, IModelParentID<T> { }
    #region [废弃的部分API功能]
    ///// <summary>
    ///// 模型类接口，在类中实现时包含一个签名为ID的公用自增量属性
    ///// </summary>
    //[Obsolete("新的类型访问请参考System.OverLoad名称空间")]
    //public interface IModel
    //{
    //    /// <summary>
    //    /// 获取或者设置一个值，该值表示自增量ID
    //    /// </summary>
    //    [Display(Name = "ID")]
    //    [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
    //    Int64 ID { get; set; }
    //}
    ///// <summary>
    ///// 模型类接口，在类中实现时包含一个签名为ID的公用自增量属性,增加一个带有名称的属性类
    ///// </summary>
    //[Obsolete("新的类型访问请参考System.OverLoad名称空间")]
    //public interface IModelWithName : IModel
    //{
    //    /// <summary>
    //    /// 获取或者设置一个值，该值表示名称
    //    /// </summary>
    //    String Name { get; set; }
    //}
    ///// <summary>
    ///// 模型类接口，在类中实现时用于包含一个签名为ImageUrl的属性
    ///// </summary>
    //[Obsolete("新的类型访问请参考System.OverLoad名称空间")]
    //public interface IModelWithImageUrl : IModelWithName
    //{
    //    String ImageUrl { get; set; }
    //}
    ///// <summary>
    ///// 定义一个模型接口，该接口在类中实现时用于增加一个带有父类别的属性
    ///// </summary>
    ///// <typeparam name="T">任意类型</typeparam>
    //[Obsolete("新的类型访问请参考System.OverLoad名称空间")]
    //public interface IModelWithPID<T> : IModelWithName
    //{
    //    T PID { get; set; }
    //}
    ///// <summary>
    ///// 定义一个接口，在类中实现时用于指定该类型具有一个类别ID
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //[Obsolete("新的类型访问请参考System.OverLoad名称空间")]
    //public interface IModelWithItemID<T> : IModelWithName
    //{
    //    T ItemID { get; set; }
    //}
    ///// <summary>
    ///// 生成下拉列表的接口，在类中实现时用于生成前台绑定的DropDownListFor
    ///// </summary>
    ///// <typeparam name="T">任意类型，一般为SelectListItem</typeparam>
    //public interface IDropDown<T>
    //{
    //    /// <summary>
    //    /// 生成下拉列表
    //    /// </summary>
    //    /// <returns>IEnumerable</returns>
    //    IEnumerable<T> GetSelectList();
    //    /// <summary>
    //    /// 生成下拉列表，并将selectIndex设置为选择的ID
    //    /// </summary>
    //    /// <typeparam name="TObj">任意类型的对象</typeparam>
    //    /// <param name="ID">选定的ID</param>
    //    /// <returns>IEnumerable</returns>
    //    IEnumerable<T> GetSelectList(object ID);
    //}
    #endregion
}
