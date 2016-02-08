using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using Project_Librari_Management.BLL;
//using Project_Librari_Management.Customer_Report;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;
using Project_Librari_Management.Report;

namespace Project_Librari_Management.UI
{
    public partial class OrderUI : Form
    {
        private int x;
        public OrderUI()
        {
            InitializeComponent();
           // CustomerMobile();
           CustomerNamteSuggestion();
            AtocompleteTextBox();
          
         x=  LastAddedInvestlNo();
            serialTextBox.Text = x.ToString();
            LoadAllBook();
            memoNumver = GetLastMemoNumber();
        }

         DataTable dataTable;

        private int memoNumver;

       public void LoadAllBook()    
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT * From Books Order by Name";
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
           //customerNameTextBox.Clear();
           // customerMobileTextBox.Clear();
            bookEditionTextBox.Clear();
            writerNameTextBox.Clear();
          bookQuantityTextBOx.Clear();
           bookUnitPriceTextBOx.Clear();
            advanceTextBox.Clear();
           dueTextBox.Clear();
            typeOfBookTextBox.Clear();
           bookNameTextBox.Clear();
            bookPrintTextbox.Clear();
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

        //Customer infor autoSuggestions method

        public void CustomerNamteSuggestion()
        {
            customerNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerMobileTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerMobileTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll=new AutoCompleteStringCollection();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string query = "select * from Orders";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    string name = reader[1].ToString();
                    string name1 = reader[2].ToString();
                    coll.Add(name);
                    collection.Add(name1);

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            customerNameTextBox.AutoCompleteCustomSource = coll;
            customerMobileTextBox.AutoCompleteCustomSource = collection;
            

        }

