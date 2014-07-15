using System;
namespace ReportSpace.Bll {
    
    using System.Linq;
    using System.Collections;
    using System.Collections.Concurrent;

    public partial class Organizationusers
    {
        #region [ Static Methods ] 
        public static ConcurrentDictionary<Int32, Bll.Organizationusers> Cache = new ConcurrentDictionary<int, Organizationusers>();

        public static bool Create(Guid OrganizationPublicId, Guid UserPublicId)
        {
            bool created = false;

            try
            {
                var user = Bll.Users.GetById(UserPublicId);
                var org = Bll.Organizations.GetById(OrganizationPublicId);

                var orgUser = new Bll.Organizationusers();
                orgUser._active = true;
                orgUser._organizationid = org.Id.Value;
                orgUser._userid = user.Id.Value;
                orgUser.Insert();

                created = true;
            }
            catch (Exception x)
            {
                throw x;
            }

            return created;
        }

        public static Bll.Organizationusers GetById(Int32 Id)
        {
            Bll.Organizationusers orguser = new Organizationusers();

            orguser = Bll.Organizationusers.Load(Id);

            return orguser;
        }

        public static bool Update(Int32 Id, Guid OrganizationPublicId, Guid UserPublicId, bool active)
        {
            bool updated = false;

            try
            {
                Bll.Organizationusers orgUser = new Organizationusers();
                orgUser._id = Id;
                orgUser._organizationid = Bll.Organizations.GetById(OrganizationPublicId).Id;
                orgUser._userid = Bll.Users.GetById(UserPublicId).Id;
                orgUser.Active = active;
                orgUser.Update();

                updated = true;
            }
            catch (Exception x)
            {
                throw x;
            }

            return updated;
        }
        #endregion

        #region [ Properties ] 
        public Int32 OrganizationId
        {
            get { return this._organizationid.Value; }
        }

        public Int32 UserId
        {
            get { return this._userid.Value; }
        }

        public Guid OrganizationPublicId
        {
            get
            {
                if (this.Organizations == null)
                {
                    this.Organizations = Bll.Organizations.Load(this._organizationid);
                }

                return this.Organizations.Publicid.Value;
            }
        }

        public Guid UserPublicId
        {
            get
            {
                if (this.Users == null) {
                    this.Users = Bll.Users.Load(this._userid);
                }

                return this.Users.Publicid.Value;
            }
        }
        #endregion
    }
}
