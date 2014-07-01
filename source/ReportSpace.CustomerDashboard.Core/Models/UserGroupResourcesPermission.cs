using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    public class UserGroupResourcesPermission : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; set; }

        public Guid? UserGroupId { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        public Guid? ResourceId { get; set; }

        public virtual Resource Resource { get; set; }

        public bool Active { get; set; }

    }
}
