using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.PMP
{
    using ReportSpace.Data;
    using System.Collections;

    public class PMPReportAccess
    {
        #region [ Fields ]
        private String ConnectionStringName = "PMP";
        #endregion

        #region [ Constructors ]
        public PMPReportAccess()
        {

        }
        #endregion

        #region [ Report Methods ] 
        public List<Hashtable> ClientHoursReport(OrganizationReportParameters parameters)
        {
            List<Hashtable> data = new List<Hashtable>();

            try
            {
                var access = DataAccess.Create("pmp");
                access.CreateProcedureCommand("sp_rpt_client_project_hours");
                access.AddParameter("@OrganizationName", parameters.OrganizationName, System.Data.ParameterDirection.Input);
                access.AddParameter("@StartDate", parameters.StartDate, System.Data.ParameterDirection.Input);
                access.AddParameter("@EndDate", parameters.EndDate, System.Data.ParameterDirection.Input);
                data = access.ExecuteHash();
            }
            catch (Exception x)
            {
                throw x;
            }

            return data;
        }
        #endregion
    }
}
