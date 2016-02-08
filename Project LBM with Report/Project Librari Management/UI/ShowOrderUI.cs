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
    public partial class ShowOrderUI : Form
    {
        public ShowOrderUI()
        {
            InitializeComponent();
            GetAllOrders();
            memoNumver = GetLastMemoNumber();
        }

        DataTable dataTable;
        public int qunatityOfRemaingBook, quan;
        public double unit_Price;
        private int memoNumver;

        private int GetLastMemoNumber()
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQ = "select MAX(Memo_No) from Deliveri_Memo_Counter";
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
           



            return memoNumver;
        }





        public void GetAllOrders1()
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Quantity From Orders";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open()
                    ;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string q = reader[0].ToString();
                     if (q.Equals(""))
                    {
                        qunatityOfRemaingBook = 0;
                    }
                    else
                    {
                        qunatityOfRemaingBook = Convert.ToInt16(q);
                    }
                }
                connection.Close();
            }
            catch (Exception exception)
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    serialTextBox.Text = row.Cells["Order_No"].Value.ToString();
                    customerNameTextBox.Text = row.Cells["Customer_Name"].Value.ToString();
                    customerMobileTextBox.Text = row.Cells["Mobile"].Value.ToString();
                    bookNameTextBox.Text = row.Cells["Book_Name"].Value.ToString();
                    writerNameTextBox.Text = row.Cells["Writer"].Value.ToString();
                    bookEditionTextBox.Text = row.Cells["Edition"].Value.ToString();
                    bookPrintTextBox.Text = row.Cells["B_Print"].Value.ToString();
                    bookQuantityTextBOx.Text = row.Cells["Quantity"].Value.ToString();
                    bookUnitPriceTextBOx.Text = row.Cells["Unit_Price"].Value.ToString();
                    advanceTextBox.Text = row.Cells["Advance"].Value.ToString();
                    dueTextBox.Text = row.Cells["Due"].Value.ToString();
                    buyingUnitPriceTextBox.Text = row.Cells["Buy_Unit_Price"].Value.ToString();

                }
            }
            catch (Exception exception)
            {
                
                  MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
              
        private void DeliveryButton(object sender, EventArgs e)
        {
            
            try
            {
                if (dueTextBox.Text.Equals(payingAmountTextBOX.Text))
                {
                    double due, pay, final_Due;
                    int quantity, serial_No;
                    double unitprice, advance, BuyUnitPrice;
                    double a, b;
                    a = Convert.ToDouble(dueTextBox.Text);
                    b = Convert.ToDouble(payingAmountTextBOX.Text);
                    if (dueTextBox.Text.Equals("")&&payingAmountTextBOX.Text.Equals(""))
                    {
                        MessageBox.Show("There are no order for delivery.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                     else if(a<b)
                    {
                        MessageBox.Show("Please check the paying amount.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {


                        due = Convert.ToDouble(dueTextBox.Text);
                        pay = Convert.ToDouble(payingAmountTextBOX.Text);
                        final_Due = due - pay;
                        BuyUnitPrice = Convert.ToDouble(buyingUnitPriceTextBox.Text);
                        quantity = Convert.ToInt16(bookQuantityTextBOx.Text);
                        unitprice = Convert.ToDouble(bookUnitPriceTextBOx.Text);
                        advance = Convert.ToDouble(advanceTextBox.Text);
                        serial_No = Convert.ToInt16(serialTextBox.Text);
                        string print = bookPrintTextBox.Text;
                        DBManager manager = new DBManager();
                        SqlConnection connection = manager.Connection();
                        string insertQuery = "INSERT INTO Delivery_Report values(@serial,@cname,@phone,@bookName,@writer,@edition,@print,@quantity,@buyUnitprice,@unitpricecell,@advance,@due,@payingAmount,@finaldue,@date)";
                       

                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        connection.Open();
                        command.Parameters.Clear();
                        command.Parameters.Add("@serial", serialTextBox.Text);
                        command.Parameters.Add("@cname", customerNameTextBox.Text);
                        command.Parameters.Add("@phone", customerMobileTextBox.Text);
                        command.Parameters.Add("@bookName", bookNameTextBox.Text);
                        command.Parameters.Add("@writer", writerNameTextBox.Text);
                        command.Parameters.Add("@edition", bookEditionTextBox.Text);
                        command.Parameters.Add("@print", bookPrintTextBox.Text);
                        command.Parameters.Add("@quantity", quantity);
                        command.Parameters.Add("@buyUnitprice", Convert.ToDouble(BuyUnitPrice));
                        command.Parameters.Add("@unitpricecell", unitprice);
                        command.Parameters.Add("@advance", advance);
                        command.Parameters.Add("@due", due);
                        command.Parameters.Add("@payingAmount", pay);
                        command.Parameters.Add("@finaldue", final_Due);
                        command.Parameters.Add("@date", DateTime.Now.ToShortDateString());
                        command.ExecuteNonQuery();

                        DBManager manager6 = new DBManager();
                        SqlConnection connection6 = manager6.Connection();
                        string selectQuery6 = "insert into  Due_Collection values(@pay,@empty,@payConleection,@date)";  
                        SqlCommand cmd6 = new SqlCommand(selectQuery6, connection6);
                        connection6.Open()
                            ;
                        cmd6.Parameters.Clear();
                        cmd6.Parameters.Add("@pay","0");
                        cmd6.Parameters.Add("@empty", "0");
                        cmd6.Parameters.AddWithValue("@payConleection", pay);
                        cmd6.Parameters.Add("@date", DateTime.Now.ToShortDateString());


                        cmd6.ExecuteNonQuery();

                         connection.Close();
                        string deleteQuery = "delete from Orders where Order_No='" + serial_No + "'";
                        SqlCommand command1 = new SqlCommand(deleteQuery, connection);
                        connection.Open();
                        int x = command1.ExecuteNonQuery();
                        MessageBox.Show(customerNameTextBox.Text + " paid his/her due.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                         connection.Close();


                        //update books

                         string name = bookNameTextBox.Text;
                         string writer = writerNameTextBox.Text;
                         string edition = bookEditionTextBox.Text;
                         



                         String selectQ = "select  Quantiy,B_Unit_Price from Books where Name=@name and Edition=@edition and Writer=@writer";

                       
                        SqlCommand sletCom = new SqlCommand(selectQ, connection);
                        connection.Open();
                         sletCom.Parameters.Clear();
                        sletCom.Parameters.AddWithValue("@name", name);
                        sletCom.Parameters.AddWithValue("@edition", edition);
                        sletCom.Parameters.AddWithValue("@writer", writer);
                        
                        SqlDataReader reader = sletCom.ExecuteReader();
                        while (reader.Read())
                        {
                            int quantity4 = Convert.ToInt16(reader[0]);
                            double unitprice5 = Convert.ToDouble(reader[1]);
                            connection.Close();

                            int quantityReudceBook, final_quantity;
                            quantityReudceBook = Convert.ToInt16(bookQuantityTextBOx.Text);
                            final_quantity = quantity4 - quantityReudceBook;
                            double T_Price = final_quantity*unitprice5;

                            string updateQuery = "UPDATE Books set Quantiy=@quantity,Total_Price=@totalPrice where Name=@name and Edition=@edition and Writer=@writer";



                            SqlCommand upCommand = new SqlCommand(updateQuery, connection);
                            upCommand.Parameters.Clear();
                            upCommand.Parameters.AddWithValue("@quantity", final_quantity);
                            upCommand.Parameters.AddWithValue("@totalPrice", T_Price);
                            upCommand.Parameters.AddWithValue("@name", name);
                            upCommand.Parameters.AddWithValue("@edition", edition);
                            upCommand.Parameters.AddWithValue("@writer", writer);
                            connection.Open();
                            int s = upCommand.ExecuteNonQuery();
                            MessageBox.Show("Updated","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

                            //temp order delivery report save 
                            TempOrder anOrder=new TempOrder(serialTextBox.Text,customerNameTextBox.Text,customerMobileTextBox.Text,bookNameTextBox.Text,writerNameTextBox.Text,bookEditionTextBox.Text,bookPrintTextBox.Text,Convert.ToInt16(bookQuantityTextBOx.Text),Convert.ToDouble(bookUnitPriceTextBOx.Text
                                ), Convert.ToDouble(Convert.ToInt16(bookQuantityTextBOx.Text)*Convert.ToDouble(bookUnitPriceTextBOx.Text)),Convert.ToDouble(advanceTextBox.Text),final_Due,Convert.ToDouble(payingAmountTextBOX.Text),memoNumver);
                            TempOrderGateway gateway=new TempOrderGateway();

                            gateway.SaveDeliveryReport(anOrder);


                            GetAllOrders();
                            GetAllOrders1();
                            ClearAllTextBox();
                            connection.Close();
                            return;
                        }

                    }

                }
                else
                {
                    double due, pay, final_Due;
                    int quantity, serial_No;
                    double unitprice, advance, BuyUnitPrice;
                    quan = Convert.ToInt16(bookQuantityTextBOx.Text);
                    double a, b;
                    a = Convert.ToDouble(dueTextBox.Text);
                    b = Convert.ToDouble(payingAmountTextBOX.Text);
                    if (dueTextBox.Text.Equals("0") || payingAmountTextBOX.Text.Equals("0"))
                    {
                        final_Due = 0;
                    }
                    else if (a < b)
                    {
                        MessageBox.Show("Please check the paying amount.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        due = Convert.ToDouble(dueTextBox.Text);
                        pay = Convert.ToDouble(payingAmountTextBOX.Text);
                        final_Due = due - pay;
                        BuyUnitPrice = Convert.ToDouble(buyingUnitPriceTextBox.Text);
                        quantity = Convert.ToInt16(bookQuantityTextBOx.Text);
                        unitprice = Convert.ToDouble(bookUnitPriceTextBOx.Text);
                        advance = Convert.ToDouble(advanceTextBox.Text);
                        serial_No = Convert.ToInt16(serialTextBox.Text);

                        DBManager manager = new DBManager();
                        SqlConnection connection = manager.Connection();
                        string insertQuery = "INSERT INTO Delivery_Report values(@serial,@cname,@phone,@bookName,@writer,@edition,@print,@quantity,@buyUnitprice,@unitpricecell,@advance,@due,@payingAmount,@finaldue,@date)";
                        
                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        connection.Open();
                        command.Parameters.Clear();
                        command.Parameters.Add("@serial", serialTextBox.Text);
                        command.Parameters.Add("@cname", customerNameTextBox.Text);
                        command.Parameters.Add("@phone", customerMobileTextBox.Text);
                        command.Parameters.Add("@bookName", bookNameTextBox.Text);
                        command.Parameters.Add("@writer", writerNameTextBox.Text);
                        command.Parameters.Add("@edition", bookEditionTextBox.Text);
                        command.Parameters.Add("@print", bookPrintTextBox.Text);
                        command.Parameters.Add("@quantity", quantity);
                        command.Parameters.Add("@buyUnitprice", Convert.ToDouble(BuyUnitPrice));
                        command.Parameters.Add("@unitpricecell", unitprice);
                        command.Parameters.Add("@advance", advance);
                        command.Parameters.Add("@due", due);
                        command.Parameters.Add("@payingAmount", pay);
                        command.Parameters.Add("@finaldue", final_Due);
                        command.Parameters.Add("@date", DateTime.Now.ToShortDateString());                      
                         command.ExecuteNonQuery();
                          connection.Close();
                        
                         
                         DBManager manager5 = new DBManager();
                SqlConnection connection5 = manager5.Connection();
                string selectQuery5 = "SELECT Quantity,Unit_Price From Orders where Order_No=@serial";

                SqlCommand cmd5 = new SqlCommand(selectQuery5, connection5);
                        cmd5.Parameters.Clear();
                        cmd5.Parameters.AddWithValue("@serial", serial_No);
                connection5.Open()
                    ;
                SqlDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    string q = reader5[0].ToString();
                    string r = reader5[1].ToString();
                     if (q.Equals("") && r.Equals(""))
                    {
                        qunatityOfRemaingBook = 0;
                        unit_Price = 0;
                    }
                    else
                    {
                        qunatityOfRemaingBook = Convert.ToInt16(q);
                        unit_Price = Convert.ToDouble(r);
                    }
                }
                connection.Close();
            
           //Due Collection table Update
                        double s_due = Convert.ToDouble(dueTextBox.Text) - Convert.ToDouble(payingAmountTextBOX.Text);

                DBManager manager6 = new DBManager();
                SqlConnection connection6 = manager6.Connection();
                string selectQuery6 = "insert into  Due_Collection values(@pay,@s_due,@payCollection,@date)";
              
                SqlCommand cmd6 = new SqlCommand(selectQuery6, connection6);
                connection6.Open()
                    ;
                cmd6.Parameters.Clear();
                cmd6.Parameters.Add("@pay", "0");
                cmd6.Parameters.Add("@s_due", s_due);
                        cmd6.Parameters.AddWithValue("@payCollection", pay);
                cmd6.Parameters.Add("@date", DateTime.Now.ToShortDateString());

                        cmd6.ExecuteNonQuery();

                        int sa = qunatityOfRemaingBook - quan;

                        string deleteQuery = "Update Orders set Quantity=@quantity,Total_price=@totalprice, Due=@due where Order_No=@serial";

                       
                        SqlCommand command1 = new SqlCommand(deleteQuery, connection);
                        command1.Parameters.Clear();
                        command1.Parameters.AddWithValue("@quantity", sa);
                        command1.Parameters.AddWithValue("@totalprice", (sa*unit_Price));
                        command1.Parameters.AddWithValue("@due", final_Due);
                        command1.Parameters.AddWithValue("@serial", serial_No);
                        connection.Open();
                        int x = command1.ExecuteNonQuery();
                        MessageBox.Show(customerNameTextBox.Text + " Your current due is "+final_Due+".", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        connection.Close();

                        //books update 
                        string name = (bookNameTextBox.Text).Trim();
                        string writer = writerNameTextBox.Text;
                        string edition = bookEditionTextBox.Text;
                        
                        string selectQ = "select  Quantiy,B_Unit_Price from Books where Name=@name and Edition=@edition and Writer=@writer";



                        SqlCommand sletCom = new SqlCommand(selectQ, connection);

                        sletCom.Parameters.Clear();
                        sletCom.Parameters.AddWithValue("@name", name);
                        sletCom.Parameters.AddWithValue("@edition", edition);
                        sletCom.Parameters.AddWithValue("@writer", writer);
                        
                        connection.Open();
                        SqlDataReader reader = sletCom.ExecuteReader();
                        while (reader.Read())
                        {
                            int quantity4 = Convert.ToInt16(reader[0]);
                            double unitprice5 = Convert.ToDouble(reader[1]);
                            connection.Close();

                            int quantityReudceBook, final_quantity;
                            quantityReudceBook = Convert.ToInt16(bookQuantityTextBOx.Text);
                            final_quantity = quantity4 - quantityReudceBook;
                            double T_Price = final_quantity*unitprice5;

                            string updateQuery = "UPDATE Books set Quantiy=@finalQuantity,Total_Price=@totalprice where Name=@name and Edition=@edition and Writer=@writer";


                            SqlCommand upCommand = new SqlCommand(updateQuery, connection);
                            upCommand.Parameters.Clear();
                            upCommand.Parameters.AddWithValue("@finalQuantity", final_quantity);
                            upCommand.Parameters.AddWithValue("@totalprice", T_Price);
                            upCommand.Parameters.AddWithValue("@name", name);
                            upCommand.Parameters.AddWithValue("@edition", edition);
                            upCommand.Parameters.AddWithValue("@writer", writer);
                            connection.Open();
                            upCommand.ExecuteNonQuery();


                            //for partial pay



                            TempOrder anOrder = new TempOrder(serialTextBox.Text, customerNameTextBox.Text, customerMobileTextBox.Text, bookNameTextBox.Text, writerNameTextBox.Text, bookEditionTextBox.Text, bookPrintTextBox.Text, Convert.ToInt16(bookQuantityTextBOx.Text), Convert.ToDouble(bookUnitPriceTextBOx.Text
                                ), Convert.ToDouble(Convert.ToInt16(bookQuantityTextBOx.Text) * Convert.ToDouble(bookUnitPriceTextBOx.Text)), Convert.ToDouble(advanceTextBox.Text),final_Due, Convert.ToDouble(payingAmountTextBOX.Text),memoNumver);
                            TempOrderGateway gateway = new TempOrderGateway();

                            gateway.SaveDeliveryReport(anOrder);




                           GetAllOrders();
                            GetAllOrders1();
                            ClearAllTextBox();
                            connection.Close();
                            MessageBox.Show("Updated","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                           return;
                        }
                    }
                }
            }
            catch (Exception formatException)
            {

                MessageBox.Show(formatException.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ClearAllTextBox()
        {
           serialTextBox.Clear();
            bookNameTextBox.Clear();
            bookEditionTextBox.Clear();
            bookQuantityTextBOx.Clear();
            bookUnitPriceTextBOx.Clear();
            writerNameTextBox.Clear();
            advanceTextBox.Clear();
            payingAmountTextBOX.Clear();
            dueTextBox.Clear();
            bookPrintTextBox.Clear();
            customerMobileTextBox.Clear();
            customerNameTextBox.Clear();
            buyingUnitPriceTextBox.Clear();
        }

        private void bookQuantityTextBOx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void payingAmountTextBOX_KeyPress(object sender, KeyPressEventArgs e)
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
            data.RowFilter = string.Format("Customer_Name LIKE '%{0}%'", textBox1.Text);
            dataGridView2.DataSource = data;
        }

        private void ShowOrderUI_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                TempOrderGateway aGateway = new TempOrderGateway();
                List<TempOrder> aList = aGateway.GeList();
                ReportDeliveryUI report = new ReportDeliveryUI(aList);
                report.ShowDialog();

                System.Windows.Forms.DialogResult dialog = MessageBox.Show("Did you print the document?", "Print Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    String deletequery = "delete from Temp_Order_Delivery";
                    SqlCommand command1 = new SqlCommand(deletequery, connection);
                    connection.Open();
                    command1.ExecuteNonQuery();
                    string que = "DBCC CHECKIDENT (Temp_Order_Delivery,Reseed,0)";
                    command1 = new SqlCommand(que, connection);
                    command1.ExecuteNonQuery();
                    string que1 = "set identity_insert Temp_Order_Delivery on";
                    command1 = new SqlCommand(que1, connection);
                    command1.ExecuteNonQuery();
                    string insQuery = "insert into Deliveri_Memo_Counter values(@date)";
                    command1 = new SqlCommand(insQuery, connection);
                    command1.Parameters.Clear();
                    command1.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    command1.ExecuteNonQuery();
                    memoNumver = GetLastMemoNumber();
                }
                else if (dialog == DialogResult.No)
                {
                    System.Windows.Forms.DialogResult dialog1 = MessageBox.Show("Are you want to print now?",
                        "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog1 == DialogResult.Yes)
                    {
                        report = new ReportDeliveryUI(aList);
                        report.ShowDialog();
                        String deletequery = "delete from Temp_Order_Delivery";
                        SqlCommand command1 = new SqlCommand(deletequery, connection);
                        connection.Open();
                        command1.ExecuteNonQuery();

                        string que = "DBCC CHECKIDENT (Temp_Order_Delivery,Reseed,0)";
                        command1 = new SqlCommand(que, connection);
                        command1.ExecuteNonQuery();
                        string que1 = "set identity_insert Temp_Order_Delivery on";
                        command1 = new SqlCommand(que1, connection);
                        command1.ExecuteNonQuery();
                        string insQuery = "insert into Deliveri_Memo_Counter values(@date)";
                        command1 = new SqlCommand(insQuery, connection);
                        command1.Parameters.Clear();
                        command1.Parameters.AddWithValue("@date", DateTime.Now.Date);
                        command1.ExecuteNonQuery();

                        memoNumver = GetLastMemoNumber();

                        DialogResult d2 = MessageBox.Show(" Print Sucessful! Are you want ot exit? ", "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (d2 == DialogResult.Yes)
                        {
                            this.Close();
                        }
                        else if (d2 == DialogResult.No)
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
            catch (Exception exception)
            {
                
                  MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            
        }

        
    }
}
