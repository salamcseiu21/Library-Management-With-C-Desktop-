using System;
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
    public partial class HolidayCounterUI : Form
    {
        public HolidayCounterUI()
        {
            InitializeComponent();
            GetAllHoliday();
        }

        private void HolidaySaveButton_Click(object sender, EventArgs e)
        {
            DBManager manager=new DBManager();
            DateTime sdTime = dateTimePicker1.Value;
            DateTime eDateTime = dateTimePicker2.Value;
            int days = (eDateTime.Day - sdTime.Day)+1;
            SqlConnection connection = manager.Connection();
            string query = "Insert into Holiday_Counter values('"+reasonTextBox.Text+"','"+sdTime+"','"+eDateTime+"','"+days+"')";
            
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            if (reasonTextBox.Text.Equals(""))
            {
                 MessageBox.Show("Enter the reason for holiday.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int i = command.ExecuteNonQuery(); 
            }
            
          
            GetAllHoliday();
            connection.Close();
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
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string query = "select sum([Total Day's]) from Holiday_Counter";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                if (reader[0].Equals("0") || reader[0].Equals(""))
                {
                    MessageBox.Show("There are no holidays.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    int days = Convert.ToInt16(reader[0]);
                    MessageBox.Show(days + " days", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllHolidayCount();
        }
    }
}
