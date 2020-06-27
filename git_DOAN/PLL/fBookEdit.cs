using DA_CNPM.BLL;
using DA_CNPM.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNPM
{
    public partial class fBookEdit : Form
    {
        public fBookEdit()
        {
            InitializeComponent();
        }
        public fBookEdit(BOOK book)
        {
            InitializeComponent();
            tb_book_id.Text = book.ID_BOOK.ToString();
            tb_book_title.Text = book.TITLE;
            tb_book_category_id.Text = book.ID_CATEGORY.ToString();
            tb_book_author.Text = book.AUTHOR;
            tb_book_publish.Text = book.PUBLISH_YEAR.ToString();
            rtb_book_pdf.Text = book.PDF_LINK;
            tb_book_overview.Text = book.OVERVIEW;
            byte[] img = book.COVER;
            MemoryStream byteimg = new MemoryStream(img);
            Image image = new Bitmap(byteimg);
            pb_book_cover.Image = image;
        }

        private void btn_book_cover_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb_book_cover.Image = new Bitmap(ofd.FileName);
            }
        }

        private void btn_book_edit_confirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thêm sách?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {

                if (String.IsNullOrEmpty(tb_book_title.Text) || String.IsNullOrEmpty(tb_book_category_id.Text) || String.IsNullOrEmpty(tb_book_author.Text)
                    && String.IsNullOrEmpty(tb_book_publish.Text) || String.IsNullOrEmpty(rtb_book_pdf.Text) || String.IsNullOrEmpty(tb_book_overview.Text) || pb_book_cover.Image == null)
                {
                    MessageBox.Show("Dữ liệu nhập chưa đúng hoặc chưa đầy đủ!");
                    return;
                }
                BOOK booktemp = new BOOK();
                booktemp.ID_BOOK = Convert.ToInt32(tb_book_id.Text);
                booktemp.TITLE = tb_book_title.Text;
                booktemp.ID_CATEGORY = Convert.ToInt32(tb_book_category_id.Text);
                booktemp.AUTHOR = tb_book_author.Text;
                booktemp.PUBLISH_YEAR = tb_book_publish.Text;
                booktemp.PDF_LINK = rtb_book_pdf.Text;
                booktemp.OVERVIEW = tb_book_overview.Text;
                MemoryStream ms = new MemoryStream();
                pb_book_cover.Image.Save(ms, pb_book_cover.Image.RawFormat);
                booktemp.COVER = ms.ToArray();
                //BookBLL.Instance.LoadBOOKList().Add(booktemp);
                //BookBLL.Instance.bookList.Add(booktemp);
                BookBLL.Instance.eSaveChanges_Update(booktemp);
                fBookAdd.ActiveForm.Dispose();
                //this.Close();
            }
        }
    }
}