        public void CustomerMobile()
        {
            customerNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerMobileTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerMobileTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            AutoCompleteStringCollection coll1=new AutoCompleteStringCollection();
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string query = "select * from Delivery_Report";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    string mobile = reader[2].ToString();
                    coll.Add(name);
                    coll1.Add(mobile);
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            customerNameTextBox.AutoCompleteCustomSource = coll;
            customerMobileTextBox.AutoCompleteCustomSource = coll1;

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
                anOrder.TypeOfBook = typeOfBookTextBox.Text;
                anOrder.BookPrint = bookPrintTextbox.Text;
                anOrder.BuyUnitPrice = Convert.ToDouble(buyingUnitPriceTextBox.Text);
                string quantiy = bookQuantityTextBOx.Text;
                anOrder.Quantity = Convert.ToInt16(quantiy);
                anOrder.UnitPrice = Convert.ToDouble(bookUnitPriceTextBOx.Text);
                anOrder.Advance = Convert.ToDouble(advanceTextBox.Text);
                
                anOrder.SupplyDate = dateTimePicker1.Text;
                
                
                string st = gateway.SaveOrder(anOrder);

                ////InvoiceUI invoice=new InvoiceUI(serialTextBox.Text,customerNameTextBox.Text,customerMobileTextBox.Text,bookNameTextBox.Text,writerNameTextBox.Text,bookEditionTextBox.Text,typeOfBookTextBox.Text,bookPrintTextbox.Text,bookQuantityTextBOx.Text,bookUnitPriceTextBOx.Text,advanceTextBox.Text,dueTextBox.Text,dateTimePicker1.Text);

                //invoice.ShowDialog();
                TempOrder aOrder=new TempOrder();
                aOrder.SerialNo = serialTextBox.Text;
                aOrder.CustomerName = customerNameTextBox.Text;
                aOrder.MobileNo = customerMobileTextBox.Text;
                aOrder.BookName = bookNameTextBox.Text;
                aOrder.WriterName = writerNameTextBox.Text;
                aOrder.Edition = bookEditionTextBox.Text;
                aOrder.Type = typeOfBookTextBox.Text;
                aOrder.Print = bookPrintTextbox.Text;
                aOrder.Quantity = Convert.ToInt16(bookQuantityTextBOx.Text);
                aOrder.Unitprice = Convert.ToDouble(bookUnitPriceTextBOx.Text);
                aOrder.Total =
                    (Convert.ToInt16(bookQuantityTextBOx.Text)*Convert.ToDouble(bookUnitPriceTextBOx.Text));
                aOrder.Advance = Convert.ToDouble(advanceTextBox.Text);
                aOrder.Due = Convert.ToDouble(dueTextBox.Text);

                aOrder.SupplyDate = dateTimePicker1.Text;
                aOrder.MemoNumber = memoNumver;
                TempOrderGateway gateway1=new TempOrderGateway();
                gateway1.SaveTempOrer(aOrder);

                MessageBox.Show(st,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

               

                ClearALLtextBox();
                LoadAllBook();

                serialTextBox.Text = LastAddedInvestlNo().ToString();
                CustomerNamteSuggestion();
                AtocompleteTextBox();
                

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                //MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
            }


        }

        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                bookNameTextBox.Text = row.Cells["Name"].Value.ToString();
                writerNameTextBox.Text = row.Cells["Writer"].Value.ToString();
               bookEditionTextBox.Text = row.Cells["Edition"].Value.ToString();
                 bookPrintTextbox.Text = row.Cells["Book_Print"].Value.ToString();
                buyingUnitPriceTextBox.Text = row.Cells["B_Unit_Price"].Value.ToString();
                typeOfBookTextBox.Text = row.Cells["Type"].Value.ToString();
            }
            



        }       

        private void buyingUnitPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void bookQuantityTextBOx_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void bookUnitPriceTextBOx_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void advanceTextBox_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataView data = new DataView(dataTable);
            data.RowFilter = string.Format("Name LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = data;
        }

        private void customerMobileTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerMobileTextBox_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        public void AtocompleteTextBox()
        {
            //bookNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //bookNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bookNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            bookNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            writerNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            writerNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bookEditionTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            bookEditionTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            typeOfBookTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            typeOfBookTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bookPrintTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            bookPrintTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection nameCollection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection writerCollection=new AutoCompleteStringCollection();
            AutoCompleteStringCollection editionCollection=new AutoCompleteStringCollection();
            AutoCompleteStringCollection typeCollection=new AutoCompleteStringCollection();
            AutoCompleteStringCollection printCollection=new AutoCompleteStringCollection();
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string query = "select * from Books";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    string writer = reader[2].ToString();
                    string edition = reader[3].ToString();
                    string type = reader[4].ToString();
                    string print = reader[5].ToString();
                    nameCollection.Add(name);
                    writerCollection.Add(writer);
                    editionCollection.Add(edition);
                    typeCollection.Add(type);
                    printCollection.Add(print);

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bookNameTextBox.AutoCompleteCustomSource = nameCollection;
            writerNameTextBox.AutoCompleteCustomSource = writerCollection;
            bookEditionTextBox.AutoCompleteCustomSource = editionCollection;
            bookPrintTextbox.AutoCompleteCustomSource = printCollection;
            typeOfBookTextBox.AutoCompleteCustomSource = typeCollection;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        

        private void OrderUI_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBManager manager=new DBManager();
            SqlConnection connection = manager.Connection();
            TempOrderGateway gateway=new TempOrderGateway();
            List<TempOrder> orders = gateway.GetempOrders();
            InvoiceUI invoice = new InvoiceUI(orders);
            invoice.ShowDialog();
            System.Windows.Forms.DialogResult dialog = MessageBox.Show("Did you print the document?", "Print Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                String deletequery = "delete from Temp_Order_Hold";
                SqlCommand command1 = new SqlCommand(deletequery, connection);
                connection.Open();
                command1.ExecuteNonQuery();
                string que = "DBCC CHECKIDENT (Temp_Order_Hold,Reseed,0)";
                command1=new SqlCommand(que,connection);
                command1.ExecuteNonQuery();
                string que1 = "set identity_insert Temp_Order_Hold on";
                command1=new SqlCommand(que1,connection);
                command1.ExecuteNonQuery();
                string insQuery = "insert into Order_Memo_Counter values(@date)";
                command1 = new SqlCommand(insQuery, connection);
                command1.Parameters.Clear();
                command1.Parameters.AddWithValue("@date", DateTime.Now.Date);
                command1.ExecuteNonQuery();
                memoNumver = GetLastMemoNumber();
                //string insQuery = "insert into Due_Memo_Counter values(@date)";
                //command1 = new SqlCommand(insQuery, connection);
                //command1.Parameters.Clear();
                //command1.Parameters.AddWithValue("@date", DateTime.Now.Date);
                //command1.ExecuteNonQuery();
                //memoNumver = GetLastMemoNumber();






            }
            else if (dialog == DialogResult.No)
            {
                System.Windows.Forms.DialogResult dialog1 = MessageBox.Show("Are you want to print now?",
                    "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog1 == DialogResult.Yes)
                {
                     invoice = new InvoiceUI(orders);
                    invoice.ShowDialog();
                    String deletequery = "delete from Temp_Order_Hold";
                    SqlCommand command1 = new SqlCommand(deletequery, connection);
                    connection.Open();
                    command1.ExecuteNonQuery();

                    string que = "DBCC CHECKIDENT (Temp_Order_Hold,Reseed,0)";
                    command1 = new SqlCommand(que, connection);
                    command1.ExecuteNonQuery();
                    string que1 = "set identity_insert Temp_Order_Hold on";
                    command1 = new SqlCommand(que1, connection);
                    command1.ExecuteNonQuery();
                    string insQuery = "insert into Order_Memo_Counter values(@date)";
                    command1 = new SqlCommand(insQuery, connection);
                    command1.Parameters.Clear();
                    command1.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    command1.ExecuteNonQuery();
                    memoNumver = GetLastMemoNumber();


                 DialogResult d2=   MessageBox.Show(" Print Sucessful! Are you want ot exit? ", "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d2==DialogResult.Yes)
                    {
                        this.Close();  
                    }
                    else if (d2==DialogResult.No)
                    {
                        //OrderUI odUi=new OrderUI();
                        //odUi.ShowDialog();
                    }
                }
                else if (dialog1 == DialogResult.No)
                {
                    this.Close();
                }
            }



        }

        private int GetLastMemoNumber()
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQ = "select MAX(Memo_No) from Order_Memo_Counter";
            SqlCommand command = new SqlCommand(selectQ, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString().Equals(""))
                {
                    memoNumver = 1;
                }
                else
                {
                    memoNumver = Convert.ToInt16(reader[0]);
                }

            }

            connection.Close();
            connection.Open();
            //string insQuery = "insert into Due_Memo_Counter values(@date)";
            //command = new SqlCommand(insQuery, connection);
            //command.Parameters.Clear();
            //command.Parameters.AddWithValue("@date", DateTime.Now.Date);
            //command.ExecuteNonQuery();



            return memoNumver;
        }
       
    }
}
