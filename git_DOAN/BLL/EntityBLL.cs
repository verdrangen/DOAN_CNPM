using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.BLL
{
    public class EntityBLL
    {
        private static EntityBLL instance;
        public static EntityBLL Instance
        {
            get { if (instance == null) instance = new EntityBLL(); return instance; }
            private set { instance = value; }
        }
        private EntityBLL() { }
        public void LoadEntity_DB()
        {
            DataProvider.Instance.LoadEntity_DB();
        }
        public void eSaveChanges()
        {
            DataProvider.Instance.eSaveChange();
        }
    }
}
