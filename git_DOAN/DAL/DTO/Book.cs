using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_CNPM.DAL.DTO
{
    public class Book
    {
        int iD_book;
        string title;
        string author;
        int iD_cate;
        string publish_year;
        string pDF_Link;
        byte[] cover;
        string overview;
        public Book() 
        {
            this.Title = "<Empty>";
            this.Author = "<Empty>";
            this.Publish_year = "<Empty>";
            this.PDF_Link = "<Empty>";
            this.Overview = "<Empty>";
        }
        public Book(DataRow row)
        {
            this.ID_book = (int)row["ID_BOOK"];
            this.Title = row["TITLE"].ToString();
            this.Author = row["AUTHOR"].ToString();
            this.ID_cate = (int)row["ID_CATEGORY"];
            this.Publish_year = row["PUBLISH_YEAR"].ToString();
            this.PDF_Link = row["PDF_LINK"].ToString();
            this.Overview = row["OVERVIEW"].ToString();
            this.Cover = (byte[])row["COVER"];
        }
        public Book(int id_book, string title, string author, int id_cate, string publish_year, string pdf_link, string overview, byte[] cover)
        {
            this.ID_book = id_book;
            this.Title = title;
            this.Author = author;
            this.ID_cate = id_cate;
            this.Publish_year = publish_year;
            this.PDF_Link = pdf_link;
            this.Overview = overview;
            this.Cover = cover;
        }

        public int ID_book { get => iD_book; set => iD_book = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int ID_cate { get => iD_cate; set => iD_cate = value; }
        public string Publish_year { get => publish_year; set => publish_year = value; }
        public string PDF_Link { get => pDF_Link; set => pDF_Link = value; }
        public byte[] Cover { get => cover; set => cover = value; }
        public string Overview { get => overview; set => overview = value; }
    }
}
