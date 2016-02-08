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
    public partial class ViewDueRecordUI : Form
    {
        public ViewDueRecordUI()
        {
            InitializeComponent();
        }

        private DataTable aTable;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager mandManager = new DBManager();
                SqlConnection connection = mandManager.Connection();
                string selectQuery = "Select * from Reduce";
                SqlCommand cmCommand = new SqlCommand(selectQuery, connection);
                SqlDataAdapter mayAdapter = new SqlDataAdapter();

                connection.Open();
                mayAdapter.SelectCommand = cmCommand;
                DataTable abTable = new DataTable();
                mayAdapter.Fill(abTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = abTable;
                dataGridView1.DataSource = bSource;
                mayAdapter.Update(abTable);
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                DBManager mandManager = new DBManager();
                SqlConnection connection = mandManager.Connection();
                string selectQuery = "Select * from Add_Due";
                SqlCommand cmCommand = new SqlCommand(selectQuery, connection);
                SqlDataAdapter mayAdapter = new SqlDataAdapter();

                connection.Open();
                mayAdapter.SelectCommand = cmCommand;
                 aTable = new DataTable();
                mayAdapter.Fill(aTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = aTable;
                dataGridView1.DataSource = bSource;
                mayAdapter.Update(aTable);
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dataview = new DataView(aTable);
            dataview.RowFilter = string.Format("Name_A Like '%{0}%'", searchTextBox.Text);
            dataGridView1.DataSource = dataview;
        }

        private void ViewDueRecordUI_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
        }
    }
}
