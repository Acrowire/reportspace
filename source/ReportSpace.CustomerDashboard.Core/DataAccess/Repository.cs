using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public class Repository<T> : IDisposable, IRepository<T> where T : BaseObject
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

        public T Retrieve(Guid id)
        {
            var obj = _dataSet.Find(id);
            return obj;
        }

        public T Retrieve(Func<T, bool> func )
        {
            T obj = _dataSet.FirstOrDefault(func);
            return obj;
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

        public T Update(T data) 
        {
            /*var original = _dataSet.Find(data.Active);
            if (original != null)
            {
                _context.Entry(original).CurrentValues.SetValues(data);
                _context.SaveChanges();
            }*/

            _dataSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return data;
        }

        public IEnumerable<T> GetAll()
        {
            return _dataSet.ToList();
        }

        public IEnumerable<T> GetAll(Func<T, bool> filter )
        {
            return _dataSet.Where(filter);
        }

        public bool Exists(Func<T, bool> func)
        {
            T obj = _dataSet.FirstOrDefault(func);
            return obj!=null;
        }

        public void Dispose()
        {
            //_context.SaveChanges();
            _context.Dispose();
        }
    }
}
