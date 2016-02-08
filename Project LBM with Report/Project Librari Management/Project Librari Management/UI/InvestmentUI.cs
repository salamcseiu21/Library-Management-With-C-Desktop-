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
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class InvestmentUI : Form
    {
        int last;
        public InvestmentUI()
        {
            InitializeComponent();
         last=LastAddedInvestlNo();
         idTextBox.Text = last.ToString();  
            
        }

        int lastAdded;

        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {

                Invest anInvest = new Invest();
                anInvest.Id = Convert.ToInt16(idTextBox.Text);
                anInvest.Book = Convert.ToDouble(bookTextBox.Text);
                anInvest.Paper = Convert.ToDouble(paperTextBox.Text);
                anInvest.Ink = Convert.ToDouble(inkTextBOx.Text);
                anInvest.Equipment = Convert.ToDouble(equipmentTextBox.Text);
                anInvest.Others = Convert.ToDouble(othersTextBox.Text);
                anInvest.Date = dateTimePicker1.Text;
                lastAdded = Convert.ToInt16(idTextBox.Text);

                InvestmentGateway gateway = new InvestmentGateway();
               string status = gateway.SaveTotalInvestment(anInvest);
                MessageBox.Show(status,"Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LastAddedInvestlNo();
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string updateQuery = "UPDATE FInvestmentCost set FBook='" + bookTextBox.Text + "',FPaper='" + paperTextBox.Text + "',FInk='" + inkTextBOx.Text + "',FEquipment='" + equipmentTextBox.Text + "',FOthers='" + othersTextBox.Text + "',FInvestment_Date='" + dateTimePicker1.Text + "' WHERE FId='" + 1 + "'";
                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                connection.Open();
                int x = updateCmd.ExecuteNonQuery();
                connection.Close();
                string query = "INSert INTo InvestmentCost values('" + bookTextBox.Text + "','" + paperTextBox.Text + "','" + inkTextBOx.Text + "','" + equipmentTextBox.Text + "','" + othersTextBox.Text + "','" + dateTimePicker1.Text + "')";
                SqlCommand command3=new SqlCommand(query,connection);
                connection.Open();
                int y = command3.ExecuteNonQuery();
                last = LastAddedInvestlNo();
                idTextBox.Text = last.ToString();  

                connection.Close();
                ClearAlltextBox();
            }
            catch (FormatException)
            {
                
                MessageBox.Show("Please fill every field properly.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

         public int  LastAddedInvestlNo()
        {
            int a = lastAdded;
            InvestmentGateway inGateway = new InvestmentGateway();
            Invest invest = new Invest();
            
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
           
            string selectQuery = "SELECT Id From InvestmentCost";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<int> totalId = new List<int>();

            while (reader.Read())
            {
                int  aId = Convert.ToInt16(reader[0]);

                
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


        private void ClearAlltextBox()
        {
           
            bookTextBox.Text = "";
            paperTextBox.Clear();
            inkTextBOx.Clear();
            equipmentTextBox.Clear();
            othersTextBox.Clear();
            showToataCostTextBox.Clear();
        }

        private void InvestmentUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to close the program?","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
            else if(dialog==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showTotalCostButton_Click(object sender, EventArgs e)
        {
            InvestmentGateway inGateway = new InvestmentGateway();
            Invest invest = new Invest();
            double total;
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string selectQuery = "SELECT Sum(FBook) ,sum(FPaper),sum(FInk),sum(FEquipment),sum(FOthers) From FInvestmentCost";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string a = reader[0].ToString();
                string b = reader[1].ToString();
                string c = reader[2].ToString();
                string d = reader[3].ToString();
                string y = reader[4].ToString();

               
                if (a.Equals("")&&b.Equals("")&&c.Equals("")&&d.Equals("")&&y.Equals(""))
                {
                    MessageBox.Show("NO data found","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                
                else
                {

                    showBookCostTextBox.Text = reader[0].ToString();
                    showpaperCostTextBox.Text = reader[1].ToString();
                    showInkCostTextBox.Text = reader[2].ToString();
                    showEquipmentCostTextBox.Text = reader[3].ToString();
                    showOthersCostTextBox.Text = reader[4].ToString();

                    total = (Convert.ToDouble(reader[0]) + Convert.ToDouble(reader[1]) + Convert.ToDouble(reader[2]) + Convert.ToDouble(reader[3]) + Convert.ToDouble(reader[4]));
                    showToataCostTextBox.Text = total.ToString();  
                }
                
            }
            
        }

        private void TextBoxClear()
        {
            showToataCostTextBox.Clear();
            showOthersCostTextBox.Clear();
            showBookCostTextBox.Clear();
            showInkCostTextBox.Clear();
            showpaperCostTextBox.Clear();
            showEquipmentCostTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxClear();
        }

        private void SearchByDateButton(object sender, EventArgs e)
        {
            try
            {
                
                double total;
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Sum(Book) ,sum(Paper),sum(Ink),sum(Equipment),sum(Others) From InvestmentCost WHERE [Investment_Date] LIKE '" + dateTimePicker2.Text + "' ";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   

                    showBookCostTextBox.Text = reader[0].ToString();

                    showpaperCostTextBox.Text = reader[1].ToString();
                    showInkCostTextBox.Text = reader[2].ToString();
                    showEquipmentCostTextBox.Text = reader[3].ToString();
                    showOthersCostTextBox.Text = reader[4].ToString();
                    if (showBookCostTextBox.Text.Equals("")&&showpaperCostTextBox.Text.Equals("")
                        &&showInkCostTextBox.Text.Equals("")&&showOthersCostTextBox.Text.Equals("")
                       &&showEquipmentCostTextBox.Text .Equals("") )
                    {
                        MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    

                    else
                    {
                     total = (Convert.ToDouble(reader[0]) + Convert.ToDouble(reader[1]) + Convert.ToDouble(reader[2]) + Convert.ToDouble(reader[3]) + Convert.ToDouble(reader[4]));
                    showToataCostTextBox.Text = total.ToString();
                    }
                   
                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ShowAllButton(object sender, EventArgs e)
        {

            InvestmentGateway inGateway = new InvestmentGateway();
            Invest invest = new Invest();
            double total;
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string selectQuery = "SELECT Sum(Book) ,sum(Paper),sum(Ink),sum(Equipment),sum(Others) From InvestmentCost";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string a = reader[0].ToString();
                string b = reader[1].ToString();
                string c = reader[2].ToString();
                string d = reader[3].ToString();
                string y = reader[4].ToString();


                if (a.Equals("")&&b.Equals("")&&c.Equals("")&&d.Equals("")&&y.Equals(""))
                {
                    MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
                else
                {

                    showBookCostTextBox.Text = reader[0].ToString();
                    showpaperCostTextBox.Text = reader[1].ToString();
                    showInkCostTextBox.Text = reader[2].ToString();
                    showEquipmentCostTextBox.Text = reader[3].ToString();
                    showOthersCostTextBox.Text = reader[4].ToString();

                    total = (Convert.ToDouble(reader[0]) + Convert.ToDouble(reader[1]) + Convert.ToDouble(reader[2]) + Convert.ToDouble(reader[3]) + Convert.ToDouble(reader[4]));
                    showToataCostTextBox.Text = total.ToString();
                }

            }
            


            
        }

        private void showTodayInvestmentCostButon_Click(object sender, EventArgs e)
        {
            GetTodaysTotalInvestmentCost();
        }

        public void GetTodaysTotalInvestmentCost()
        {
            try
            {
               
                DateTime date = DateTime.Now;

                double total;
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Sum(Book) ,sum(Paper),sum(Ink),sum(Equipment),sum(Others) From InvestmentCost WHERE [Investment_Date] LIKE '" + date.ToShortDateString() + "' ";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   

                    showBookCostTextBox.Text = reader[0].ToString();

                    showpaperCostTextBox.Text = reader[1].ToString();
                    showInkCostTextBox.Text = reader[2].ToString();
                    showEquipmentCostTextBox.Text = reader[3].ToString();
                    showOthersCostTextBox.Text = reader[4].ToString();

                    if (showBookCostTextBox.Text.Equals("")&&showpaperCostTextBox.Text.Equals("")&&
                        showInkCostTextBox.Text.Equals("")&&showOthersCostTextBox.Text.Equals("")&&
                        showEquipmentCostTextBox.Text.Equals(""))
                    {
                        MessageBox.Show("NO data found","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    
                    else
                    {
                        total = (Convert.ToDouble(reader[0]) + Convert.ToDouble(reader[1]) + Convert.ToDouble(reader[2]) + Convert.ToDouble(reader[3]) + Convert.ToDouble(reader[4]));
                        showToataCostTextBox.Text = total.ToString();
                    }

                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void equipmentTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch!=8 && ch!=46)
            {
                e.Handled = true;
            }
        }

        private void othersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void inkTextBOx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void paperTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void bookTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
