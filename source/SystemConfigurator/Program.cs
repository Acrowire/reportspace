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
             var createAdminAccount = new Function()
                {
                    Name = "Create_Admin_Account",
                    ResourceName = "Create Admin Account",
                    Controller = "AdminAccount",
                    Action = "index"
                };

             var createUserGroup = new Function()
             {
                 Name = "Create_User_Group",
                 ResourceName = "Create User Group",
                 Controller = "UserGroup",
                 Action = "index"
             };

            ctx.Functions.Add(createAdminAccount);
            ctx.Functions.Add(createUserGroup);

            functions.Add(createAdminAccount);
            functions.Add(createUserGroup);

            var adminTemplate = new Template(){ Name = "Admin" };

            adminTemplate.Functions = new Collection<Function>();
            adminTemplate.Functions.Add(createAdminAccount);
            adminTemplate.Functions.Add(createUserGroup);
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
