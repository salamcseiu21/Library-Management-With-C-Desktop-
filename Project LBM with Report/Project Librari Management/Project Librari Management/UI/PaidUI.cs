using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.UI
{
    public partial class PaidUI : Form
    {
      public  RecordDue aDue = new RecordDue();

        public PaidUI(RecordDue aRecord)
        {
            InitializeComponent();
            aDue = aRecord;


            serialtextBox.Text = aDue.Serial;
            veiwNameTextBox.Text = aDue.Name;
            ViewMobile.Text = aDue.Mobile;
            ViewBook.Text = aDue.Fbook.ToString();
            viewPhotocopy.Text = aDue.Fcopy.ToString();
            ViewOthers.Text = aDue.Fothers.ToString();
            ViewTotal.Text = aDue.Total.ToString();
            textBox1.Text = aDue.Date;
           
        }


      
        private void button1_Click(object sender, EventArgs e)
        {
            
        try
          {
              DBManager manager = new DBManager();
              SqlConnection connection = manager.Connection();

              string sltQ = "SELECT Total From DueRecords where Serial ='" + aDue.Serial + "' ";
            SqlCommand sltCommand=new SqlCommand(sltQ,connection);
            connection.Open();
              SqlDataReader aReader = sltCommand.ExecuteReader();
              while (aReader.Read())
              {
                  double totalDue = Convert.ToDouble(aReader[0]);

                  if (aDue.Total==totalDue)
                  {
                      connection.Close();

                      string insert = "INsert INto Due_Collection values('" + totalDue + "','"+0+"','"+DateTime.Now.ToShortDateString()+"')";
                      SqlCommand cMdCommand=new SqlCommand(insert,connection);
                      connection.Open();
                      cMdCommand.ExecuteNonQuery();
                      connection.Close();
                      string selectQuery = "Delete  from DueRecords where Serial ='" + aDue.Serial + "'";
                      SqlCommand cmd = new SqlCommand(selectQuery, connection);
                      connection.Open();
                      int i = cmd.ExecuteNonQuery();
                      MessageBox.Show(aDue.Name + " has been paid his/her due.", "Information", MessageBoxButtons.OK,
                          MessageBoxIcon.Information); 
                     
                  }


                 
                return;

              }

             

              ClearAlltextBox();
          }
          catch (Exception ex)
          {

              MessageBox.Show(ex.Message);
          }               
      }

        private void ClearAlltextBox()
        {
            serialtextBox.Clear();
            textBox1.Clear();
            ViewBook.Clear();
            veiwNameTextBox.Clear();
            ViewMobile.Clear();
            ViewOthers.Clear();
            ViewTotal.Clear();
            viewDate.Text = "";
            viewPhotocopy.Clear();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
           
                 {
                      try
                      {
                          DBManager manager = new DBManager();
                          double a, b, c, d;
                          a = aDue.Fbook - Convert.ToDouble(pBookTextBox.Text);
                          b = aDue.Fcopy - Convert.ToDouble(pPhotocopyTextBox.Text);
                          c = aDue.Fothers - Convert.ToDouble(pOtheresTextBox.Text);
                          d = (a + b + c)
                          ;
                          SqlConnection connection = manager.Connection();
                          string updateQuary = "Update DueRecords set F_Book='" + a + "',F_Copy='" + b + "',F_Others='" + c + "',Total='" + d + "'where Serial ='" + aDue.Serial + "'";
                          SqlCommand cmdCommand = new SqlCommand(updateQuary, connection);
                          connection.Open();
                          int i = cmdCommand.ExecuteNonQuery();
                          MessageBox.Show(i + "");
                          connection.Close();
                          string insert = "INsert INto Due_Collection values('" + d + "','" + 0 + "','"+DateTime.Now.ToShortDateString()+"')";
                          SqlCommand cMdCommand = new SqlCommand(insert, connection);
                          connection.Open();
                          cMdCommand.ExecuteNonQuery();
                          connection.Close();



                      }
                      catch (FormatException)
                      {

                          MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                      }

                  }

                 try
                 {
                     double a1, b1, c1, d1, x2;
                     a1 = aDue.Fbook - Convert.ToDouble(pBookTextBox.Text);
                     b1 = aDue.Fcopy - Convert.ToDouble(pPhotocopyTextBox.Text);
                     c1 = aDue.Fothers - Convert.ToDouble(pOtheresTextBox.Text);
                     d1 = (a1 + b1 + c1)
                     ;
                     x2 = Convert.ToDouble(pBookTextBox.Text) + Convert.ToDouble(pPhotocopyTextBox.Text) + Convert.ToDouble(pOtheresTextBox.Text);
                     DBManager manager1 = new DBManager();
                     SqlConnection connection1 = manager1.Connection();
                     string insertQuery = "Insert into Reduce values('" + aDue.Name + "','" + aDue.Mobile + "','" + aDue.Fbook + "','" + a1 + "','" + aDue.Fcopy + "','" + b1 + "','" + aDue.Fothers + "','" + c1 + "','" + aDue.Total + "','" + x2 + "','" + d1 + "','" + DateTime.Now.ToShortDateString() + "')";
                     SqlCommand cmdCommand1 = new SqlCommand(insertQuery, connection1);
                     connection1.Open();
                     int x = cmdCommand1.ExecuteNonQuery();
                     MessageBox.Show(x + " Saved");

                 }
                 catch (FormatException )
                 {

                     MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                 }

        }

        private void addNeeDueBotton_Click(object sender, EventArgs e)
        {
            



            try
            {
                DBManager manager = new DBManager();
                double a, b, c, d,y;
                a = aDue.Fbook + Convert.ToDouble(pBookTextBox.Text);
                b = aDue.Fcopy + Convert.ToDouble(pPhotocopyTextBox.Text);
                c = aDue.Fothers + Convert.ToDouble(pOtheresTextBox.Text);
                d = (a + b + c)
                ;
                y = Convert.ToDouble(pBookTextBox.Text) + Convert.ToDouble(pPhotocopyTextBox.Text) + Convert.ToDouble(pOtheresTextBox.Text);
                SqlConnection connection = manager.Connection();
                string updateQuary = "Update DueRecords set F_Book='" + a + "',F_Copy='" + b + "',F_Others='" + c + "',Total='" + d + "'where Serial ='" + aDue.Serial + "'";
                SqlCommand cmdCommand = new SqlCommand(updateQuary, connection);
                connection.Open();
                int i = cmdCommand.ExecuteNonQuery();
                MessageBox.Show(i + "");
                connection.Close();
                string insert = "INsert INto Due_Collection values('" + 0 + "','" + y + "')";
                SqlCommand cMdCommand = new SqlCommand(insert, connection);
                connection.Open();
                cMdCommand.ExecuteNonQuery();
                connection.Close();

            }
            catch (FormatException)
            {

                MessageBox.Show("Please fill every fields properly.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            double a1, b1, c1, d1, x1;
            a1 = aDue.Fbook + Convert.ToDouble(pBookTextBox.Text);
            b1 = aDue.Fcopy + Convert.ToDouble(pPhotocopyTextBox.Text);
            c1 = aDue.Fothers + Convert.ToDouble(pOtheresTextBox.Text);
            d1 = (a1 + b1 + c1)
            ;
            x1=Convert.ToDouble(pBookTextBox.Text)+Convert.ToDouble(pPhotocopyTextBox.Text)+Convert.ToDouble(pOtheresTextBox.Text);
            DBManager manager1 = new DBManager();
            SqlConnection connection1 = manager1.Connection();
            string insertQuery = "Insert into Add_Due values('" + aDue.Name + "','" + aDue.Mobile + "','" + aDue.Fbook + "','" + a1 + "','" + aDue.Fcopy + "','" + b1 + "','" + aDue.Fothers + "','" + c1 + "','" + aDue.Total + "','"+x1+"','" + d1 + "','" + DateTime.Now.ToShortDateString() + "')";
            SqlCommand cmdCommand1 = new SqlCommand(insertQuery, connection1);
            connection1.Open();
            int x = cmdCommand1.ExecuteNonQuery();
            MessageBox.Show(x + " Saved");

            connection1.Close();
            ViewBook.Text = "0";

            DBManager manager11 = new DBManager();
            SqlConnection connection11 = manager11.Connection();
            string selectQuery = "select F_Copy,F_Others,Total from DueRecords where Serial ='" + aDue.Serial + "' ";
            SqlCommand cmdCommand11 = new SqlCommand(selectQuery, connection11);
            connection11.Open();
            SqlDataReader reader = cmdCommand11.ExecuteReader();
            while (reader.Read())
            {
                double copy = Convert.ToDouble(reader[0]);
                double others = Convert.ToDouble(reader[1]);
                double total = Convert.ToDouble(reader[2]);

                viewPhotocopy.Text = copy.ToString();
                ViewOthers.Text = others.ToString();
                ViewTotal.Text = total.ToString();
                ClearAllTextBox();
                return;



            }


        }

        

        private void ClearAllTextBox(object sender, EventArgs e)
        {

            try
            {
                ViewBook.Text = "0";

                DBManager manager1 = new DBManager();
                SqlConnection connection1 = manager1.Connection();
                string selectQuery = "select F_Copy,F_Others,Total from DueRecords where Serial ='" + aDue.Serial + "' ";
                SqlCommand cmdCommand1 = new SqlCommand(selectQuery, connection1);
                connection1.Open();
                SqlDataReader reader = cmdCommand1.ExecuteReader();
                while (reader.Read())
                {
                    double copy = Convert.ToDouble(reader[0]);
                    double others = Convert.ToDouble(reader[1]);
                    double total = Convert.ToDouble(reader[2]);

                    viewPhotocopy.Text = copy.ToString();
                    ViewOthers.Text = others.ToString();
                    ViewTotal.Text = total.ToString();
                    ClearAllTextBox();
                    return;



                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

            
        }

        private void ClearAllTextBox()
        {
           pPhotocopyTextBox.Clear();
            pOtheresTextBox.Clear();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "delete from DueRecords where Date<'" + dateTimePicker2.Text + "'";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();

                int i = selectCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            catch
                   (Exception obj)
            {

                MessageBox.Show(obj.Message);
            }

        }

        }
    }

