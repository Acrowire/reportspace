using System;
using System.Web.Mvc;
using ReportSpace.CustomerDashboard.BusinessLayer.Managers;
using ReportSpace.CustomerDashboard.Core.QueryableExtensions;

namespace ReportSpace.CustomerDashboard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Core.Models;
    using ReportSpace.CustomerDashboard.Web.ViewModels;

    using AutoMapper;

    using WebMatrix.WebData;

    public class UserController : Controller
    {
        private IUserContext _userContext;
        
        public UserController(IUserContext context)
        {
            _userContext = context;
        }

        //Add Admin
        public ActionResult Index()
        {
            ViewBag.OperationRole = EnumRole.Admin;
            List<UserProfile> userProfiles = _userContext.UserProfiles.Where(x => x.Role == EnumRole.Admin).ToList();
            return View(userProfiles.Select(Mapper.Map<UserProfileViewModel>).ToList());
        }

        //Add Admin
        public ActionResult IndexAdmin()
        {
            ViewBag.OperationRole = EnumRole.Admin;
            List<UserProfile> userProfiles = _userContext.UserProfiles.Where(x => x.Role == EnumRole.Admin).ToList();
            return View("Index",userProfiles.Select(Mapper.Map<UserProfileViewModel>).ToList());
        }

        public ActionResult IndexUser()
        {
            ViewBag.OperationRole = EnumRole.User;
            List<UserProfile> userProfiles = _userContext.UserProfiles.Where(x => x.Role == EnumRole.User).ToList();
            return View("Index", userProfiles.Select(Mapper.Map<UserProfileViewModel>).ToList());
        }

        public ActionResult New( EnumRole role)
        {
            var availableRoles = new List<EnumRole> { role };
            ViewBag.AvailableRoles = availableRoles;

            ViewBag.DialogTitle = "Create " + role.ToString();

            return View("UserEdit", new UserProfileViewModel());
        }


        public ActionResult Show(int id)
        {
            UserProfile userProfile = _userContext.UserProfiles.Find(id);

            return View("_User", Mapper.Map<UserProfileViewModel>(userProfile));
        }

        
        public ActionResult Create(UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return PartialView("_ValidationSummary", userProfileViewModel);
            }

            var newProfile = SaveUserProfile(
                Mapper.Map<UserProfile>(userProfileViewModel), 
                userProfileViewModel.Password);

            return this.PartialView("_User", Mapper.Map<UserProfileViewModel>(newProfile));
        }

        public ActionResult Edit(int id)
        {
            UserProfile userProfile = _userContext.UserProfiles.Find(id);
            
            ViewBag.DialogTitle = "Edit User";
            return View("UserEdit", Mapper.Map<UserProfileViewModel>(userProfile));
        }

        public ActionResult Update(int id, UserProfileViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("_ValidationSummary", userProfileViewModel);
            }

            var userProfile = Mapper.Map<UserProfile>(userProfileViewModel);
            if (!string.IsNullOrEmpty(userProfileViewModel.Password))
            {
                ChangePassword(userProfileViewModel, userProfile);
            }

            _userContext.SaveChanges();
            
            return View("_User", Mapper.Map<UserProfileViewModel>(userProfile));
        }

        private static bool ChangePassword(UserProfileViewModel userProfileViewModel, UserProfile userProfile)
        {
            var passwordResetToken = WebSecurity.GeneratePasswordResetToken(userProfile.UserName);
            
            return WebSecurity.ResetPassword(passwordResetToken, userProfileViewModel.Password);
        }

        public ActionResult Delete(int id)
        {
            var userProfile = _userContext.UserProfiles.Include(up => up.Roles).Include(up => up.Clients).First(up => up.UserId == id);
            _userContext.UserProfiles.Remove(userProfile);

            _userContext.SaveChanges();

            return Json(userProfile);
        }

        private UserProfile SaveUserProfile(UserProfile userProfile, string password)
        {
            WebSecurity.CreateUserAndAccount(
                userProfile.UserName,password,
                new { userProfile.FirstName, userProfile.LastName,
                      userProfile.Email,
                      userProfile.CompanyLogoFileName,
                      userProfile.Role,
                      Active = true,
                });

            var savedUserProfile = _userContext.UserProfiles.First(up => up.UserName == userProfile.UserName);
            savedUserProfile.Clients = userProfile.Clients;
            savedUserProfile.Roles = userProfile.Roles;
            _userContext.SaveChanges();
            return savedUserProfile;
        }
    }
}
