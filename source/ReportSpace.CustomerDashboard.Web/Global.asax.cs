using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ReportSpace.CustomDashboard.Common;
using ReportSpace.CustomerDashboard.Core.DataAccess;

namespace ReportSpace.CustomerDashboard.Web
{
    using ReportSpace.CustomerDashboard.Web.App_Start;

    public class MvcApplication : HttpApplication
    {
        #region [ Constructors ]
        public MvcApplication()
            : base()
        {

        }
        #endregion



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DataBaseConfig.RegisterDatabase();
            AuthConfig.RegisterAuth();
            MappingConfig.RegisterMaps();
        }

        protected void Application_BeginRequest()
        {
            AppContext.Context.HttpContext = HttpContext.Current;
            AppContext.Context.DbContext = new UsersContext();
        }

        protected void Application_EndRequest()
        {
            var ctx = AppContext.Context.DbContext as UsersContext;
            if (ctx != null)
            {
                ctx.SaveChanges();
                ctx.Dispose();
            }
        }
    }
}