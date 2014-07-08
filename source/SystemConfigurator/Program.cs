using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace SystemConfigurator
{
    class Program
    {
        private static List<Function> functions = new List<Function>(); 

        static void Main(string[] args)
        {
            try
            {
                var ctx = new UsersContext();

                Console.WriteLine("Init System Configuration");
                FirstTimeConfiguration(ctx);

                //var loader = new CustomClassLoader();
                /*CustomClassLoader.LoadRepositories();
                var rep = CustomClassLoader.GetRepository<UserProfile>();
                if (rep!=null)
                {
                    Console.WriteLine("GOOD");
                }*/

            }
            catch (Exception e)
            {
                Console.WriteLine("Error Message {0}", e.Message);
            }
            Console.WriteLine("End System Configuration. Press enter to finish");
            Console.ReadLine();
        }

        public static void FirstTimeConfiguration(UsersContext ctx)
        {
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
            LoadFunctions(ctx);
            AddFunctionsToUsers(ctx, root);
        }

        private static void LoadFunctions(UsersContext ctx)
        {
             var manageAdminAccount = new Function()
                {
                    Name = "Manage_Admin_Account",
                    ResourceName = "Manager Admin Account",
                    Controller = "User",
                    Action = "IndexAdmin"// "Index"
                };

             var manageUsers = new Function()
             {
                 Name = "Manage_Users",
                 ResourceName = "Manage User Account",
                 Controller = "User",
                 Action = "IndexUser"
             };

             var manageUserGroup = new Function()
             {
                 Name = "Manager_Usergroups",
                 ResourceName = "Manage User Groups",
                 Controller = "UserGroup",
                 Action = "Index"
             };

            ctx.Functions.Add(manageAdminAccount);
            ctx.Functions.Add(manageUsers);

            ctx.Functions.Add(manageUserGroup);

            functions.Add(manageAdminAccount);
            functions.Add(manageUsers);
            functions.Add(manageUserGroup);

            var adminTemplate = new Template(){ Name = "Admin" };

            adminTemplate.Functions = new Collection<Function>();
            adminTemplate.Functions.Add(manageAdminAccount);
            adminTemplate.Functions.Add(manageUsers);
            ctx.Templates.Add(adminTemplate);

            var userTemplate = new Template() { Name = "User" };

            ctx.Templates.Add(userTemplate);

            ctx.SaveChanges();
        }

        private static void AddFunctionsToUsers(UsersContext ctx, UserProfile userProfile)
        {
            foreach (var function in functions)
            {
                var userFunc = new UserFunction()
                    {
                        UserProfile = userProfile,
                        Function = function
                    };
                ctx.UserFunctions.Add(userFunc);
            }
            ctx.SaveChanges();
        }

    }
}
