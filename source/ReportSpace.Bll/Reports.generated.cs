using System;

namespace ReportSpace.Bll {
    
    
    public partial class Reports {
        
        private System.Nullable<int> _id;
        
        private System.Nullable<System.Guid> _publicid;
        
        private string _name;
        
        private string _controller;
        
        private string _action;
        
        private System.Nullable<int> _organizationid;
        
        private Organizations _organizations;
        
        private UserreportsCollection _userreportsCollection;
        
        public virtual System.Nullable<int> Id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }
        
        public virtual System.Nullable<System.Guid> Publicid {
            get {
                return _publicid;
            }
            set {
                _publicid = value;
            }
        }
        
        public virtual string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }
        
        public virtual string Controller {
            get {
                return _controller;
            }
            set {
                _controller = value;
            }
        }
        
        public virtual string Action {
            get {
                return _action;
            }
            set {
                _action = value;
            }
        }

        public virtual System.Nullable<int> OrganizationId
        {
            get {
                return _organizationid;
            }
            set { 
                _organizationid = value;
            }
        }

        public virtual Organizations Organizations {
            get {
                if ((this._organizations == null)) {
                    this._organizations = ReportSpace.Bll.Organizations.Load(this._organizationid);
                }
                return this._organizations;
            }
            set {
                _organizations = value;
            }
        }
        
        public virtual UserreportsCollection UserreportsCollection {
            get {
                if ((this._userreportsCollection == null)) {
                    _userreportsCollection = ReportSpace.Bll.Userreports.Select_UserReportss_By_ReportId(this.Id);
                }
                return this._userreportsCollection;
            }
        }
        
        private void Clean() {
            this.Id = null;
            this.Publicid = null;
            this.Name = string.Empty;
            this.Controller = string.Empty;
            this.Action = string.Empty;
            this._organizationid = null;
            this.Organizations = null;
            this._userreportsCollection = null;
        }
        
        public void Fill(System.Data.DataRow dr) {
            this.Clean();
            if ((dr["Id"] != System.DBNull.Value)) {
                this.Id = ((System.Nullable<int>)(dr["Id"]));
            }
            if ((dr["PublicId"] != System.DBNull.Value)) {
                this.Publicid = ((System.Nullable<System.Guid>)(dr["PublicId"]));
            }
            if ((dr["Name"] != System.DBNull.Value)) {
                this.Name = ((string)(dr["Name"]));
            }
            if ((dr["Controller"] != System.DBNull.Value)) {
                this.Controller = ((string)(dr["Controller"]));
            }
            if ((dr["Action"] != System.DBNull.Value)) {
                this.Action = ((string)(dr["Action"]));
            }
            if ((dr["OrganizationId"] != System.DBNull.Value)) {
                this._organizationid = ((System.Nullable<int>)(dr["OrganizationId"]));
            }
        }
        
        public static ReportsCollection Select_Reportss_By_OrganizationId(System.Nullable<int> OrganizationId) {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                System.Data.DataSet ds = dbo.Select_Reportss_By_OrganizationId(OrganizationId);
                ReportsCollection collection = new ReportsCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Reports obj = new Reports();
                        obj.Fill(ds.Tables[0].Rows[i]);
                        if ((obj != null)) {
                            collection.Add(obj);
                        }
                    }
                }
                return collection;
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
        
        public static ReportsCollection GetAll() {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                System.Data.DataSet ds = dbo.Reports_Select_All();
                ReportsCollection collection = new ReportsCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Reports obj = new Reports();
                        obj.Fill(ds.Tables[0].Rows[i]);
                        if ((obj != null)) {
                            collection.Add(obj);
                        }
                    }
                }
                return collection;
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
        
        public static Reports Load(System.Nullable<int> Id) {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                System.Data.DataSet ds = dbo.Reports_Select_One(Id);
                Reports obj = null;
                if (GlobalTools.IsSafeDataSet(ds)) {
                    if ((ds.Tables[0].Rows.Count > 0)) {
                        obj = new Reports();
                        obj.Fill(ds.Tables[0].Rows[0]);
                    }
                }
                return obj;
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
        
        public virtual void Load() {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                System.Data.DataSet ds = dbo.Reports_Select_One(this.Id);
                if (GlobalTools.IsSafeDataSet(ds)) {
                    if ((ds.Tables[0].Rows.Count > 0)) {
                        this.Fill(ds.Tables[0].Rows[0]);
                    }
                }
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
        
        public virtual void Insert() {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                dbo.Reports_Insert(this.Publicid, this.Name, this.Controller, this.Action, this._organizationid);
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
        
        public virtual void Delete() {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                dbo.Reports_Delete(this.Id);
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
        
        public virtual void Update() {
            ReportSpace.Dal.Reports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Reports();
                dbo.Reports_Update(this.Id, this.Publicid, this.Name, this.Controller, this.Action, this._organizationid);
            }
            catch (System.Exception ) {
                throw;
            }
            finally {
                if ((dbo != null)) {
                    dbo.Dispose();
                }
            }
        }
    }
}
