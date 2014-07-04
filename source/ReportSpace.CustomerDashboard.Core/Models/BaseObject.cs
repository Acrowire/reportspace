using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    public abstract class BaseObject: IDataObject // : EntityBase
    {
        //public abstract Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Created { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Updated { get; set; }

        public bool Active { get; set; }
    }
}
