using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Application.Security
{
    using ReportSpace.Bll;

    public class ApplicationRoleStore : Microsoft.AspNet.Identity.IRoleStore<ApplicationRole>
    {
        #region IRoleStore<ApplicationRole,string> Members

        public bool RoleExists(ApplicationRole role)
        {
            bool exists = false;

            try
            {
                exists = Bll.Roles.GetAll()
                            .Where(r => r.Active == true)
                            .Where(r => r.Name.ToLower() == role.Name.ToLower())
                            .Any();
                
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Can not find role", x);
            }

            return exists;
        }

        public async Task CreateAsync(ApplicationRole role)
        {
            try
            {
                if (this.RoleExists(role))
                {
                    throw new ApplicationSecurityException(this.GetObjectContext(), "Can not create Role, this role already exists", null);
                }
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Can not create role", x);
            }
        }

        public async Task DeleteAsync(ApplicationRole role)
        {
            try
            {
                if (this.RoleExists(role) == false)
                {
                    throw new ApplicationSecurityException(this.GetObjectContext(), "Can not delete Role, this role does not exist", null);
                }
                else
                {
                    Bll.Roles.GetById(Guid.Parse(role.Id)).Delete();
                }
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Can not delete role", x);
            }
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId)
        {
            ApplicationRole role = new ApplicationRole();

            try
            {
                var result =  Roles.GetById(Guid.Parse(roleId));

                role = new ApplicationRole()
                {
                     Name = result.Name
                };
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Can not find by Id role", x);
            }

            return role;
        }

        public async Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            ApplicationRole role = new ApplicationRole();

            try
            {
                var result = Roles.GetByName(roleName);

                role = new ApplicationRole()
                {
                    Name = result.Name
                };
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Can not find by Id role", x);
            }

            return role;
        }

        public async Task UpdateAsync(ApplicationRole role)
        {
            try
            {
                var urole = Roles.GetById(Guid.Parse(role.Id));
                urole.Name = role.Name;
                urole.Update();
            }
            catch (Exception x)
            {
                throw new ApplicationSecurityException(this.GetObjectContext(), "Can not update role", x);
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
          
        }

        #endregion
    }
}
