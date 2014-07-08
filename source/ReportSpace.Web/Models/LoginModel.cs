using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportSpace.Web.Models
{
    public class LoginModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public Boolean RememberMe { get; set; }  
    }
}