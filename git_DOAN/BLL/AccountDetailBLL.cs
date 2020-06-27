using DA_CNPM.DAL;
using DA_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.BLL
{
    public class AccountDetailBLL
    {
        private static AccountDetailBLL instance;
        public static AccountDetailBLL Instance
        {
            get { if (instance == null) instance = new AccountDetailBLL(); return instance; }
            private set { instance = value; }
        }
        private AccountDetailBLL() { }
        public List<AccountDetail> LoadAccountDetailList()
        {
            return AccountDetailDAL.Instance.LoadAccountDetailList();
        }
        public List<ACCOUNT_DETAIL> LoadACCOUNTDETAILList()
        {
            return AccountDetailDAL.Instance.LoadACCOUNTDETAILList();
        }
    }
}
