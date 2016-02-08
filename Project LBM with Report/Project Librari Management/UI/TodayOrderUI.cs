using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.UI
{
    public partial class TodayOrderUI : Form
    {
        DBManager manager = new DBManager();
        private SqlConnection connection;
        public TodayOrderUI()
        {
            InitializeComponent();
            GetAllSelfOrder();
            memoNumver = GetLastMemoNumber();
        }

        private int memoNumver;

        public void GetAllSelfOrder()
        {


            try
            {
                connection = manager.Connection();

                string query =
                    "Select [Serial No] as SN,[Book Name],[Writer Name],Edition,Type,[Print],Quanitity from Self_Order";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter();

                myAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                myAdapter.Fill(dataTable);
                BindingSource bsSource = new BindingSource();
                bsSource.DataSource = dataTable;
                dataGridView1.DataSource = dataTable;
                myAdapter.Update(dataTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OrderReportUI order = new OrderReportUI();
                order.ShowDialog();
                System.Windows.Forms.DialogResult dialog = MessageBox.Show("Did you print the document?", "Print Message",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    String deletequery = "delete from Self_Order";
                    SqlCommand command1 = new SqlCommand(deletequery, connection);
                    connection.Open();
                    command1.ExecuteNonQuery();
                    string que = "DBCC CHECKIDENT (Self_Order,Reseed,0)";
                    command1 = new SqlCommand(que, connection);
                    command1.ExecuteNonQuery();
                    string que1 = "set identity_insert Self_Order on";
                    command1 = new SqlCommand(que1, connection);
                    command1.ExecuteNonQuery();
                    string insQuery = "insert into Self_Order_Memo_Counter values(@date)";
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
                        order = new OrderReportUI();
                        order.ShowDialog();
                        String deletequery = "delete from Self_Order";
                        SqlCommand command1 = new SqlCommand(deletequery, connection);
                        connection.Open();
                        command1.ExecuteNonQuery();

                        string que = "DBCC CHECKIDENT (Self_Order,Reseed,0)";
                        command1 = new SqlCommand(que, connection);
                        command1.ExecuteNonQuery();
                        string que1 = "set identity_insert Self_Order on";
                        command1 = new SqlCommand(que1, connection);
                        command1.ExecuteNonQuery();
                        string insQuery = "insert into Self_Order_Memo_Counter values(@date)";
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
                string selectQ = "select MAX(Memo_No) from Self_Order_Memo_Counter";
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

    }
}
