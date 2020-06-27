using DA_CNPM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNPM.DAO
{
    class AccountDAL
    {
        private static AccountDAL instance;
        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set { instance = value; }
        }
        private AccountDAL() { }
        public bool Login_Admin(string username, string password)
        {
            //string query = "USP_Login @userName , @passWord , @groupID";
            //DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password, "001" });
            //return result.Rows.Count > 0;
            try
            {
                using (var context = new DOAN_CNPMEntities())
                {
                    var account = context.USP_Login(username, password, "001").ToList();
                    if (account.Any()) return true;
                    else return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
                return false;
            }
           
        }
        public bool Login_User(string username, string password)
        {
            DOAN_CNPMEntities db = DataProvider.Instance.Entity_DB;
            /*string query = "USP_Login @userName , @passWord , @groupID";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password, "002" });
            return result.Rows.Count > 0;*/
            try
            {
                using (var context = new DOAN_CNPMEntities())
                {
                    var account = context.USP_Login(username, password, "002").ToList();
                    if (account.Any()) return true;
                    else return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu");
                return false;
            }
        }
        public List<Account> LoadAccountList()
        {
            List<Account> accountList = new List<Account>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetAccountList");
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                accountList.Add(account);
            }
            return accountList;
        }
        public List<ACCOUNT> LoadACCOUNTList()
        {
            //DOAN_CNPMEntities db = new DOAN_CNPMEntities();
            var accountList = DataProvider.Instance.Entity_DB.ACCOUNTs.Select(p => p).ToList();
            //var accountList = db.ACCOUNTs.Select(p => p).ToList();
            return accountList;
        }
    }
}
