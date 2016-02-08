using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.DAL.DAO;
using System.Data.SqlClient;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class UpdateAndSellUI : Form
    {
        Book newBook;
        string b_type;
        double sell_total;
        int quantity;
        
        public UpdateAndSellUI(Book aBook)
        {
            this.newBook = aBook;
            InitializeComponent();
            serialTextBox.Text = newBook.SerialNo;
            nameTextBox.Text = newBook.BookName;
            writernameTextBox.Text = newBook.AuthorName;
            editionTextBox.Text = newBook.Edition;
            if (radioButton1.Text.Equals(newBook.TypeOfBook))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            int a= newBook.Quantity;
            double b = newBook.UnitPrice;
            quantityTextBox.Text = a.ToString();

            uintPriceTextBox.Text = b.ToString();
            dateTimePiker.Text = newBook.PurchasesDate;
            
        }

        

        private void updateButton(object sender, EventArgs e)
        {
            UpdateBookInfo();
            ClearALLTextBox();
        }

        public  void UpdateBookInfo()
        {
            try
            {

                //start  here 
                DBManager manager2 = new DBManager();
                SqlConnection connection2 = manager2.Connection();
                string selectQuery = "select Quantiy,B_Unit_Price,Total_Price from Books where [S.No]='" + serialTextBox.Text + "'";
                connection2.Open();
                SqlCommand cmd2 = new SqlCommand(selectQuery, connection2);
                SqlDataReader reader = cmd2.ExecuteReader();
                List<Book> sellBooks = new List<Book>();
                while (reader.Read())
                {
                   
                    quantity = Convert.ToInt16(reader[0]);
                    double unitPrice = Convert.ToDouble(reader[1]);
                    double T_Price;


                int toatalQuantity = quantity + (Convert.ToInt16(quantityTextBox.Text));
                    T_Price = toatalQuantity*unitPrice;
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string updateQuery = "UPDATE Books SET Name='" + nameTextBox.Text + "',Writer='" + writernameTextBox.Text + "',Edition='" + editionTextBox.Text + "',Type='" + b_type + "',Quantiy='" + toatalQuantity + "',B_Unit_Price='" + uintPriceTextBox.Text + "',Total_Price='"+T_Price+"',Purchase_Date='" + dateTimePiker.Text + "' where [S.No]='" + serialTextBox.Text + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Row updated");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //sell Button

               private void SellButton(object sender, EventArgs e)
        {

            try
            {
                double unitPrice;
            double total;
            int a, b,quantity;
            double totalBookPrice;
              
                int toatalQuantity;
                a = Convert.ToInt16(quantityTextBox.Text);
                b = Convert.ToInt16(quantitySellTextBox.Text);
                if (a <= 0 ||( a<Convert.ToInt16(quantitySellTextBox.Text)))
                {
                    MessageBox.Show("There are no available book for sell.","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    toatalQuantity = a;
                    return;
                }
                
                {
                    toatalQuantity = Convert.ToInt16(a - b);
                }

                DBManager manager3 = new DBManager();
                SqlConnection connection3 = manager3.Connection();
                string selectQuery1 = "select Quantiy,B_Unit_Price,Total_Price from Books where [S.No]='" + serialTextBox.Text + "'";
                connection3.Open();
                SqlCommand cmd3 = new SqlCommand(selectQuery1, connection3);
                SqlDataReader reader1 = cmd3.ExecuteReader();
               
                Book abook = new Book();
                while (reader1.Read())
                {

                    quantity = Convert.ToInt16(reader1[0]);
                    unitPrice = Convert.ToDouble(reader1[1]);
                    total = Convert.ToDouble(reader1[2]);
                   
                    abook.Quantity = quantity;
                    abook.UnitPrice = unitPrice;

                    totalBookPrice = total - (unitPrice * Convert.ToInt16(quantitySellTextBox.Text));
                    totalBookBuyAmount(totalBookPrice);
                }
                


                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string updateQuery = "UPDATE Books SET Name='" + nameTextBox.Text + "',Writer='" + writernameTextBox.Text + "',Edition='" + editionTextBox.Text + "',Type='" + b_type + "',Quantiy='" + toatalQuantity + "',B_Unit_Price='" + uintPriceTextBox.Text + "',Total_Price='" + ((abook.UnitPrice*abook.Quantity)-(b*abook.UnitPrice))+ "',Purchase_Date='" + dateTimePiker.Text + "' where [S.No]='" + newBook.SerialNo + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                                     
                double unitprice, pay, due;
                
                double benifit,loss;
                double buy_total =Convert.ToDouble(uintPriceTextBox.Text)*Convert.ToDouble(quantitySellTextBox.Text);
               
               
                quantity = Convert.ToInt16(quantitySellTextBox.Text);
                unitprice = Convert.ToDouble(unitpriceSellTextBox.Text);
                
                pay = Convert.ToDouble(payTextBox.Text);
                due = sell_total - Convert.ToDouble(payTextBox.Text);


                if (pay <sell_total)
                {
                    loss = buy_total- pay;
                    benifit = 0;
                }
                else
                {
                    benifit =  pay-buy_total;
                    loss = 0;
                }
                
                string insertQuery = "Insert into sell_Counter values('" + serialTextBox.Text + "','" + nameTextBox.Text + "','" + writernameTextBox.Text + "','" + editionTextBox.Text + "','" + b_type + "','" + quantitySellTextBox.Text + "','" + unitpriceSellTextBox.Text + "','" + totalTextBox.Text + "','" + uintPriceTextBox.Text + "','" + buy_total + "','"+payTextBox.Text+"','"+due+"','" + benifit + "','" + loss + "','" + DateTime.Today.ToShortDateString() + "')";
                SqlCommand insCmd = new SqlCommand(insertQuery, connection);
                connection.Open();
                int c = insCmd.ExecuteNonQuery();
                MessageBox.Show("Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dueTextBox.Text = due.ToString();           

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
            }

               private void ClearALLTextBox()
               {
                   unitpriceSellTextBox.Clear();
                   quantitySellTextBox.Clear();
                   totalTextBox.Clear();
                   serialTextBox.Clear();
                   nameTextBox.Clear();
                   writernameTextBox.Clear();
                   editionTextBox.Clear();
                   radioButton1.Checked = false;
                   radioButton2.Checked = false;
                   quantityTextBox.Clear();
                   uintPriceTextBox.Clear();
                   payTextBox.Clear();
                   dueTextBox.Clear();

               }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            b_type = "New";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            b_type = "Old";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            editionTextBox.Clear();
            editionTextBox.Text = comboBox1.SelectedItem.ToString();
        }

        

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenuUI homeUI = new MainMenuUI("0","0");
            this.Hide();
            homeUI.ShowDialog();
        }
        public void totalBookBuyAmount(double x)
        {
            double y = x;
        }

          private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                quantity = Convert.ToInt16(quantitySellTextBox.Text);
                double unitprice = Convert.ToDouble(unitpriceSellTextBox.Text);
                sell_total = quantity * unitprice;
                totalTextBox.Text = sell_total.ToString();
                MessageBox.Show("Your total cost is : " + sell_total+ " Tk","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (FormatException formatException)
            {

                MessageBox.Show(formatException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

          private void button1_Click(object sender, EventArgs e)
          {
              try
              {
                  double dueAmount = Convert.ToDouble(dueTextBox.Text);
                  DueRecord dueRecord = new DueRecord(dueAmount);
                  dueRecord.ShowDialog();
              }
              catch (FormatException formatException)
              {

                  MessageBox.Show(formatException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }

          }

          private void clearAllButton_Click(object sender, EventArgs e)
          {
              ClearALLTextBox();
          }
    }
}
