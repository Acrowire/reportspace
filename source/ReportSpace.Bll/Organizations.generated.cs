namespace ReportSpace.Bll {
    
    
    public partial class Organizations {
        
        private System.Nullable<int> _id;
        
        private System.Nullable<System.Guid> _publicid;
        
        private string _name;
        
        private System.Nullable<bool> _active;
        
        private OrganizationusersCollection _organizationusersCollection;
        
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
        
        public virtual System.Nullable<bool> Active {
            get {
                return _active;
            }
            set {
                _active = value;
            }
        }
        
        public virtual OrganizationusersCollection OrganizationusersCollection {
            get {
                if ((this._organizationusersCollection == null)) {
                    _organizationusersCollection = ReportSpace.Bll.Organizationusers.Select_OrganizationUserss_By_OrganizationId(this.Id);
                }
                return this._organizationusersCollection;
            }
        }
        
        private void Clean() {
            this.Id = null;
            this.Publicid = null;
            this.Name = string.Empty;
            this.Active = null;
            this._organizationusersCollection = null;
        }
        
        private void Fill(System.Data.DataRow dr) {
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
            if ((dr["Active"] != System.DBNull.Value)) {
                this.Active = ((System.Nullable<bool>)(dr["Active"]));
            }
        }
        
        public static OrganizationsCollection GetAll() {
            ReportSpace.Dal.Organizations dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizations();
                System.Data.DataSet ds = dbo.Organizations_Select_All();
                OrganizationsCollection collection = new OrganizationsCollection();
                if (GlobalTools.IsSafeDataSet(ds)) {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1)) {
                        Organizations obj = new Organizations();
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
        
        public static Organizations Load(System.Nullable<int> Id) {
            ReportSpace.Dal.Organizations dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizations();
                System.Data.DataSet ds = dbo.Organizations_Select_One(Id);
                Organizations obj = null;
                if (GlobalTools.IsSafeDataSet(ds)) {
                    if ((ds.Tables[0].Rows.Count > 0)) {
                        obj = new Organizations();
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
            ReportSpace.Dal.Organizations dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizations();
                System.Data.DataSet ds = dbo.Organizations_Select_One(this.Id);
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
            ReportSpace.Dal.Organizations dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizations();
                dbo.Organizations_Insert(this.Publicid, this.Name, this.Active);
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
            ReportSpace.Dal.Organizations dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizations();
                dbo.Organizations_Delete(this.Id);
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
            ReportSpace.Dal.Organizations dbo = null;
            try {
                dbo = new ReportSpace.Dal.Organizations();
                dbo.Organizations_Update(this.Id, this.Publicid, this.Name, this.Active);
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
