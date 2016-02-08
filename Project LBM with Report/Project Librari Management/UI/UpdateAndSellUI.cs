using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project_Librari_Management.DAL.DAO;
using System.Data.SqlClient;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class UpdateAndSellUI : Form
    {
        Book newBook;
        private string b_type, book_Print;
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
            book_Print = newBook.BookPrint;
            string s = book_Print.Trim();
            foreach (var bP   in groupBox4.Controls)
            {
                RadioButton button = (RadioButton) bP;
                if (button.Text.Equals(s))
                {
                    button.Checked = true;
                }
            }
            int a= newBook.Quantity;
            double b = newBook.UnitPrice;
            quantityTextBox.Text = a.ToString();

            uintPriceTextBox.Text = b.ToString();
            dateTimePiker.Text = newBook.PurchasesDate;
            memoNumver = GetLastMemoNumber();
        }


        private int memoNumver;
        private void updateButton(object sender, EventArgs e)
        {
            UpdateBookInfo();
            GetAll();
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
                String updateQuery = "update Books set Name=@name,Writer=@writer,Edition=@edition,Type=@type,Book_Print=@print,Quantiy=@quantity,B_Unit_Price=@bunitprice,Total_Price=@total,Purchase_Date=@date where [S.No]=@serial";
               
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                connection.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("@writer", writernameTextBox.Text);
                cmd.Parameters.AddWithValue("@edition", editionTextBox.Text);
                cmd.Parameters.AddWithValue("@type", b_type);
                cmd.Parameters.AddWithValue("@print", book_Print);
                cmd.Parameters.AddWithValue("@quantity", toatalQuantity);
                cmd.Parameters.AddWithValue("@bunitprice", uintPriceTextBox.Text);
                cmd.Parameters.AddWithValue("@total", T_Price);
                cmd.Parameters.AddWithValue("@date", dateTimePiker.Text);
                cmd.Parameters.AddWithValue("@serial", newBook.SerialNo);
                cmd.ExecuteNonQuery();
                
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show(i + " Row updated","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                
             double total, unitPrice, totalBookPrice;
            int a, b,quantity;
            
              
                int toatalQuantity;
                a = Convert.ToInt16(quantityTextBox.Text);
                b = Convert.ToInt16(quantitySellTextBox.Text);

                if (a <= 0 || (a < Convert.ToInt16(quantitySellTextBox.Text)))
                {
                    MessageBox.Show("There are no available book for sell.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toatalQuantity = a;
                    //return;
                }
               
               
                {
                    toatalQuantity = Convert.ToInt16(a - b);   
                }
               

                DBManager manager3 = new DBManager();
                SqlConnection connection3 = manager3.Connection();
                string selectQuery1 = "select Quantiy,B_Unit_Price,Total_Price from Books where [S.No]=@serialNo";
              
                connection3.Open();
                SqlCommand cmd3 = new SqlCommand(selectQuery1, connection3);
                cmd3.Parameters.Clear();
               
                cmd3.Parameters.AddWithValue("@serialNo", serialTextBox.Text);
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
                double total_Price = ((abook.UnitPrice*abook.Quantity) - (b*abook.UnitPrice));
                String updateQuery = "update Books set Name=@name,Writer=@writer,Edition=@edition,Type=@type,Book_Print=@print,Quantiy=@quantity,B_Unit_Price=@bunitprice,Total_Price=@total,Purchase_Date=@date where [S.No]=@serial";
               
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                connection.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name",nameTextBox.Text );
                 cmd.Parameters.AddWithValue("@writer", writernameTextBox.Text);
                cmd.Parameters.AddWithValue("@edition",editionTextBox.Text );
                 cmd.Parameters.AddWithValue("@type",b_type );
                cmd.Parameters.AddWithValue("@print", book_Print);
                 cmd.Parameters.AddWithValue("@quantity",toatalQuantity );
                cmd.Parameters.AddWithValue("@bunitprice", uintPriceTextBox.Text);
                 cmd.Parameters.AddWithValue("@total",total_Price );
                cmd.Parameters.AddWithValue("@date", dateTimePiker.Text);
                cmd.Parameters.AddWithValue("@serial", newBook.SerialNo);
                 cmd.ExecuteNonQuery();
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
                string insertQuery = "Insert into sell_Counter values(@serial,@name,@writer,@edition,@type,@print,@quantity,@unitpricesell,@totalpricesell,@unitpriceBuy,@buy_total,@paytotal,@dueTotal,@benifitTotal,@lossTotal,@pdate)";

                SqlCommand insCmd = new SqlCommand(insertQuery, connection);
                connection.Open();
                insCmd.Parameters.Clear();
                insCmd.Parameters.Add("@serial", serialTextBox.Text);
                insCmd.Parameters.Add("@name", nameTextBox.Text);
                insCmd.Parameters.Add("@writer", writernameTextBox.Text);
                insCmd.Parameters.Add("@edition", editionTextBox.Text);
                insCmd.Parameters.Add("@type", b_type);
                insCmd.Parameters.Add("@print", book_Print);
                insCmd.Parameters.Add("@quantity", quantitySellTextBox.Text);
                insCmd.Parameters.Add("@unitpricesell", unitpriceSellTextBox.Text);
                insCmd.Parameters.Add("@totalpricesell", totalTextBox.Text);
                insCmd.Parameters.Add("@unitpriceBuy", uintPriceTextBox.Text);
                insCmd.Parameters.Add("@buy_total", buy_total);
                insCmd.Parameters.Add("@paytotal", payTextBox.Text);
                insCmd.Parameters.Add("@dueTotal", due);
                insCmd.Parameters.Add("@benifitTotal", benifit);
                insCmd.Parameters.Add("@lossTotal", loss);
                insCmd.Parameters.Add("@pdate",DateTime.Now.ToShortDateString());
                double x, y;
                x = Convert.ToDouble(totalTextBox.Text);
                y = Convert.ToDouble(payTextBox.Text);
               
                if (y>x)
                {
                    MessageBox.Show("Please check the paying amount.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                
                else
                {
                   int i=insCmd.ExecuteNonQuery();

                    MessageBox.Show("Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (i == 1)
                    {
                        string query = "Insert Into Temp_Sell_Counter values(@bookname,@writerName,@edition,@type,@print,@quantity,@unitprice,@total,@pay,@due,@memoNumber)";
                        SqlCommand command=new SqlCommand(query,connection);
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@bookname", nameTextBox.Text);
                        command.Parameters.AddWithValue("@writerName", writernameTextBox.Text);
                        command.Parameters.AddWithValue("@edition",editionTextBox.Text);
                        command.Parameters.AddWithValue("@type",b_type);
                        command.Parameters.AddWithValue("@print",book_Print);
                        command.Parameters.AddWithValue("@quantity",Convert.ToInt16(quantitySellTextBox.Text));
                        command.Parameters.AddWithValue("@unitprice",Convert.ToDouble(unitpriceSellTextBox.Text));
                        command.Parameters.AddWithValue("@total",Convert.ToDouble(totalTextBox.Text));
                        command.Parameters.AddWithValue("@pay",Convert.ToDouble(payTextBox.Text));
                        //if (dueTextBox.Text.Equals("")||dueTextBox.Text.Equals("0"))
                        //{
                           command.Parameters.AddWithValue("@due", due);
                        command.Parameters.AddWithValue("@memoNumber", memoNumver+1);
                       
                        

                        command.ExecuteNonQuery();


                    }
                    GetAll();
                    dueTextBox.Text = due.ToString();    
                }
                        

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

       
        

       
        public void totalBookBuyAmount(double x)
        {
            double y = x;
        }

          private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double p, q;
                int a, b=0,t;
                quantity = Convert.ToInt16(quantitySellTextBox.Text);
                double unitprice = Convert.ToDouble(unitpriceSellTextBox.Text);
                p = Convert.ToDouble(uintPriceTextBox.Text);
                q = Convert.ToDouble(unitpriceSellTextBox.Text);
                a = Convert.ToInt16(quantityTextBox.Text);
                //b = Convert.ToInt16(quantitySellTextBox.Text);

                //select Quantity form Order

                string name = nameTextBox.Text;
                string writer = writernameTextBox.Text;
                string edition = editionTextBox.Text;
                if (name.Contains("'"))
                {
                    name = name.Replace("'", "''");
                }
                if (writer.Contains("'"))
                {
                    writer = writer.Replace("'", "''");
                }
                if (edition.Contains("'"))
                {
                    edition = edition.Replace("'", "''");
                }



                DBManager manager3 = new DBManager();
                SqlConnection connection3 = manager3.Connection();
                string selectQuery = string.Format("SELECT  sum(Quantity) from Orders where Book_Name='" + name + "' and Writer='" + writer + " ' and Edition='" + edition + "'");
                connection3.Open();
                SqlCommand cmd3 = new SqlCommand(selectQuery, connection3);
                SqlDataReader reader1 = cmd3.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1[0].ToString().Equals("0") || reader1[0].ToString().Equals(""))
                    {
                        b = 0;
                    }
                    else
                    {
                        b = Convert.ToInt16(reader1[0]);   
                    }
                   
                }
                
                if (a <= 0 || (a < Convert.ToInt16(quantitySellTextBox.Text)))
                {
                    MessageBox.Show("There are no available book for sell..", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //toatalQuantity = a;
                    //return;
                }
                else if (a > 0)
                {
                    if (b >= a)
                    {
                        t = b - a;
                        MessageBox.Show("There are " + t + " book less than order. So,Please do not sell.", "Sorry",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (a > b)
                    {
                        t = a - b;
                        if (t>=quantity)
                        {
                            sell_total = quantity * unitprice;
                            totalTextBox.Text = sell_total.ToString();
                            MessageBox.Show("Your total cost is : " + sell_total + " Tk", "Message", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);  
                        }
                        else
                        {
                            MessageBox.Show("There are " + t + "  pices  available book for sell.", "Sorry",
                              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                        }
                        
                    }




                    else if (p > q)
                    {
                        MessageBox.Show("Please check the buying unit price.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        sell_total = quantity*unitprice;
                        totalTextBox.Text = sell_total.ToString();
                        MessageBox.Show("Your total cost is : " + sell_total + " Tk", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }



                }

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

          
          private void uintPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
          {
              char ch = e.KeyChar;
              if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
              {
                  e.Handled = true;
              }
          }

          private void quantitySellTextBox_KeyPress(object sender, KeyPressEventArgs e)
          {
              char ch = e.KeyChar;
              if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
              {
                  e.Handled = true;
              }
          }

          private void unitpriceSellTextBox_KeyPress(object sender, KeyPressEventArgs e)
          {
              char ch = e.KeyChar;
              if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
              {
                  e.Handled = true;
              }
          }

          private void payTextBox_KeyPress(object sender, KeyPressEventArgs e)
          {
              char ch = e.KeyChar;
              if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
              {
                  e.Handled = true;
              }
          }

        public void GetAll()
        {
            try
            {
                DBManager manager3 = new DBManager();
                SqlConnection connection3 = manager3.Connection();
                string selectQuery1 = "select * from Books where [S.No]='" + serialTextBox.Text + "'";
                connection3.Open();
                SqlCommand cmd3 = new SqlCommand(selectQuery1, connection3);
                SqlDataReader reader1 = cmd3.ExecuteReader();

                Book abook = new Book();
                while (reader1.Read())
                {

                    nameTextBox.Text = reader1[1].ToString();
                    writernameTextBox.Text = reader1[2].ToString();
                    editionTextBox.Text = reader1[3].ToString();
                    string type = reader1[4].ToString();
                    string print = reader1[5].ToString();

                    quantityTextBox.Text = Convert.ToInt16(reader1[6]).ToString();
                    uintPriceTextBox.Text = Convert.ToDouble(reader1[7]).ToString();
                    foreach (var control in groupBox2.Controls)
                    {
                        RadioButton radio = (RadioButton)control;
                        if (type.Equals(radio.Text))
                        {
                            radio.Checked = true;
                        }
                    }
                    foreach (var control in groupBox4.Controls)
                    {
                        RadioButton radio = (RadioButton)control;
                        if (print.Equals(radio.Text))
                        {
                            radio.Checked = true;
                        }
                    }
                }
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
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                String query = "select * from Temp_Sell_Counter";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                List<TempSell> tempSells = new List<TempSell>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt16(reader[0]);
                    string bookname = reader[1].ToString();
                    string writer = reader[2].ToString();
                    string edition = reader[3].ToString();
                    string type = reader[4].ToString();
                    string print = reader[5].ToString();
                    int quantity = Convert.ToInt16(reader[6]);
                    double unitpirce = Convert.ToDouble(reader[7]);
                    double total = Convert.ToDouble(reader[8]);
                    double pay = Convert.ToDouble(reader[9]);
                    double due = Convert.ToDouble(reader[10]);
                    int memoNumber = Convert.ToInt16(reader[11]);
                    TempSell aSell = new TempSell();
                    aSell.Id = id;
                    aSell.BookName = bookname;
                    aSell.WriterName = writer;
                    aSell.Edition = edition;
                    aSell.Type = type;
                    aSell.Print = print;
                    aSell.Quantity = quantity;
                    aSell.Unitprice = unitpirce;
                    aSell.Total = total;
                    aSell.Pay = pay;
                    aSell.Due = due;
                    aSell.Memonumber = memoNumber;
                    tempSells.Add(aSell);
                }

                connection.Close();
                SellReprotUI sellReprot = new SellReprotUI(tempSells);
                sellReprot.ShowDialog();
                System.Windows.Forms.DialogResult dialog = MessageBox.Show("Did you print the document?", "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                SqlCommand command1;
                String deletequery = "delete from Temp_Sell_Counter";
                if (dialog == DialogResult.Yes)
                {

                    command1 = new SqlCommand(deletequery, connection);
                    connection.Open();
                    command1.ExecuteNonQuery();

                    string que = "DBCC CHECKIDENT (Temp_Sell_Counter,Reseed,0)";
                    command1 = new SqlCommand(que, connection);
                    command1.ExecuteNonQuery();
                    string que1 = "set identity_insert Temp_Sell_Counter on";
                    command1 = new SqlCommand(que1, connection);
                    command1.ExecuteNonQuery();

                    string insQuery = "insert into Memo_Counter values(@date)";
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
                        sellReprot = new SellReprotUI(tempSells);
                        sellReprot.ShowDialog();
                        connection.Open();
                        command1 = new SqlCommand(deletequery, connection);
                        command1.ExecuteNonQuery();
                        string que = "DBCC CHECKIDENT (Temp_Sell_Counter,Reseed,0)";
                        command1 = new SqlCommand(que, connection);
                        command1.ExecuteNonQuery();
                        string que1 = "set identity_insert Temp_Sell_Counter on";
                        command1 = new SqlCommand(que1, connection);
                        command1.ExecuteNonQuery();

                        string insQuery = "insert into Memo_Counter values(@date)";
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
        private int GetLastMemoNumber()
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQ = "select MAX(Memo_No) from Memo_Counter";
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

            }
            catch (Exception exception)
            {
                
                  MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



            return memoNumver;
        }
    }
}
