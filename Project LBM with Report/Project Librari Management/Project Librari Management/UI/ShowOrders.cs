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

namespace Project_Librari_Management.UI
{
    public partial class ShowOrders : Form
    {
        public ShowOrders()
        {
            InitializeComponent();
            GetAllOrders();
        }

        DataTable dataTable;


        public void GetAllOrders()
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT * From Orders";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                //connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource binding = new BindingSource();
                binding.DataSource = dataTable;
                dataGridView2.DataSource = dataTable;
                adapter.Update(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView data = new DataView(dataTable);
            data.RowFilter = string.Format("Customer_Name LIKE '%{0}%'", textBox1.Text);
            dataGridView2.DataSource = data;
        }
    }
}
