using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.Models
{
    public class Resource : BaseObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual ResourceType ResourceType { get; set; }

        public Guid? ResourceTypeId { get; set; }

        public string Path { get; set; }

    }


    
}
