namespace ReportSpace.Bll {
    
    
    public partial class Userreports {
        
        private System.Nullable<int> _id;
        
        private System.Nullable<int> _userid;
        
        private System.Nullable<int> _reportid;
        
        private Reports _reports;
        
        private Users _users;
        
        public virtual System.Nullable<int> Id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }
        
        public virtual Reports Reports {
            get {
                if ((this._reports == null)) {
                    this._reports = ReportSpace.Bll.Reports.Load(this._reportid);
                }
                return this._reports;
            }
            set {
                _reports = value;
            }
        }
        
        public virtual Users Users {
            get {
                if ((this._users == null)) {
                    this._users = ReportSpace.Bll.Users.Load(this._userid);
                }
                return this._users;
            }
            set {
                _users = value;
            }
        }
        
        private void Clean() {
            this.Id = null;
            this._userid = null;
            this._reportid = null;
            this.Reports = null;
            this.Users = null;
        }
        
        private void Fill(System.Data.DataRow dr) {
            this.Clean();
            if ((dr["Id"] != System.DBNull.Value)) {
                this.Id = ((System.Nullable<int>)(dr["Id"]));
            }
            if ((dr["UserId"] != System.DBNull.Value)) {
                this._userid = ((System.Nullable<int>)(dr["UserId"]));
            }
            if ((dr["ReportId"] != System.DBNull.Value)) {
                this._reportid = ((System.Nullable<int>)(dr["ReportId"]));
            }
        }
        
        public static UserreportsCollection Select_UserReportss_By_ReportId(System.Nullable<int> ReportId) {
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                System.Data.DataSet ds = dbo.Select_UserReportss_By_ReportId(ReportId);
                UserreportsCollection collection = new UserreportsCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Userreports obj = new Userreports();
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
        
        public static UserreportsCollection Select_UserReportss_By_UserId(System.Nullable<int> UserId) {
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                System.Data.DataSet ds = dbo.Select_UserReportss_By_UserId(UserId);
                UserreportsCollection collection = new UserreportsCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Userreports obj = new Userreports();
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
        
        public static UserreportsCollection GetAll() {
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                System.Data.DataSet ds = dbo.UserReports_Select_All();
                UserreportsCollection collection = new UserreportsCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Userreports obj = new Userreports();
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
        
        public static Userreports Load(System.Nullable<int> Id) {
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                System.Data.DataSet ds = dbo.UserReports_Select_One(Id);
                Userreports obj = null;
                if (GlobalTools.IsSafeDataSet(ds)) {
                    if ((ds.Tables[0].Rows.Count > 0)) {
                        obj = new Userreports();
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
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                System.Data.DataSet ds = dbo.UserReports_Select_One(this.Id);
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
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                dbo.UserReports_Insert(this._userid, this._reportid);
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
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                dbo.UserReports_Delete(this.Id);
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
            ReportSpace.Dal.Userreports dbo = null;
            try {
                dbo = new ReportSpace.Dal.Userreports();
                dbo.UserReports_Update(this.Id, this._userid, this._reportid);
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
