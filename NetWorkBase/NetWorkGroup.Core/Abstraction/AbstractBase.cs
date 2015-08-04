using NetWorkGroup.Data;
using NetWorkGroup.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkGroup.Abstraction
{
    /// <summary>
    /// 抽象基类，为实现层提供基础抽象服务
    /// <para>包含查询、根据主键查询、根据外键查询等</para>
    /// </summary>
    /// <typeparam name="TModel">模型层,约束为：<para>必须为引用类型</para><para>并且具有无参数的构造函数</para><para>并且实现IModel接口</para></typeparam>
    public abstract class AbstractBase<TModel> : CoreBase where TModel : class , new()
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AbstractBase() { }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="ConnectionString">数据库连接字符串</param>
        public AbstractBase(DbConnectionString ConnectionString)
        {
            this._connString = ConnectionString;
        }
        /// <summary>
        /// 内部成员，表示LINQ TO SQL支持点的属性使用
        /// </summary>
        private DbContext<TModel> _dbContext = new DbContext<TModel>();
        /// <summary>
        /// 获取或者设置一个值，该值表示数据上下文，此属性为LINQ TO SQL提供支持
        /// </summary>
        public DbContext<TModel> DbContext
        {
            get
            {
                return this._dbContext;
            }
            set
            {
                this._dbContext = value;
            }
        }
        private DbConnectionString _connString = null;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库连接字符串
        /// </summary>
        public DbConnectionString ConnectionString
        {
            get
            {
                if (this._connString == null)
                {
                    _connString = new DbConnectionString();
                }
                return _connString;
            }
            set
            {
                _connString = value;
            }
        }

        private DBase db = null;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库层类型，根据配置文件返回一个特定的数据库处理类的实例
        /// </summary>
        public virtual DBase DataBase
        {
            get
            {

                db = new SqlServerDb(this.ConnectionString);
                return db;
            }
            set
            {
                this.db = value;
            }
        }
        /// <summary>
        /// 显示数据，抽象方法
        /// </summary>
        abstract public IQueryable<TModel> Show();
        /// <summary>
        /// 显示数据，抽象方法
        /// </summary>
        abstract public IQueryable<TModel> Show(Expression<Func<TModel, bool>> KeyValue);
    }
}
