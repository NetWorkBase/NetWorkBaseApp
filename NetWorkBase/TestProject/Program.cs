using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorkGroup.Data.SqlServer;
using NetWorkGroup.Data;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSqlServerDataBase();
            Console.Read();
        }

        static DbConnectionString db1 = DbConnectionString.Create(DataBaseType.SqlServer, "www.mrhuo.com", "mrpject", "zhiweikeji", "MProject", 52705, true);
        static void TestSqlServerDataBase()
        {
            SqlServerDb db = new SqlServerDb(db1);
            db.cmdText = "SELECT * FROM TB_USER";
            var ret=db.Execute(System.Data.CommandType.Text);
            Console.WriteLine(ret);
        }
    }
}
