using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
            GetAllCoustomerName();
            
            comboBox1.DisplayMember = "Name";
         GetAllDueRecord();
         memoNumver =GetLastMemoNumber();

        }

        public int memoNumver;

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                double total;
                if (forBooktextBox.Text.Equals("")||forphotocopytextBox.Text.Equals("")||previousDueTextBox.Text.Equals("")||forOThersTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please fill every fields properly. ", "Error", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);  
                }
                else if (forBooktextBox.Text.Equals("0") && forphotocopytextBox.Text.Equals("0") && previousDueTextBox.Text.Equals("0") && forOThersTextBox.Text.Equals("0"))
                {
                    MessageBox.Show("Due could not be saved.Because this person has no due. ", "Error", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);  
                }

                total = Convert.ToDouble(forBooktextBox.Text) + Convert.ToDouble(forphotocopytextBox.Text) +
                        Convert.ToDouble(forOThersTextBox.Text)+Convert.ToDouble(previousDueTextBox.Text);
                totalDuetextBox.Text = total.ToString();

            }
            catch (FormatException)
            {

               
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
            DBManager manager6 = new DBManager();
            SqlConnection connection6 = manager6.Connection();
            string selectQuery6 = "insert into  Due_Collection values(@pay,@empty,@payCollection,@date)";
            SqlCommand cmd6 = new SqlCommand(selectQuery6, connection6);
            connection6.Open()
                ;
            cmd6.Parameters.Clear();
            cmd6.Parameters.Add("@pay", "0");
            cmd6.Parameters.Add("@empty", totalDuetextBox.Text);
            cmd6.Parameters.AddWithValue("@payCollection", "0");
            cmd6.Parameters.Add("@date", DateTime.Now.ToShortDateString());


            cmd6.ExecuteNonQuery();

            connection6.Close();

            
                RecordDue aRecordDue = new RecordDue();
                aRecordDue.Name = cnameTextBox.Text;
                aRecordDue.Mobile = cMobileTextBox.Text;
                aRecordDue.Fbook = Convert.ToDouble(forBooktextBox.Text);
                aRecordDue.Fcopy = Convert.ToDouble(forphotocopytextBox.Text);
                aRecordDue.Fothers = Convert.ToDouble(forOThersTextBox.Text);
                aRecordDue.PreviousDue = Convert.ToDouble(previousDueTextBox.Text);
                RecordDueGateway gateway = new RecordDueGateway();
                gateway.SaveDueRecord(aRecordDue);

                listView1.Items.Clear();
                LoadAllBook();

               
                GetAllDueRecord();
                TempDueRecord aRecord=new TempDueRecord();
                aRecord.CoustemerName = cnameTextBox.Text;
                aRecord.Mobile = cMobileTextBox.Text;
                aRecord.ForBook = Convert.ToDouble(forBooktextBox.Text);
                aRecord.ForCopy = Convert.ToDouble(forphotocopytextBox.Text);
                aRecord.ForOthers = Convert.ToDouble(forOThersTextBox.Text);
                aRecord.Total = Convert.ToDouble(totalDuetextBox.Text);
                if (previousDueTextBox.Text.Equals("")||previousDueTextBox.Text.Equals("0"))
                {
                    aRecord.PreviousDue = 0;
                }
                else
                {
                    aRecord.PreviousDue = Convert.ToDouble(previousDueTextBox.Text
                       );    
                }
                aRecord.MemoNumber = memoNumver;
                TempDueRecordGateway DueRecordGateway=new TempDueRecordGateway();
                DueRecordGateway.SaveTempDueRecord(aRecord);


                //DueReportUI dueReportUi=new DueReportUI(cnameTextBox.Text,cMobileTextBox.Text,forBooktextBox.Text,forphotocopytextBox.Text,forOThersTextBox.Text,totalDuetextBox.Text);
                //dueReportUi.ShowDialog();

                //listView1.Items.Clear();
                //LoadAllBook();
                //ClearALLTextbox();
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show("Please fill every fields properly. ", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
            catch (Exception exception)
            {
              MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, 
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
                    double prveious = Convert.ToDouble(myReader[6]);
                    
                   
                    double total = Convert.ToDouble(myReader[7]);
                   string date = myReader[8].ToString();
                    RecordDue aDue = new RecordDue();




                    ListViewItem item = new ListViewItem(serial);
                    item.SubItems.Add(name);
                    item.SubItems.Add(mobile);
                    item.SubItems.Add(fbook.ToString());
                    item.SubItems.Add(fCopy.ToString());
                    item.SubItems.Add(fothers.ToString());
                    item.SubItems.Add(prveious.ToString());
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


       

        

        private void TotalDueCalculateButton(object sender, EventArgs e)
        {

            try
            {
                double total_Due_Collection;
                double f_Due;
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
               
                string selectQuery1 = "select  sum(D_Collection),Sum(Add_Due)from Due_Collection";
                    SqlCommand command = new SqlCommand(selectQuery1, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        string fff = reader[0].ToString();
                        string d = reader[1].ToString();

                        if ((d.Equals("") || d.Equals("0")))
                        {

                            total_Due_Collection = 0;
                            f_Due = 0;
                            ShowTotalDueTExtBox.Text = (f_Due + total_Due_Collection).ToString();

                        }
                        else
                        {

                            total_Due_Collection = Convert.ToDouble(reader[0]);
                            f_Due = Convert.ToDouble(reader[1]);
                            double restDue = f_Due - total_Due_Collection;
                             ShowTotalDueTExtBox.Text=(restDue).ToString()
                                ;
                            connection.Close();

                         

                        }



                        return;


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

        public void GetAllCoustomerName()
        {

            cnameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cnameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection customernameCollection = new AutoCompleteStringCollection();

            cMobileTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cMobileTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection mobileCollection = new AutoCompleteStringCollection();
            try
            {
                
                DBManager manager=new DBManager();
                SqlConnection connection=new SqlConnection();
                connection = manager.Connection();
                connection.Open();
                string selectQuery = "select * from Orders";
                SqlCommand command=new SqlCommand(selectQuery,connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    string phone = reader[2].ToString();
                    customernameCollection.Add(name);
                    mobileCollection.Add(phone);
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.StackTrace);
            }
            cnameTextBox.AutoCompleteCustomSource = customernameCollection;
            cMobileTextBox.AutoCompleteCustomSource = mobileCollection;
        }

        private void cMobileTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void DueRecord_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
            //this.forBooktextBox.MaximumSize=
            comboBox1.Text = "Search for a Name";
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
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
                string f = item.SubItems[6].Text;
                double fbook = Convert.ToDouble(a);
                double fcopy = Convert.ToDouble(b);
                double fothers = Convert.ToDouble(c);
                double previousDue = Convert.ToDouble(f);
                string d = item.SubItems[7].Text;
                double total = Convert.ToDouble(d);
                string date = item.SubItems[8].Text;
                RecordDue aDue = new RecordDue();

                aDue.Serial = serial;
                aDue.Name = name;
                aDue.Mobile = mobile;
                aDue.Fbook = fbook;
                aDue.Fcopy = fcopy;
                aDue.Fothers = fothers;
                aDue.PreviousDue = previousDue;
                aDue.Total = total;
                aDue.Date = date;


                PaidUI paid = new PaidUI(aDue);
                DialogResult dialog = MessageBox.Show("Are you want to paid/add/Reduce now ?", "Message", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    listView1.Items.RemoveAt(index);
                    paid.ShowDialog();
                    
                }
                else if(dialog==DialogResult.No)
                {
                    //this.Close();  
                }

                return;
            }
            catch (Exception exception)
            {

                // MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void GetAllDueRecord()
        {
            try
            {
                comboBox1.Items.Clear();
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = "select * from DueRecords";
                SqlCommand command = new SqlCommand(selectQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string name = reader[1].ToString();
                    comboBox1.Items.Add(name);

                }
            }
            catch (Exception exception)
            {
                
                  MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double due = 0;
           
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQuery = "select * from DueRecords where Name=@name";

            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", comboBox1.Text);
            List<RecordDue> recordDues = new List<RecordDue>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                string name = reader[1].ToString();
                string mobile=reader[2].ToString();

                cnameTextBox.Text = name;

                cMobileTextBox.Text = mobile;
                
                if (reader[7].ToString().Equals(""))
                {
                due = 0;
                }

                else
                {
                   due = Convert.ToDouble(reader[7]);
                }
                previousDueTextBox.Text = due.ToString();


            }
        }

        private void previousDueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void printDueRecordButton(object sender, EventArgs e)
        {
            DBManager manager=new DBManager();
            SqlConnection connection = manager.Connection();


            TempDueRecordGateway gateway = new TempDueRecordGateway();
           
            List<TempDueRecord> aList = gateway.GeTempDueRecords();
            try
            {
                
                DueReportUI dueReport = new DueReportUI(aList);
                dueReport.ShowDialog();
                //temp due record 
                System.Windows.Forms.DialogResult dialog = MessageBox.Show("Did you print the document?", "Print Message",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    String deletequery = "delete from TempDueRecord";
                    SqlCommand command1 = new SqlCommand(deletequery, connection);
                    connection.Open();
                    command1.ExecuteNonQuery();
                    string que = "DBCC CHECKIDENT (TempDueRecord,Reseed,0)";
                    command1 = new SqlCommand(que, connection);
                    command1.ExecuteNonQuery();
                    string que1 = "set identity_insert TempDueRecord on";
                    command1 = new SqlCommand(que1, connection);
                    command1.ExecuteNonQuery();
                    string insQuery = "insert into Due_Memo_Counter values(@date)";
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
                       dueReport = new DueReportUI(aList);
                        dueReport.ShowDialog();
                        String deletequery = "delete from TempDueRecord";
                        SqlCommand command1 = new SqlCommand(deletequery, connection);
                        connection.Open();
                        command1.ExecuteNonQuery();

                        string que = "DBCC CHECKIDENT (TempDueRecord,Reseed,0)";
                        command1 = new SqlCommand(que, connection);
                        command1.ExecuteNonQuery();
                        string que1 = "set identity_insert TempDueRecord on";
                        command1 = new SqlCommand(que1, connection);
                        command1.ExecuteNonQuery();
                        string insQuery = "insert into Due_Memo_Counter values(@date)";
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
                            //OrderUI odUi=new OrderUI();
                            //odUi.ShowDialog();
                        }
                    }
                    else if (dialog1 == DialogResult.No)
                    {
                        //this.Close();
                    }
                }
                
                    //end 
                
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
                string selectQ = "select MAX(Memo_No) from Due_Memo_Counter";
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

        private void paidToolStripMenuItem_Click(object sender, EventArgs e)
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

                double fbook = Convert.ToDouble(a);
                double fcopy = Convert.ToDouble(b);
                double fothers = Convert.ToDouble(c);
                double previousDue = Convert.ToDouble(item.SubItems[6]);
                string d = item.SubItems[7].Text;
                double total = Convert.ToDouble(d);
                string date = item.SubItems[8].Text;
                RecordDue aDue = new RecordDue();

                aDue.Serial = serial;
                aDue.Name = name;
                aDue.Mobile = mobile;
                aDue.Fbook = fbook;
                aDue.Fcopy = fcopy;
                aDue.Fothers = fothers;
                aDue.PreviousDue = previousDue;
                aDue.Total = total;
                aDue.Date = date;


                PaidUI paid = new PaidUI(aDue);
                DialogResult dialog = MessageBox.Show("Are you want to paid/add/Reduce now ?", "Message", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    listView1.Items.RemoveAt(index);
                    paid.ShowDialog();
                }

                return;
            }
            catch (Exception exception)
            {

               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void forphotocopytextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void forOThersTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
