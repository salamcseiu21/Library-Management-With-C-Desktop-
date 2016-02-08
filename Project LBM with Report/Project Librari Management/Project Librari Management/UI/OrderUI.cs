using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class OrderUI : Form
    {
        private int x;
        public OrderUI()
        {
            InitializeComponent();
         x=  LastAddedInvestlNo();
            serialTextBox.Text = x.ToString();
            LoadAllBook();
        }

         DataTable dataTable;
        
     

       public void LoadAllBook()    
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
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource binding = new BindingSource();
                binding.DataSource = dataTable;
                dataGridView1.DataSource = dataTable;
                adapter.Update(dataTable);


            }
            catch ( SqlException exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

      

        private void ClearALLtextBox()
        {
           customerNameTextBox.Clear();
            customerMobileTextBox.Clear();
            bookEditionTextBox.Clear();
            writerNameTextBox.Clear();
          bookQuantityTextBOx.Clear();
           bookUnitPriceTextBOx.Clear();
            advanceTextBox.Clear();
           dueTextBox.Clear();
           bookNameTextBox.Clear();
            buyingUnitPriceTextBox.Clear();
        }

        
        public int LastAddedInvestlNo()
        {
           
            OrderGateway gateway=new OrderGateway();
            
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
           

            string selectQuery = "SELECT Order_No From Orders";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            connection.Open();  
            SqlDataReader reader = cmd.ExecuteReader();
            List<int> totalId = new List<int>();

            while (reader.Read())
            {
                int aId = Convert.ToInt16(reader[0]);

               
                totalId.Add(aId);
            }
            if (totalId.Count<=0)
            {
                return 0;
            }
            else
            {
                int x = totalId.Max();

                return x;  
            }
           

        }

       

       

        

        private void customerPhonetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void quantityTextox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void unitPricetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void advanceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

      
        private void showDueButton_Click(object sender, EventArgs e)
        {
            try
            {
                double due, advance;


                if (bookQuantityTextBOx.Equals("")&&bookUnitPriceTextBOx.Equals("")&&advanceTextBox.Equals(""))
                {
                    MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                
               
                else
                {
                    advance = Convert.ToDouble(advanceTextBox.Text);
                    due = (Convert.ToDouble(bookQuantityTextBOx.Text) * Convert.ToDouble(bookUnitPriceTextBOx.Text) -advance )
                    ;
                    dueTextBox.Text = due.ToString();
                }

            }
            catch (FormatException )
            {

                MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //save an Order 
        private void orderAcceptButton_Click(object sender, EventArgs e)
        {

            try
            {
                OrderGateway gateway = new OrderGateway();
                Order anOrder = new Order();
                anOrder.CustomerName = customerNameTextBox.Text;
                anOrder.CustomerPhone = customerMobileTextBox.Text;
                anOrder.BookName = bookNameTextBox.Text;
                anOrder.WriterName = writerNameTextBox.Text;
                anOrder.Edition = bookEditionTextBox.Text;
                anOrder.BuyUnitPrice = Convert.ToDouble(buyingUnitPriceTextBox.Text);
                string quantiy = bookQuantityTextBOx.Text;
                anOrder.Quantity = Convert.ToInt16(quantiy);
                anOrder.UnitPrice = Convert.ToDouble(bookUnitPriceTextBOx.Text);
                anOrder.Advance = Convert.ToDouble(advanceTextBox.Text);
                
                anOrder.SupplyDate = dateTimePicker1.Text;
                string st = gateway.SaveOrder(anOrder);
                MessageBox.Show(st,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ClearALLtextBox();
                LoadAllBook();

                serialTextBox.Text = LastAddedInvestlNo().ToString();
            }
            catch (Exception)
            {
               
                MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView data=new DataView(dataTable);
            data.RowFilter = string.Format("Name LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                bookNameTextBox.Text = row.Cells["Name"].Value.ToString();
                writerNameTextBox.Text = row.Cells["Writer"].Value.ToString();
                bookEditionTextBox.Text = row.Cells["Edition"].Value.ToString();
                buyingUnitPriceTextBox.Text = row.Cells["B_Unit_Price"].Value.ToString();
            }
            



        }

        private void customerMobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void bookQuantityTextBOx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void bookUnitPriceTextBOx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void advanceTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

      

        

       

       
    }
}
