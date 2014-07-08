using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Application.Security
{
    /// <summary>
    /// Primary Application User
    /// </summary>
    public class ApplicationUser : IUser
    {
        #region [ Fields ]
        private Guid m_public_id = Guid.Empty;
        #endregion

        #region [ Constructors ] 
        public ApplicationUser() : base()
        {

        }

        public ApplicationUser(Guid PublicId)
        {
            this.m_public_id = PublicId;

        }
        #endregion

        #region [ Properties ]
        public string Id
        {
            get { return this.m_public_id.ToString(); }
        }

        public string UserName { get; set; } 

        #endregion

        #region [ Properties ] 
        public string Email { get; set; }

        public String PasswordHash { get; set; }  
        #endregion
    }
}
