using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportSpace.Bll;
using ReportSpace.WebApplication.Models;

namespace ReportSpace.WebApplication.Controllers
{
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

        public ActionResult UpdateUserReports()
        {

            return View();
        }

    }
}