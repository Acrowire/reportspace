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

        public bool UserExists(String username)
        {
            return _repository.Exists(x => x.UserName == username); ;
        }
    }
}
