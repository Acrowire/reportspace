using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportSpace.Bll;
using ReportSpace.WebApplication.Controllers.Attributes;
using ReportSpace.WebApplication.Extensions;
using ReportSpace.WebApplication.Models;

namespace ReportSpace.WebApplication.Controllers
{
    [ApplicationAuthorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        public ActionResult ReportsList()
        {
            Bll.ReportsCollection model = Bll.ReportsCollection.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult EditReport(Guid PublicId)
        {
            Bll.Reports report = Bll.Reports.GetById(PublicId);

            var model = new ReportViewModel
            {
                Action = report.Action,
                Controller = report.Controller,
                Name = report.Name,
                PublicId = report.Publicid.Value,
                OrganizationId = report.OrganizationId.Value
            };

            var organizations = Bll.Organizations.GetAll();
            ViewBag.Organizations = organizations;


            return View(model);
        }

        [HttpPost]
        public ActionResult EditReport(ReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bll.Reports reports = Bll.Reports.GetById(model.PublicId);
                reports.Action = model.Action;
                reports.Controller = model.Controller;
                reports.Name = model.Name;
                reports.OrganizationId = model.OrganizationId;

                reports.Update();

                return RedirectToAction("ReportsList", "Reports");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateReport()
        {
            var model = new ReportViewModel();

            var organizations = Bll.Organizations.GetAll();
            ViewBag.Organizations = organizations;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateReport(ReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Bll.Reports.Exists(model.Name) == false)
                {
                    var reports = new Reports
                    {
                        Name = model.Name,
                        Controller = model.Controller,
                        Action = model.Action,
                        Publicid = Guid.NewGuid(),
                        OrganizationId = model.OrganizationId
                    };
                    reports.Insert();

                    return RedirectToAction("ReportsList", "Reports");
                }
            }
            return View(model);
        }

        public ActionResult DeleteReport(Guid PublicId)
        {
            Bll.Reports reports = Bll.Reports.GetById(PublicId);
            reports.Delete();
            return RedirectToAction("ReportsList", "Reports");
        }

        public ActionResult ShowUserList()
        {
            var users = Bll.Users.GetAll();

            return View(users);
        }

        public ActionResult UpdateUserReports(int userid)
        {
            var  response = new Dictionary<Organizations, ReportsCollection>();

            var orgUser = Bll.Organizationusers.Select_OrganizationUserss_By_UserId(userid);
            var list = orgUser.Select(x => x.Organizations);

            foreach (var org in list)
            {
                var reports = Bll.Reports.Select_Reportss_By_OrganizationId(org.Id);
                response.Add(org,reports);
            }

            var user = Bll.Users.GetById(userid);
            var userReports = Bll.UserreportsCollection.GetAllByUserId(user.Id.Value);

            ViewBag.UserReports = userReports.Select( x => x.ReportId ).ToList();
            ViewBag.Userid = user.Publicid;
            return View(response);
        }

        [HttpPost]
        public ActionResult UpdateUserReports(FormCollection collection)
        {
            var userId = collection["UserPublicid"];

            var value = collection["selectedcheckboxes"];
            var list =  value.Split(',');
            var idReports = list.Select(str => str.Replace("rep_", "")).Select(id => Int32.Parse(id)).ToList();
            var user = Bll.Users.GetById(Guid.Parse(userId));

            Bll.Userreports.AddUpdateReports(user.Id.Value, idReports);

            return RedirectToAction("ShowUserList", "Reports");
        }
    }
}