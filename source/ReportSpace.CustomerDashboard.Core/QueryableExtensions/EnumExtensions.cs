using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSpace.CustomerDashboard.Core.Models;

namespace ReportSpace.CustomerDashboard.Core.QueryableExtensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> ToEnumList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
