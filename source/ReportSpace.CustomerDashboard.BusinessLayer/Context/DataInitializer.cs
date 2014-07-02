using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.BusinessLayer.Context
{
    public class DataInitializer
    {

        public static void Initialize()
        {
            Repository<UserProfile> repository = RepositoryFactory.GetRepository<UserProfile>();

        }


        private static void CreateUser()
        {
            
            
            UserProfile admin = new UserProfile();
        }


    }
}
