using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using ReportSpace.CustomerDashboard.Web.ReportingService2010;

namespace ReportSpace.CustomerDashboard.Web.Controllers.Core
{
    public class SSRSContext
    {
        #region [ Static / Cache Items ]
        public static Dictionary<String, ReportingService2010.CatalogItem[]> CatalogCache = new Dictionary<string, ReportingService2010.CatalogItem[]>();
        #endregion

        #region [ Fields ]
        private bool m_authenticated = false;
        private ReportingService2010.ReportingService2010 m_client = new ReportingService2010.ReportingService2010();
        #endregion

        #region [ Constructors ]
        public SSRSContext()
        {
            this.m_authenticated = this.Authenticate();
        }
        #endregion

        #region [ Properties ] 
        public ReportingService2010.ReportingService2010 client
        {
            get
            {
                this.Authenticate();
                return this.m_client;
            }
        }
        #endregion

        #region [ Actions ] 
        #endregion

        #region [ Local ]
        private bool Authenticate()
        {
            bool result = false;
            if (this.m_client != null) this.m_client = new ReportingService2010.ReportingService2010();
            
            try
            {
                // Basic 
                string username = ConfigurationManager.AppSettings["ssrs.username"];
                string password = ConfigurationManager.AppSettings["ssrs.password"];
                string domain = ConfigurationManager.AppSettings["ssrs.domain"];

                this.m_client.Credentials = new System.Net.NetworkCredential(username, password, domain);

                this.m_client.Url = ConfigurationManager.AppSettings["ReportServerUrl"];

                result = true;
            }
            catch (Exception x)
            {
                result = false;
                throw x;
            }

            return result;
        }

        public CataLogViewModel GetCatalog(string path = "/")
        {
            var vm = new CataLogViewModel();
            vm.Path = path;

            #region [ Resource Plugins ] 
            try
            {
                ReportingService2010.CatalogItem[] items = new ReportingService2010.CatalogItem[0];

                // Check Cache for Path
                this.m_client.Credentials = System.Net.CredentialCache.DefaultCredentials;
                items = this.m_client.ListChildren(path, false);


                foreach (var item in items)
                {
                    var vmItem = new CatalogItemViewModel();
                    vmItem.CreatedBy = item.CreatedBy;
                    vmItem.CreationDate = item.CreationDate;
                    vmItem.Description = item.Description;
                    vmItem.Name = item.Name;
                    vmItem.Path = item.Path;
                    vmItem.TypeName = item.TypeName;
                    vmItem.VirtualPath = item.VirtualPath;
                    vm.Items.Add(vmItem);
                }
            }
            catch (Exception x)
            {
                // Create a Basic Empty Catalog Item 
                var generic = new CatalogItemViewModel()
                {
                    CreatedBy = "Application",
                    CreationDate = DateTime.Now,
                    Description = "You currently have no resources!",
                    Name = "None",
                    Path = path,
                    TypeName = "/type",
                    VirtualPath = path
                };

                vm.Items.Add(generic);
            }
            #endregion

            return vm;
        }

        public bool CreateCatalog(String username)
        {
            // when a new User is Created, we need to automatically create the Folder in SSRS for them
            bool created = false;

            try
            {

                Property newProp = new Property();
                newProp.Name = "FolderType";
                newProp.Value = "User";
                Property[] props = new Property[1];
                props[0] = newProp;

                this.m_client.CreateFolder(username, "/", props);
                created = true;
            }
            catch (Exception x)
            {
                throw x;
            }

            return created;
        }

        public void AddReport()
        {
            
        }
        #endregion
    }

    public class CataLogViewModel
    {
        public List<CatalogItemViewModel> Items { get; set; }
        public String Path { get; set; }

        public CataLogViewModel()
        {
            this.Items = new List<CatalogItemViewModel>();
        }
    }

    public class CatalogItemViewModel
    {

        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string TypeName { get; set; }

        public string VirtualPath { get; set; }
    }
}