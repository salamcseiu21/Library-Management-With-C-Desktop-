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
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class QuantitySelect : Form
    {
        public List<Order> order2;
        public List<Order> orders;

        public QuantitySelect(List<Order> orders)
        {
            InitializeComponent();
             GetAllOrders();
            GetAllBooks();
            this.orders = orders;
        }

        public void AllOrder()
        {

            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Book_Name,Writer,Edition,Quantity from Orders";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                order2 = new List<Order>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookName = reader[0].ToString();
                    string writerName = reader[1].ToString();
                    string edition = reader[2].ToString();
                    string qu = reader[3].ToString();
                    int quantity = Convert.ToInt16(qu);

                    Order anOrder = new Order();
                    anOrder.BookName = bookName;
                    anOrder.WriterName = writerName;
                    anOrder.Edition = edition;
                    anOrder.Quantity = quantity;
                    order2.Add(anOrder);

                }


            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }


        }



        public void GetAllOrders()
        {
            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT * From Orders";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource binding = new BindingSource();
                binding.DataSource = dataTable;
                dataGridView1.DataSource = dataTable;
                adapter.Update(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private DataTable dataTable, dataTable1;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT  sum(Quantity) from Orders where Book_Name='" + booknameTextbox.Text +
                                     "'and Writer='" + writernameTextbox.Text + "' and Edition='" + editionTextbox.Text +
                                     "'";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string a = reader[0].ToString();
                    try
                    {
                        if (a.Equals(""))
                        {
                            quantityTextbox.Text = "0";

                        }
                        else
                        {
                            int quantity = Convert.ToInt16(reader[0]);
                            quantityTextbox.Text = quantity.ToString();
                        }
                    }
                    catch (InvalidCastException exception)
                    {

                        MessageBox.Show(exception.Message);
                    }

                    return;

                }
            }

            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                booknameTextbox.Text = row.Cells["Book_Name"].Value.ToString();
                writernameTextbox.Text = row.Cells["Writer"].Value.ToString();
                editionTextbox.Text = row.Cells["Edition"].Value.ToString();
               


            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                booknameTextbox.Text = row.Cells["Book_Name"].Value.ToString();
                writernameTextbox.Text = row.Cells["Writer"].Value.ToString();
                editionTextbox.Text = row.Cells["Edition"].Value.ToString();
                

            }
        }


        public void GetAllBooks()
        {
            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT * From Books";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                //connection.Open();    
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dataTable1 = new DataTable();
                adapter.Fill(dataTable1);
                BindingSource binding = new BindingSource();
                binding.DataSource = dataTable1;
                dataGridView2.DataSource = dataTable1;
                adapter.Update(dataTable1);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dataView = new DataView(dataTable1);
            dataView.RowFilter = string.Format("Name LIKE '%{0}%'", richTextBox1.Text);
            dataGridView2.DataSource = dataView;
        }

        private void SaveSelfOrder(object sender, EventArgs e)
        {
            try
            {
                SelfOrder selfOrder = new SelfOrder();
                selfOrder.BName = booknameTextbox.Text;
                selfOrder.BWriter = writernameTextbox.Text;
                selfOrder.BEdition = editionTextbox.Text;
                selfOrder.Quantity = Convert.ToInt16(quantityTextbox.Text);
                if (selfOrder.BName.Equals(""))
                {
                    MessageBox.Show("Enter the Book name.","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
                else if(selfOrder.BWriter.Equals(""))
                {
                    MessageBox.Show("Enter the writer name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                }
                else if (selfOrder.BEdition.Equals(""))
                {
                    MessageBox.Show("Enter the book edition.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SelfOrderGateway gateway = new SelfOrderGateway();

                    gateway.SaveSelfOrder(selfOrder);
                }
                
            }
            catch (FormatException)
            {
                
                
            }


        }

        private void ShowSelfOrdersButton(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            ShowSelfOrderUI showSelfOrder=new ShowSelfOrderUI(date);
            showSelfOrder.ShowDialog();

        }

    }

}

