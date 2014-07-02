using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportSpace.CustomerDashboard.BusinessLayer.Context;
using ReportSpace.CustomerDashboard.Core;
using ReportSpace.CustomerDashboard.Core.DataAccess;

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

            ContextInitializer.Initialize();
        }
    }
}