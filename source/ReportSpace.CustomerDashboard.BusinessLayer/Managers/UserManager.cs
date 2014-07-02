using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.BusinessLayer.Context;
using ReportSpace.CustomerDashboard.Core.Models;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace ReportSpace.CustomerDashboard.BusinessLayer.Managers
{
    public enum ValidationProtocol
    {
        DataBase,
        ActiveDirectory,
        LocalMachine,
    }


    public class UserManager
    {
        private readonly Repository<UserProfile> _repository = RepositoryFactory.GetRepository<UserProfile>();

        public bool ValidateDataBaseUser(string user, string password)
        {
            //TODO Validate password
            bool response = _repository.Exists(x => x.UserName == user);
            return response;
        }

        public bool ValidateExternalUser(string username, string password, ContextType contexttype, string contextName)
        {
            bool response = false;
            using (PrincipalContext context = new PrincipalContext(contexttype, contextName))
            {
                if (context.ValidateCredentials(username, password))
                {
                    if (!UserExists(username))
                    {   //create user
                        _repository.Create(new UserProfile()
                            { UserName = username, 
                              FirstName = "",
                              LastName = "",
                              Email = ""
                            });
                    }
                    response = true;
                }
            }
            return response;

        }
        public bool ValidateActiveDirectoryUser(string username, string password)
        {
            return ValidateExternalUser(username, password, ContextType.Domain, ConfigurationManager.AppSettings["security.domain_name"]);
        }

        public bool ValidateLocalMachineUser(string username, string password)
        {
            return ValidateExternalUser(username, password,ContextType.Machine, Environment.MachineName);
            
        }

        public bool ValidateUser(string username, string password, ValidationProtocol protocol)
        {
            switch (protocol)
            {
                case ValidationProtocol.ActiveDirectory:
                    ValidateActiveDirectoryUser(username, password);
                    break;
                case ValidationProtocol.DataBase:
                    ValidateDataBaseUser(username, password);
                    break;
                case ValidationProtocol.LocalMachine:
                    ValidateLocalMachineUser(username, password);
                    break;
            }
            return true;
        }

        public bool UserExists(String username)
        {
            return _repository.Exists(x => x.UserName == username); ;
        }
    }
}
