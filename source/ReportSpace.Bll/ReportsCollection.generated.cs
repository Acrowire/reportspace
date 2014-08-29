namespace ReportSpace.Bll
{
    using System.Collections.ObjectModel;

    public partial class ReportsCollection : Collection<Reports>
    {
        public static ReportsCollection GetAll()
        {
            ReportSpace.Dal.Reports dbo = null;
            try
            {
                dbo = new ReportSpace.Dal.Reports();
                System.Data.DataSet ds = dbo.Reports_Select_All();
                ReportsCollection collection = new ReportsCollection();
                if (GlobalTools.IsSafeDataSet(ds))
                {
                    for (int i = 0; (i < ds.Tables[0].Rows.Count); i = (i + 1))
                    {
                        Reports obj = new Reports();
                        obj.Fill(ds.Tables[0].Rows[i]);
                        if ((obj != null))
                        {
                            collection.Add(obj);
                        }
                    }
                }
                return collection;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                if ((dbo != null))
                {
                    dbo.Dispose();
                }
            }
        }
        
    }
}
