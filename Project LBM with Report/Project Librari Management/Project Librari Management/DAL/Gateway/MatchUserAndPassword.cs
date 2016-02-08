using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Project_Librari_Management.BLL;

namespace Project_Librari_Management.DAL.Gateway
{
    public class MatchUserAndPassword
    {
        private DBManager manager = new DBManager();
        private SqlConnection connection;

       public string user;
      public  string pass;

        public bool PasswordAndUserNameVerification(string st1, string st2)
        {

            
            connection = manager.Connection();
            string query = "SELECT * From Security_12";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               user = reader[0].ToString();
                pass = reader[1].ToString();
            }
           

            if (st1.Equals(user) && st2.Equals(pass))
            {
                return true;
            }

            else
            {
                return false;
            }
            

        }
    }
}
    

