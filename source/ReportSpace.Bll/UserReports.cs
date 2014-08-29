using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.Bll.Exceptions;

namespace ReportSpace.Bll
{
    public partial class Userreports
    {
        public bool Create(Reports report, Users user)
        {
            bool created = false;

            try
            {
                // Assign local values
                this._userid = user.Id.Value;
                this._reportid = report.Id.Value;
                this.Insert();
                created = true;
            }
            catch (Exception x)
            {
                throw new UsersRolesException("Could not Create user-Role Mapping", x);
            }

            return created;
        }

        public String UserName
        {
            get
            {
                if (this._users == null)
                {
                    this._users = Bll.Users.Load(this._userid);
                }

                return this._users.Username;
            }
        }

        public String ReportName
        {
            get
            {
                if (this._reports == null)
                {
                    this._reports = Bll.Reports.Load(this._reportid);
                }

                return this._reports.Name;
            }
        }

        public Int32 UserId
        {
            get { return this._userid.Value; }
        }

        public Int32 ReportId
        {
            get { return this._reportid.Value; }
        }


    }
}
