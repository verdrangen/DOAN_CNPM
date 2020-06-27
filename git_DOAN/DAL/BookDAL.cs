using DA_CNPM.BLL;
using DA_CNPM.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.DAL
{
    class BookDAL
    {
        private static BookDAL instance;
        public static BookDAL Instance
        {
            get { if (instance == null) instance = new BookDAL(); return instance; }
            private set { instance = value; }
        }
        private BookDAL() { }
     /*   public List<Book> LoadBookList()
        {
            List<Book> bookList = new List<Book>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetBookList");
            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                bookList.Add(book);
            }
            return bookList;
        }*/
        public List<BOOK> LoadBOOKList()
        {
            //DOAN_CNPMEntities db = new DOAN_CNPMEntities();
            var bookList = DataProvider.Instance.Entity_DB.BOOKs.Select(p => p).ToList();
            return bookList;
        }
        public void eSaveChanges_Add(BOOK book)
        {
            //DataProvider.Instance.Entity_DB.BOOKs.AddRange(BookBLL.Instance.bookList);
            /*foreach( BOOK book in DataProvider.Instance.Entity_DB.BOOKs)
            {
                foreach (BOOK Book in BookBLL.Instance.bookList)
                {
                    if (book.TITLE != Book.TITLE)
                    {
                        DataProvider.Instance.Entity_DB.BOOKs.Add(Book);
                    }
                }
            }*/
            //DataProvider.Instance.Entity_DB.Entry(bookList).State = System.Data.Entity.EntityState.Modified;
            /* foreach (BOOK item in bookList)
             {
                 DataProvider.Instance.Entity_DB.Entry(item).State = System.Data.Entity.EntityState.Added;
             }*/
            //DataProvider.Instance.Entity_DB.Entry(BookDAL.Instance.LoadBOOKList()).CurrentValues.SetValues(bookList);
            //List<DataProvider.Instance.Entity_DB.BOOKs> BOOKLIST = new List<DataProvider.Instance.Entity_DB.BOOKs>();
            /*foreach (BOOK item in bookList)
            {
                DataProvider.Instance.Entity_DB.BOOKs.Attach(item);
                var entry = DataProvider.Instance.Entity_DB.Entry(item);
                entry.Property
            }*/
            DataProvider.Instance.Entity_DB.BOOKs.Add(book);
            //DataProvider.Instance.Entity_DB.Entry(book).State = System.Data.Entity.EntityState.Added;
            DataProvider.Instance.Entity_DB.SaveChanges();
        }
        public void eSaveChanges_Update(BOOK book)
        {
            BOOK tmp = DataProvider.Instance.Entity_DB.BOOKs.Find(book.ID_BOOK);
            tmp.TITLE = book.TITLE;
            tmp.AUTHOR = book.AUTHOR;
            tmp.CATEGORY = book.CATEGORY;
            tmp.PUBLISH_YEAR = book.PUBLISH_YEAR;
            tmp.PDF_LINK = book.PDF_LINK;
            tmp.OVERVIEW = book.OVERVIEW;
            tmp.COVER = book.COVER;
            DataProvider.Instance.Entity_DB.SaveChanges();
        }
        public void eSaveChanges_Delete(BOOK book)
        {
            //BOOK tmp = DataProvider.Instance.Entity_DB.BOOKs.Where(p => p.ID_BOOK == id).SingleOrDefault();
            //DataProvider.Instance.Entity_DB.Entry(book).State = System.Data.Entity.EntityState.Modified;
            /* var tmp = new BOOK() { ID_BOOK = book.ID_BOOK, TITLE = book.TITLE, CATEGORY = book.CATEGORY,
                                     AUTHOR = book.AUTHOR, PUBLISH_YEAR = book.PUBLISH_YEAR, PDF_LINK = book.PDF_LINK,
                                     OVERVIEW = book.OVERVIEW, COVER = book.COVER};*/
            //BOOK tmp = new BOOK() { ID_BOOK = book.ID_BOOK };
            var tmp = DataProvider.Instance.Entity_DB.BOOKs.Find(book.ID_BOOK);
            if (tmp == null)
            {
                DataProvider.Instance.Entity_DB.BOOKs.Add(tmp);
                return;
            }
            //bool oldValidateOnSaveEnabled = DataProvider.Instance.Entity_DB.Configuration.ValidateOnSaveEnabled;
            //try
            //{
            //    DataProvider.Instance.Entity_DB.Configuration.ValidateOnSaveEnabled = false;

            //DataProvider.Instance.Entity_DB.BOOKs.Attach(tmp);
            //if (DataProvider.Instance.Entity_DB.BOOKs.Contains(tmp))
            //{
            //DataProvider.Instance.Entity_DB.BOOKs.Attach(tmp);
            //}
            //DataProvider.Instance.Entity_DB.BOOKs.Remove(tmp);
            DataProvider.Instance.Entity_DB.Entry(tmp).CurrentValues.SetValues(book);
                DataProvider.Instance.Entity_DB.Entry(tmp).State = System.Data.Entity.EntityState.Deleted;
                DataProvider.Instance.Entity_DB.SaveChanges();
            //}
            //finally
            //{
            //    DataProvider.Instance.Entity_DB.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
            //}
        }
    }
}
