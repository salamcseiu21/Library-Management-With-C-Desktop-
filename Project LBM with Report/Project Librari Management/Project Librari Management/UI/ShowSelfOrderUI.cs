using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.UI
{
    public partial class ShowSelfOrderUI : Form
    {

        private string date;
        public ShowSelfOrderUI(string date)
        {
            InitializeComponent();
            this.date = date;
            GetAllSelfOrder();
           
        }


        public void GetAllSelfOrder()
        {


            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string query = "Select [Serial No],[Book Name],[Writer Name],Edition,[Quanitity of Book] from Self_Order where [Order Date]='" + date + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataAdapter myAdapter=new SqlDataAdapter();

            myAdapter.SelectCommand = command;
            DataTable dataTable=new DataTable();
            myAdapter.Fill(dataTable);
            BindingSource bsSource=new BindingSource();
            bsSource.DataSource = dataTable;
            dataGridView1.DataSource = dataTable;
            myAdapter.Update(dataTable);
            GetTotalQuantity();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void GetTotalQuantity()
        {
            int quantity;


            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string query = " select sum([Quanitity of Book]) from Self_Order where [Order Date]='" + date + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                try
                {
                    if (reader1[0].Equals("") || reader1[0].Equals("0"))
                    {
                        richTextBox1.Text = "0";
                    }
                    else
                    {
                        quantity = Convert.ToInt16(reader1[0]);
                        richTextBox1.Text = quantity.ToString();
                    }
                }
                catch (InvalidCastException )
                {

                  
                }                
               
            }

        }
    }
}
