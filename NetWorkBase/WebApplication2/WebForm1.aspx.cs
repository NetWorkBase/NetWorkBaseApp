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
            Entity<School.Models.ArticleType<Int32>> logic = new Entity<School.Models.ArticleType<int>>();
            Response.Write(logic.Show().Count());
        }
    }
}