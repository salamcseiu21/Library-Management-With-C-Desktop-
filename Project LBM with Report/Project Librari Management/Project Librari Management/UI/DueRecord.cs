using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class DueRecord : Form
    {
        private double dueAmount;

        public DueRecord(double aDueRecord)
        {
            InitializeComponent();
            dueAmount = aDueRecord;
            forBooktextBox.Text = dueAmount.ToString();

        }


        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                double total;

                total = Convert.ToDouble(forBooktextBox.Text) + Convert.ToDouble(forphotocopytextBox.Text) +
                        Convert.ToDouble(forOThersTextBox.Text);
                totalDuetextBox.Text = total.ToString();

            }
            catch (FormatException)
            {

                MessageBox.Show("Please fill every fields properly. ", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void forBooktextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void forphotocopytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void forOThersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                RecordDue aRecordDue = new RecordDue();
                aRecordDue.Name = cnameTextBox.Text;
                aRecordDue.Mobile = cMobileTextBox.Text;
                aRecordDue.Fbook = Convert.ToDouble(forBooktextBox.Text);
                aRecordDue.Fcopy = Convert.ToDouble(forphotocopytextBox.Text);
                aRecordDue.Fothers = Convert.ToDouble(forOThersTextBox.Text);
                RecordDueGateway gateway = new RecordDueGateway();
                gateway.SaveDueRecord(aRecordDue);
                listView1.Items.Clear();
                LoadAllBook();
                ClearALLTextbox();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill every fields properly. ", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }

        private void ClearALLTextbox()
        {
            cnameTextBox.Clear();
            cMobileTextBox.Clear();
            forBooktextBox.Clear();
            forphotocopytextBox.Clear();
            forOThersTextBox.Clear();
            totalDuetextBox.Clear();
        }



        private void searchButton_Click(object sender, EventArgs e)
        {

            if (searchTextBox.Text.Equals(""))
            {
                MessageBox.Show("Please search by any part of Customer Name.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
            else
            {
                listView1.Items.Clear();

                LoadAllBook();

            }


        }

        public void LoadAllBook()
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = "select * from DueRecords where Name LIKE '%" + searchTextBox.Text + "%'";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                List<RecordDue> books = new List<RecordDue>();
                while (myReader.Read())
                {
                    string serial = myReader[0].ToString();
                    string name = myReader[1].ToString();
                    string mobile = myReader[2].ToString();
                    double fbook = Convert.ToDouble(myReader[3]);
                    double fCopy = Convert.ToDouble(myReader[4]);
                    double fothers = Convert.ToDouble(myReader[5]);
                    double total = Convert.ToDouble(myReader[6]);
                    string date = myReader[7].ToString();

                    RecordDue aDue = new RecordDue();




                    ListViewItem item = new ListViewItem(serial);
                    item.SubItems.Add(name);
                    item.SubItems.Add(mobile);
                    item.SubItems.Add(fbook.ToString());
                    item.SubItems.Add(fCopy.ToString());
                    item.SubItems.Add(fothers.ToString());
                    item.SubItems.Add(total.ToString());
                    item.SubItems.Add(date);
                    item.Tag = aDue;
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            if (listView1.Items.Count <= 0)
            {
                MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            paidToolStripMenuItem.Enabled = (listView1.SelectedItems.Count >= 0);

        }


        private void cMobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = listView1.SelectedIndices[0];
                ListViewItem item = listView1.Items[index];
                string serial = item.Text;
                string name = item.SubItems[1].Text;
                string mobile = item.SubItems[2].Text;

                string a = item.SubItems[3].Text;
                string b = item.SubItems[4].Text;
                string c = item.SubItems[5].Text;
                string d = item.SubItems[6].Text;
                double fbook = Convert.ToDouble(a);
                double fcopy = Convert.ToDouble(b);
                double fothers = Convert.ToDouble(c);
                double total = Convert.ToDouble(d);
                string date = item.SubItems[7].Text;
                RecordDue aDue = new RecordDue();

                aDue.Serial = serial;
                aDue.Name = name;
                aDue.Mobile = mobile;
                aDue.Fbook = fbook;
                aDue.Fcopy = fcopy;
                aDue.Fothers = fothers;
                aDue.Total = total;
                aDue.Date = date;


                PaidUI paid = new PaidUI(aDue);
                listView1.Items.RemoveAt(index);
                paid.ShowDialog();
                return;
            }
            catch (Exception)
            {

                MessageBox.Show("Are you want to delivery the book?.", "?", MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            }
        }

        private void TotalDueCalculateButton(object sender, EventArgs e)
        {

            try
            {
                double total_Due_Collection;
                double f_Due;
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = "select  Sum(Total) from  DueRecords ";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {

                    string dd = myReader[0].ToString();
                    if (dd.Equals("") || dd.Equals("0"))
                    {
                        total_Due_Collection = 0;
                    }
                    else
                    {
                        total_Due_Collection = Convert.ToDouble(dd);
                    }

                    connection.Close();
                    string selectQuery1 = "select  Sum(Add_Due)from Due_Collection";
                    SqlCommand command = new SqlCommand(selectQuery1, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {


                        string d = reader[0].ToString();

                        if ((d.Equals("") || d.Equals("0")))
                        {


                            f_Due = 0;
                            ShowTotalDueTExtBox.Text = (total_Due_Collection + f_Due).ToString();

                        }
                        else
                        {

                            f_Due = Convert.ToDouble(reader[0])

                                ;




                            connection.Close();

                            string selectQ = "select sum(Paying_Amount) from Delivery_Report where Final_Due='"+0+"'";
                          connection.Open();
                            SqlCommand cmdCommand = new SqlCommand(selectQ, connection);
                            SqlDataReader read = cmdCommand.ExecuteReader();
                            while (read.Read())
                            {
                                if (read[0].Equals(""))
                                {
                                    ShowTotalDueTExtBox.Text = (total_Due_Collection + f_Due).ToString();
                                }
                                else
                                {

                                    double asssss = Convert.ToDouble(read[0]);
                                    ShowTotalDueTExtBox.Text = (total_Due_Collection + f_Due-asssss).ToString();



                                }
                            }


                        }



                        return;


                    }
                }
            }
            catch
                (Exception ex)
            {

                MessageBox.Show( ex.Message+"No Due.", "Wellcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }

        private void deleteButton_Click(object sender, EventArgs e)
      {
          try
          {
              DBManager manager1 = new DBManager();
              SqlConnection connection = manager1.Connection();
              string seletQuery = "delete from DueRecords where Date<='" +dateTimePicker1.Text + "'";
              SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
              connection.Open();
              int i = selectCmd.ExecuteNonQuery();
              MessageBox.Show("Sucessful ", "Message", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
              
          }
          catch (Exception obj)
          {

              MessageBox.Show(obj.Message);
          }

      }

      private void button2_Click(object sender, EventArgs e)
      {
          listView1.Items.Clear();
          LoadAllBook();
      }

    }
}
