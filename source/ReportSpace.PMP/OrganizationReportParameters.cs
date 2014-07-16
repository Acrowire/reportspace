using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.PMP
{
    public class OrganizationReportParameters
    {
        public String OrganizationName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public OrganizationReportParameters()
        {
            this.OrganizationName = "/";
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }
    }
}
