using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using System.Data.SqlClient;

namespace Project_Librari_Management.UI
{
    public partial class IncomeRecord : Form
    {
        public IncomeRecord()
        {
            InitializeComponent();
        }

        private DataTable dataTable;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = "select * from Income";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = cmd;

                dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dataTable;
                dataGridView1.DataSource = bSource;
                myAdapter.Update(dataTable);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showTotalButton_Click(object sender, EventArgs e)
        {
            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();
            string selectQuery =
                "select SUM(From_Book), sum(From_Photocopy),sum(From_Others),sum(Total_Income) from Income";
            connection.Open();
            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<double> sellBooks = new List<double>();
            while (reader.Read())
            {
                try
                {

                    double fbook = Convert.ToInt16(reader[0]);
                    double fphotocopy = Convert.ToDouble(reader[1]);
                    double fothers = Convert.ToDouble(reader[2]);
                    double total = Convert.ToDouble(reader[3]);


                    bookTextBox.Text = fbook.ToString();
                    photocopyTextBox.Text = fphotocopy.ToString();
                    othersTextBox.Text = fothers.ToString();
                    sumofAllTextBox.Text = total.ToString();
                }
                catch (Exception)
                {

                    MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void searchByDateButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery =
                    "select SUM(From_Book), sum(From_Photocopy),sum(From_Others),sum(Total_Income) from Income Where Income_Date='" +
                    dateTimePicker1.Text + "'";
                connection.Open();
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<double> sellBooks = new List<double>();
                while (reader.Read())
                {


                    if (reader[0].ToString().Equals(""))
                    {
                        MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (reader[1].ToString().Equals(""))
                    {
                        MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (reader[2].ToString().Equals(""))
                    {
                        MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (reader[3].ToString().Equals(""))
                    {
                        MessageBox.Show("NO data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        double fbook = Convert.ToInt16(reader[0]);
                        double fphotocopy = Convert.ToDouble(reader[1]);
                        double fothers = Convert.ToDouble(reader[2]);
                        double total = Convert.ToDouble(reader[3]);


                        bookTextBox.Text = fbook.ToString();
                        photocopyTextBox.Text = fphotocopy.ToString();
                        othersTextBox.Text = fothers.ToString();
                        sumofAllTextBox.Text = total.ToString();

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
                    string seletQuery = "delete from DueRecords where Date<'" + dateTimePicker1.Text + "'";
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

        private void IncomeRecord_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
        }
    }
}