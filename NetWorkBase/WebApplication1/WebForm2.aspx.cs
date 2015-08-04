using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ("系统测试").Alert(this.Update1, "window.alert('执行完了，哈哈！')", true);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ("系统测试").Alert<Page>(this, "window.alert('执行完了，哈哈！')", true);
            }
        }
    }
}