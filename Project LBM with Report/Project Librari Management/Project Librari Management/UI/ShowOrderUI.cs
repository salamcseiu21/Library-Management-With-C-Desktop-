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
    public partial class ShowOrderUI : Form
    {
        public ShowOrderUI()
        {
            InitializeComponent();
            GetAllOrders();
        }

        DataTable dataTable;
        public int qunatityOfRemaingBook, quan;
        public double unit_Price;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                bookQuantityTextBOx.Text = row.Cells["Quantity"].Value.ToString();
                bookUnitPriceTextBOx.Text = row.Cells["Unit_Price"].Value.ToString();
                advanceTextBox.Text = row.Cells["Advance"].Value.ToString();
                dueTextBox.Text = row.Cells["Due"].Value.ToString();
                buyingUnitPriceTextBox.Text = row.Cells["Buy_Unit_Price"].Value.ToString();

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView data = new DataView(dataTable);
            data.RowFilter = string.Format("Customer_Name LIKE '%{0}%'", textBox1.Text);
            dataGridView2.DataSource = data;
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


                    if (dueTextBox.Text.Equals("")&&payingAmountTextBOX.Text.Equals(""))
                    {
                        MessageBox.Show("There are no order for delivery.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
                        string insertQuery = "INSERT INTO Delivery_Report values('" + serialTextBox.Text + "','" +
                                             customerNameTextBox.Text + "','" + customerMobileTextBox.Text + "','" +
                                             bookNameTextBox.Text + "','" + writerNameTextBox.Text + "','" +
                                             bookEditionTextBox.Text + "','" + quantity + "','" + Convert.ToDouble(BuyUnitPrice) + "','" + unitprice +
                                             "','" + advance + "','" + due + "','" +
                                             pay + "','" + (final_Due) + "','" +
                                             DateTime.Now.ToShortDateString() + "')";


                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        connection.Open();
                        int i = command.ExecuteNonQuery();

                        DBManager manager6 = new DBManager();
                        SqlConnection connection6 = manager6.Connection();

                        string selectQuery6 = "insert into  Due_Collection values('" + pay + "','" + 0 + "','"+DateTime.Now.ToShortDateString()+"')";
                        SqlCommand cmd6 = new SqlCommand(selectQuery6, connection6);
                        connection6.Open()
                            ;

                        int ix = cmd6.ExecuteNonQuery();

                         connection.Close();
                        string deleteQuery = "delete from Orders where Order_No='" + serial_No + "'";
                        SqlCommand command1 = new SqlCommand(deleteQuery, connection);
                        connection.Open();
                        int x = command1.ExecuteNonQuery();
                        MessageBox.Show(customerNameTextBox.Text + " paid his/her due.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();


                        //update books
                        string selectQ = "select Quantiy,B_Unit_Price from Books where Name='" + bookNameTextBox.Text +
                                         "'and Edition='" + bookEditionTextBox.Text + "'and Writer='"+writerNameTextBox.Text+"'";
                        SqlCommand sletCom = new SqlCommand(selectQ, connection);
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
                            string updateQuery = "UPDATE Books set Quantiy='" + final_quantity + "',Total_Price='" +
                                                 T_Price +
                                                 "' where Name='" + bookNameTextBox.Text + "'and Edition='" +
                                                 bookEditionTextBox.Text + "' and Writer='"+writerNameTextBox.Text+"'";
                            SqlCommand upCommand = new SqlCommand(updateQuery, connection);
                            connection.Open();
                            int s = upCommand.ExecuteNonQuery();
                            MessageBox.Show("Updated");




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
                    if (dueTextBox.Text.Equals("0") || payingAmountTextBOX.Text.Equals("0"))
                    {
                        final_Due = 0;
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
                        string insertQuery = "INSERT INTO Delivery_Report values('" + serialTextBox.Text + "','" +
                                             customerNameTextBox.Text + "','" + customerMobileTextBox.Text + "','" +
                                             bookNameTextBox.Text + "','" + writerNameTextBox.Text + "','" +
                                             bookEditionTextBox.Text + "','" + quantity + "','"+BuyUnitPrice+"','" + unitprice +
                                             "','" + advance + "','" + due + "','" +
                                             pay + "','" + final_Due + "','" +
                                             DateTime.Now.ToShortDateString() + "')";
                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        connection.Open();
                        int i = command.ExecuteNonQuery();
                       
                        connection.Close();
                        

                         
                         DBManager manager5 = new DBManager();
                SqlConnection connection5 = manager5.Connection();

                string selectQuery5 = "SELECT Quantity,Unit_Price From Orders where Order_No='" + serial_No + "'";
                SqlCommand cmd5 = new SqlCommand(selectQuery5, connection5);
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

                string selectQuery6 = "insert into  Due_Collection values('"+payingAmountTextBOX.Text+"','"+s_due+"','"+DateTime.Now.ToShortDateString()+"')";
                SqlCommand cmd6 = new SqlCommand(selectQuery6, connection6);
                connection6.Open()
                    ;

                        int ix = cmd6.ExecuteNonQuery();

                        int sa = qunatityOfRemaingBook - quan;
                        string deleteQuery = "Update Orders set Quantity='" + (sa) + "',Total_price='"+(sa*unit_Price)+"', Due='" + final_Due + "' where Order_No='" + serial_No + "'";
                        SqlCommand command1 = new SqlCommand(deleteQuery, connection);
                        connection.Open();
                        int x = command1.ExecuteNonQuery();
                        MessageBox.Show(customerNameTextBox.Text + " Your current due is "+final_Due+".", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        connection.Close();

                        //books update 
                        string selectQ = "select Quantiy,B_Unit_Price from Books where Name='" + bookNameTextBox.Text +
                                         "'and Edition='" + bookEditionTextBox.Text + "' and Writer='"+writerNameTextBox.Text+"'";
                        SqlCommand sletCom = new SqlCommand(selectQ, connection);
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
                            string updateQuery = "UPDATE Books set Quantiy='" + final_quantity + "',Total_Price='" +
                                                 T_Price + "' where Name='" + bookNameTextBox.Text + "'and Edition='" +
                                                 bookEditionTextBox.Text + "' and Writer='"+writerNameTextBox.Text+"'";
                            SqlCommand upCommand = new SqlCommand(updateQuery, connection);
                            connection.Open();
                            int s = upCommand.ExecuteNonQuery();
                           // MessageBox.Show("Updated");
                            GetAllOrders();
                            GetAllOrders1();
                            ClearAllTextBox();
                            connection.Close();
                            return;
                        }
                    }
                }
            }
            catch (SqlException formatException)
            {

                MessageBox.Show(formatException.Message);
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
            customerMobileTextBox.Clear();
            customerNameTextBox.Clear();
            buyingUnitPriceTextBox.Clear();
        }

        
    }
}
