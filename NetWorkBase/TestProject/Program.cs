using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorkGroup.Data.SqlServer;
using NetWorkGroup.Data;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using NetWorkGroup.Entity;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSqlServerDataBase();
            Console.Read();
        }

        static DbConnectionString db1 = DbConnectionString.Create(DataBaseType.Oracle, "192.168.0.116", "Jack", "wcw840525", "orcl", 1521, true);
        static void TestSqlServerDataBase()
        {
            DefaultEntity<MyObj> Entity = new DefaultEntity<TestProject.Program.MyObj>(new DbConnectionString(DataBaseType.SqlServer,
                "127.0.0.1",
                "sa",
                "wvw840525.",
                "FileManager_V20",
                1433,
                true));
        }
        public class MyObj : IModelID<Int64>
        {
            public long ID
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
