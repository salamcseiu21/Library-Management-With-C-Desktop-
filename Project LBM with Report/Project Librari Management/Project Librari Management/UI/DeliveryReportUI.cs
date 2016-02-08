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
    public partial class DeliveryReportUI : Form
    {
        public DeliveryReportUI()
        {
            InitializeComponent();
            LoadAllDeliveryReport();
        }

        private DataTable dataTable;

        public void LoadAllDeliveryReport()
        {
            DBManager manager=new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQuery = "Select * from Delivery_Report";
            SqlCommand command=new SqlCommand(selectQuery,connection);
            SqlDataAdapter adapter=new SqlDataAdapter();
            adapter.SelectCommand = command;
            dataTable=new DataTable();
            adapter.Fill(dataTable);

            BindingSource bSource=new BindingSource();
            bSource.DataSource = dataTable;
            dataGridView1.DataSource = dataTable;
            adapter.Update(dataTable);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchByNameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dataView=new DataView(dataTable);
            dataView.RowFilter = string.Format("Customer_Name LIKE '%{0}%'", searchByNameTextBox.Text);
            dataGridView1.DataSource = dataView;
        }
    }
}
