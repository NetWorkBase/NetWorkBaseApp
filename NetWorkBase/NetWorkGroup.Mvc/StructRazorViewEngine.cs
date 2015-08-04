//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace NetWorkGroup.Mvc
//{
//    /// <summary>
//    /// 定义一个用户系统管理的ViewEngine
//    /// </summary>
//    public class StructRazorViewEngine : RazorViewEngine
//    {
//        /// <summary>
//        /// 默认构造函数
//        /// </summary>
//        public StructRazorViewEngine()
//            : base()
//        {
//            //Area视图路径其中{2},{1},{0}分别代表Area名，Controller名，Action名 
//            AreaViewLocationFormats = new string[] { "~/Views/WebManager/{2}/{1}/{0}.cshtml", "~/Views/WebManager/{0}.cshtml" };
//            //Area模版路径 
//            AreaMasterLocationFormats = new[] { "~/Views/WebManager/Shared/{0}.cshtml" };
//            //Area的分部视图路径 
//            AreaPartialViewLocationFormats = new[] { "~/Views/WebManager/{2}/{1}/{0}.cshtml", "~/Views/WebManager/Shared/{0}.cshtml" };
//            //主视图路径 
//            ViewLocationFormats = new[] { "~/Views/WebManager/{1}/{0}.cshtml", "~/Views/WebManager/Shared/{0}.cshtml" };
//            //主模版路径 
//            MasterLocationFormats = new[] { "~/Views/WebManager/Shared/{0}.cshtml" };
//            //主分部视图路径 
//            PartialViewLocationFormats = new[] { "~/Views/WebManager/{1}/{0}.cshtml", "~/Views/WebManager/Shared/{0}.cshtml" };
//            //Area视图路径其中{2},{1},{0}分别代表Area名，Controller名，Action名 
//            AreaViewLocationFormats = new string[] { "~/Views/WebManager/Tables/{2}/{1}/{0}.cshtml", "~/Views/WebManager/Tables/{0}.cshtml" };
//            //Area模版路径 
//            AreaMasterLocationFormats = new[] { "~/Views/WebManager/Shared/{0}.cshtml" };
//            //Area的分部视图路径 
//            AreaPartialViewLocationFormats = new[] { "~/Views/WebManager/Tables/{2}/{1}/{0}.cshtml", "~/Views/WebManager/Shared/{0}.cshtml" };
//            //主视图路径 
//            ViewLocationFormats = new[] { "~/Views/WebManager/Tables/{1}/{0}.cshtml", "~/Views/WebManager/Shared/{0}.cshtml" };
//            //主模版路径 
//            MasterLocationFormats = new[] { "~/Views/WebManager/Shared/{0}.cshtml" };
//            //主分部视图路径 
//            PartialViewLocationFormats = new[] { "~/Views/WebManager/{1}/{0}.cshtml", "~/Views/WebManager/Shared/{0}.cshtml" };
//        }
//    }
//}
