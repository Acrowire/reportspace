using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportSpace.PMPConnector.Connector;
using ReportSpace.WebApplication;
using ReportSpace.Application;
using Newtonsoft.Json;
using System.Collections;
using ReportSpace.Application.Security;

namespace ReportSpace.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Bll.UserreportsCollection useReports = Bll.Userreports.Select_UserReportss_By_UserId(Bll.Users.GetByUserName(User.Identity.Name).Id);

            var list = useReports.Select(x => x.Reports).ToList();

            Console.WriteLine(" [{0}] ", list.Count);

            return View(list);
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

        [Authorize]
        public ActionResult Report_WeeklyClientHours(String ClientName)
        {
            var dic = new Dictionary<string, string>
                {
                    {"client", ClientName}
                };
            return View(dic);
        }

        /// <summary>
        /// Fixed to allow for proper Year to Date Logic
        /// </summary>
        /// <param name="ClientName"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public JsonResult Report_ClientHoursData(String ClientName)
        {
            PMP.PMPReportAccess reports = new PMP.PMPReportAccess();

            List<Hashtable> report_data = reports.ClientHoursReport(new PMP.OrganizationReportParameters()
            {
                StartDate = DateTime.Parse(String.Format("01/01/{0}", DateTime.Now.Year)),
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

        [HttpGet]
        [Authorize]
        public JsonResult Report_WeeklyClientHoursData(String ClientName, int week, int year)
        {
            PMP.PMPReportAccess reports = new PMP.PMPReportAccess();

            List<Hashtable> reportData = reports.WeeklyClientReport(week, year, ClientName);

            return new JsonResult()
            {
                Data = reportData,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        [Authorize]
        public JsonResult Report_WeekNameData()
        {
            var reports = new PMP.PMPReportAccess();
            List<PmpWeekInfo> reportData = reports.GetAllWeekName();

            return new JsonResult()
            {
                Data = reportData,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        [HttpGet]
        [Authorize]
        public JsonResult Report_GetAssignedByUser()
        {
            Nullable<int> id = 0;
            Bll.UserreportsCollection useReports = Bll.Userreports.Select_UserReportss_By_UserId(id);

            var list = useReports.Select(x => x.Reports).ToList();

            return new JsonResult()
            {
                Data = list,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        #endregion
    }
}