using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class HolidayCounterUI : Form
    {
        public HolidayCounterUI()
        {
            InitializeComponent();
            GetAllHoliday();
        }

        private void HolidaySaveButton_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            try
            {
                int s_day, s_month, s_year, e_day, e_month, e_year, total_Holiday;
                int day = 0, month = 0, year = 0;

                
                DateTime sdTime = dateTimePicker1.Value;
                s_day = sdTime.Day;
                s_month = sdTime.Month;
                s_year = sdTime.Year;

                DateTime eDateTime = dateTimePicker2.Value;
                e_day = eDateTime.Day;
                e_month = eDateTime.Month;
                e_year = eDateTime.Year;
                if (s_year > e_year)
                {
                    MessageBox.Show("Invalid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    if (s_day > e_day)
                    {

                        day = (e_day + 30) - s_day;
                        e_month = e_month - 1;

                    }
                    else
                    {
                        day = e_day - s_day;
                    }
                    if (s_month > e_month)
                    {
                        month = (e_month + 12) - s_month;
                        e_year = e_year - 1;
                    }
                    else
                    {
                        month = e_month - s_month;
                    }

                    total_Holiday = ((e_year - s_year)*365) + (month*30) + day + 1;
                    //int days = (eDateTime.Day - sdTime.Day)+1;

                    string query = "Insert into Holiday_Counter values(@reason,@sdtime,@eDateTime,@days)";


                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    if (reasonTextBox.Text.Equals(""))
                    {
                        MessageBox.Show("Enter the reason for holiday.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add("@reason", reasonTextBox.Text);
                        command.Parameters.Add("@sdtime", sdTime);
                        command.Parameters.Add("@eDateTime", eDateTime);
                        command.Parameters.Add("@days", total_Holiday);
                        command.ExecuteNonQuery();
                    }


                    GetAllHoliday();
                }
            }
            catch (Exception ecException)
            {
                MessageBox.Show(ecException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            
        }


        public void GetAllHoliday()
        {
            DBManager manager = new DBManager();


            DateTime sdTime = dateTimePicker1.Value;
            DateTime eDateTime = dateTimePicker2.Value;
            int days = (eDateTime.Day - sdTime.Day) + 1;

            SqlConnection connection = manager.Connection();
            string query = "select * from Holiday_Counter";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataAdapter myAdapter=new SqlDataAdapter();
            myAdapter.SelectCommand = command;
            DataTable dataTable=new DataTable();
            myAdapter.Fill(dataTable);
            BindingSource bSource=new BindingSource();
            bSource.DataSource = dataTable;
            dataGridView1.DataSource = dataTable;
            myAdapter.Update(dataTable);

        }


        public void GetAllHolidayCount()    
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string query = "select sum([Total Day's]) from Holiday_Counter";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].Equals("0") || reader[0].Equals(""))
                    {
                        MessageBox.Show("There are no holidays.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        int days = Convert.ToInt16(reader[0]);
                        int year = days/365;
                         days = days%365;
                        int month = days/30;
                        days = days%30;
                       
                        MessageBox.Show(year + "  Years " + month + "  Month  " + days + "  Day.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Empty", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllHolidayCount();
        }
    }
}
