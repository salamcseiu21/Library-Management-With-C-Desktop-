using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using  System.IO;

namespace Project_Librari_Management.UI
{
    public partial class TestUI : Form
    {
        public TestUI()
        {
            InitializeComponent();
           // GetAllBook();
            TestBook();
        }

        private DataTable dt,dataTable;
        public void GetAllBook()
        {
            
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string query = "select * from Books";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    //comboBox1.Items.Add(name);

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

        private void TestUI_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
        }

        public void TestBook()
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "select * from ALl_Table_Name";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();

                    comboBox2.Items.Add(name);
                    //textBox3.Text = name;
                }


                //return null;
            }
            catch (Exception obj)
            {

                throw new Exception("Error", obj);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String fileName = "";
                String date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Title = "Save File As";
                saveFileDialog1.Filter = "Text Files(*.txt)|*.txt| Pdf Files(*.pdf)|*.pdf| All Files(*.*)|*.*";
                saveFileDialog1.FileName = fileName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))

                    using (StreamWriter sw = new StreamWriter(s))
                    {
                       
                        //sw.WriteLine(textBox1.Text);
                        //sw.WriteLine(tbSummary.Text);
                    }

                }
            }
            catch ( Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = string.Format("select * from " + comboBox2.SelectedItem);
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = cmd;

                dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dataTable;
                dataGridView2.DataSource = bSource;
                myAdapter.Update(dataTable);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

       

       

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection complete = new AutoCompleteStringCollection();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {

                DirectoryInfo file = Directory.CreateDirectory(folderBrowser.SelectedPath);
                string[] f1 = Directory.GetFiles(folderBrowser.SelectedPath);
                textBox2.Text = file.FullName;
                foreach (string s in f1)
                {
                    string nn = Path.GetFileName(s);
                    string str = nn.Remove(nn.Length - 4);
                    complete.Add(str);
                }

            }
            textBox3.AutoCompleteCustomSource = complete;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DBManager manager1 = new DBManager();
                SqlConnection connection = manager1.Connection();
                string seletQuery = "select * from  ALl_Table_Name where T_Name='" + comboBox2.SelectedItem + "'";
                SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
                connection.Open();

                SqlDataReader reader = selectCmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();

                    comboBox2.Items.Add(name);
                    textBox3.Text = name;
                }


                //return null;
            }
            catch (Exception obj)
            {

                throw new Exception("Error", obj);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string dirPath = string.Format(textBox2.Text + "\\");
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string selectQuery = string.Format("select * from " + comboBox2.SelectedItem);
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                myAdapter.SelectCommand = cmd;

                dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dataTable;
                dataGridView2.DataSource = bSource;
                myAdapter.Update(dataTable);


                DataSet dataSet = new DataSet("First_Datasheet");
                dataSet.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                //myAdapter.Fill(dataTable);
                dataSet.Tables.Add(dataTable);
                ExcelLibrary.DataSetHelper.CreateWorkbook(dirPath + textBox3.Text + ".xls", dataSet);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Please! enter the table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
