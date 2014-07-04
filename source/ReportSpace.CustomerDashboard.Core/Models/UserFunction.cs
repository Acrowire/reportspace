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
    public class UserFunction : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public Guid FunctionId { get; set; }

        public virtual Function Function { get; set; }
    }
}
