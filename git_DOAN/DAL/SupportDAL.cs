using DA_CNPM.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.DAL
{
    class SupportDAL
    {
        private static SupportDAL instance;
        public static SupportDAL Instance
        {
            get { if (instance == null) instance = new SupportDAL(); return instance; }
            private set { instance = value; }
        }
        private SupportDAL() { }
        public List<Support> LoadSupportList()

        {
            List<Support> supportList = new List<Support>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetSupportList");
            foreach (DataRow item in data.Rows)
            {
                Support sp = new Support(item);
                supportList.Add(sp);
            }
            return supportList;
        }
        public List<SUPPORT> LoadSUPPORTList()
        {
            //DOAN_CNPMEntities db = new DOAN_CNPMEntities();
            var supportList = DataProvider.Instance.Entity_DB.SUPPORTs.Select(p => p).ToList();
            return supportList;
        }

    }
}
