using System.Web.Mvc;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    public class AdminController : Controller
    {
        #region [ Indexes ] 
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}