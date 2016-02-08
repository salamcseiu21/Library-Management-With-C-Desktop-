using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Project_Librari_Management.DAL.DAO;
namespace Project_Librari_Management.DAL.Gateway
{
   public class DBGateway
    {
       private string connectionString = @"server=.\SQLExpress;database=LIbrary12;integrated security=true";
       protected SqlConnection connection;

       public SqlConnection GetDBconnection()
       {
           connection = new SqlConnection(connectionString);
           return connection;
       }


      
    }
}
