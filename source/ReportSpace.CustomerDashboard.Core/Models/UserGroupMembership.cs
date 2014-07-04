using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    public class UserGroupMembership : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid? UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }

        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

    }
}
