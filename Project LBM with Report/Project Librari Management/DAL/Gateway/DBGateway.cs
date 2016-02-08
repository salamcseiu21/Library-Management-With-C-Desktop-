using System.Configuration;
using System.Data.SqlClient;
namespace Project_Librari_Management.DAL.Gateway
{
   public class DBGateway
    {
       private string connectionString = ConfigurationManager.ConnectionStrings["library managemment"].ConnectionString;
       protected SqlConnection connection;

       public SqlConnection GetDBconnection()
       {
           connection = new SqlConnection(connectionString);
           return connection;
       }


      
    }
}
