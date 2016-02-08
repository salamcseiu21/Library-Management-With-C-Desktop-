using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class BalanceCalculationUI : Form
    {
        public BalanceCalculationUI()
        {
            InitializeComponent();
            GetTodaysTotalInvestmentCost();
            //showtotalInvestMentTextBox.Text = "0";
            GetTodaysTotalInvestmentCost();
            GetToalBookAndCost();
            
        }

        public void GetTodaysTotalInvestmentCost()
        {
            try
            {

                DateTime date = DateTime.Now;
                string a, b, c, d, x;
                double total;
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Sum(Book) ,sum(Paper),sum(Ink),sum(Equipment),sum(Others) From InvestmentCost ";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    a = reader[0].ToString();

                    b = reader[1].ToString();
                    c = reader[2].ToString();
                    d = reader[3].ToString();
                    x = reader[4].ToString();

                    if (a.Equals(""))
                    {
                        total = 0.0;
                        showtotalInvestMentTextBox.Text = total.ToString();
                    }
                    else if (b.Equals(""))
                    {
                        total = 0.0;
                        showtotalInvestMentTextBox.Text = total.ToString();
                    }
                    else if (c.Equals(""))
                    {
                        total = 0.0;
                        showtotalInvestMentTextBox.Text = total.ToString();
                    }
                    else if (d.Equals(""))
                    {
                        total = 0.0;
                        showtotalInvestMentTextBox.Text = total.ToString();
                    }

                    else if (x.Equals(""))
                    {
                        total = 0.0;
                        showtotalInvestMentTextBox.Text = total.ToString();
                    }

                    else
                    {

                        total = (Convert.ToDouble(reader[0]) + Convert.ToDouble(reader[1]) + Convert.ToDouble(reader[2]) + Convert.ToDouble(reader[3]) + Convert.ToDouble(reader[4]));
                        showtotalInvestMentTextBox.Text = total.ToString();




                    }

                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void totalBookShowButton_Click(object sender, EventArgs e)
        {
            GetSoldBookAmountAndCost();
        }

        public void GetToalBookAndCost()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "select sum(Quantiy) as Total_Book,sum(Total_Price)as Total_Book_Price  from Books";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();




                SqlDataReader myReader = selectCmd.ExecuteReader();

                //List<Book> books = new List<Book>();
                while (myReader.Read())
                {
                    int total;
                    double total_Book_price;
                    if (myReader[0].Equals(""))
                    {
                         total = 0;
                        total_Book_price = 0;
                    }
                    else if (myReader[1].Equals(""))
                    {
                        total = 0;
                        total_Book_price = 0;
                    }
                    else
                    {
                        total = Convert.ToInt16(myReader[0]);
                        total_Book_price = Convert.ToDouble(myReader[1]);   
                    }
                    


                    showtotalBookTextBox.Text = total.ToString();
                    textBox2.Text = total_Book_price.ToString();

                }

            }
            catch (Exception)
            {

                MessageBox.Show("There are no books in Library.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

        public void GetSoldBookAmountAndCost()
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery =
                    "select SUM(Quantiy), sum(Unit_Price_Buy*Quantiy) from sell_Counter ";
                connection.Open();
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].Equals("") || reader[0].Equals("0"))
                    {
                        numberofSoldBook.Text = "0";
                        CostOfSoldBook.Text = "0";
                    }
                    else
                    {
                        int quantity = Convert.ToInt16(reader[0]);
                        double price = Convert.ToDouble(reader[1]);
                        int quant;
                         double unit;
                        connection.Close();
                        string selectQuery1 =
                    "select SUM(Quantity), sum(Buy_Unit_Price*Quantity) from Delivery_Report ";
                        connection.Open();
                        SqlCommand cmd1 = new SqlCommand(selectQuery1, connection);
                        SqlDataReader reader1 = cmd1.ExecuteReader();

                        while (reader1.Read())
                        {

                            string s1 = reader1[0].ToString();
                            string s2 = reader1[1].ToString();

                            if (s1.Equals("0")||s2.Equals(""))
                            {
                                quant = 0;
                                unit = 0;
                            }
                            else
                            {
                                quant = Convert.ToInt16(s1);
                                unit = Convert.ToDouble(s2);  
                            }
                            

                            numberofSoldBook.Text = (Convert.ToInt16(quantity)+quant).ToString();
                            CostOfSoldBook.Text = (Convert.ToDouble(price)+unit).ToString();



                        }


                    }
                    return;
                }

            }
            catch ( Exception exception)
            {

                MessageBox.Show(exception.StackTrace,"Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

    }
}
