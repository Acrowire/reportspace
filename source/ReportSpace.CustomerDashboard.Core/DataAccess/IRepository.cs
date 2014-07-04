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

        bool Exists(Func<T, bool> func);

    }
}
