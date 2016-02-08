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
using Project_Librari_Management.Report;

namespace Project_Librari_Management.UI
{
    public partial class OrderReportUI : Form
    {
        public OrderReportUI()
        {
            InitializeComponent();
            GetAll();

        }

        public List<SelfOrder> GetAll()
        {
            DBManager manager=new DBManager();
            SqlConnection connection = manager.Connection();
            connection.Open();
            List<SelfOrder> orders = new List<SelfOrder>();
            try
            {
                string query = "select * from Self_Order";
                SqlCommand command = new SqlCommand(query, connection);
              
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SelfOrder anOrder = new SelfOrder();
                    anOrder.SerilNo = reader[0].ToString();
                    anOrder.BName = reader[1].ToString();
                    anOrder.BWriter = reader[2].ToString();
                    anOrder.BEdition = reader[3].ToString();
                    anOrder.BType = reader[4].ToString();
                    anOrder.BPrint = reader[5].ToString();
                    anOrder.Quantity = Convert.ToInt16(reader[6]);
                    anOrder.MemoNo = Convert.ToInt16(reader[8]);
                    orders.Add(anOrder);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ;
            }
            finally
            {
                connection.Close();
            }

            return orders;
        }

        private void OrderReportUI_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
            List<SelfOrder> orders = GetAll();
            OrderCrystalReport1  report1=new OrderCrystalReport1();
            report1.SetDataSource(orders);
            crystalReportViewer1.ReportSource = report1;
        }

    }
}
