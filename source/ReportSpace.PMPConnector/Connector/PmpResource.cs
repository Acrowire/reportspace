using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.PMPConnector.Connector
{
    public class PmpResource
    {
        public string Project { get; set; }
        public float Direct_labor { get; set; }
        public float Billable_hours { get; set; }
        public float Total_hours { get; set; }
        public string User_name { get; set; }
        public float Gross_revenue { get; set; }
    }
}
