using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    public class UserGroup : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; set; }

        public String Name { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<UserGroupMembership> UserGroupMemberships { get; set; }

        public virtual ICollection<UserGroupResourcesPermission> UserGroupResourcesPermissions { get; set; }
    }
}
