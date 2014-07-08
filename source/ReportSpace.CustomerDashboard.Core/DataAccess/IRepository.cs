using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public interface IRepository<T>
    {
        void SaveChanges();

        T Retrieve(Guid id);

        T Retrieve(Func<T, bool> function );

        T Create(T data);

        T Update(T data);
        
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Func<T, bool> filter);

        bool Exists(Func<T, bool> func);

    }
}
