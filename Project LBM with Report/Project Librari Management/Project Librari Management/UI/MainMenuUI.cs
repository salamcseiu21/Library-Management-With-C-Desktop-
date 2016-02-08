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
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class MainMenuUI : Form
    {
        public string userName, passWord;

        public MainMenuUI( string user,string password)
        {
            InitializeComponent();
            this.userName = user;
            this.passWord = password;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateUI update = new UpdateUI();
            update.ShowDialog();
        }

        private void entryButton_Click(object sender, EventArgs e)
        {
            LibraryManagementUI uI = new LibraryManagementUI();
            uI.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SearchAndEdit shui = new SearchAndEdit();
            shui.ShowDialog();
        }

        private void costEntryButton_Click(object sender, EventArgs e)
        {
            InvestmentUI inUI = new InvestmentUI();
            inUI.ShowDialog();
        }

        private void summaryButton_Click(object sender, EventArgs e)
        {
            SummaryUI smUI = new SummaryUI();
            smUI.ShowDialog();
        }

       



        private void incomeRecordButton(object sender, EventArgs e)
        {
            IncomeRecord inRecord = new IncomeRecord();
            inRecord.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderUI order=new OrderUI();
            order.ShowDialog();
        }

        private void DuerecordButton_Click(object sender, EventArgs e)
        {
            double b=0;
            DueRecord dueRecord = new DueRecord(b);
            dueRecord.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowOrderUI showOrder=new ShowOrderUI();
            showOrder.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT Book_Name,Writer,Edition,Quantity from Orders";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
               List<Order> orders=new List<Order>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string bookName = reader[0].ToString();
                    string writerName = reader[1].ToString();
                    string edition = reader[2].ToString();
                    string qu = reader[3].ToString();
                    int quantity = Convert.ToInt16(qu);

                    Order anOrder=new Order();
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

        private void showALlDueButton(object sender, EventArgs e)
        {
            ViewDueRecordUI viewDueRecord = new ViewDueRecordUI();
            viewDueRecord.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DeliveryReportUI daUi=new DeliveryReportUI();
            daUi.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowOrders showOrder= new ShowOrders();
            showOrder.ShowDialog();
        }

        private void changeUserButton(object sender, EventArgs e)
        {
            ChangeUserAndPasswordUI change=new ChangeUserAndPasswordUI(userName,passWord);

            change.ShowDialog();
           
        }

        private void photocopyIncomeEntryButton_Click(object sender, EventArgs e)
        {
            PhotocopyIncomeEnteryUI photocopy=new PhotocopyIncomeEnteryUI();
            photocopy.ShowDialog();
        }

        private void BalanceClauclationButton(object sender, EventArgs e)
        {

            BalanceCalculationUI balanceCalculation=new BalanceCalculationUI();
            balanceCalculation.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CashAdjustUI cashAdjust=new CashAdjustUI();
            cashAdjust.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HolidayCounterUI holiday=new HolidayCounterUI();
            holiday.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString();
        }

        private void MainMenuUI_Load(object sender, EventArgs e)
        {

        }
    }
}
