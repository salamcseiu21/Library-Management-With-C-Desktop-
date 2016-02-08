using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.DAL.Gateway
{
   public class RecordDueGateway
    {
       public void SaveDueRecord(RecordDue aRecordDue)
       {
           DBManager manager = new DBManager();
           SqlCommand cmdCommand;
           SqlConnection connection = manager.Connection();
           double total;

           total = aRecordDue.Fbook + aRecordDue.Fcopy + aRecordDue.Fothers + aRecordDue.PreviousDue;
           connection.Open();
           try
           {


               if (HasThisCustomerPreviousDue(aRecordDue.Name, aRecordDue.Mobile) == false)
               {

               
               
               
               string insertQuery =
                   "Insert into DueRecords values(@name,@mobile,@fbook,@fcopy,@others,@previousdue,@total,@pdate)";
              
               cmdCommand = new SqlCommand(insertQuery, connection);
             
               cmdCommand.Parameters.Clear();
               cmdCommand.Parameters.Add("@name", aRecordDue.Name);
               cmdCommand.Parameters.Add("@mobile", aRecordDue.Mobile);
               //cmdCommand.Parameters.Add("@edition", aRecordDue.Fbook);
               cmdCommand.Parameters.Add("@fbook", aRecordDue.Fbook);
               cmdCommand.Parameters.Add("@fcopy", aRecordDue.Fcopy);
               cmdCommand.Parameters.Add("@others", aRecordDue.Fothers);
               cmdCommand.Parameters.AddWithValue("@previousdue", aRecordDue.PreviousDue);
               cmdCommand.Parameters.Add("@total", total);
               cmdCommand.Parameters.Add("@pdate", DateTime.Now.ToShortDateString());
               int i = cmdCommand.ExecuteNonQuery();
               MessageBox.Show(" Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
               else
               {
                   
                   string updateQuery =
                       "Update DueRecords Set F_Book=@fbook,F_Copy=@fcopy,F_Others=@others,Previous_Due=@previousdue,Total=@total,Date=@pdate where Name=@name and Mobile=@mobile";
                   cmdCommand=new SqlCommand(updateQuery,connection);
                   cmdCommand.Parameters.Clear();
                   
                   //cmdCommand.Parameters.Add("@edition", aRecordDue.Fbook);
                   cmdCommand.Parameters.Add("@fbook", aRecordDue.Fbook);
                   cmdCommand.Parameters.Add("@fcopy", aRecordDue.Fcopy);
                   cmdCommand.Parameters.Add("@others", aRecordDue.Fothers);
                   cmdCommand.Parameters.AddWithValue("@previousdue", aRecordDue.PreviousDue);
                   cmdCommand.Parameters.Add("@total", total);
                   cmdCommand.Parameters.Add("@pdate", DateTime.Now.ToShortDateString());
                   cmdCommand.Parameters.Add("@name", aRecordDue.Name);
                   cmdCommand.Parameters.Add("@mobile", aRecordDue.Mobile);
                   //connection.Open();
                   int i = cmdCommand.ExecuteNonQuery();
                   MessageBox.Show("Updated","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
               }
        }
            catch (FormatException exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private bool HasThisCustomerPreviousDue(string p, string p_2)
       {


           List<RecordDue> recordDues = GeDues();
           foreach (RecordDue recordDue in recordDues)
           {
               if (recordDue.Name.Equals(p)&&recordDue.Mobile.Equals(p_2))
               {
                   return true;
               }
           }

           return false;
       }

       public List<RecordDue> GeDues()
       {
           List<RecordDue> dues = new List<RecordDue>();
           try
           {
               DBManager manager = new DBManager();
               SqlConnection connection = manager.Connection();
               string selctQuery = "select * from DueRecords";
               SqlCommand command = new SqlCommand(selctQuery, connection);
              
               connection.Open();
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                   string name = reader[1].ToString();
                   string mobile = reader[2].ToString();
                   RecordDue aDue = new RecordDue();
                   aDue.Name = name;
                   aDue.Mobile = mobile;
                   dues.Add(aDue);

               }
               
           }
           catch (Exception exception)
           {

               MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return dues;
       } 
    }
}
