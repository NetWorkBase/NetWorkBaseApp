using Sample.Model;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class HomeController : ControllerBase<ArticleType<Int32>>
    {
        public override ActionResult List()
        {
            Entity.Entity<ArticleType<Int32>> logic = new Entity.Entity<ArticleType<Int32>>();
            var x = logic.Show();
            return View(x);
        }
    }
}
