using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.DAL.Gateway
{
   public class TempOrderGateway
    {
       DBManager manager=new DBManager();
       private SqlConnection connection;

       public List<TempOrder> GetempOrders()
       {
           List<TempOrder> orders = new List<TempOrder>();
           try
           {
               connection = manager.Connection();
              
               string selectQuery = "select * from Temp_Order_Hold";
               SqlCommand command = new SqlCommand(selectQuery, connection);
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   TempOrder aTempOrder = new TempOrder();
                   aTempOrder.SerialNo = reader[0].ToString();
                   aTempOrder.CustomerName = reader[1].ToString();
                   aTempOrder.MobileNo = reader[2].ToString();
                   aTempOrder.BookName = reader[3].ToString();
                   aTempOrder.WriterName = reader[4].ToString();
                   aTempOrder.Edition = reader[5].ToString();
                   aTempOrder.Type = reader[6].ToString();
                   aTempOrder.Print = reader[7].ToString();
                   aTempOrder.Quantity = Convert.ToInt16(reader[8]);
                   aTempOrder.Unitprice = Convert.ToDouble(reader[9]);
                   aTempOrder.Total = Convert.ToDouble(reader[10]);
                   aTempOrder.Advance = Convert.ToDouble(reader[11]);
                   aTempOrder.Due = Convert.ToDouble(reader[12]);
                   aTempOrder.SupplyDate = reader[13].ToString();
                   aTempOrder.Id = Convert.ToInt16(reader[14]);
                   aTempOrder.MemoNumber = Convert.ToInt16(reader[15]);
                   orders.Add(aTempOrder);
               }
               connection.Close();
           }
           catch (Exception exception)
           {
               
               
               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return orders;
         
       }

       public void SaveTempOrer(TempOrder aOrder)
       {
           try
           {
               DBManager maneageManager = new DBManager();
               SqlConnection connection1 = maneageManager.Connection();
               string query = "Insert into Temp_Order_Hold values(@serial,@customerName,@mobile,@bookName,@writerName,@edition,@type,@print,@quantity,@unitPrice,@total,@advance,@due,@supplydate,@memoNumber)";
               SqlCommand command = new SqlCommand(query, connection1);
               command.Parameters.Clear();
               command.Parameters.AddWithValue("@serial", aOrder.SerialNo);
               command.Parameters.AddWithValue("@customerName", aOrder.CustomerName);
               command.Parameters.AddWithValue("@mobile", aOrder.MobileNo);
               command.Parameters.AddWithValue("@bookName", aOrder.BookName);
               command.Parameters.AddWithValue("@writerName", aOrder.WriterName);
               command.Parameters.AddWithValue("@edition", aOrder.Edition);
               command.Parameters.AddWithValue("@type", aOrder.Type);
               command.Parameters.AddWithValue("@print", aOrder.Print);
               command.Parameters.AddWithValue("@quantity", aOrder.Quantity);
               command.Parameters.AddWithValue("@unitPrice", aOrder.Unitprice);
               command.Parameters.AddWithValue("@total", aOrder.Total);
               command.Parameters.AddWithValue("@advance", aOrder.Advance);
               command.Parameters.AddWithValue("@due", aOrder.Due);
               command.Parameters.AddWithValue("@supplydate", aOrder.SupplyDate);
               command.Parameters.AddWithValue("@memoNumber", aOrder.MemoNumber);
               connection1.Open();
               command.ExecuteNonQuery();
               MessageBox.Show("Saved", "Save Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

           }
           catch (Exception exception)
           {

               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       public void SaveDeliveryReport(TempOrder aOrder)
       {
           try
           {
               connection = manager.Connection();
               string query =
                   "Insert into Temp_Order_Delivery values(@serial,@customerName,@mobile,@bookName,@writerName,@edition,@print,@quantity,@unitPrice,@total,@advance,@due,@payingAmount,@memoNo)";

               SqlCommand cmd = new SqlCommand(query, connection);
               connection.Open();
               cmd.Parameters.Clear();
               cmd.Parameters.AddWithValue("@serial", aOrder.SerialNo);
               cmd.Parameters.AddWithValue("@customerName", aOrder.CustomerName);
               cmd.Parameters.AddWithValue("@mobile", aOrder.MobileNo);
               cmd.Parameters.AddWithValue("@bookName", aOrder.BookName);
               cmd.Parameters.AddWithValue("@writerName", aOrder.WriterName);
               cmd.Parameters.AddWithValue("@edition", aOrder.Edition);
               cmd.Parameters.AddWithValue("@print", aOrder.Print);
               cmd.Parameters.AddWithValue("@quantity", aOrder.Quantity);
               cmd.Parameters.AddWithValue("@unitPrice", aOrder.Unitprice);
               cmd.Parameters.AddWithValue("@total", aOrder.Total);
               cmd.Parameters.AddWithValue("@advance", aOrder.Advance);
               cmd.Parameters.AddWithValue("@due", aOrder.Due);
               cmd.Parameters.AddWithValue("@payingAmount", aOrder.PayingAmmount);
               cmd.Parameters.AddWithValue("@memoNo", aOrder.MemoNumber);
               cmd.ExecuteNonQuery();
              // MessageBox.Show("Saved into temp delivery report");
           }
           catch (Exception exception)
           {

               MessageBox.Show(exception.Message);
           }
           finally
           {
               connection.Close();
           }
       }


       public List<TempOrder> GeList()
       {

           connection = manager.Connection();
           List<TempOrder> orders = new List<TempOrder>();
           string selectQuery = "select * from Temp_Order_Delivery";
           try
           {
               SqlCommand command = new SqlCommand(selectQuery, connection);
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   TempOrder aTempOrder = new TempOrder();
                   aTempOrder.SerialNo = reader[0].ToString();
                   aTempOrder.CustomerName = reader[1].ToString();
                   aTempOrder.MobileNo = reader[2].ToString();
                   aTempOrder.BookName = reader[3].ToString();
                   aTempOrder.WriterName = reader[4].ToString();
                   aTempOrder.Edition = reader[5].ToString();
                   aTempOrder.Print = reader[6].ToString();
                   aTempOrder.Quantity = Convert.ToInt16(reader[7]);
                   aTempOrder.Unitprice = Convert.ToDouble(reader[8]);
                   aTempOrder.Total = Convert.ToDouble(reader[9]);
                   aTempOrder.Advance = Convert.ToDouble(reader[10]);
                   aTempOrder.Due = Convert.ToDouble(reader[11]);
                   aTempOrder.Id = Convert.ToInt16(reader[12]);
                   aTempOrder.PayingAmmount = Convert.ToDouble(reader[13]);
                   aTempOrder.MemoNumber = Convert.ToInt16(reader[14]);
                   orders.Add(aTempOrder);
               }
               connection.Close();
           }
           catch (Exception exception)
           {
               
               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return orders;
         

 


       } 


    }
}
