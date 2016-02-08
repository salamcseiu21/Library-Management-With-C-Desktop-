using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.DAL.Gateway
{
  public class TempDueRecordGateway
    {

        private DBManager manager = new DBManager();
        private SqlConnection connection;
        private SqlCommand command;
     
      public void SaveTempDueRecord(TempDueRecord aTempDueRecord)
      {
          try
          {
              connection = manager.Connection();
              string insertQuery =
                  "insert into TempDueRecord values(@name,@mobile,@forBook,@forCopy,@forOthers,@previousDue,@total,@memoNo)";
              command = new SqlCommand(insertQuery, connection);
              command.Parameters.Clear();
              command.Parameters.AddWithValue("@name", aTempDueRecord.CoustemerName);
              command.Parameters.AddWithValue("@mobile", aTempDueRecord.Mobile);
              command.Parameters.AddWithValue("@forBook", aTempDueRecord.ForBook);
              command.Parameters.AddWithValue("@forCopy", aTempDueRecord.ForCopy);
              command.Parameters.AddWithValue("@forOthers", aTempDueRecord.ForOthers);
              command.Parameters.AddWithValue("@previousDue", aTempDueRecord.PreviousDue);
              command.Parameters.AddWithValue("@total", aTempDueRecord.Total);
              command.Parameters.AddWithValue("@memoNo", aTempDueRecord.MemoNumber);
              connection.Open();
              command.ExecuteNonQuery();
              MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

      public List<TempDueRecord> GeTempDueRecords()
      {


          List<TempDueRecord> tempDueRecords = new List<TempDueRecord>();

          try
          {
              connection = manager.Connection();

              string selectQuery = "select * from TempDueRecord";
              command = new SqlCommand(selectQuery, connection);
              connection.Open();
              SqlDataReader reader = command.ExecuteReader();
             
              
              while (reader.Read())
              {

                  if (reader[0].ToString().Equals(""))
                  {
                      MessageBox.Show("There are no avilable Due", "Message", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
                  }
                  else
                  {
                      TempDueRecord aRecord = new TempDueRecord();
                      aRecord.SerialNo = Convert.ToInt16(reader[0]);
                      aRecord.CoustemerName = reader[1].ToString();
                      aRecord.Mobile = reader[2].ToString();
                      aRecord.ForBook = Convert.ToDouble(reader[3]);
                      aRecord.ForCopy = Convert.ToDouble(reader[4]);
                      aRecord.ForOthers = Convert.ToDouble(reader[5]);
                      aRecord.PreviousDue = Convert.ToDouble(reader[6]);
                      aRecord.Total = Convert.ToDouble(reader[7]);
                      aRecord.MemoNumber = Convert.ToInt16(reader[8]);
                      tempDueRecords.Add(aRecord);
                  }

              }
              
          }
          catch (Exception exception)
          {
              MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          finally
          {
              connection.Close();
          }
          return tempDueRecords;
      } 
    }
}
