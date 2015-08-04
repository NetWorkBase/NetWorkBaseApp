using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public abstract class ControllerBase<TModel> : Controller where TModel : class,IModelID<Int32>, new()
    {
        public virtual ActionResult List()
        {
            return View();
        }
    }
}
