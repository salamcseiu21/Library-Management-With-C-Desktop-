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
using System.Speech;
using System.Speech.Synthesis;
namespace Project_Librari_Management
{
    public partial class LibraryManagementUI : Form
    {
        int last;
        public LibraryManagementUI()
        {
            InitializeComponent();
            AtocompleteTextBox();
            AutoSuggetionsWrtername();
            last = LastAddedInvestlNo();
            serialTextBox.Text = last.ToString();
           
          
            
            GetALLBooks();
            ShowAllBook();
            ShowAllOldBook();
            totalBooks();
        }

        private string b_type, book_print;
        DataTable dt;
        private SpeechSynthesizer reader;
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
                aBook.Edition = textBox1.Text;
                aBook.TypeOfBook = b_type;
                aBook.BookPrint = book_print;
                aBook.Quantity = Convert.ToInt16(quantityTextBox.Text);
                aBook.UnitPrice = Convert.ToDouble(uintPriceTextBox.Text);
                aBook.PurchasesDate =dateTimePiker.Text;

                string status =manager.SaveBookS(aBook);
                //if (status!=null)
                //{
                //  reader.Dispose();
                //    reader=new SpeechSynthesizer();
                //    reader.SpeakAsync("   Saved");
                    MessageBox.Show(status, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
               
                ClearAllText();
               serialTextBox.Text=LastAddedInvestlNo().ToString();
               Search.GetALLBooks();

                //28-02-2015


               ShowAllBook();
                ShowAllOldBook();
                totalBooks();

                nameTextBox.TabIndex = 0;

            }
                catch(FormatException)
            {
                MessageBox.Show("Please fill up every field properly","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            catch (Exception)
            {

                MessageBox.Show("Book Couldn't Save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        //autocmplete method
        public void AtocompleteTextBox()
        {
            nameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection=new AutoCompleteStringCollection();
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
                    collection.Add(name);

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            nameTextBox.AutoCompleteCustomSource = collection;
        }

        public void AutoSuggetionsWrtername()
        {

            writernameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            writernameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
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
                    string name = reader[2].ToString();
                    collection.Add(name);

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            writernameTextBox.AutoCompleteCustomSource = collection;


        }

        public void ShowAllBook()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery =
                    "select sum(Quantiy) as Total_Book,sum(Total_Price)as Total_Book_Price  from Books where [Type]='New'";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();


                SqlDataReader myReader = selectCmd.ExecuteReader();

                //List<Book> books = new List<Book>();
                while (myReader.Read())
                {
                    int total = Convert.ToInt16(myReader[0]);
                    //double total_Book_price = Convert.ToDouble(myReader[1]);


                    newBookTextBox.Text = total.ToString();
                    //textBox2.Text = total_Book_price.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There are no books in Library.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        public void ShowAllOldBook()
        {

            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery =
                    "select sum(Quantiy) as Total_Book,sum(Total_Price)as Total_Book_Price  from Books where [Type]='Old'";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();


                SqlDataReader myReader = selectCmd.ExecuteReader();

                //List<Book> books = new List<Book>();
                while (myReader.Read())
                {
                    int total = Convert.ToInt16(myReader[0]);
                    //double total_Book_price = Convert.ToDouble(myReader[1]);


                    oldBookTextBox.Text = total.ToString();
                    //textBox2.Text = total_Book_price.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There are no books in Library.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void totalBooks()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery =
                    "select sum(Quantiy) as Total_Book,sum(Total_Price)as Total_Book_Price  from Books";
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
                MessageBox.Show("There are no books in Library.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
 
        }
        private void ClearAllText()
        {
           // serialTextBox.Clear();
            nameTextBox.Clear();
            writernameTextBox.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            uintPriceTextBox.Clear();
            quantityTextBox.Clear();
           //textBox1
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



        

       


        public int LastAddedInvestlNo()
        {
           
            
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

        private void quantityTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void uintPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            book_print = "Original";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            book_print = "Photocopy";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            book_print = "White";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            book_print = "News";
        }

        

      
        private void LibraryManagementUI_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ImportExcelDataUI import=new ImportExcelDataUI();
            import.ShowDialog();
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (nameTextBox.Text=="")
            {
                errorProvider1.SetError(nameTextBox,"Please! Write the Book Name here.....!");
                
            }
            else
            {
                errorProvider1.SetError(nameTextBox,"");
            }
        }

        private void writernameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (writernameTextBox.Text == "")
            {
                errorProvider1.SetError(writernameTextBox, "Please! Write the Book Name here.....!");

            }
            else
            {
                errorProvider1.SetError(writernameTextBox, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Please! Write the editio of Book  here.....!");

            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void quantityTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (quantityTextBox.Text == "")
            {
                errorProvider1.SetError(quantityTextBox, "Please! Write the quantity of  Book here.....!");

            }
            else
            {
                errorProvider1.SetError(quantityTextBox, "");
            }
        }

        private void uintPriceTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (uintPriceTextBox.Text == "")
            {
                errorProvider1.SetError(uintPriceTextBox, "Please! Write the unit price of Book here.....!");

            }
            else
            {
                errorProvider1.SetError(uintPriceTextBox, "");
            }
        }

       


       

        

    }
}
