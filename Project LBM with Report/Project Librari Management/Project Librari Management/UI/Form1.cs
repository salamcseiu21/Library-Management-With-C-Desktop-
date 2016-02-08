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
using Project_Librari_Management.DAL.Gateway;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.UI;
namespace Project_Librari_Management
{
    public partial class LibraryManagementUI : Form
    {
        int last;
        public LibraryManagementUI()
        {
            InitializeComponent();
            last = LastAddedInvestlNo();
            serialTextBox.Text = last.ToString();
           
          
            
            GetALLBooks();
        }
        string b_type;
        DataTable dt;
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAndEdit Search = new SearchAndEdit();
                DBManager manager = new DBManager();
                Book aBook = new Book();
                aBook.SerialNo = serialTextBox.Text;
                aBook.BookName = nameTextBox.Text;
                aBook.AuthorName = writernameTextBox.Text;
                aBook.Edition = comboBox1.SelectedItem.ToString();
                aBook.TypeOfBook = b_type;
                aBook.Quantity = Convert.ToInt16(quantityTextBox.Text);
                aBook.UnitPrice = Convert.ToDouble(uintPriceTextBox.Text);
                aBook.PurchasesDate =dateTimePiker.Text;

                string status =manager.SaveBookS(aBook);
                MessageBox.Show(status,"Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ClearAllText();
               serialTextBox.Text=LastAddedInvestlNo().ToString();
               Search.GetALLBooks();
               
            }
                catch(FormatException)
            {
                MessageBox.Show("Please fill up every field properly","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            catch (Exception)
            {

                MessageBox.Show("Book id must be unique.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ClearAllText()
        {
           // serialTextBox.Clear();
            nameTextBox.Clear();
            writernameTextBox.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            uintPriceTextBox.Clear();
            quantityTextBox.Clear();
            comboBox1.SelectedItem = "";
            textBox1.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            b_type = "New";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            b_type = "Old";
        }

        private void serialTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) &&ch!=8 && ch !=46)
            {
                e.Handled = true;
            }
        }

        private void quantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAllText();
        }


        public int LastAddedInvestlNo()
        {
           // int a = lastAdded;
            InvestmentGateway inGateway = new InvestmentGateway();
            Invest invest = new Invest();
            
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            

            string selectQuery = "SELECT [S.No] From Books";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<int> totalId = new List<int>();

            while (reader.Read())
            {
                int aId = Convert.ToInt16(reader[0]);

              
                totalId.Add(aId);
            }
            if (totalId.Count.Equals(0))
            {
                return 0;
            }
            else
            {
                int x = totalId.Max();
                //idTextBox.Text = x.ToString();
                return x;  
            }
            
        }

        public List<Book> GetALLBooks()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "select * from Books";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();

                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = selectCmd;

                dt = new DataTable();
                myAdapter.Fill(dt);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dt;
              //listBox1 .DataSource = dt;
                myAdapter.Update(dt);


                
                return null;
            }
            catch (Exception obj)
            {

                throw new Exception("Error", obj);
            }
        }



       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

        private void totalBookShowButton_Click(object sender, EventArgs e)
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
                    int total = Convert.ToInt16(myReader[0]);
                    double total_Book_price = Convert.ToDouble(myReader[1]);
                   

                    showtotalBookTextBox.Text = total.ToString();
                    textBox2.Text = total_Book_price.ToString();
                   
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("There are no books in Library.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }



        }

       


       

        

    }
}
