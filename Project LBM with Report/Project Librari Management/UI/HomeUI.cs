using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.UI
{
    public partial class HomeUI : Form
    {
        public string userName, passWord;
        public HomeUI(string user, string password)
        {
            InitializeComponent();
            this.userName = user;
            this.passWord = password;
            timer1.Start();
            TestBook();
        }
        private string b_type, book_print;
        DataTable dataTable;
        private void HomeUI_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
        }
        


        private void entryButton_Click_1(object sender, EventArgs e)
        {
            LibraryManagementUI uI = new LibraryManagementUI();
            uI.ShowDialog();
        }

        private void SearchAndSellButton(object sender, EventArgs e)
        {
            SearchAndEdit shui = new SearchAndEdit();
            shui.ShowDialog();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateUI update = new UpdateUI();
            update.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IncomeRecord inRecord = new IncomeRecord();
            inRecord.ShowDialog();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ShowOrders showOrder = new ShowOrders();
            showOrder.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Book_Name,Writer,Edition,Quantity from Orders";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                List<Order> orders = new List<Order>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookName = reader[0].ToString();
                    string writerName = reader[1].ToString();
                    string edition = reader[2].ToString();
                    string qu = reader[3].ToString();
                    int quantity = Convert.ToInt16(qu);

                    Order anOrder = new Order();
                    anOrder.BookName = bookName;
                    anOrder.WriterName = writerName;
                    anOrder.Edition = edition;
                    anOrder.Quantity = quantity;
                    orders.Add(anOrder);


                }

                QuantitySelect aQuantitySelect = new QuantitySelect(orders);
                aQuantitySelect.ShowDialog();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void showSelfOrderAndDoPdf_Click_1(object sender, EventArgs e)
        {
            ShowSelfOrderUI showSelfOrder = new ShowSelfOrderUI();
            showSelfOrder.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            DeliveryReportUI daUi = new DeliveryReportUI();
            daUi.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ShowOrderUI showOrder = new ShowOrderUI();
            showOrder.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OrderUI order = new OrderUI();
            order.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HolidayCounterUI holiday = new HolidayCounterUI();
            holiday.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangeUserAndPasswordUI change = new ChangeUserAndPasswordUI(userName, passWord);

            change.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewDueRecordUI viewDueRecord = new ViewDueRecordUI();
            viewDueRecord.ShowDialog();
        }

        private void DuerecordButton_Click_1(object sender, EventArgs e)
        {
            double b = 0;
            DueRecord dueRecord = new DueRecord(b);
            dueRecord.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            BalanceCalculationUI balanceCalculation = new BalanceCalculationUI();
            balanceCalculation.ShowDialog();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            CashAdjustUI cashAdjust = new CashAdjustUI();
            cashAdjust.ShowDialog();
        }

        private void summaryButton_Click_1(object sender, EventArgs e)
        {
            SummaryUI smUI = new SummaryUI();
            smUI.ShowDialog();
        }

        private void costEntryButton_Click_1(object sender, EventArgs e)
        {
            InvestmentUI inUI = new InvestmentUI();
            inUI.ShowDialog();
        }

        private void photocopyIncomeEntryButton_Click_1(object sender, EventArgs e)
        {
            PhotocopyIncomeEnteryUI photocopy = new PhotocopyIncomeEnteryUI();
            photocopy.ShowDialog();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            SimpleCalculationUI calculation = new SimpleCalculationUI();
            calculation.ShowDialog();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            TestUI test = new TestUI();
            test.ShowDialog();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //LibraryManagementUI uI = new LibraryManagementUI();
            //uI.ShowDialog();
        }

        private void button15_Click_1(object sender, EventArgs e)
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

        private void button16_Click(object sender, EventArgs e)
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
                MessageBox.Show("Sucessful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
