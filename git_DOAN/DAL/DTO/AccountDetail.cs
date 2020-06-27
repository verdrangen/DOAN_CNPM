using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DA_CNPM
{
    public class AccountDetail
    {
        int ID_USER;
        string USER_NAME;
        string PHONENUMBER;
        DateTime DOB;
        string GENDER;
        string EMAIL;
        public AccountDetail() { }
        public AccountDetail(DataRow row)
        {
            this._ID_USER = (int)row["ID_ACCOUNT"];
            this._USER_NAME = row["USER_NAME"].ToString();
            this._PHONENUMBER = row["PHONENUMBER"].ToString();
            this._DOB = (DateTime)row["D.O.B"];
            this._GENDER = row["GENDER"].ToString();
            this._EMAIL = row["EMAIL"].ToString();
        }
        public AccountDetail(int id_user, string user_name, string phonenumber, DateTime dob, string gender, string email)
        {
            this.ID_USER = id_user;
            this.USER_NAME = user_name;
            this.PHONENUMBER = phonenumber;
            this.DOB = dob;
            this.GENDER = gender;
            this.EMAIL = email;
        }
        public int _ID_USER
        {
            set { ID_USER = value; }
            get { return ID_USER; }
        }
        public string _USER_NAME
        {
            set { USER_NAME = value; }
            get { return USER_NAME; }
        }
        public string _PHONENUMBER
        {
            set { PHONENUMBER = value; }
            get { return PHONENUMBER; }
        }
        public DateTime _DOB
        {
            set { DOB = value; }
            get { return DOB; }
        }
        public string _GENDER
        {
            set { GENDER = value; }
            get { return GENDER; }
        }
        public string _EMAIL
        {
            set { EMAIL = value; }
            get { return EMAIL; }
        }
    }
}
