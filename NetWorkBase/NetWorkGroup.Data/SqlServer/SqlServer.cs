/********************************************************************************
** 开发人：王诚武  首次开发时间：2013年4月27日21:30:44 版本号：1.0.0.0
** 功能描述：Sql Server 数据库互操作相关功能，添加数据库操作参数、执行SQL命令等…
**
** 修改人：霍小平 修改时间：2004-12-9
** 修改内容：将修改内容填写在这里………
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace NetWorkGroup.Data.SqlServer
{
    /// <summary>
    /// SQL Server 数据库处理类
    /// </summary>
    public class SqlServerDb : DBase
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SqlServerDb() { }
        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="ConnectionString">数据库连接字符串类</param>
        public SqlServerDb(DbConnectionString ConnectionString) : base(ConnectionString) { }
        private SqlConnection _Connection = null;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库连接对象
        /// </summary>
        public override IDbConnection Connection
        {
            get { return new SqlConnection(base.ConnectionString.ToString()); }
            set { this._Connection = (value as SqlConnection); }
        }
        /// <summary>
        /// 在当前连接上执行查询操作，并将影像的行数返回
        /// </summary>
        /// <param name="cmdType">查询的类型</param>
        /// <returns>受影响的行数</returns>
        public override int Execute(CommandType cmdType)
        {
            try
            {
                Int32 ret = 0;
                using (SqlConnection conn = Connection as SqlConnection)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = base.cmdText.Trim(),
                        CommandTimeout = 0x1388,
                        CommandType = cmdType
                    })
                    {
                        cmd.Parameters.AddRange(this.ParamentCollections.ToArray());
                        ret = cmd.ExecuteNonQuery();
                        base.SetOutputParameter(DbOutPutValue);
                        cmd.Parameters.Clear();
                    }
                }
                return ret;
            }
            catch (SqlException e)
            {
                throw new DBaseException(e.Message, "SQLServer_" + e.Number);
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 在当前连接上执行查询操作，并将影像的行数返回
        /// </summary>
        /// <typeparam name="TResult">目前支持两种类型的返回数据,DataTable和DataSet</typeparam>
        /// <param name="cmdType">查询的类型</param>
        /// <returns>DataTable或DataSet</returns>
        public override TResult Execute<TResult>(CommandType cmdType)
        {
            try
            {
                Object ret = null;
                using (SqlConnection conn = this.Connection as SqlConnection)
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = base.cmdText.Trim(),
                        CommandTimeout = 0x1388,
                        CommandType = cmdType
                    })
                    {
                        cmd.Parameters.AddRange(this.ParamentCollections.ToArray());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if (typeof(TResult).Equals(typeof(DataTable)))
                            {
                                ret = ds.Tables[0];
                            }
                            else if (typeof(TResult).Equals(typeof(DataSet)))
                            {
                                ret = ds;
                            }
                            base.SetOutputParameter(DbOutPutValue);
                            cmd.Parameters.Clear();
                        }
                    }
                }
                return (TResult)ret;
            }
            catch (SqlException e)
            {
                throw new DBaseException(e.Message, "SQLServer_" + e.Number);
            }
            finally
            {
                this.Dispose();
            }
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Value">参数表示的值</param>
        public override void AddNewParameter(string Name, object Value)
        {
            this.AddNewParameter<SqlDbType>(Name, SqlDbType.VarChar, 500, Value);
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <typeparam name="TDbType">数据类型</typeparam>
        /// <param name="Name">名称</param>
        /// <param name="_DbType">参数数据类型枚举</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数表示的值</param>
        /// <param name="direction">参数类型</param>
        public override void AddNewParameter<TDbType>(string Name, TDbType _DbType, int Size, object Value, ParameterDirection direction = ParameterDirection.Input)
        {
            base.ParamentCollections.Add(new SqlParameter()
            {
                ParameterName = Name,
                SqlDbType = _DbType.To<SqlDbType>(),
                Size = Size,
                Value = Value,
                Direction = direction
            });
        }
    }
}
