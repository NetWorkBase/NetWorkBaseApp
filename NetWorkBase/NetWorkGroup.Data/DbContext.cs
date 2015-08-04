using NetWorkGroup.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkGroup.Data
{
    /// <summary>
    /// 为LINQ TO SQL 的自定义类型提供抽象基类
    /// </summary>
    /// <typeparam name="T">Model类</typeparam>
    public class DbContext<T> : DataContext
        where T : class, new()
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DbContext() : base(new DbConnectionString().ToString()) { }
        /// <summary>
        /// 通过引用由 .NET Framework 使用的连接来初始化 System.Data.Linq.DataContext 类的新实例。
        /// </summary>
        /// <param name="connection">由 .NET Framework 使用的连接。</param>
        public DbContext(IDbConnection connection)
            : base(connection)
        {
        }
        /// <summary>
        /// 通过引用文件源来初始化 System.Data.Linq.DataContext 类的新实例。
        /// </summary>
        /// <param name="fileOrServerOrConnection">此参数可以是下列项之一： 
        /// <para>SQL Server Express 数据库所在的文件的名称。 数据库所在的服务器的名称。 在此情况下，提供程序对用户使用默认数据库。</para>
        /// <para>一个完整的连接字符串。 LINQ to SQL 仅将字符串传递给提供程序，而不进行修改。</para>
        /// </param>
        public DbContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection) { }
        /// <summary>
        /// 通过引用连接和映射源初始化 System.Data.Linq.DataContext 类的新实例。
        /// </summary>
        /// <param name="connection">由 .NET Framework 使用的连接。</param>
        /// <param name="mapping">映射的源。</param>
        public DbContext(IDbConnection connection, MappingSource mapping) : base(connection, mapping) { }
        /// <summary>
        /// 通过引用文件源和映射源初始化 System.Data.Linq.DataContext 类的新实例。
        /// </summary>
        /// <param name="fileOrServerOrConnection">此参数可以是下列项之一： 
        /// <para>SQL Server Express 数据库所在的文件的名称。 数据库所在的服务器的名称。 在此情况下，提供程序对用户使用默认数据库。</para>
        /// <para>一个完整的连接字符串。 LINQ to SQL 仅将字符串传递给提供程序，而不进行修改。</para>
        /// </param>
        /// <param name="mapping">映射的源</param>
        public DbContext(string fileOrServerOrConnection, MappingSource mapping) : base(fileOrServerOrConnection, mapping) { }
        private T _Model = new T();
        /// <summary>
        /// 在类中实现时用于获取或者设置Model层
        /// </summary>
        public virtual T Model
        {
            get
            {
                return this._Model;
            }
            set
            {
                this._Model = value;
            }
        }
        /// <summary>
        /// 获取一个值，该值表示一个映射的实体表
        /// </summary>
        public virtual ITable<T> getTable
        {
            get
            {
                return base.GetTable<T>();
            }
        }
        /// <summary>
        /// 虚方法，将新的数据库连接字符串应用在DataContext中
        /// </summary>
        /// <param name="ConnectionString">数据库连接字符串类</param>
        public virtual void SetBaseConnectionString(DbConnectionString ConnectionString)
        {
            base.Connection.ConnectionString = ConnectionString.ToString();
        }
        /// <summary>
        /// 创建一个数据库Guid并返回
        /// </summary>
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
        /// <summary>
        /// 生成一个新的GUID
        /// </summary>
        /// <returns></returns>
        [Function(Name = "NEWID", IsComposable = true)]
        public Guid NEWID()
        {
            return ((Guid)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
        }
    }
}
