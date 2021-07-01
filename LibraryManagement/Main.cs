using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class Main : Form
    {
        List<Book> books = new List<Book>();

        public Main()
        {
            InitializeComponent();
            listUpdate();
        }

        private void listUpdate() 
        {
            listBox.DataSource = books;
            listBox.DisplayMember = "BookInfo";
        }

        private void txtClear() 
        {
            txtSearch.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtQuantity.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();

                books = db.BookGet(txtSearch.Text);

                listUpdate();

                txtBookName.Text = string.Join("", books[0].BookName);
                txtAuthor.Text = string.Join("", books[0].Author);
                txtCategory.Text = string.Join("", books[0].Category);
                txtQuantity.Text = string.Join("", books[0].Quantity);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Book Found");
            }
            finally 
            {
                txtSearch.Clear();
            }

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();

                db.BookInsert(txtBookName.Text, txtAuthor.Text, txtCategory.Text, int.Parse(txtQuantity.Text));

                txtClear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter All Necessary Information");
            }
            finally 
            {
                txtClear();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();

                string id = string.Join("", books[0].Id);
                db.BookUpdate(id, txtBookName.Text, txtAuthor.Text, txtCategory.Text, int.Parse(txtQuantity.Text));

                txtClear();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Such A Book Found, Please Add As New Book");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Enter All The Required Field");
            }
            finally 
            {
                txtClear();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();

                db.BookDelete(txtBookName.Text);

                txtClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally 
            {
                txtClear();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

 
    }
}
