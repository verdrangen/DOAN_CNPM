using DA_CNPM.BLL;
using DA_CNPM.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNPM
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            EntityBLL.Instance.LoadEntity_DB();
        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text;
            string password = txbPassword.Text;
            if (Login_Admin(username, password))
            {
                fManagement f = new fManagement();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if (Login_User(username, password))
            {
                //form cua nguoi dung
                return;
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        public bool Login_Admin(string username, string password)
        {
            //string query = "USP_Login @userName , @password";
            //DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return AccountBLL.Instance.Login_Admin(username, password);
        }
        public bool Login_User(string username, string password)
        {
            //string query = "USP_Login @userName , @password";
            //DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return AccountBLL.Instance.Login_User(username, password);
        }
    }
}
