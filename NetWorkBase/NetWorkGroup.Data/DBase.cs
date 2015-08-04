using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Common;

namespace NetWorkGroup.Data
{
    /// <summary>
    /// 数据核心处理程序集抽象层
    /// </summary>
    public abstract class DBase : IDisposable 
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DBase() { }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        /// <param name="_ConnectionString">数据库连接参数对象</param>
        public DBase(DbConnectionString _ConnectionString)
        {
            this.ConnectionString = _ConnectionString;
        }
        /// <summary>
        /// 表示没有任何数据的数据抽象类
        /// </summary>
        public static readonly DBase Empty = null;
        private List<DbParameter> _list = new List<DbParameter>();
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库参数集合
        /// </summary>
        public virtual List<DbParameter> ParamentCollections { get { return _list; } }
        private DbConnectionString _ConnectionString = DbConnectionString.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库连接字符串类
        /// </summary>
        public virtual DbConnectionString ConnectionString
        {
            get
            {
                return this._ConnectionString;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("DbConnectionString", "DbConnectionString不能为空！");
                }
                _ConnectionString = value;
            }
        }
        private String _CmdText = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示要执行的数据库指令
        /// </summary>
        public virtual String cmdText { get { return this._CmdText; } set { this._CmdText = value; } }
        /// <summary>
        /// 抽象属性，获取或者设置一个值，该值表示数据库连接对象，需要在继承类中重写
        /// </summary>
        abstract public IDbConnection Connection { get; set; }
        /// <summary>
        /// 抽象方法，执行命令并返回int
        /// </summary>
        /// <param name="cmdType">执行类型</param>
        /// <returns>int</returns>
        public abstract Int32 Execute(CommandType cmdType);
        /// <summary>
        /// 抽象方法，执行命令并返回指定的类型
        /// </summary>
        /// <typeparam name="TResult">指定的类型</typeparam>
        /// <param name="cmdType">执行类型</param>
        /// <returns>泛型类型</returns>
        public abstract TResult Execute<TResult>(CommandType cmdType) where TResult : class;
        /// <summary>
        /// 获取数据库输出参数
        /// </summary>
        /// <param name="outPutParams">输出参数</param>
        protected virtual void SetOutputParameter(Dictionary<String, dynamic> outPutParams)
        {
            if (outPutParams.Count > 0)
            {
                outPutParams.Clear();
            }
            foreach (var item in this.ParamentCollections.ToArray<DbParameter>())
            {
                if (item.Direction == ParameterDirection.Output || item.Direction == ParameterDirection.InputOutput)
                {
                    outPutParams.Add(item.ParameterName, item.Value);
                }
            }
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Value">参数表示的值</param>
        abstract public void AddNewParameter(String Name, Object Value);
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <typeparam name="TDbType">数据类型</typeparam>
        /// <param name="Name">名称</param>
        /// <param name="_DbType">参数数据类型枚举</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数表示的值</param>
        /// <param name="direction">参数类型</param>
        abstract public void AddNewParameter<TDbType>(String Name, TDbType _DbType, Int32 Size, Object Value, System.Data.ParameterDirection direction = ParameterDirection.Input) where TDbType : IConvertible;
        #region [重要说明]
        /* 
         * DbOutPutValue霍小平修改，如果不给初始化值，后台执行过程中会出现错误
         * 2013年4月18日20:38:53王诚武修改，不是静态变量桥接过程中会出现无00法得到值的问题
         */
        #endregion
        private Dictionary<String, dynamic> _DbOutPutValue = new Dictionary<String, dynamic>();
        /// <summary>
        /// 静态数据库输出参数，此属性为动态属性类型为：Dictionary&lt;String,dynamic&gt;
        /// </summary>
        public Dictionary<String, dynamic> DbOutPutValue { get { return _DbOutPutValue; } }
        /// <summary>
        /// 释放任何使用过的资源
        /// </summary>
        public virtual void Dispose()
        {
            if (this.Connection != null)
            {
                this.Connection = null;
            }
            if (this.ParamentCollections.Count > 0)
            {
                this.ParamentCollections.Clear();
            }
            GC.ReRegisterForFinalize(this);
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
