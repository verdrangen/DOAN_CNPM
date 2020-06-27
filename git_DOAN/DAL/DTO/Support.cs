using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.DAL.DTO
{
    class Support
    {
        int ID_SUPPORT;
        int ID_USER;
        string FEEDBACK;
        DateTime DATE;
        Support() { }
        public Support(DataRow row)
        {
            this._ID_SUPPORT = (int)row["ID_SUPPORT"];
            this._ID_USER = (int)row["ID_ACCOUNT"];
            this._FEEDBACK = row["FEEDBACK"].ToString();
            this.Date = (DateTime)row["POST_DATE"];
        }
        Support(int id_sup, int id_user, string feedback, DateTime date)
        {
            this.ID_SUPPORT = id_sup;
            this.ID_USER = id_user;
            this.FEEDBACK = feedback;
            this.Date = date;
        }
        public int _ID_SUPPORT
        {
            set { ID_SUPPORT = value; }
            get { return ID_SUPPORT; }
        }
        public int _ID_USER
        {
            set { ID_USER = value; }
            get { return ID_USER; }
        }
        public string _FEEDBACK
        {
            set { FEEDBACK = value; }
            get { return FEEDBACK; }
        }

        public DateTime Date { get => DATE; set => DATE = value; }
    }
}
