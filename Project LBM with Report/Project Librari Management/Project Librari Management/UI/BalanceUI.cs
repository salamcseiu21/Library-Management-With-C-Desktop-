using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using System.Data.SqlClient;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.UI
{
    public partial class BalanceUI : Form
    {
        private double ddd;
        public BalanceUI(double othersIncome)
        {
            InitializeComponent();
            ddd = othersIncome;
            GetAllProfit();
            othersincomeTextOBx.Text = ddd.ToString();
        }
       
       

        

        private void GetAllProfit()
        {
            double unitpricecell;
            double unitPrice;
            double total,y;

            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQuery =
                "select SUM(Quantiy)As Totol_Sell, sum(Unit_Price_Sell*Quantiy) aS Sell_Price,sum(Unit_Price_Buy*Quantiy) as Buying_Price ,sum(Collection) from [sell_Counter]sell_Counter";
            connection.Open();
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Book> sellBooks = new List<Book>();
            while (reader.Read())
            {
                string a = reader[0].ToString();
                string b = reader[1].ToString();
                string c = reader[2].ToString();

                if (a.Equals(""))
                {
                    y = 0;
                }
                else if (b.Equals(""))
                {
                    y = 0;
                }

                else if (c.Equals(""))
                {
                    y = 0;
                }

                else
                {
                    double st3;
                    string st1;

                    SqlConnection connection3 = manager.Connection();
                    string selectQuery3 =
                        "select SUM(D_Collection)As Totol_Due_Sell from Due_Collection where Due_Collection_Add_Date='" +
                        DateTime.Now.ToShortDateString() + "'";
                    connection3.Open();
                    SqlCommand cmd3 = new SqlCommand(selectQuery3, connection3);
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    while (reader3.Read())
                    {
                        st1 = reader3[0].ToString();
                        if (st1.Equals(""))
                        {
                            st3 = 0;
                        }

                        else
                        {
                            st3 = Convert.ToDouble(st1);
                        }


                        int quantity = Convert.ToInt16(reader[0]);
                        unitpricecell = Convert.ToDouble(reader[1]);
                        unitPrice = Convert.ToDouble(reader[2]);
                        total = Convert.ToDouble(reader[3]);
                        double tt = st3;
                     
                      GetTotalBookBenifit(unitpricecell, unitPrice, total);
                        GetTotalPhotocopyIncome();
                        
                    }
                }
            }
            
        }

        private void GetTotalBookBenifit(double unitpricecell, double unitPrice, double total)
        {
            if (unitPrice > total)
            {
                bookProfitTextBox.Text = "0";
            }
            else
            {
                double benifit = total - unitPrice;
                bookProfitTextBox.Text = benifit.ToString();
                
            }
            
        }

        private void totalIncomeCalculationButton(object sender, EventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(bookProfitTextBox.Text) + Convert.ToDouble(photocopyTextBpx.Text) + Convert.ToDouble(othersincomeTextOBx.Text);
                totalIncomeTextBOx.Text = total.ToString();

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string insertQ = "insert into Income values('" + bookProfitTextBox.Text + "','" + photocopyTextBpx.Text + "','" + othersincomeTextOBx.Text + "','" + totalIncomeTextBOx.Text + "','" + DateTime.Now.ToShortDateString() + "')";
                SqlCommand insCommand = new SqlCommand(insertQ, connection);
                connection.Open();
                int i = insCommand.ExecuteNonQuery();

                MessageBox.Show(" Hi,Well  Done Campus Library today's profit = " + totalIncomeTextBOx.Text + " Tk", "Best of Luck", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (FormatException)
            {

                MessageBox.Show("Please fill up every field properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

       
        private void BalanceUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to close the program ?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dialog==DialogResult.OK)
            {
                Application.Exit();
            }else if(dialog==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void GetTotalPhotocopyIncome()
        {

            try
            {


                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string query = "select sum(Total_Copy*.45), sum(Total_Amount) from Photocopy where Copy_Date='" + DateTime.Now.ToShortDateString() + "'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {


                    if (reader[0].Equals("")||reader[0].Equals("0"))
                    {
                      
                        
                        photocopyTextBpx.Text = "0";
                    }
                    
                    else
                    {
                        double total_Cost = Convert.ToDouble(reader[0]);
                        double totalTaka = Convert.ToDouble(reader[1]);
                        double netProfit = totalTaka - total_Cost;
                        photocopyTextBpx.Text = netProfit.ToString();

                    }

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


       
    }
}
