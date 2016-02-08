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
    public class OrderGateway
    {
        public string SaveOrder(Order anOrder)
        {
            try
            {


                if (anOrder.Quantity <= 0)
                {
                    MessageBox.Show("Enter the book quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (anOrder.Advance < 0)
                {
                    MessageBox.Show("Enter the advance ammount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //int quantity =;
                     double total = anOrder.Quantity*anOrder.UnitPrice;
                    double due = total - anOrder.Advance;
                    DBManager manager = new DBManager();
                    SqlConnection connection = manager.Connection();
                    string insertQuery = "INSERT INTO Orders values('" + anOrder.CustomerName + "','" +
                                         anOrder.CustomerPhone + "','" + anOrder.BookName + "','" + anOrder.WriterName +
                                         "','" + anOrder.Edition + "','"+anOrder.BuyUnitPrice+"','" + anOrder.Quantity + "','" + anOrder.UnitPrice +
                                         "','" + total + "','" + anOrder.Advance + "','" + due + "','" +
                                         DateTime.Now.ToShortDateString() + "','" + anOrder.SupplyDate + "')";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    connection.Open();
                    int i = insertCommand.ExecuteNonQuery();
                    
                }
                

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            return " Order Saved";
        }
    }
}

