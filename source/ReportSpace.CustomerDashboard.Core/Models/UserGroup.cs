using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    [Export(typeof(IDataObject))]
    [ExportMetadata("BaseObjectName", "UserGroup")]
    public class UserGroup : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        public virtual ICollection<UserGroupMembership> UserGroupMemberships { get; set; }

        public virtual ICollection<UserGroupResourcesPermission> UserGroupResourcesPermissions { get; set; }
    }
}
