using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            AtocompleteTextBox();
            this.orders = orders;
            memoNumver = GetLastMemoNumber();
        }

        private int memoNumver;
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
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable dataTable, dataTable1;

        private void CountButton(object sender, EventArgs e)
        {
            try
            {
                string na=booknameTextbox.Text;
                string name = na.Trim();
                string writer = writernameTextbox.Text;
                string edition =editionTextbox.Text;
                string type = typeTextBox.Text;
                string print = printTexBox.Text;
                if (name.Contains("'"))
                {
                    name = name.Replace("'", "''");
                }
                if (writer.Contains("'"))
                {
                   writer= writer.Replace("'", "''");
                }
                if (edition.Contains("'"))
                {
                  edition=  edition.Replace("'", "''");
                }
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = string.Format("SELECT  sum(Quantity) from Orders where Book_Name=@name and Writer=@writer and Edition=@edition and Type=@type and B_Print=@print");
                SqlCommand command = new SqlCommand(selectQuery, connection);
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", booknameTextbox.Text);
                command.Parameters.AddWithValue("@writer", writernameTextbox.Text);
                command.Parameters.AddWithValue("@edition", editionTextbox.Text);
                command.Parameters.AddWithValue("@type", typeTextBox.Text);
                command.Parameters.AddWithValue("@print", printTexBox.Text);

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

                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;

                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                typeTextBox.Text = row.Cells["Type"].Value.ToString();
                printTexBox.Text = row.Cells["B_Print"].Value.ToString();


            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                booknameTextbox.Text = row.Cells["Name"].Value.ToString();
                writernameTextbox.Text = row.Cells["Writer"].Value.ToString();
                editionTextbox.Text = row.Cells["Edition"].Value.ToString();
                typeTextBox.Text = row.Cells["Type"].Value.ToString();
                printTexBox.Text = row.Cells["Book_Print"].Value.ToString();

            }
        }


        public void GetAllBooks()
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
                dataTable1 = new DataTable();
                adapter.Fill(dataTable1);
                BindingSource binding = new BindingSource();
                binding.DataSource = dataTable1;
                dataGridView2.DataSource = dataTable1;
                adapter.Update(dataTable1);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                selfOrder.BType = typeTextBox.Text;
                selfOrder.BPrint = printTexBox.Text;
                selfOrder.Quantity = Convert.ToInt16(quantityTextbox.Text);
                selfOrder.MemoNo = memoNumver;
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                
            }


        }

       

        private void quantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch!=8 && ch!=46)
            {
                e.Handled = true;
            }
        }

        

        public void AtocompleteTextBox()
        {
            booknameTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            booknameTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            writernameTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            writernameTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection1 = new AutoCompleteStringCollection();
            editionTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            editionTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection editCollection = new AutoCompleteStringCollection();
            typeTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            typeTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection typeCollection = new AutoCompleteStringCollection();
            printTexBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            printTexBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection printCollection = new AutoCompleteStringCollection();
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
                    printCollection.Add(print);
                    typeCollection.Add(type);
                    editCollection.Add(edition);
                    collection.Add(name);
                    collection1.Add(writer);

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            booknameTextbox.AutoCompleteCustomSource = collection;
            writernameTextbox.AutoCompleteCustomSource = collection1;
            editionTextbox.AutoCompleteCustomSource = editCollection;
            typeTextBox.AutoCompleteCustomSource = typeCollection;
            printTexBox.AutoCompleteCustomSource = printCollection;
        }

        private void QuantitySelect_Load(object sender, EventArgs e)
        {
          FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
        }

        private void booknameTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (booknameTextbox.Text=="")
            {
              errorProvider1.SetError(booknameTextbox,"Please! Write the Book Name here.....!");  
            }
            else
            {
                errorProvider1.SetError(booknameTextbox,"");
            }
        }

        private void writernameTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (writernameTextbox.Text=="")
            {
                errorProvider1.SetError(writernameTextbox,"Please! Write the writer name here.....!");
            }
            else
            {
                errorProvider1.SetError(writernameTextbox,"");
            }
        }

        private void editionTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (editionTextbox.Text == "")
            {
                errorProvider1.SetError(editionTextbox, "Please! Write the book edition here.....!");
            }
            else
            {
                errorProvider1.SetError(editionTextbox, "");
            }
        }

        private void typeTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (typeTextBox.Text == "")
            {
                errorProvider1.SetError(typeTextBox, "Please! Write the book edition here.....!");
            }
            else
            {
                errorProvider1.SetError(typeTextBox, "");
            }   
        }

        private void printTexBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (printTexBox.Text == "")
            {
                errorProvider1.SetError(printTexBox, "Please! Write the book edition here.....!");
            }
            else
            {
                errorProvider1.SetError(printTexBox, "");
            }
        }




        private int GetLastMemoNumber()
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQ = "select MAX(Memo_No) from Self_Order_Memo_Counter";
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

