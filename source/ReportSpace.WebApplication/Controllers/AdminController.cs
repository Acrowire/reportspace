
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ReportSpace.WebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        #region [ Controller Actions ] 
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        
        public ActionResult Users()
        {
            return View();
        }
        #endregion

    }
}