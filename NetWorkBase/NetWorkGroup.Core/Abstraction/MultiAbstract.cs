using NetWorkGroup.Abstraction;
using NetWorkGroup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkGroup.Abstraction
{
    /// <summary>
    /// 抽象基类扩展
    /// <para>包含增加、删除、修改等</para>
    /// </summary>
    /// <typeparam name="TModel">模型层,约束为：<para>必须为引用类型</para><para>并且具有无参数的构造函数</para></typeparam>
    public abstract class MultiAbstract<TModel> : AbstractBase<TModel> where TModel : class,new()
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MultiAbstract() { }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="ConnectionString">数据库连接字符串</param>
        public MultiAbstract(DbConnectionString ConnectionString) : base(ConnectionString) { }
        /// <summary>
        /// 增加一条数据，抽象方法
        /// </summary>
        abstract public void Append(String Msg = "增加成功");
        /// <summary>
        /// 删除一条数据，抽象方法
        /// </summary>
        abstract public void Delete(String Msg = "删除成功");
        /// <summary>
        /// 更新一条数据，抽象方法
        /// </summary>
        abstract public void Update(String Msg = "更新成功");
    }
}
