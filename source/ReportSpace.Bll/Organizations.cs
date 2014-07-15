namespace ReportSpace.Bll {
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    
    public partial class Organizations
    {
        #region [ Static Cache ]
        public static ConcurrentDictionary<Guid, Bll.Organizations> Cache = new ConcurrentDictionary<Guid, Organizations>();
        #endregion

        #region [ Searches ]
        public static Organizations GetById(Guid PublicId)
        {
            Organizations org = new Organizations();

            if (Organizations.Cache.ContainsKey(PublicId) == false)
            {
                org = Bll.Organizations.GetAll()
                                       .Where(o => o.Active == true)
                                       .Where(o => o.Publicid.Value == PublicId)
                                       .First();

                Organizations.Cache.TryAdd(PublicId, org);
            }

            org = Organizations.Cache[PublicId];

            return org;
        }

        public static bool Exists(String Name)
        {
            bool exists = false;

            exists = Bll.Organizations.GetAll()
                                      .Where(o => o.Name.ToLower() == Name.ToLower())
                                      .Any();

            return exists;
        }
        #endregion
    }
}
