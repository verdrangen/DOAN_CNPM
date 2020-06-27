using DA_CNPM.DAL;
using DA_CNPM.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.BLL
{
    class SupportBLL
    {
        private static SupportBLL instance;
        public static SupportBLL Instance
        {
            get { if (instance == null) instance = new SupportBLL(); return instance; }
            private set { instance = value; }
        }
        private SupportBLL() { }
        public List<Support> LoadSupportList()
        {
            return SupportDAL.Instance.LoadSupportList();
        }
        public List<SUPPORT> LoadSUPPORTList()
        {
            return SupportDAL.Instance.LoadSUPPORTList();
        }
    }
}
