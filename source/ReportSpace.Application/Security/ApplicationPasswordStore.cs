using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ReportSpace.Application.Security
{
    public class ApplicationPasswordStore : IUserPasswordStore<ApplicationUser>
    {
        #region [ Fields ] 
        private IUserStore<ApplicationUser> userStore = new ApplicationUserStore();
        #endregion

        #region IUserPasswordStore<ApplicationUser,string> Members

        public async Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return user.PasswordHash;
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return true;
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            try
            {
                var u = Bll.Users.GetById(Guid.Parse(user.Id));
                u.Passwordhash = passwordHash;
                u.Update();
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Error updating password hash", x);
            }
        }

        #endregion



        #region IUserStore<ApplicationUser,string> Members

        public async Task CreateAsync(ApplicationUser user)
        {
            await this.userStore.CreateAsync(user);
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            await this.userStore.DeleteAsync(user);
        }

        public async  Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return this.userStore.FindByIdAsync(userId).Result;
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return this.userStore.FindByNameAsync(userName).Result;
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            await this.userStore.UpdateAsync(user);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
           
        }

        #endregion
    }
}
