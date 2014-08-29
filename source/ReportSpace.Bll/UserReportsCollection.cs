using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.Bll
{
    public partial class UserreportsCollection : Collection<Userreports>
    {
        public static ConcurrentDictionary<Int32, Userreports> Cache = new ConcurrentDictionary<int, Userreports>();

        public static Bll.UserreportsCollection GetAll()
        {
            var results = new Bll.UserreportsCollection();

            var list = Bll.Userreports.GetAll();

            foreach (var item in list)
            {
                if (UserreportsCollection.Cache.ContainsKey(item.Id.Value) == false)
                {
                    item.Reports = Bll.Reports.Load(item.ReportId);
                    item.Users = Bll.Users.Load(item.UserId);
                    Cache.TryAdd(item.Id.Value, item);
                }
                results.Add(UserreportsCollection.Cache[item.Id.Value]);
            }
            return results;
        }
    }
}
