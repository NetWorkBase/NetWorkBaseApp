using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileManager.Models;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = new NetWorkGroup.Entity.DefaultEntity<Category>().Show();
            var item=obj.ShowSelectListItemByParentItem<Category, Int64>(obj.SingleOrDefault(p => p.Name.Equals("工程档案")));
        }
    }
}