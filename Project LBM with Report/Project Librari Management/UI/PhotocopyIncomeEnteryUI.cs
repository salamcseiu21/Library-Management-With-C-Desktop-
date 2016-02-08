using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class PhotocopyIncomeEnteryUI : Form
    {
        public int currentReadingMachine_1, currentReadingMachine_2, currentReadingMachine_3, currentReadingMachine_4;
        public PhotocopyIncomeEnteryUI()
        {
            InitializeComponent();
            GetCurrentReading();
            GetAllPhotocopyIncomeRecord();
        }

        private DataTable dataTable;

        public void GetAllPhotocopyIncomeRecord()
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string query = "select * from Photocopy";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {


                if (reader[0].ToString().Equals("")&& reader[1].ToString().Equals("")
                    && reader[2].ToString().Equals("")&&reader[3].ToString().Equals("")
                    && reader[4].ToString().Equals("")&&reader[5].ToString().Equals("")
                    &&reader[6].ToString().Equals(""))
                {
                    MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    int serial = Convert.ToInt16(reader[0]);
                    int machine_1 = Convert.ToInt16(reader[1]);
                    int machine_2 = Convert.ToInt16(reader[2]);
                    int machine_3 = Convert.ToInt16(reader[3]);
                    int machine_4 = Convert.ToInt16(reader[4]);
                    double total_Copy = Convert.ToDouble(reader[5]);
                    double copyRate = Convert.ToDouble(reader[6]);
                    double totalTaka = Convert.ToDouble(reader[7]);
                    string date = reader[8].ToString();

                  ListViewItem item=new ListViewItem(serial.ToString());
                    item.SubItems.Add(machine_1.ToString());
                    item.SubItems.Add(machine_2.ToString());
                    item.SubItems.Add(machine_3.ToString());
                    item.SubItems.Add(machine_4.ToString());
                    item.SubItems.Add(total_Copy.ToString());
                    item.SubItems.Add(copyRate.ToString());
                    item.SubItems.Add(totalTaka.ToString());
                    item.SubItems.Add(date.ToString());
                    listView1.Items.Add(item);
                }

            }


        }

        public void GetCurrentReading()
        {
            DBManager manager=new DBManager();
            SqlConnection connection = manager.Connection();
            string query = "select * from CurrentReading";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();  
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string s1 = reader[1].ToString();
                string s2 = reader[2].ToString();
                string s3 = reader[3].ToString();
                string s4 = reader[4].ToString();

                if (s1.Equals("")||s1.Equals("0"))
                {
                    currentReadingMachine_1 = 0;
                }
                if (s2.Equals("") || s2.Equals("0"))
                {
                    currentReadingMachine_2 = 0;
                }
                if (s3.Equals("") || s3.Equals("0"))
                {
                    currentReadingMachine_3 = 0;
                }

                if (s4.Equals("") || s4.Equals("0"))
                {
                    currentReadingMachine_4 = 0;
                }
                else
                {
                    currentReadingMachine_1 = Convert.ToInt16(s1);
                    currentReadingMachine_2 = Convert.ToInt16(s2);
                    currentReadingMachine_3 = Convert.ToInt16(s3);
                    currentReadingMachine_4 = Convert.ToInt16(s4);

                }

              
            }


        }


        private int mcn1, mcn2, mcn3, mcn4;
        private double  total;
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateTotalNumberofCopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (machine_1TextBox.Text.Equals("") || machine_1TextBox.Text.Equals("0"))
                {
                    MessageBox.Show("Pleace enter your 1st machine current reading.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (machine_2TextBox.Text.Equals("")||machine_2TextBox.Text.Equals("0"))
                {
                    MessageBox.Show("Pleace enter your 2nd machine current reading.", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                }
                else  if (machine_3TextBox.Text.Equals("") || machine_3TextBox.Text.Equals("0"))
                {
                    MessageBox.Show("Pleaceenter your 3rd machine current reading.", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                }
                else  if (machine_4TextBox.Text.Equals("") || machine_4TextBox.Text.Equals("0"))
                {
                    MessageBox.Show("Pleace enter your 4th machine current reading.", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                }
                else
                {
                    mcn1 = Convert.ToInt16(machine_1TextBox.Text) - currentReadingMachine_1;
                    mcn2 = Convert.ToInt16(machine_2TextBox.Text) - currentReadingMachine_2;
                    mcn3 = Convert.ToInt16(machine_3TextBox.Text) - currentReadingMachine_3;
                    mcn4 = Convert.ToInt16(machine_4TextBox.Text) - currentReadingMachine_4;
                }
                total = (mcn1 + mcn2 + mcn3 + mcn4)/2.0;
                totalCopyTextBox.Text = total.ToString();

            }
            catch (FormatException fxException)
            {

                MessageBox.Show(fxException.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {


            try
            {
                double total_Taka = Convert.ToDouble(totalCopyTextBox.Text) * Convert.ToDouble(copyRateTextBox.Text);
                totalTakaTextBox.Text = total_Taka.ToString();
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string query = "Insert Into Photocopy values('" + mcn1 + "','" + mcn2 + "','" + mcn3 + "','" + mcn4 + "','" + (Convert.ToDouble(totalCopyTextBox.Text)) + "','" + (Convert.ToDouble(copyRateTextBox.Text)) + "','" + (Convert.ToDouble(totalTakaTextBox.Text)) + "','" + DateTime.Now.ToShortDateString() + "')";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int i = command.ExecuteNonQuery();
                MessageBox.Show("Saved");
                connection.Close();
                string UpdateQuery = "UPDATE CurrentReading set Machine_1='" + mcn1 + "',Machine_2='" + mcn2 + "',Machine_3='" + mcn3 + "',Machine_4='" + mcn4 + "' where Id='" + 1 + "'";
                SqlCommand command1 = new SqlCommand(UpdateQuery, connection);
                connection.Open();
                int x = command1.ExecuteNonQuery();
                
                listView1.Items.Clear();
                GetAllPhotocopyIncomeRecord();
                connection.Close();
                ClearAlltextBox();
            }
            catch (FormatException )
            {

                MessageBox.Show("Please enter the copy rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAlltextBox()
        {
            machine_1TextBox.Clear();
            machine_2TextBox.Clear();
            machine_3TextBox.Clear();
            machine_4TextBox.Clear();
            totalCopyTextBox.Clear();
            copyRateTextBox.Clear();
            totalTakaTextBox.Clear();
        }

        private void SearchByButton(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery =
                    "select * from Photocopy where Copy_Date='"+dateTimePicker1.Text+"'";
                connection.Open();
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {


                    if (reader[0].ToString().Equals("")&&reader[1].ToString().Equals("")
                        &&reader[2].ToString().Equals("")&&reader[3].ToString().Equals("")
                        && reader[4].ToString().Equals("") && reader[5].ToString().Equals("")
                        && reader[6].ToString().Equals(""))
                    {
                        MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                   
                    else
                    {
                        int  serial = Convert.ToInt16(reader[0]);
                        int machine_1 = Convert.ToInt16(reader[1]);
                        int machine_2 = Convert.ToInt16(reader[2]);
                        int machine_3 = Convert.ToInt16(reader[3]);
                        int machine_4 = Convert.ToInt16(reader[4]);
                        double total_Copy = Convert.ToDouble(reader[5]);
                        double copyRate = Convert.ToDouble(reader[6]);
                        double totalTaka = Convert.ToDouble(reader[7]);
                        string date = reader[8].ToString();

                        ListViewItem item = new ListViewItem(serial.ToString());
                        item.SubItems.Add(machine_1.ToString());
                        item.SubItems.Add(machine_2.ToString());
                        item.SubItems.Add(machine_3.ToString());
                        item.SubItems.Add(machine_4.ToString());
                        item.SubItems.Add(total_Copy.ToString());
                        item.SubItems.Add(copyRate.ToString());
                        item.SubItems.Add(totalTaka.ToString());
                        item.SubItems.Add(date.ToString());
                        listView1.Items.Add(item);


                    }

                }
            }
            catch (FormatException)
            {

                MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "delete from Photocopy where Copy_Date<'" + dateTimePicker1.Text + "'";
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

        private void machine_1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void machine_2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void machine_3TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void machine_4TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void copyRateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void PhotocopyIncomeEnteryUI_Load(object sender, EventArgs e)
        {
           FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
        }

        
    }
}
