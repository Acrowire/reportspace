using ReportSpace.Application.Security;
using ReportSpace.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ReportSpace.Web.Controllers
{
    public class HomeController : Controller
    {
        #region [ Site ] 
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = String.Format("Welcome {0}", Session["session.username"]);
            return View();
        }
        #endregion

        #region [ Login / Logout ]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.Cookies.AllKeys.Contains("reportspace.auth"))
            {

            }
            else
            {

            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            bool auth_valid = true;
            ViewBag.Message = String.Empty;

            // Authorize 

            auth_valid = SecurityComponent.Authenticate(model.UserName, model.Password);

            if (auth_valid)
            {
                Guid SessionID = Guid.NewGuid();

                Session.Add("session.id",SessionID);
                Session.Add("session.username", model.UserName);
                Session.Add("session.createdate", DateTime.Now);

                Response.Cookies.Add(new HttpCookie("reportspace.auth", Guid.NewGuid().ToString()));
                RedirectToLocal("Index");
            }

            // Error State
            ViewBag.Message = "The user name or password provided is incorrect.";
            ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            return View(model);
        }
        #endregion


        #region [ Utilities ] 
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }
        #endregion
    }
}