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

namespace Project_Librari_Management.UI
{
    public partial class SearchAndEdit : Form
    {
        public SearchAndEdit()
        {
            InitializeComponent();
            GetALLBooks();
        }
        Book aBook = new Book();
    
        DataTable dt;
       
        private void searchButton(object sender, EventArgs e)
        {
            DBManager manger = new DBManager();
            List<Book> books = GetALLBooks();
          
            
        }


        public List<Book> GetALLBooks()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "select * from Books";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();

                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = selectCmd;

               dt = new DataTable();
                myAdapter.Fill(dt);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dt;
                dataGridView1.DataSource = dt;
                myAdapter.Update(dt);


               
                return null;
            }
            catch (Exception obj)
            {

                throw new Exception("Error", obj);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dataviw = new DataView(dt);
            dataviw.RowFilter = string.Format("Name Like '%{0}%'", searchTextBox.Text);
            dataGridView1.DataSource = dataviw;
        }

       

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if( e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                GetInformation(row);

                UpdateAndSellUI updateAndSell = new UpdateAndSellUI(aBook);
               
                this.Hide();
                updateAndSell.ShowDialog();
            }
          
        }

        private void GetInformation(DataGridViewRow row)
        {
            string serialNo = row.Cells["S.No"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();
            string aName = row.Cells["Writer"].Value.ToString();
            string edition = row.Cells["Edition"].Value.ToString();
            string type = row.Cells["Type"].Value.ToString();
            int quantity = Convert.ToInt16(row.Cells["Quantiy"].Value);
            double unitprice = Convert.ToDouble(row.Cells["B_Unit_Price"].Value);
            string date = row.Cells["Purchase_Date"].Value.ToString();
           

            aBook.SerialNo = serialNo;
            aBook.BookName = name;
            aBook.AuthorName = aName;
            aBook.Edition = edition;
            aBook.TypeOfBook = type;
            aBook.Quantity = quantity;
            aBook.UnitPrice = unitprice;
            aBook.PurchasesDate = date;
           
        }

       
    }
}