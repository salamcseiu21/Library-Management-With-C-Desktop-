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
        
        public void SaveSelfOrder(SelfOrder selfOrder)
        {

            
        

            if (HasThisBookalradyinList(selfOrder.BName,selfOrder.BWriter,selfOrder.BEdition) == false)
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                connection.Close();
                string selectQuery = "Insert into Self_Order values('" + selfOrder.BName + "','" +
                                     selfOrder.BWriter + "','" + selfOrder.BEdition + "','" + selfOrder.Quantity +
                                     "','" + DateTime.Now.ToShortDateString() + "')";

                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                
            }

            else
            {
                MessageBox.Show("This book already include.","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private bool HasThisBookalradyinList(string p,string st1,string st2)
        {
            List<SelfOrder> orders = new List<SelfOrder>();
            {
                string b_Name, b_Edition, b_Writer;


                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string query = "Select [Book Name],[Writer Name],Edition from Self_Order";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader1 = command.ExecuteReader();
                
                while (reader1.Read())
                {
                    b_Name = reader1[0].ToString();
                    b_Writer = reader1[1].ToString();
                    b_Edition = reader1[2].ToString();

                    SelfOrder anOrder = new SelfOrder();
                    anOrder.BName = b_Name;
                    anOrder.BWriter = b_Writer;
                    anOrder.BEdition = b_Edition;
                    orders.Add(anOrder);
                }
            }




            foreach (SelfOrder aOd in orders)
            {
                if (aOd.BName.Equals(p) && aOd.BWriter.Equals(st1)&& aOd.BEdition.Equals(st2))
                {
                    return true;
                }
            }
            return false;
        }

       
    }
}
