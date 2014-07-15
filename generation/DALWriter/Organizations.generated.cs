namespace ReportSpace.Dal {
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    using System.Xml;
    
    
    public partial class Organizations : IDisposable {
        
        private DataAccess _dataAccess;
        
        public Organizations() {
            this._dataAccess = new DataAccess();
        }
        
        public virtual System.Data.DataSet Organizations_Select_All() {
            this._dataAccess.CreateProcedureCommand("sp_Organizations_Select_All");
            DataSet value = this._dataAccess.ExecuteDataSet();
            return value;
        }
        
        public virtual System.Data.DataSet Organizations_Select_One(System.Nullable<int> Id) {
            this._dataAccess.CreateProcedureCommand("sp_Organizations_Select_One");
            this._dataAccess.AddParameter("Id", Id, ParameterDirection.Input);
            DataSet value = this._dataAccess.ExecuteDataSet();
            return value;
        }
        
        public virtual System.Nullable<int> Organizations_Insert(System.Nullable<System.Guid> PublicId, string Name, System.Nullable<bool> Active) {
            this._dataAccess.CreateProcedureCommand("sp_Organizations_Insert");
            this._dataAccess.AddParameter("PublicId", PublicId, ParameterDirection.Input);
            this._dataAccess.AddParameter("Name", Name, ParameterDirection.Input);
            this._dataAccess.AddParameter("Active", Active, ParameterDirection.Input);
            int value = this._dataAccess.ExecuteNonQuery();
            return value;
        }
        
        public virtual System.Nullable<int> Organizations_Delete(System.Nullable<int> Id) {
            this._dataAccess.CreateProcedureCommand("sp_Organizations_Delete");
            this._dataAccess.AddParameter("Id", Id, ParameterDirection.Input);
            int value = this._dataAccess.ExecuteNonQuery();
            return value;
        }
        
        public virtual System.Nullable<int> Organizations_Update(System.Nullable<int> Id, System.Nullable<System.Guid> PublicId, string Name, System.Nullable<bool> Active) {
            this._dataAccess.CreateProcedureCommand("sp_Organizations_Update");
            this._dataAccess.AddParameter("Id", Id, ParameterDirection.Input);
            this._dataAccess.AddParameter("PublicId", PublicId, ParameterDirection.Input);
            this._dataAccess.AddParameter("Name", Name, ParameterDirection.Input);
            this._dataAccess.AddParameter("Active", Active, ParameterDirection.Input);
            int value = this._dataAccess.ExecuteNonQuery();
            return value;
        }
        
        public virtual void Dispose() {
            if ((this._dataAccess != null)) {
                this._dataAccess.Dispose();
            }
        }
    }
}
