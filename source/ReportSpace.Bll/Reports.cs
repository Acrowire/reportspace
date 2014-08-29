using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Bll
{
    public partial class Reports
    {
        public static Reports GetById(Guid publicId)
        {
            var report = Bll.Reports.GetAll().First(x => x.Publicid == publicId);
            return report;
        }

        public static bool Exists(string name)
        {
            return Bll.Reports.GetAll().Any(o => o.Name.ToLower() == name.ToLower());
        }
    }
}
