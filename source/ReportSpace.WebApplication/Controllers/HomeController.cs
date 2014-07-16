using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportSpace.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Unauthroized()
        {
            return View();
        }

        #region [ Reports ] 
        public ActionResult Report_ClientHours(String ClientName)
        {
            dynamic model = new ExpandoObject();

            model.Client = ClientName;


            return View();
        }
        #endregion
    }
}