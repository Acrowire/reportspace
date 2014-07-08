using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportSpace.CustomerDashboard.BusinessLayer.Managers;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    public class UserGroupController : Controller
    {
        //
        // GET: /UserGroup/

        public ActionResult Index()
        {
            var manager = new RepositoryManager();
            var userGroups = manager.GetAll<UserGroup>();

            return View(userGroups);
        }

        public ActionResult New()
        {
            return View("UserGroupEdit", new UserGroup());
        }

        public ActionResult Create(UserGroup userGroup)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_ValidationSummary", userGroup);
            }

            var manager = new RepositoryManager();
            var newUserGroup =  manager.Create(userGroup);
            return this.PartialView("_UserGroup", newUserGroup);
        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.DialogTitle = "Edit User Group";
            var manager = new RepositoryManager();
            var userGroup = manager.Retrieve<UserGroup>(id);
            return View("UserGroupEdit", userGroup);
        }

        public ActionResult Update(Guid id, UserGroup userGroup)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_ValidationSummary", userGroup);
            }

            var manager = new RepositoryManager();
            var updated = manager.Retrieve<UserGroup>(userGroup.Id);
            updated.Name = userGroup.Name;
            manager.Update(updated);

            return View("_UserGroup", updated);
        }


        public ActionResult Delete()
        {
            return new EmptyResult();
        }

    }
}
