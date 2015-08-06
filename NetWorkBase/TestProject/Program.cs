using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorkGroup.Data.SqlServer;
using NetWorkGroup.Data;
using System.Data;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSqlServerDataBase();
            Console.Read();
        }

        static DbConnectionString db1 = DbConnectionString.Create(DataBaseType.SqlServer, "121.40.193.211", "sa", "3e8i9o8i", "youkong_log", 1433, true);
        static void TestSqlServerDataBase()
        {
            SqlServerDb db = new SqlServerDb(db1);
            db.cmdText = "SELECT * FROM ALLTABLES";
            var ret = db.Execute<DataTable>(CommandType.Text).AsEnumerable();
            foreach (var item in ret)
            {
                Console.WriteLine(item[1].ToString());
            }
        }
    }
}
