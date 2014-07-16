using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ReportSpace.WebApplication.Extensions
{
    using ReportSpace.Application;
    using ReportSpace.Application.Security;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;


    public static class WebSecurityExtensions
    {
        public static ApplicationUser User(this IIdentity identity)
        {
            ApplicationUser user = new ApplicationUser();

            user = MvcApplication.Security.FindByNameAsync(identity.GetUserName()).Result;

            return user;
        }

        public static Boolean HasRole(this IIdentity identity, String RoleName)
        {
            bool has_role = false;
            string user_public_id = identity.User().PublicId.ToString();

            // Cache 
            if (MvcApplication.UserRolesCache.ContainsKey(user_public_id) == false)
            {
                var roles = MvcApplication.Security.GetRolesAsync(identity.User()).Result;
                MvcApplication.UserRolesCache.TryAdd(user_public_id, roles.ToList());
            }
            // End Cache

            has_role = MvcApplication.UserRolesCache[user_public_id]
                                     .Where(r => r.ToLower() == RoleName.ToLower())
                                     .Any();                                     
       
            return has_role;
        }

        #region [ Organizations ]
        public static Bll.Organizations GetUserOrganization(this IIdentity identity)
        {
            Bll.Organizations org = new Bll.Organizations();
            Guid PublicId = identity.User().PublicId;

            var orgs = Bll.Organizationusers.GetAll()
                                 .Where(u => u.UserPublicId == PublicId);

            if (orgs.Any()) {
                org = Bll.Organizations.Load(orgs.First().OrganizationId);
            }

            return org;
        }
        #endregion
    }
}