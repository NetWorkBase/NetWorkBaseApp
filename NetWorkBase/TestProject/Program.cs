using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorkGroup.Data.SqlServer;
using NetWorkGroup.Data;
using System.Data;
using Oracle.ManagedDataAccess.Client;

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
            //SqlServerDb db = new SqlServerDb(db1);
            //db.cmdText = "SELECT * FROM SYS.TABLES";
            //var ret = db.Execute<DataTable>(CommandType.Text).AsEnumerable();
            //foreach (var item in ret)
            //{
            //    
            //}
            OracleConnection conn = new OracleConnection(db1.ToString());
            conn.Open();
            Console.WriteLine(conn.State.ToString());
            OracleCommand cmd = new OracleCommand("select * from TB_Agencies", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Console.WriteLine($"{item[0].ToString()}<------>{item[1].ToString()}");
            }
            Console.ReadLine();

        }
    }
}
