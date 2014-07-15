using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Application.Organizations
{
    public class OrganizationException : Exception
    {
        #region [ Constructors ]
        public OrganizationException(String Message, Exception Inner)
            : base(Message, Inner)
        {

        }
        #endregion
    }
}
