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

namespace Project_Librari_Management.UI
{
    public partial class BanglaQueryUI : Form
    {
        public BanglaQueryUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string name = "N''জাভা";
            //    string writer = "N''বালাগুরুশামী";
            //    string edition = "3rd";

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
            try
            {


                string selectQuery = "SELECT * FROM Self_Order where [Book Name]=@name and [Writer Name]=@writer and Edition=@edition";
                connection.Open();

                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.Parameters.AddWithValue("@writer", writer_textBox.Text);
                command.Parameters.AddWithValue("@edition", edition_textBox.Text);
                SqlDataReader reader = command.ExecuteReader();
                List<SelfOrder> bookList=new List<SelfOrder>();
                while (reader.Read())
                {
                    string id = reader[0].ToString();
                    string bookname = reader[1].ToString();
                    string writer = reader[2].ToString();
                    string edition = reader[3].ToString();
                    string type = reader[4].ToString();
                    string print = reader[5].ToString();
                    string quantity = reader[6].ToString();
                   SelfOrder anOrder=new SelfOrder();
                    anOrder.SerilNo = id;
                    anOrder.BName = bookname;
                    anOrder.BWriter = writer;
                    anOrder.BEdition= edition;
                    anOrder.BType = type;
                    anOrder.BPrint = print;
                    if (quantity.Equals("")||quantity.Equals("0"))
                    {
                        anOrder.Quantity =0;  
                    }
                    else
                    {
                        anOrder.Quantity = Convert.ToInt16(quantity);
                    }
                    
                   bookList.Add(anOrder);
                }
                //dataGridView1.Columns[0].DataPropertyName = id;
                //dataGridView1.AutoGenerateColumns = false;
                //dataGridView1.Columns[1].DataPropertyName = "Name";
                //dataGridView1.Columns[2].DataPropertyName = "Writer";
                //dataGridView1.Columns[3].DataPropertyName = "Editon";
                dataGridView1.DataSource = bookList;


            }
            catch ( Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            connection.Close();
            }
        }

        
    }
}
