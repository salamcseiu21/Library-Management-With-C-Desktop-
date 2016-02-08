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
   public class RecordDueGateway
    {
       public void SaveDueRecord(RecordDue aRecordDue)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                double total;

                total = aRecordDue.Fbook + aRecordDue.Fcopy + aRecordDue.Fothers;
                string insertQuery = "INSERT INTO DueRecords values('" + aRecordDue.Name + "','" + aRecordDue.Mobile + "','" + aRecordDue.Fbook + "','" + aRecordDue.Fcopy + "','" + aRecordDue.Fothers + "','" + total + "','" + DateTime.Now.ToShortDateString() + "')";
                SqlCommand cmdCommand = new SqlCommand(insertQuery, connection);
                connection.Open();
                int i = cmdCommand.ExecuteNonQuery();
                MessageBox.Show(" Saved","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (FormatException exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
