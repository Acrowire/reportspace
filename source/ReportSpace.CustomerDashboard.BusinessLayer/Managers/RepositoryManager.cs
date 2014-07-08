using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.BusinessLayer.Context;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.BusinessLayer.Managers
{
    public class RepositoryManager : IDisposable
    {

        public T Retrieve<T>(Func<T, bool> func ) where T : BaseObject
        {
            var repository = RepositoryFactory.GetRepository<T>();
            T t = repository.Retrieve(func);
            return t;
        }


        public T Retrieve<T>(Guid id) where T : BaseObject
        {
            var repository = RepositoryFactory.GetRepository<T>();
            T t = repository.Retrieve(id);
            return t;
        }

        public T Create<T>(T data) where T : BaseObject
        {
            var repository = RepositoryFactory.GetRepository<T>();
            return repository.Create(data);
        }

        public T Update<T>(T data) where T : BaseObject
        {
            var repository = RepositoryFactory.GetRepository<T>();
            return repository.Update(data);
        }

        public IEnumerable<T> GetAll<T>() where T : BaseObject
        {
            var repository = RepositoryFactory.GetRepository<T>();
            return repository.GetAll();
        }

        public IEnumerable<T> GetAll<T>(Func<T, bool> filter ) where T : BaseObject
        {
            var repository = RepositoryFactory.GetRepository<T>();
            return repository.GetAll(filter);
        }


        public void Dispose()
        {
            
        }
    }
}
