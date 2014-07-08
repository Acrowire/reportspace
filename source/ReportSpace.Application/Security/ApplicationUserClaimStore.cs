using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Application.Security
{
    public class ApplicationUserClaimStore : Microsoft.AspNet.Identity.IUserClaimStore<ApplicationUser>
    {

        #region IUserClaimStore<ApplicationUser,string> Members

        public Task AddClaimAsync(ApplicationUser user, System.Security.Claims.Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task<IList<System.Security.Claims.Claim>> GetClaimsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(ApplicationUser user, System.Security.Claims.Claim claim)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserStore<ApplicationUser,string> Members
        private IUserStore<ApplicationUser> userStore = new ApplicationUserStore();

        public async Task CreateAsync(ApplicationUser user)
        {
            await this.userStore.CreateAsync(user);
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            await this.userStore.DeleteAsync(user);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
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
