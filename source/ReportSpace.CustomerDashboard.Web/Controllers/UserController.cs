using System;
using System.Web.Mvc;
using ReportSpace.CustomerDashboard.BusinessLayer.Managers;

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

        public ActionResult Index()
        {
            List<UserProfile> userProfiles = _userContext.UserProfiles.ToList();

            return View(userProfiles.Select(Mapper.Map<UserProfileViewModel>).ToList());
        }

        public ActionResult Show(int id)
        {
            UserProfile userProfile = _userContext.UserProfiles.Find(id);

            return View("_User", Mapper.Map<UserProfileViewModel>(userProfile));
        }

        public ActionResult New()
        {
            return View("UserEdit", new UserProfileViewModel());
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
            /*var manager = new RepositoryManager();

            WebSecurity.CreateUserAndAccount(userProfile.UserName, password);
            int id = WebSecurity.GetUserId(userProfile.UserName);
            
            var newUser = manager.Create(new UserProfile()
                {
                    UserName = userProfile.UserName,
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    Email = userProfile.Email,
                    CompanyLogoFileName = userProfile.CompanyLogoFileName,
                    Clients = userProfile.Clients,
                    Roles = userProfile.Roles,
                    MembershipId = id
                });
            return newUser;*/

            WebSecurity.CreateUserAndAccount(
                userProfile.UserName,password,
                new { userProfile.FirstName, userProfile.LastName, 
                    userProfile.Email, userProfile.CompanyLogoFileName, Active=true });

            
            var savedUserProfile = _userContext.UserProfiles.First(up => up.UserName == userProfile.UserName);
            savedUserProfile.Clients = userProfile.Clients;
            savedUserProfile.Roles = userProfile.Roles;
            _userContext.SaveChanges();
            return savedUserProfile;
             


        }
    }
}
