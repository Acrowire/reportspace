using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.DataAccess;

namespace ReportSpace.CustomerDashboard.BusinessLayer.Context
{
    public class ContextInitializer
    {
        public static void Initialize()
        {
            RepositoryFactory.LoadRepositories();
        }

    }
}
