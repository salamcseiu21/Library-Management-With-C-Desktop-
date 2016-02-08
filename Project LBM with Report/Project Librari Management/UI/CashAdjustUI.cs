using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class CashAdjustUI : Form
    {
        DBManager manager=new DBManager();
       
        public CashAdjustUI()
        {
            InitializeComponent();
            
        }
        double 
                sell_Book,
                
                due_Coll,
                photocopy,
                addvance;

        private double addvance1, fromBook, ffcopy;

      

        private double GetPhotocopyIncome()
        {
            SqlConnection connection = manager.Connection();
            string query = "select SUM(Total_Amount)as Photocopy from Photocopy where Copy_Date='" +
                           DateTime.Now.ToShortDateString() + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string total = reader[0].ToString();


                if (total.Equals("") || total.Equals("0"))
                {
                    photocopytextBox.Text = "0";
                    ffcopy = 0;

                }
                else
                {
                    photocopytextBox.Text = total;
                    ffcopy = Convert.ToDouble(total);
                }
            }
            return ffcopy;
        }

       

        private double GetsellAmountWithoutOrder()
        {
            SqlConnection connection = manager.Connection();
            string query = "select SUM(Collection)as T_Collection from sell_Counter where Sell_Date='" +
                           DateTime.Now.ToShortDateString() + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string total = reader[0].ToString();


                if (total.Equals("") || total.Equals("0"))
                {
                    sellAmountTextBox.Text = "0";
                    fromBook = 0;
                }
                else
                {
                    sellAmountTextBox.Text = total;
                    fromBook = Convert.ToDouble(total);
                }
            }
            return fromBook;
        }

      

       

        private void LoadAllcashButton(object sender, EventArgs e)
        {
         
            
            DBManager manager=new DBManager();
            SqlConnection connection = manager.Connection();
            string query = "select SUM(Collection)as T_Collection from sell_Counter where Sell_Date='" +
           
                           DateTime.Now.ToShortDateString() + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string total = reader[0].ToString();


                if (total.Equals("") || total.Equals("0"))
                {
                    sell_Book = 0;
                    
                }
                else
                {
                    sell_Book = Convert.ToDouble(total);
                   
                }

               
            }
           
            connection.Close();

            GetTotalDueCollection(connection);
            connection.Close();
            string query1 = "select SUM(Total_Amount)as Photocopy from Photocopy where Copy_Date='" +
                           DateTime.Now.ToShortDateString() + "'";

            SqlCommand command3 = new SqlCommand(query1, connection);
            connection.Open();
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                string total1 = reader3[0].ToString();


                if (total1.Equals("") || total1.Equals("0"))
                {
                    photocopy = 0 + due_Coll;
                   
                }
                else
                {
                    photocopy = Convert.ToDouble(total1)+due_Coll;
                   
                }
            }
           

            
            
          connection.Close();

            GetAdvanceAmount(connection);
        }

        private void GetAdvanceAmount(SqlConnection connection)
        {
            string selectQuery2 = "SELECT Sum(Advance) from Orders where Order_Date='" + DateTime.Now.ToShortDateString() + "'";
            SqlCommand cmd2 = new SqlCommand(selectQuery2, connection);
            connection.Open();
            SqlDataReader reader5 = cmd2.ExecuteReader();

            while (reader5.Read())
            {
                string a = reader5[0].ToString();
                if (a.Equals("") || a.Equals("0"))
                {
                    if (cashTextBox.Text.Equals("0") || cashTextBox.Text.Equals(""))
                    {
                        addvance = photocopy + 0;
                        richTextBox1.Text = addvance.ToString();
                        GetPhotocopyIncome();
                        GetsellAmountWithoutOrder();
                       
                        GetallDueCollection();
                        GetTotalAdvance();
                        
                    }
                    else
                    {
                        double dd = Convert.ToDouble(cashTextBox.Text);
                        addvance = dd - (photocopy + 0);
                        richTextBox1.Text = addvance.ToString();
                        GetPhotocopyIncome();
                        GetsellAmountWithoutOrder();
                       
                        GetallDueCollection();
                        GetTotalAdvance();
                    }

                    
                }


                else
                {
                    if (cashTextBox.Text.Equals("0") || cashTextBox.Text.Equals(""))
                    {
                        addvance = photocopy + 0;
                        richTextBox1.Text = addvance.ToString();
                        GetPhotocopyIncome();
                        GetsellAmountWithoutOrder();
                      
                        GetallDueCollection();
                        GetTotalAdvance();
                    }
                    else
                    {
                        double dd = Convert.ToDouble(cashTextBox.Text);
                        addvance = dd - ((Convert.ToDouble(reader5[0])) + photocopy);

                        richTextBox1.Text = addvance.ToString();
                        GetPhotocopyIncome();
                        GetsellAmountWithoutOrder();
                        
                        GetallDueCollection();
                        GetTotalAdvance();
                    }
                }
            }
        }

        private double GetTotalDueCollection(SqlConnection connection)
        {
            string selectQuery1 = "select sum(D_Collection) from Due_Collection where Due_Collection_Add_Date='" +
                                  DateTime.Now.ToShortDateString() + "'";
            SqlCommand command2 = new SqlCommand(selectQuery1, connection);
            connection.Open();
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                try
                {
                    string a = reader2[0].ToString();
                    //string b = reader2[1].ToString();
                    if (a.Equals("0") || a.Equals(""))
                    {
                       //double x = 0;
                        due_Coll = sell_Book + 0;

                    }
                   
                    
                    else
                    {
                        due_Coll = Convert.ToDouble(a) + sell_Book;


                    }
                }
                catch(InvalidCastException)
                {
                    
                    //throw;
                }
            }
            return due_Coll;
        }

        public void GetallDueCollection()
        {
            double totalDue;
            DBManager manager=new DBManager();
            SqlConnection con = manager.Connection();


            string selectQuery1 = "select sum(D_Collection),sum(Pay_Collection) from Due_Collection where Due_Collection_Add_Date='" +
                                 DateTime.Now.ToShortDateString() + "'";
            SqlCommand command2 = new SqlCommand(selectQuery1, con);
            con.Open();
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                try
                {
                    string a = reader2[0].ToString();
                    string b = reader2[1].ToString();
                    if (a.Equals("0") || a.Equals("") && (b.Equals("0") || b.Equals("")))
                    {
                        totalDue = 0;
                        duecollectionTextBoxtext.Text = totalDue.ToString();
                    }
                    else if (!(a.Equals("0") || a.Equals("")) && (b.Equals("0") || b.Equals("")))
                    {
                        due_Coll = sell_Book + Convert.ToDouble(a);

                    }
                    else if ((a.Equals("0") || a.Equals("")) && !(b.Equals("0") || b.Equals("")))
                    {
                        due_Coll = sell_Book + Convert.ToDouble(b);

                    }
                    else
                    {
                        totalDue = Convert.ToDouble(a)+Convert.ToDouble(b);
                        duecollectionTextBoxtext.Text = totalDue.ToString();
                    }
                }
                catch (InvalidCastException)
                {
                    
                    //throw;
                }
            }

        }


        public double GetTotalAdvance()
        {
            
            DBManager manager = new DBManager();
            SqlConnection con = manager.Connection();
            string selectQuery2 = "SELECT Sum(Advance) from Orders where Order_Date='" + DateTime.Now.ToShortDateString() + "'";
            SqlCommand cmd2 = new SqlCommand(selectQuery2, con);
            con.Open();
            SqlDataReader reader5 = cmd2.ExecuteReader();

            while (reader5.Read())
            {
                string a = reader5[0].ToString();
                if (a.Equals("") || a.Equals("0"))
                {
                   
                        addvance1 =  0;
                       advanceTextBox.Text = addvance1.ToString();
                  

                   
                }


                
                    else
                    {
                       
                        addvance1 =  Convert.ToDouble(reader5[0]);

                       advanceTextBox.Text = addvance1.ToString();
                      
                    }
                }
            return addvance1;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                matchTotalCashTextBox.Text = Convert.ToDouble(sellAmountTextBox.Text) +
                                                Convert.ToDouble(photocopytextBox.Text) +
                                                Convert.ToDouble(duecollectionTextBoxtext.Text) +
                                                Convert.ToDouble(advanceTextBox.Text) + Convert.ToDouble(richTextBox1.Text) +
                                                "";
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter the total cash and then press the load button.", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double others = Convert.ToDouble(richTextBox1.Text);
                BalanceUI balance = new BalanceUI(others);
                balance.ShowDialog();
            }
            catch (Exception)
            {
                
                 MessageBox.Show("Please enter the total cash and then press the load button.", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cashTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

            
        }
        }

    

