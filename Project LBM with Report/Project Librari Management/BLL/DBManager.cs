using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_Librari_Management.DAL.Gateway;
using System.Data.SqlClient;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.BLL
{
   public class DBManager
    {
       DBGateway gateway = new DBGateway();
       BookGateway bGateway = new BookGateway();
       protected SqlConnection connection;

       public SqlConnection Connection()
       {
           connection = gateway.GetDBconnection();

           return connection;
       }
       public string SaveBookS(Book aBook)
       {

           string st = bGateway.SaveBook(aBook);
           return st;
       }

      

       public List<Book> GetAllBooks()
       {
           BookGateway bGateway1 = new BookGateway();
           //List<Book> books = bGateway1.GetALLBooks();

           return null;
       }
    }
}
