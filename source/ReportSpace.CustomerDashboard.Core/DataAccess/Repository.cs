using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public class Repository<T> where T : BaseObject
    {
        private IDbSet<T> _dataSet;
        private DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Create(T data)
        {
            data.Created = DateTime.Now;
            data.Updated = DateTime.Now;
            data.Active = true;
            var obj =  _dataSet.Add(data);

            SaveChanges();
            return obj;
        }

        public bool Exists(Func<T, bool> func)
        {
            T obj = _dataSet.FirstOrDefault(func);
            return obj!=null;
        }

    }
}
