using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;


namespace ReportSpace.Application.Security
{
    public class ApplicationUserManager : Microsoft.AspNet.Identity.UserManager<ApplicationUser>
    {
        #region [ Fields ] 
        #endregion

        #region [ Constructor ]
        public ApplicationUserManager(ApplicationSecurityComponent comp)
            : base(comp)
        {
            
        }
        #endregion

        #region [ Overides ]
        public override Task<Microsoft.AspNet.Identity.IdentityResult> CreateAsync(ApplicationUser user)
        {
            return base.CreateAsync(user);
        }

        public override Task<Microsoft.AspNet.Identity.IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return base.CreateAsync(user, password);
        }
        #endregion
    }
}
