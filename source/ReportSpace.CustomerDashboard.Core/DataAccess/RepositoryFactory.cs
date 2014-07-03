using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.BusinessLayer.Context
{
    public static class RepositoryFactory
    {
        private static readonly Dictionary<Type, Func<object>> Dictionary = new Dictionary<Type, Func<object>>();

        public static void LoadRepositories()
        {
            //Func<object> f = () => new Repository<UserProfile>(new UsersContext());
            Dictionary.Add(typeof(UserProfile), () => new Repository<UserProfile>(new UsersContext()));
            Dictionary.Add(typeof(UserFunction), () => new Repository<UserFunction>(new UsersContext()));
            Dictionary.Add(typeof(Function), () => new Repository<Function>(new UsersContext()));
            Dictionary.Add(typeof(Template), () => new Repository<Template>(new UsersContext()));
        }

        public static Repository<T> GetRepository<T>() where T : BaseObject
        {
            if (Dictionary.ContainsKey(typeof(T)))
            {
                Func<object> function = Dictionary[typeof (T)];
                return function() as Repository<T>;
            }
            throw new KeyNotFoundException("The type [" + (typeof(T) + "] could not be found" ));
        }

    }
}
