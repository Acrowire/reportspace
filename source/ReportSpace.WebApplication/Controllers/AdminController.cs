
using Microsoft.AspNet.Identity;
using ReportSpace.Application.Security;
using ReportSpace.Application.Security;
using ReportSpace.WebApplication.Controllers.Attributes;
using ReportSpace.WebApplication.Models;
using ReportSpace.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ReportSpace.WebApplication.Controllers
{
    [ApplicationAuthorizeAttribute(Roles = "Admin")]
    public class AdminController : Controller
    {
        #region [ Fields ] 
        public ApplicationUserManager UserManager { get; private set; }
        #endregion

        #region [ Constructors ] 
        public AdminController()
            : this(new ApplicationUserManager(new ApplicationSecurityComponent()))
        {

        }

        public AdminController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        #endregion


        #region [ Controller Actions ]
        //
        // GET: /Admin/
     
        [HttpGet]
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            
            Bll.UsersCollection Users = Bll.Users.GetAll();

            model.Users = Users;

            return View(model);
        }


        #region [ Users ]
        [HttpGet]
        public ActionResult UserList()
        {
            Bll.UsersCollection users = Bll.Users.GetAll();

            return View(users);
        }

        [HttpGet]
        public ActionResult EditUser(Guid PublicId)
        {
            var model = new EditUserViewModel();
            var user = Bll.Users.GetById(PublicId);

            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("UserList");

            model.Email = user.Email;
            model.UserName = user.Username;
            model.PublicId = user.Publicid.Value;
 
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser(model.PublicId)
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                    };

                    // OWIN : Registration
                    var result = UserManager.UpdateAsync(user).Result;

                    if (result.Errors.Count() == 0)
                    {
                        return RedirectToAction("UserList", "Admin");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult NewUser()
        {
            var model = new CreateUserViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult NewUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PasswordHash = model.Password
                };

                // OWIN : Registration
                var result = UserManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("UserList", "Admin");
                }else{
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult UserDetails(Guid PublicId)
        {
            var user = Bll.Users.GetById(PublicId);

            return View(user);
        }

        //
        // GET: /Account/Manage
        public ActionResult ResetPassword(Guid PublicId)
        {
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");

            var model = new ResetPasswordViewModel();
            model.PublicId = PublicId;


            return View(model);
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("ResetPassword");

                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    var result = UserManager.SetPassword(model.PublicId, model.NewPassword).Result;


                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserList");
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }


            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion


        #endregion


        #region [ Local Methods ] 
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
        #endregion
        #region [ Local Enums ]
        public enum AdminManageMessageId
        {
            Ready,
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }
        #endregion
    }
}