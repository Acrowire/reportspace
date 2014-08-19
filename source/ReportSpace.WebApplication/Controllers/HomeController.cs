using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportSpace.WebApplication;
using ReportSpace.Application;
using Newtonsoft.Json;
using System.Collections;

namespace ReportSpace.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unauthroized()
        {
            return View();
        }

        #region [ Reports ] 
        [Authorize]
        public ActionResult Report_ClientHours(String ClientName)
        {
            var dic = new Dictionary<string, string>
                {
                    {"client", ClientName}
                };
            return View(dic);
        }

        [HttpGet]
        [Authorize]
        public JsonResult Report_ClientHoursData(String ClientName)
        {
            PMP.PMPReportAccess reports = new PMP.PMPReportAccess();

            List<Hashtable> report_data = reports.ClientHoursReport(new PMP.OrganizationReportParameters()
            {
                StartDate = DateTime.Parse("01/01/2014"),
                EndDate = DateTime.Now,
                OrganizationName = ClientName
            });


            return new JsonResult()
            {
                Data = report_data,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        #endregion
    }
}