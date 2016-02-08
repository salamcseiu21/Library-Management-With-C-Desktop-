using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_Librari_Management.BLL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project_Librari_Management.DAL.Gateway
{
   public class InvestmentGateway
    {
        public string SaveTotalInvestment(DAO.Invest anInvest)
        {
            try
            {
                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();
                string insertQuery = "INSERT INTO InvestmentCost values('" + anInvest.Book + "','" + anInvest.Paper + "','" + anInvest.Ink + "','" + anInvest.Equipment + "','" + anInvest.Others + "','" + anInvest.Date + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                //MessageBox.Show("Saved");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return "Saved";
        }
    }
}
