using System.Web;

namespace ReportSpace.CustomDashboard.Common
{
    public class AppContext
    {
        private static InstanceContext _instanceContext = new InstanceContext();

        public static InstanceContext Context
        {
            get { return _instanceContext; }
        }

      
    }

    public class InstanceContext
    {
        private HttpContext _context;

        public object DbContext
        {
            get
            {
                return _context.Items["UserContext"];
            }
            set
            {
                _context.Items["UserContext"] = value;
            }
        }

        public HttpContext HttpContext {
            get { return _context; }
            set { _context = value; }
        }
    }

}
