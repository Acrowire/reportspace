namespace ReportSpace.Bll {
    
    
    public partial class Organizationusers {
        
        private System.Nullable<int> _id;
        
        private System.Nullable<int> _organizationid;
        
        private System.Nullable<int> _userid;
        
        private System.Nullable<bool> _active;
        
        private Organizations _organizations;
        
        private Users _users;
        
        public virtual System.Nullable<int> Id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        }
        
        public virtual System.Nullable<bool> Active {
            get {
                return _active;
            }
            set {
                _active = value;
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
            this._organizationid = null;
            this._userid = null;
            this.Active = null;
            this.Organizations = null;
            this.Users = null;
        }
        
        private void Fill(System.Data.DataRow dr) {
            this.Clean();
            if ((dr["Id"] != System.DBNull.Value)) {
                this.Id = ((System.Nullable<int>)(dr["Id"]));
            }
            if ((dr["OrganizationId"] != System.DBNull.Value)) {
                this._organizationid = ((System.Nullable<int>)(dr["OrganizationId"]));
            }
            if ((dr["UserId"] != System.DBNull.Value)) {
                this._userid = ((System.Nullable<int>)(dr["UserId"]));
            }
            if ((dr["Active"] != System.DBNull.Value)) {
                this.Active = ((System.Nullable<bool>)(dr["Active"]));
            }
        }
        
        public static OrganizationusersCollection Select_OrganizationUserss_By_OrganizationId(System.Nullable<int> OrganizationId) {
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                System.Data.DataSet ds = dbo.Select_OrganizationUserss_By_OrganizationId(OrganizationId);
                OrganizationusersCollection collection = new OrganizationusersCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Organizationusers obj = new Organizationusers();
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
        
        public static OrganizationusersCollection Select_OrganizationUserss_By_UserId(System.Nullable<int> UserId) {
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                System.Data.DataSet ds = dbo.Select_OrganizationUserss_By_UserId(UserId);
                OrganizationusersCollection collection = new OrganizationusersCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Organizationusers obj = new Organizationusers();
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
        
        public static OrganizationusersCollection GetAll() {
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                System.Data.DataSet ds = dbo.OrganizationUsers_Select_All();
                OrganizationusersCollection collection = new OrganizationusersCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Organizationusers obj = new Organizationusers();
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
        
        public static Organizationusers Load(System.Nullable<int> Id) {
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                System.Data.DataSet ds = dbo.OrganizationUsers_Select_One(Id);
                Organizationusers obj = null;
                if (GlobalTools.IsSafeDataSet(ds)) {
                    if ((ds.Tables[0].Rows.Count > 0)) {
                        obj = new Organizationusers();
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
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                System.Data.DataSet ds = dbo.OrganizationUsers_Select_One(this.Id);
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
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                dbo.OrganizationUsers_Insert(this._organizationid, this._userid, this.Active);
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
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                dbo.OrganizationUsers_Delete(this.Id);
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
            ReportSpace.Dal.Organizationusers dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizationusers();
                dbo.OrganizationUsers_Update(this.Id, this._organizationid, this._userid, this.Active);
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
