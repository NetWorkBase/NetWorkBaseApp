using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NetWorkGroup.Data.SqlServer.SqlServerDb db = new NetWorkGroup.Data.SqlServer.SqlServerDb();
            db.cmdText = "SELECT GETDATE()  as 'CURRENT_TIME'";
            var ret = db.Execute(System.Data.CommandType.Text);
        }
    }
}