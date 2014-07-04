using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.DataAccess;
using ReportSpace.CustomerDashboard.Core.Models;

namespace SystemConfigurator
{
    public static class CustomClassLoader
    {
        [ImportMany(typeof(IDataObject))]
        public static IEnumerable<Lazy<IDataObject, IDictionary<string, object>>> _dataObjects;

        public static void LoadRepositories()
        {
            try
            {
                string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)?? @"c:\\";
                AggregateCatalog catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()), new DirectoryCatalog(location));
                var container = new CompositionContainer(catalog);
                container.ComposeParts();
                _dataObjects = container.GetExports<IDataObject, IDictionary<string, object>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Repository<T> GetRepository<T>() where T : BaseObject
        {
            var list1 =_dataObjects.ToList();
            int count = list1.Count;
            String name = typeof (T).Name;
            //var list = _dataObjects.Where(s => (s.Value.GetType()) == typeof(T));
            var list = _dataObjects.Where(s => s.Metadata["BaseObjectName"].Equals(name));
            if (list.Any())
            {
                return new Repository<T>(new UsersContext());
            }
            throw new KeyNotFoundException("The type [" + (typeof(T) + "] could not be found"));
        }
    }
}
