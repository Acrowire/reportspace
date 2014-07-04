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
    [ExportMetadata("BaseObjectName", "UserProfile")]
    public class Function : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ResourceName { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public virtual ICollection<UserFunction> UserFunctions { get; set; }

        public virtual ICollection<Template> Templates { get; set; }
    }
}
