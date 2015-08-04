using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Extensions;
using System.Net;
using System.Text;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient wet = new WebClient();
            byte[] bt = wet.DownloadData("http://www.lzsynykj.com/Article/ArticleShow/1");
            Response.Write(Encoding.UTF8.GetString(bt).ClearHtml());
        }
    }
}