using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DA_CNPM
{
    public class Account
    {
        string USER_NAME;
        string PASSWORD;
        string group_ID;
        public Account() { }
        public Account(string user_name, string pass, string group)
        {
            this.USER_NAME = user_name;
            this.PASSWORD = pass;
            this.Group_ID = group;
        }
        public Account(DataRow row)
        {
            this._USER_NAME = row["USER_NAME"].ToString();
            this._PASSWORD = row["PASSWORD"].ToString();
            this.Group_ID = row["GROUP_ID"].ToString();
        }
        public string _USER_NAME
        {
            set { USER_NAME = value; }
            get { return USER_NAME; }
        }
        public string _PASSWORD
        {
            set { PASSWORD = value; }
            get { return PASSWORD; }
        }

        public string Group_ID { get => group_ID; set => group_ID = value; }
    }
}
