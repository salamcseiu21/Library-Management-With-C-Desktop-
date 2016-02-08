using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.UI
{
    public partial class UpdateUI : Form
    {
        public UpdateUI()
        {
            InitializeComponent();
            //LoadAllBook();
            TestBook();
        }
        string b_type;
        private DataTable dt;
        
       
       
        public void TestBook()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "select * from Books Order by Name";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();

                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = selectCmd;

                dt = new DataTable();
                myAdapter.Fill(dt);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dt;
                dataGridView1.DataSource = dt;
                myAdapter.Update(dt);



                //return null;
            }
            catch (Exception obj)
            {

                throw new Exception("Error", obj);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dataviw = new DataView(dt);
            dataviw.RowFilter = string.Format("Name Like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dataviw;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.RowCount >= 0)
            //{
            //    int n = dataGridView1.SelectedRows.Count;
            //    for (int j = 0; j < n; j++)
            //    {
            //        DataGridView row = this.dataGridView1;
            //        string i=
            //        MessageBox.Show(i);
            //    }
               
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    string serialNo = row.Cells["S.No"].Value.ToString();
                    DBManager manager=new DBManager();
                    SqlConnection connection = manager.Connection();
                    string query = "delete from Books Where [S.No]='" + serialNo + "'";
                    SqlCommand delCommand=new SqlCommand(query,connection);
                    connection.Open();

                    System.Windows.Forms.DialogResult result =
                        MessageBox.Show("Do you wnat to delete the selected book?", "Message", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        delCommand.ExecuteNonQuery();
                        MessageBox.Show("deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TestBook(); 
                    }


 
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.StackTrace);
            }
        }

        private void UpdateUI_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
        }

       
       
    }
}
