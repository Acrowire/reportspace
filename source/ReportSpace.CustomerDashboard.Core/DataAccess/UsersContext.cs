using System.Data.Entity;
using System.Reflection;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public class UsersContext : DbContext, IUserContext
    {
        public UsersContext()
            //: base("DefaultConnection")
            : base(DBConstants.GetDBConnection(), true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
 
        public IDbSet<UserProfile> UserProfiles { get; set; }

        public IDbSet<Membership> Memberships { get; set; }

        public IDbSet<ResourceType> ResourceTypes { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<UserGroup> UserGroups { get; set; }

        public IDbSet<UserGroupMembership> UserGroupMemberships { get; set; }

        public IDbSet<UserGroupResourcesPermission> UserGroupResourcesPermissions { get; set; }

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Role> Roles { get; set; }


    }
}