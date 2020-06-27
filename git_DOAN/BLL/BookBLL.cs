using DA_CNPM.DAL;
using DA_CNPM.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.BLL
{
    class BookBLL
    {
        private static BookBLL instance;
        public static BookBLL Instance
        {
            get { if (instance == null) instance = new BookBLL(); return instance; }
            private set { instance = value; }
        }
        public List<BOOK> bookList { get; set; }
        public void LoadbookList()
        {
            //bookList = LoadBOOKList();
            bookList = BookDAL.Instance.LoadBOOKList();
        }
        /*public List<Book> LoadBookList()
        {
            return BookDAL.Instance.LoadBookList();
        }*/
     /*   public List<BOOK> LoadBOOKList()
        {
            return BookDAL.Instance.LoadBOOKList();
        }*/
        public void eSaveChanges_Add(BOOK book)
        {
            BookDAL.Instance.eSaveChanges_Add(book);
        }
        public void eSaveChanges_Update(BOOK book)
        {
            BookDAL.Instance.eSaveChanges_Update(book);
        }
        public void eSaveChanges_Delete(BOOK book)
        {
            BookDAL.Instance.eSaveChanges_Delete(book);
        }
    }
}
