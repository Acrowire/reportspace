
using Microsoft.AspNet.Identity;
using ReportSpace.Application.Security;
using ReportSpace.Application.Security;
using ReportSpace.Bll;
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

        #region [ Roles ] 
        public ActionResult RoleList()
        {
            var model = Bll.Roles.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult NewRole()
        {
            NewRoleViewModel model = new NewRoleViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult NewRole(NewRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bll.Roles _role = new Bll.Roles();
                _role.Active = true;
                _role.Name = model.Name;
                _role.Publicid = Guid.NewGuid();
                _role.Insert();

                return RedirectToAction("RoleList", "Admin");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult EditRole(Guid PublicId)
        {
            EditRoleViewModel model = new EditRoleViewModel();

            Bll.Roles role = Bll.Roles.GetById(PublicId);
            model.Active = role.Active.Value;
            model.Name = role.Name;
            model.PublicId = role.Publicid.Value;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bll.Roles role = Bll.Roles.GetById(model.PublicId);
                role.Active = model.Active;
                role.Name = model.Name;
                role.Update();

                return RedirectToAction("RoleList", "Admin");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion

        #region [ User Roles ] 
        public ActionResult UserRoleList()
        {
            var model = Bll.UserrolesCollection.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUserRole()
        {
            CreateUserRoleViewModel model = new CreateUserRoleViewModel();
            List<SelectListItem> roles = new List<SelectListItem>();
            List<SelectListItem> users = new List<SelectListItem>();

            roles = Bll.Roles.GetAll()
                             .Where( r=> r.Active == true)
                             .Select(r => new SelectListItem()
                             {
                                 Text = r.Name,
                                 Value = r.Publicid.Value.ToString()
                             }).ToList();

            users = Bll.Users.GetAll()
                             .Where(u => u.Active == true)
                             .Select(u => new SelectListItem()
                             {
                                 Text = String.Format("{0} ({1})",u.Username,u.Email),
                                 Value = u.Publicid.Value.ToString()
                             }).ToList();

            ViewBag.Roles = roles;
            ViewBag.Users = users;

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateUserRole(CreateUserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bll.Userroles _userrole = new Bll.Userroles();
                _userrole.Create(Bll.Roles.GetById(model.RolePublicId), Bll.Users.GetById(model.UserPublicId));

                // Finally
                return RedirectToAction("UserRoleList", "Admin");
            }

            return View(model);
        }

        #endregion

        #region [ Organizations ]
        public ActionResult OrgList()
        {
            Bll.OrganizationsCollection model = Bll.Organizations.GetAll();

            return View(model);
        }

       
        [HttpGet]
        public ActionResult NewOrg()
        {
            var model = new NewOrgViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult NewOrg(NewOrgViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Bll.Organizations.Exists(model.Name) == false)
                {
                    Bll.Organizations _org = new Bll.Organizations();
                    _org.Name = model.Name;
                    _org.Active = true;
                    _org.Publicid = Guid.NewGuid();
                    _org.Insert();
                    
                    return RedirectToAction("OrgList", "Admin");
                }
                else
                {
                    ModelState.AddModelError("An organization by that name already exists",new ArgumentException("An organization by that name already exists"));
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditOrg(Guid PublicId)
        {
            var model = new EditOrgViewModel();
            Bll.Organizations org = Bll.Organizations.GetById(PublicId);

            model.Active = org.Active.Value;
            model.Name = org.Name;
            model.PublicId = org.Publicid.Value;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditOrg(EditOrgViewModel model)
        {
            if (ModelState.IsValid)
            {
                    Bll.Organizations _org = Bll.Organizations.GetById(model.PublicId);
                    _org.Name = model.Name;
                    _org.Active = model.Active;
                    _org.Update();

                    return RedirectToAction("OrgList", "Admin");
            }

            return View(model);
        }
        #endregion

        #region [ Organization Users ]

        public ActionResult OrgUsersList()
        {
            Bll.OrganizationusersCollection model = Bll.Organizationusers.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateOrgUser()
        {
            CreateOrgUserViewModel model = new Models.CreateOrgUserViewModel();

            List<SelectListItem> orgList = new List<SelectListItem>();
            List<SelectListItem> userList = new List<SelectListItem>();

            orgList = Bll.Organizations.GetAll()
                         .Where(o => o.Active == true)
                         .Select(o => new SelectListItem()
                         {
                              Text = o.Name,
                              Value = o.Publicid.Value.ToString()
                         })
                         .ToList();

            userList = Bll.Users.GetAll()
                          .Where(u => u.Active == true)
                          .Select(u => new SelectListItem()
                          {
                              Text = String.Format("{0} - ({1})",u.Username, u.Email),
                              Value = u.Publicid.Value.ToString()
                          })
                          .ToList();

            ViewBag.orgs = orgList;
            ViewBag.users = userList;

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrgUser(CreateOrgUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bll.Organizationusers.Create(model.OrganizationPublicId, model.UserPublicId);

                if (MvcApplication.UserRolesCache.ContainsKey(model.UserPublicId.ToString()))
                {
                    List<String> old = new List<string>();
                    MvcApplication.UserRolesCache.TryRemove(model.UserPublicId.ToString(), out old);
                }

                return RedirectToAction("OrgUsersList", "Admin");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditOrgUser(Int32 Id)
        {
            EditOrgUserViewModel model = new Models.EditOrgUserViewModel();
            Bll.Organizationusers orgUser =  Bll.Organizationusers.GetById(Id);
            List<SelectListItem> orgList = new List<SelectListItem>();
            List<SelectListItem> userList = new List<SelectListItem>();

            model.Active = orgUser.Active.Value ;
            model.Id = Id;
            model.OrganizationPublicId = orgUser.OrganizationPublicId;
            model.UserPublicId = orgUser.UserPublicId;

            orgList = Bll.Organizations.GetAll()
                       .Where(o => o.Active == true)
                       .Select(o => new SelectListItem()
                       {
                           Text = o.Name,
                           Value = o.Publicid.Value.ToString()
                       })
                       .ToList();

            userList = Bll.Users.GetAll()
                          .Where(u => u.Active == true)
                          .Select(u => new SelectListItem()
                          {
                              Text = String.Format("{0} - ({1})", u.Username, u.Email)
                          })
                          .ToList();

            ViewBag.orgs = orgList;
            ViewBag.users = userList;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditOrgUser(EditOrgUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bll.Organizationusers.Update(model.Id, model.OrganizationPublicId, model.UserPublicId, model.Active);
                
                return RedirectToAction("OrgUsersList", "Admin");
            }

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