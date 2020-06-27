using DA_CNPM.BLL;
using DA_CNPM.DAL;
using DA_CNPM.DAL.DTO;
using DA_CNPM.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_CNPM
{
    public partial class fManagement : Form
    {
        public fManagement()
        {
            InitializeComponent();
            //LoadAccountListLV();
            BookBLL.Instance.LoadbookList();
            LoadACCOUNT_lv();
            //List<Book> bookList = BookBLL.Instance.LoadBookList();
            LoadBOOKListDTG();
        }
        //public static List<Book> bookList = BookBLL.Instance.LoadBookList();

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void fplTest_Paint(object sender, PaintEventArgs e)
        {
            /*Panel dynamicpanel = new Panel();
            dynamicpanel.Name = "Paneltest";
            dynamicpanel.Size = new System.Drawing.Size(100, 100);
            dynamicpanel.Visible = true;
            Button buttontest = new Button();
            buttontest.Name = "buttontest";
            buttontest.Text = "buttontesting";
            buttontest.Size = new System.Drawing.Size(20, 10);
            buttontest.Location = new Point(50, 50);
            buttontest.Visible = true;
            dynamicpanel.Controls.Add(buttontest);
            fplTest.Controls.Add(dynamicpanel);*/
        }

        private void pb_book_cover_Click(object sender, EventArgs e)
        {

        }

        private void btn_book_add_Click(object sender, EventArgs e)
        {
            fBookAdd f = new fBookAdd();
            f.ShowDialog();
            this.Show();
            if (f.IsDisposed)
            {
                lvBook.Items.Clear();
                BookBLL.Instance.LoadbookList();
                LoadBOOKListDTG();
            }
        }

        private void btn_book_update_Click(object sender, EventArgs e)
        {
            BOOK book = new BOOK();
            if (lvBook.SelectedItems.Count > 0)
            {
                foreach (BOOK item in BookBLL.Instance.bookList)
                {
                    if (item.ID_BOOK.ToString() == lvBook.SelectedItems[0].SubItems[0].Text)
                    {
                        book = item;
                        break;
                    }
                }
                fBookEdit f = new fBookEdit(book);
                f.ShowDialog();
                this.Show();
                if (f.IsDisposed)
                {
                    lvBook.Items.Clear();
                    BookBLL.Instance.LoadbookList();
                    LoadBOOKListDTG();
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn dữ liệu nào!");
        }

        private void btn_book_delete_Click(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa dữ liệu của sách đã chọn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BOOK book = new BOOK();
                    int id = Convert.ToInt32(lvBook.SelectedItems[0].SubItems[0].Text);
                    //MessageBox.Show(id.ToString());
                    foreach (BOOK item in BookBLL.Instance.bookList)
                    {
                        if (item.ID_BOOK.ToString() == lvBook.SelectedItems[0].SubItems[0].Text)
                        {
                            book = item;
                            break;
                        }
                    }
                    BookBLL.Instance.eSaveChanges_Delete(book);
                    lvBook.Items.Clear();
                    BookBLL.Instance.LoadbookList();
                    LoadBOOKListDTG();
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn dữ liệu nào!");
        }


        /*public void LoadAccountListLV()
        {
            List<ACCOUNT> accountList = AccountBLL.Instance.LoadACCOUNTList();
            foreach (ACCOUNT item in accountList)
            {
                string[] arr = new string[3];
                ListViewItem acc;
                arr[0] = item.USER_NAME;
                arr[1] = item.PASSWORD;
                if (item.Group_ID.Trim() == "001")
                {
                    arr[2] = "ADMIN";
                }
                else if (item.Group_ID.Trim() == "002")
                {
                    arr[2] = "USER";
                }
                //else arr[2] = item.Group_ID;
                //arr[2] = item.Group_ID;
                acc = new ListViewItem(arr);
                lvAccount.Items.Add(acc); 
            }
        }*/

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<AccountDetail> accountdetailList = AccountDetailBLL.Instance.LoadAccountDetailList();
            //List<Support> supportList = SupportBLL.Instance.LoadAccountList();
            if(lvAccount.SelectedItems.Count > 0)
            {
                foreach (ACCOUNT_DETAIL item in AccountDetailBLL.Instance.LoadACCOUNTDETAILList())
                {
                    if(lvAccount.SelectedItems[0].SubItems[0].Text == item.USER_NAME)
                    {
                        tb_user_id.Text = item.ID_ACCOUNT.ToString();
                        tb_user_name.Text = item.USER_NAME;
                        tb_user_phone.Text = item.PHONENUMBER;
                        tb_user_dob.Text = item.D_O_B.ToString();
                        tb_user_gender.Text = item.GENDER;
                        tb_user_email.Text = item.EMAIL;
                        foreach (SUPPORT support in SupportBLL.Instance.LoadSUPPORTList())
                        {
                            if (support.ID_ACCOUNT == item.ID_ACCOUNT)
                            {
                                TextBox tb_sp = new TextBox();
                                //tb_sp.Size = new System.Drawing.Size(Width = 200, Height = 100); // loi Form?
                                tb_sp.Width = 400;
                                tb_sp.Height = 50;
                                tb_sp.ScrollBars = ScrollBars.Vertical;
                                tb_sp.Multiline = true;
                                tb_sp.Text = support.POST_DATE.ToString();
                                string newline = Environment.NewLine;
                                tb_sp.Text += newline;
                                tb_sp.Text += support.FEEDBACK;
                                flp_user_feedback.Controls.Add(tb_sp);
                            }
                        }
                        break;
                    }
                }
            }
            else //if (lvAccount.SelectedItems[0] == null)
            {
                tb_user_id.Clear();
                tb_user_name.Clear();
                tb_user_phone.Clear();
                tb_user_dob.Clear();
                tb_user_gender.Clear();
                tb_user_email.Clear();
                flp_user_feedback.Controls.Clear();
                return;
            }
        }
        /*public void LoadBookListDTG(List<Book> bookList)
        {
            //List<Book> bookList = BookBLL.Instance.LoadBookList();
            foreach (Book item in bookList)
            {
                string[] arr = new string[2];
                ListViewItem bk;
                arr[0] = item.ID_book.ToString();
                arr[1] = item.Title;
                bk = new ListViewItem(arr);
                lvBook.Items.Add(bk);
            }
        }*/
        public void LoadBOOKListDTG()
        {
            //List<Book> bookList = BookBLL.Instance.LoadBookList();
            foreach (BOOK item in BookBLL.Instance.bookList)
            {
                string[] arr = new string[2];
                ListViewItem bk;
                arr[0] = item.ID_BOOK.ToString();
                arr[1] = item.TITLE;
                bk = new ListViewItem(arr);
                lvBook.Items.Add(bk);
            }
        }

        private void lvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<Book> bookList = BookBLL.Instance.LoadBookList();
            if (lvBook.SelectedItems.Count > 0)
            {
                foreach (BOOK item in /*bookList*/ BookBLL.Instance.bookList)
                {
                    if (lvBook.SelectedItems[0].SubItems[0].Text == item.ID_BOOK.ToString())
                    {
                        tb_book_id.Text = item.ID_BOOK.ToString();
                        tb_book_title.Text = item.TITLE;
                        tb_book_author.Text = item.AUTHOR;
                        tb_book_category_id.Text = item.ID_CATEGORY.ToString();
                        tb_book_publish.Text = item.PUBLISH_YEAR;
                        ll_book_pdf.Text = item.PDF_LINK;
                        ll_book_pdf.LinkArea = new LinkArea(0, item.PDF_LINK.Trim().Length);
                        //ll_book_pdf.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(ll_book_pdf_LinkClicked);
                        tb_book_overview.Text = item.OVERVIEW;
                        byte[] img = item.COVER;
                        MemoryStream byteimg = new MemoryStream(img);
                        Image image = new Bitmap(byteimg);
                        pb_book_cover.Image = image;
                        break;
                    }
                    else
                    {
                        tb_book_id.Clear();
                        tb_book_title.Clear();
                        tb_book_author.Clear();
                        tb_book_category_id.Clear();
                        tb_book_publish.Clear();
                        ll_book_pdf.Links.Clear();
                        tb_book_overview.Clear();
                        pb_book_cover.InitialImage.Dispose();
                    }
                }
            }
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ll_book_pdf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(e.Link.LinkData as string);
            System.Diagnostics.Process.Start(ll_book_pdf.Text);
        }
        public void LoadACCOUNT_lv()
        {
            List<ACCOUNT> accountList = AccountBLL.Instance.LoadACCOUNTList();
            foreach (ACCOUNT item in accountList.ToList())
            {
                string[] arr = new string[3];
                ListViewItem acc;
                arr[0] = item.USER_NAME;
                arr[1] = item.PASSWORD;
                if (item.GROUP_ID.Trim() == "001")
                {
                    arr[2] = "ADMIN";
                }
                else if (item.GROUP_ID.Trim() == "002")
                {
                    arr[2] = "USER";
                }
                //else arr[2] = item.Group_ID;
                //arr[2] = item.Group_ID;
                acc = new ListViewItem(arr);
                lvAccount.Items.Add(acc);
            }
        }

        private void btn_book_saveChanges_Click(object sender, EventArgs e)
        {
            //EntityBLL.Instance.eSaveChanges();
            //BookBLL.Instance.eSaveChanges_BOOK();
        }
    }
}
