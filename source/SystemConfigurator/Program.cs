using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace SystemConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Init System Configuration");
                FirstTimeConfiguration();
                Console.WriteLine("End System Configuration");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Message {0}", e.Message);
            }
            
        }

        public static void FirstTimeConfiguration()
        {
            var ctx = new UsersContext();

            ctx.Database.CreateIfNotExists();

            var root = new UserProfile()
                {
                    UserName = "root", 
                    Email = "root@root.com",
                    FirstName = "system",
                    LastName = "admin",
                    Active = true,
                };
            ctx.UserProfiles.Add(root);

            ctx.SaveChanges();

        }
    }
}
