using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace NetWorkGroup.Data
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public class DbConnectionString
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DbConnectionString() { }
        /// <summary>
        /// 表示没有任何数据的连接类
        /// </summary>
        public static readonly DbConnectionString Empty = new DbConnectionString();

        private DbConnectionString(DataBaseType DbType, String DataSource, String UserName, String Password, String DataBase, Int32 Port = 0, Boolean IsPooling = true, String EncodingName = "utf8")
        {
            this._DataSource = DataSource;
            this._UserID = UserName;
            this._Password = Password;
            this._DbType = DbType;
            this._Port = Port;
            this._IsPooling = IsPooling;
            this._EncodingName = EncodingName;
            this._DataBase = DataBase;
        }
        /// <summary>
        /// 根据参数创建DbConnectionString类的实例
        /// </summary>
        /// <param name="DbType">数据库类型</param>
        /// <param name="DataSource">数据源，或者IP地址</param>
        /// <param name="UserName">数据库登录账号</param>
        /// <param name="Password">数据库密码</param>
        /// <param name="DataBase">数据库名称</param>
        /// <param name="Port">数据库端口号</param>
        /// <param name="IsPooling">是否使用数据库连接池</param>
        /// <param name="EncodingName">字符编码集，默认UTF-8</param>
        /// <returns>数据库连接字符串类的实例</returns>
        public static DbConnectionString Create(DataBaseType DbType, String DataSource, String UserName, String Password, String DataBase, Int32 Port, Boolean IsPooling, String EncodingName = "utf8")
        {
            return new DbConnectionString(DbType, DataSource, UserName, Password, DataBase, Port, IsPooling, EncodingName);
        }
        private String _DataSource = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据源
        /// </summary>
        public String DataSource
        {
            get
            {
                return String.IsNullOrEmpty(_DataSource) ? DbConfig.GetConfig("DataSource") : _DataSource.Trim();
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("DataSource", "数据源（或IP地址）不能为空！");
                }
                _DataSource = value.Trim();
            }
        }

        private String _UserID = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库用户名
        /// <para>Access默认不带用用户名和密码</para>
        /// </summary>
        public String UserID
        {
            get
            {
                return String.IsNullOrEmpty(_UserID) ? DbConfig.GetConfig("UserID") : _UserID.Trim();
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("UserID", "数据用户名不能为空！");
                }
                _UserID = value.Trim();
            }
        }

        private String _Password = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库服务器密码
        /// </summary>
        public String Password
        {
            get
            {
                return String.IsNullOrEmpty(_Password) ? DbConfig.GetConfig("Password") : _Password.Trim();
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Password", "数据用户密码不能为空！");
                }
                _Password = value.Trim();
            }
        }
        private String _DataBase = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示使用的数据库
        /// </summary>
        public String DataBase
        {
            get
            {
                return String.IsNullOrEmpty(_DataBase) ? DbConfig.GetConfig("DataBase") : _DataBase.Trim();
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("DataBase", "数据名称不能为空！");
                }
                _DataBase = value.Trim();
            }
        }
        private Boolean? _IsPooling = null;
        /// <summary>
        /// 获取或者设置一个值，该值表示是否使用数据库连接池
        /// </summary>
        public Boolean IsPooling
        {
            get
            {
                return !_IsPooling.HasValue ? Boolean.Parse(DbConfig.GetConfig("Pooling")) : _IsPooling.Value;
            }
            set
            {
                _IsPooling = value;
            }
        }
        private DataBaseType _DbType = DataBaseType.Unkown;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库类型
        /// </summary>
        public DataBaseType DbType
        {
            get
            {
                return _DbType == DataBaseType.Unkown ? (DataBaseType)Enum.Parse(typeof(DataBaseType), DbConfig.GetConfig("DbType"), true) : _DbType;
            }
            set
            {
                if (value == DataBaseType.Unkown)
                {
                    throw new ArgumentNullException("DbType", "数据库类型不能为Unkown！");
                }
                _DbType = value;
            }
        }
        private Int32 _Port = -1;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库服务器端口号
        /// </summary>
        public Int32 Port
        {
            get
            {
                return (this._Port == -1) ? Int32.Parse(DbConfig.GetConfig("Port")) : this._Port;
            }
            set
            {
                this._Port = value;
            }
        }
        private String _EncodingName = String.Empty;
        /// <summary>
        /// 获取或者设置一个值，该值表示数据库的默认字符集
        /// </summary>
        public String EncodingName
        {
            get
            {
                return String.IsNullOrEmpty(_EncodingName) ? DbConfig.GetConfig("EncodingName") : _EncodingName.Trim();
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    _EncodingName = "UTF8";
                }
                else
                {
                    _EncodingName = value.Trim();
                }
            }
        }
        /// <summary>
        /// 重写底层ToString输出连接字符串
        /// </summary>
        /// <returns>数据库连接字符串</returns>
        public override string ToString()
        {
            String ConnectionString = String.Empty;
            switch (DbType)
            {
                case DataBaseType.SqlServer:
                    ConnectionString = "Data Source=" + DataSource + "," + (Port == -1 ? 1433 : Port) + ";User ID=" + UserID + ";Password=" + Password + ";DataBase=" + DataBase + ";Pooling=" + IsPooling;
                    break;
                case DataBaseType.DB2:
                    ConnectionString = "Server=" + DataSource + ":" + (Port == -1 ? 50000 : Port) + ";User ID=" + UserID + ";Password=" + Password + ";DataBase=" + DataBase + ";";
                    break;
                case DataBaseType.Access:
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DataSource;
                    break;
                case DataBaseType.MySQL:
                    ConnectionString = "Data Source=" + DataSource + ";User ID=" + UserID + ";Password=" + Password + ";Database=" + DataBase + ";Pooling=" + IsPooling + ";CharSet=" + (EncodingName == "utf8" ? "utf8" : EncodingName) + ";Port=" + Port + "";
                    break;
                case DataBaseType.Oracle:
                    ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + DataSource + ")(PORT=" + (Port == -1 ? 1521 : Port) + "))(CONNECT_DATA=(SERVICE_NAME=" + DataBase + ")));User ID=" + UserID + ";Password=" + Password + ";";
                    break;
            }
            return ConnectionString;
        }
    }

    internal class DbConfig
    {
        public static String GetConfig(String key)
        {
            XDocument doc = XDocument.Load(configFilePath);
            return doc.Elements("DataBaseConfig").Elements().Where(p => p.Name == key).Single().Value.Trim();
        }
        private static Boolean IsWebApplication
        {
            get
            {
                return HttpContext.Current != null;
            }
        }
        private static String configFilePath
        {
            get
            {
                String ret = String.Empty;
                if (IsWebApplication)
                {
                    ret = HttpContext.Current.Server.MapPath("~/Configs/DataBaseConfig.xml");
                }
                else
                {
                    ret = AppDomain.CurrentDomain.BaseDirectory + "Configs\\DataBaseConfig.xml";
                }
                return ret;
            }
        }
    }
    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    public enum DataBaseType
    {
        /// <summary>
        /// 表示SqlServer数据库
        /// </summary>
        SqlServer = 0,
        /// <summary>
        /// 表示Oracle数据库
        /// </summary>
        Oracle = 1,
        /// <summary>
        /// 表示Access数据库
        /// </summary>
        Access = 2,
        /// <summary>
        /// 表示MySQL数据库
        /// </summary>
        MySQL = 3,
        /// <summary>
        /// 表示DB2数据库
        /// </summary>
        DB2 = 4,
        /// <summary>
        /// 表示未知的数据库
        /// </summary>
        Unkown = -1
    }
}