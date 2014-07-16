namespace ReportSpace.PMP.Dal {
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    using System.Xml;
    
    
    public partial class Views : IDisposable {
        
        private DataAccess _dataAccess;
        
        public Views() {
            this._dataAccess = new DataAccess();
        }
        
        public virtual System.Data.DataSet rpt_client_project_hours_Select_All() {
            this._dataAccess.CreateProcedureCommand("sp_rpt_client_project_hours_Select_All");
            DataSet value = this._dataAccess.ExecuteDataSet();
            return value;
        }
        
        public virtual void Dispose() {
            if ((this._dataAccess != null)) {
                this._dataAccess.Dispose();
            }
        }
    }
}
