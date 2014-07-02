using System.Data.Entity;
using System.Linq;
using System.Reflection;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public class ReportsContext : DbContext, IReportsContext
    {
        public ReportsContext()
            //: base("DefaultConnection")
            : base(DBConstants.GetDBConnection(), true)
        {
        }

        public void ResetPreviousDefaultReport(int currentDefaultReportId)
        {
            var previousDefaultReport = this.Reports.FirstOrDefault(r => r.IsDefault && r.Id != currentDefaultReportId);
            if (previousDefaultReport != null)
            {
                previousDefaultReport.IsDefault = false;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public IDbSet<Report> Reports { get; set; }

        public IDbSet<Role> Roles { get; set; }
    }
}