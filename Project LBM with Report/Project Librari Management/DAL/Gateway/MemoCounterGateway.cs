using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.DAL.Gateway
{
   public class MemoCounterGateway
   {
       private DBManager manager=new DBManager();
       private SqlConnection connection;
       private SqlCommand command;
       private List<int> maxMemoNo=new List<int>();

       public List<int> GetLastMemoNumber()
       {
           try
           {
               connection = manager.Connection();
               string selectQuery = "select Max(Memo_No) from Order_Memo_Counter";

               command = new SqlCommand(selectQuery, connection);
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   int memoSerial = Convert.ToInt16(reader[0]);
                   maxMemoNo.Add(memoSerial);
               }



               
           }
           catch (Exception exception)
           {
               MessageBox.Show(exception.Message);
           }
           finally
           {
               connection.Close();
           }
           return maxMemoNo;
       }

       public List<int> GetLastMemoNumberFromMemoCounter()
       {
           try
           {
               connection = manager.Connection();
               string selectQuery = "select Max(Memo_No) from Order_Memo_Counter";

               command = new SqlCommand(selectQuery, connection);
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   int memoSerial = Convert.ToInt16(reader[0]);
                   maxMemoNo.Add(memoSerial);
               }

           }
           catch (Exception exception)
           {
               MessageBox.Show(exception.Message);
           }
           finally
           {
               connection.Close();
           }


           return maxMemoNo;
       }
       public List<int> GetLastMemoNumberFromDueMemoCounter()
       {
           try
           {
               connection = manager.Connection();
               string selectQuery = "select Max(Memo_No) from Order_Memo_Counter";

               command = new SqlCommand(selectQuery, connection);
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   int memoSerial = Convert.ToInt16(reader[0]);
                   maxMemoNo.Add(memoSerial);
               }
           }
           catch (Exception exception)
           {
               MessageBox.Show(exception.Message);
           }
           finally
           {
               connection.Close();
           }



           return maxMemoNo;
       }
   }
}
