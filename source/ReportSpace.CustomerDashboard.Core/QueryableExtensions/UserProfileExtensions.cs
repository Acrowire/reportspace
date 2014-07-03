using System;

namespace ReportSpace.CustomerDashboard.Core.QueryableExtensions
{
    using System.Data.Entity;
    using System.Linq;

    using ReportSpace.CustomerDashboard.Core.Models;

    public static class UserProfileExtensions
    {
        public static UserProfile FindById(this IQueryable<UserProfile> query, Guid id)
        {
            return query.First(up => up.Id == id);
        }
    }
}