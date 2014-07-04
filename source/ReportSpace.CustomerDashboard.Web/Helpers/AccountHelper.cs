using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportSpace.CustomerDashboard.BusinessLayer.Context;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Web.Helpers
{
    public static class AccountHelper
    {
        public static List<Function> GetUserFunctions(string username)
        {
            Repository<UserProfile> repository = RepositoryFactory.GetRepository<UserProfile>();
            var user = repository.Retrieve(usr => usr.UserName == username);
            if (user!=null)
            {
                var list = user.UserFunctions.Select(x => x.Function);
                return list.ToList();
            }
            return new List<Function>();
        }

    }
}