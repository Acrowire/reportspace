using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public class RepositoryFactory
    {
        [ImportMany(typeof(IDataObject))]
        public static IEnumerable<Lazy<IDataObject, IDictionary<string, object>>> _dataObjects;
        //private static readonly Dictionary<Type, Func<object>> Dictionary = new Dictionary<Type, Func<object>>();

        public static void LoadRepositories()
        {
            try
            {
                string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? @"c:\\";
                var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly()),
                    new DirectoryCatalog(location));
                var container = new CompositionContainer(catalog);
                container.ComposeParts();
                _dataObjects = container.GetExports<IDataObject, IDictionary<string, object>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Func<object> f = () => new Repository<UserProfile>(new UsersContext());
            /*Dictionary.Add(typeof(UserProfile), () => new Repository<UserProfile>(new UsersContext()));
            Dictionary.Add(typeof(UserFunction), () => new Repository<UserFunction>(new UsersContext()));
            Dictionary.Add(typeof(Function), () => new Repository<Function>(new UsersContext()));
            Dictionary.Add(typeof(Template), () => new Repository<Template>(new UsersContext()));*/
        }

        public static Repository<T> GetRepository<T>() where T : BaseObject
        {
            String name = typeof(T).Name;
            var list = _dataObjects.Where(s => s.Metadata["BaseObjectName"].Equals(name));
            if (list.Any())
            {
                return new Repository<T>(new UsersContext());
            }
            throw new KeyNotFoundException("The type [" + (typeof(T) + "] could not be found"));

            /*if (Dictionary.ContainsKey(typeof(T)))
            {
                Func<object> function = Dictionary[typeof (T)];
                return function() as Repository<T>;
            }*/
        }
    }
}
