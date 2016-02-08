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
using Project_Librari_Management.DAL.Gateway;
using System.Collections;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.UI
{
    public partial class SummaryUI : Form
    {
        public SummaryUI()
        {
            InitializeComponent();
            GetAll();
           
        }
        DataTable dataTable;
       
        public void GetAll()
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string selectQuery = "select * from sell_Counter";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
           List<Book> sellBooks = new List<Book>();
            while(reader.Read())
            {
                string serial = reader[0].ToString();
                string name = reader[1].ToString();
                string AName = reader[2].ToString();
                string edition = reader[3].ToString();
                string type = reader[4].ToString();
                int quantity = Convert.ToInt16(reader[5]);
                double unitpricecell = Convert.ToDouble(reader[6]);
                double unitPrice = Convert.ToDouble(reader[7]);
                double total = Convert.ToDouble(reader[8]);
                string date = reader[9].ToString();
                Book aBook = new Book();
                aBook.SerialNo = serial;
                aBook.BookName = name;
                aBook.AuthorName = AName;
                aBook.PurchasesDate = date;
                aBook.Edition = edition;
                aBook.TypeOfBook = type;
                aBook.Quantity = quantity;
                aBook.UnitPrice = unitPrice;
                sellBooks.Add(aBook);
                
            }
            ;

        }


        private void showSellSummaryButton(object sender, EventArgs e)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = "select * from sell_Counter";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = cmd;

               dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dataTable;
                dataGridView1.DataSource = bSource;
                myAdapter.Update(dataTable);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dataview = new DataView(dataTable);
            dataview.RowFilter = string.Format("Book_Name Like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dataview;
        }

        private void Cost_BenifitButton(object sender, EventArgs e)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery =
                    "select SUM(Quantiy)As Totol_Sell, sum(Unit_Price_Sell*Quantiy) aS Sell_Price,sum(Unit_Price_Buy*Quantiy) as Buying_Price ,sum(Total_Sell_Amount),sum(Collection)from [sell_Counter]sell_Counter where sell_date='" +
                    DateTime.Today.ToShortDateString() + "'";
                connection.Open();
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                        string a = reader[0].ToString();
                        string b = reader[1].ToString();
                        string c = reader[2].ToString();
                        string d = reader[3].ToString();
                       
                        string t = reader[4].ToString();
                        if (a.Equals(""))
                        {
                            MessageBox.Show("No sell today.", "Message", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                        }
                        

                        else
                        {



                            int quantity = Convert.ToInt16(reader[0]);
                            double unitpricecell = Convert.ToDouble(reader[1]);
                            double unitPrice = Convert.ToDouble(reader[2]);
                            double total_sell_amount = Convert.ToDouble(reader[3]);
                          
                            double collection = Convert.ToDouble(reader[4]);

                            soldQunatityTextBox.Text = quantity.ToString();
                            sellingTextBOx.Text = unitpricecell.ToString();
                            buyingTextBox.Text = unitPrice.ToString();
                           
                            if (unitPrice > collection)
                            {
                                lossTextBox.Text = (unitPrice - collection).ToString();
                            }
                            else
                            {
                                double benifit = collection - unitPrice;
                                benifitTextBOx.Text = benifit.ToString();
                            }
                        }


                    }


               

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        
    }
}
