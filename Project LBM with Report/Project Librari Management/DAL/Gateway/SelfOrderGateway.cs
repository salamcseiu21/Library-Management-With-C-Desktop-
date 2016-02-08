using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.DAL.Gateway
{
    public class SelfOrderGateway
    {
        DBManager manager = new DBManager();
        
        public void SaveSelfOrder(SelfOrder selfOrder)
        {

            try
            {
                //start

                SqlConnection connection1 = manager.Connection();
                connection1.Close();
                string selectQuery1 = "Insert into Current_Self_Order values(@name,@writer,@edition,@type,@print,@quantity,@date)";


                SqlCommand cmd1 = new SqlCommand(selectQuery1, connection1);
                connection1.Open();
                cmd1.Parameters.Clear();
                cmd1.Parameters.AddWithValue("@name", selfOrder.BName);
                cmd1.Parameters.AddWithValue("@writer", selfOrder.BWriter);
                cmd1.Parameters.AddWithValue("@edition", selfOrder.BEdition);
                cmd1.Parameters.AddWithValue("@type", selfOrder.BType);
                cmd1.Parameters.AddWithValue("@print", selfOrder.BPrint);
                cmd1.Parameters.AddWithValue("@quantity", selfOrder.Quantity);
                cmd1.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                int ix = cmd1.ExecuteNonQuery();
                connection1.Close();
                //end



                if (HasThisBookalradyinList(selfOrder.BName, selfOrder.BWriter, selfOrder.BEdition, selfOrder.BType, selfOrder.BPrint) == false)
                {
                    manager = new DBManager();
                    SqlConnection connection = manager.Connection();
                    connection.Close();
                    string selectQuery = "Insert into Self_Order values(@name,@writer,@edition,@type,@print,@quantity,@date,@memoNumber)";


                    SqlCommand cmd = new SqlCommand(selectQuery, connection);
                    connection.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", selfOrder.BName);
                    cmd.Parameters.AddWithValue("@writer", selfOrder.BWriter);
                    cmd.Parameters.AddWithValue("@edition", selfOrder.BEdition);
                    cmd.Parameters.AddWithValue("@type", selfOrder.BType);
                    cmd.Parameters.AddWithValue("@print", selfOrder.BPrint);
                    cmd.Parameters.AddWithValue("@quantity", selfOrder.Quantity);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@memoNumber", selfOrder.MemoNo);
                    int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

                else
                {
                    MessageBox.Show("This book already include.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exception)
            {
                
                
               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool HasThisBookalradyinList(string p,string st1,string st2,string st3,string st4)
        {
            try
            {
                List<SelfOrder> orders = new List<SelfOrder>();
                {
                    string b_Name, b_Edition, b_Writer, b_type, b_print;


                    DBManager manager = new DBManager();
                    SqlConnection connection = manager.Connection();

                    string query = "Select [Book Name],[Writer Name],Edition,Type,[Print] from Self_Order where [Order Date]='" + DateTime.Now.ToShortDateString() + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader1 = command.ExecuteReader();

                    while (reader1.Read())
                    {
                        b_Name = reader1[0].ToString();
                        b_Writer = reader1[1].ToString();
                        b_Edition = reader1[2].ToString();
                        b_type = reader1[3].ToString();
                        b_print = reader1[4].ToString();
                        SelfOrder anOrder = new SelfOrder();
                        anOrder.BName = b_Name;
                        anOrder.BWriter = b_Writer;
                        anOrder.BEdition = b_Edition;
                        anOrder.BType = b_type;
                        anOrder.BPrint = b_print;
                        orders.Add(anOrder);
                    }
                }




                foreach (SelfOrder aOd in orders)
                {
                    if (aOd.BName.Equals(p) && aOd.BWriter.Equals(st1) && aOd.BEdition.Equals(st2) && aOd.BType.Equals(st3) && aOd.BPrint.Equals(st4))
                    {
                        return true;
                    }
                }
            }
            catch ( Exception exception)
            {
                
               
               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

       
    }
}
