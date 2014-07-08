using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Application.Security
{
    using Microsoft.AspNet.Identity;
    using ReportSpace.Bll;


    public class ApplicationUserStore : Microsoft.AspNet.Identity.IUserStore<ApplicationUser> , Microsoft.AspNet.Identity.IUserPasswordStore<ApplicationUser>
    {
        #region [ Fields ] 
        private IUserPasswordStore<ApplicationUser> m_passwordstore = new ApplicationPasswordStore();
        #endregion

        public bool UserExists(ApplicationUser user)
        {
            bool user_exists = false;

            try 
            {
                user_exists = Users.GetAll().Where(u => u.Email == user.Email || u.Username == user.UserName).Any();
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Could not search for user", x);
            }

            return user_exists;
        }


        #region IUserStore<ApplicationUser,string> Members

        public async Task CreateAsync(ApplicationUser user)
        {
            bool success = false;

            try
            {
                Bll.Users _user = new Users()
                {
                    Active = true,
                    Email = user.Email,
                    Publicid = Guid.Parse(user.Id),
                    Username = user.UserName
                };

                if (this.UserExists(user))
                {
                    throw new ApplicationSecurityException(this.GetObjectContext(), "User with that username/email already exists", null);
                }

                _user.Insert();

                success = true;
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Failed creating user", x);
            }
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
             try
             {
                 if (this.UserExists(user) == false)
                 {
                     throw new ApplicationSecurityException(this.GetObjectContext(), "User with that username/email doest not exist", null);
                 }

                 Users.GetByEmail(user.Email).Delete();
             }
             catch (Exception x)
             {
                 throw new ApplicationSecurityException(this.GetObjectContext(), "Can not delete user", x);
             }
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            ApplicationUser appUser = new ApplicationUser();

            try
            {
                var user = Users.GetById(Guid.Parse(userId));

                appUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = user.Username
                };
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Could not Find user by id", x);
            }

            return appUser;
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            ApplicationUser appUser = new ApplicationUser();

            try
            {
                var user = Users.GetByUserName(userName);

                appUser = new ApplicationUser()
                {
                    Email = user.Email,
                    UserName = user.Username
                };
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Could not Find user by id", x);
            }

            return appUser;
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            try
            {
                if (this.UserExists(user))
                {
                    Bll.Users u = Users.GetById(Guid.Parse(user.Id));

                    // refactor later to make sure we arent reusing an email address
                    u.Username = user.UserName;
                    u.Email = user.Email;
                }
                else
                {
                    throw new ApplicationSecurityException(this.GetObjectContext(), "Could not update user, user does not exist", new ArgumentException("User does not exist"));
                }
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Could not update user", x);
            }

        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion

        #region IUserPasswordStore<ApplicationUser,string> Members

        public async Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return this.m_passwordstore.GetPasswordHashAsync(user).Result;
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return this.m_passwordstore.HasPasswordAsync(user);
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            await this.m_passwordstore.SetPasswordHashAsync(user, passwordHash);
        }

        #endregion
    }
}
