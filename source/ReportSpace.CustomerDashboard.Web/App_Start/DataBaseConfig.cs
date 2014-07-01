using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportSpace.CustomerDashboard.Core;

namespace ReportSpace.CustomerDashboard.Web.App_Start
{
    public class DataBaseConfig
    {
        public static void RegisterDatabase()
        {
            UsersContext usersContext = new UsersContext();
            usersContext.Database.CreateIfNotExists();

            ReportsContext reportsContext = new ReportsContext();
            reportsContext.Database.CreateIfNotExists();
        }
    }
}