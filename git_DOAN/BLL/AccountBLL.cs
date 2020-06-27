using DA_CNPM.DAL;
using DA_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.BLL
{
    class AccountBLL
    {
        private static AccountBLL instance;
        public static AccountBLL Instance
        {
            get { if (instance == null) instance = new AccountBLL(); return instance; }
            private set { instance = value; }
        }
        private AccountBLL() { }
        public List<Account> LoadAccountList()
        {
            return AccountDAL.Instance.LoadAccountList();
        }
        public List<ACCOUNT> LoadACCOUNTList()
        {
            return AccountDAL.Instance.LoadACCOUNTList();
        }
        public bool Login_Admin(string username, string password)
        {
            return AccountDAL.Instance.Login_Admin(username, password);
        }
        public bool Login_User(string username, string password)
        {
            return AccountDAL.Instance.Login_User(username, password);
        }
    }
}
