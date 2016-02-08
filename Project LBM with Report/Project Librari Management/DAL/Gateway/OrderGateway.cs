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
                    string insertQuery = "INSERT INTO Orders values(@name,@phone,@bname,@bwriter,@bEdition,@type,@bPrint,@buyUnitprice,@bQuantity,@unitprice,@total,@advance,@due,@odrderDate,@supplyDate)";

                    //string insertQuery = "INSERT INTO Orders values('" + anOrder.CustomerName + "','" +
                    //                     anOrder.CustomerPhone + "','" + anOrder.BookName + "','" + anOrder.WriterName +
                    //                     "','" + anOrder.Edition + "','" + anOrder.BookPrint + "','" + anOrder.BuyUnitPrice + "','" + anOrder.Quantity + "','" + anOrder.UnitPrice +
                    //                     "','" + total + "','" + anOrder.Advance + "','" + due + "','" +
                    //                     DateTime.Now.ToShortDateString() + "','" + anOrder.SupplyDate + "')";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    connection.Open();
                    insertCommand.Parameters.Clear();
                    insertCommand.Parameters.AddWithValue("@name", anOrder.CustomerName);
                    insertCommand.Parameters.AddWithValue("@phone", anOrder.CustomerPhone);
                    insertCommand.Parameters.AddWithValue("@bname", anOrder.BookName);
                    insertCommand.Parameters.AddWithValue("@bwriter", anOrder.WriterName);
                    insertCommand.Parameters.AddWithValue("@bEdition", anOrder.Edition);
                    insertCommand.Parameters.AddWithValue("@type", anOrder.TypeOfBook);
                    insertCommand.Parameters.AddWithValue("@bPrint", anOrder.BookPrint);
                    insertCommand.Parameters.AddWithValue("@buyUnitprice", anOrder.BuyUnitPrice);
                    insertCommand.Parameters.AddWithValue("@bQuantity", anOrder.Quantity);
                    insertCommand.Parameters.AddWithValue("@unitprice", anOrder.UnitPrice);
                    insertCommand.Parameters.AddWithValue("@total", total);
                    insertCommand.Parameters.AddWithValue("@advance", anOrder.Advance);
                    insertCommand.Parameters.AddWithValue("@due", due);
                    insertCommand.Parameters.AddWithValue("@odrderDate", DateTime.Now.ToShortDateString());
                    insertCommand.Parameters.AddWithValue("@supplyDate", anOrder.SupplyDate);
                   
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

