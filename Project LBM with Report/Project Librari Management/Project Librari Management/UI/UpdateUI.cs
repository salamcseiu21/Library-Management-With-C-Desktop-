using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class UpdateUI : Form
    {
        public UpdateUI()
        {
            InitializeComponent();
            LoadAllBook();
           
        }
        string b_type;

        public void LoadAllBook()
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = "select * from Books where Name LIKE '%" + textBox1.Text + "%'";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                List<Book> books = new List<Book>();
                while (myReader.Read())
                {
                    string serial = myReader[0].ToString();
                    string name = myReader[1].ToString();
                    string authorName = myReader[2].ToString();
                    string edition = myReader[3].ToString();
                    string type = myReader[4].ToString();
                    int quantity = Convert.ToInt16(myReader[5]);
                    double unitprice = Convert.ToDouble(myReader[6]);
                    string date = myReader[7].ToString();
                    Book aBook = new Book();
                    aBook.SerialNo = serial;
                    aBook.BookName = name;
                    aBook.AuthorName = authorName;
                    aBook.Edition = edition;
                    aBook.TypeOfBook = type;
                    aBook.Quantity = quantity;
                    aBook.UnitPrice = unitprice;
                    aBook.PurchasesDate = date;
                    ListViewItem item = new ListViewItem(aBook.SerialNo);
                    item.SubItems.Add(aBook.BookName);
                    item.SubItems.Add(aBook.AuthorName);
                    item.SubItems.Add(aBook.Edition);
                    item.SubItems.Add(aBook.TypeOfBook);
                    item.SubItems.Add(aBook.Quantity.ToString());
                    item.SubItems.Add(aBook.UnitPrice.ToString());
                    item.SubItems.Add(aBook.PurchasesDate);
                    item.Tag = aBook;
                   
                   
                    listView1.Items.Add(item); 
                    

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }        


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            b_type = "New";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            b_type = "Old";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled=(listView1.SelectedItems.Count>0);
          
        }

        private void searchButton(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Please search by any part of Book Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                listView1.Items.Clear();
                LoadAllBook();
               
            }
            
        }
        

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listView1.SelectedIndices[0];
            ListViewItem item = listView1.Items[index];
            Book aBook = (Book)item.Tag;
            BookGateway gateway = new BookGateway();
            string i = gateway.DeleteInfo(aBook);
            MessageBox.Show(i);
           
            
           
           
        }

       
       
    }
}
