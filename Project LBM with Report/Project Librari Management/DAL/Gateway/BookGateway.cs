using System;
using Project_Librari_Management.BLL;
using System.Data.SqlClient;
using Project_Librari_Management.DAL.DAO;

namespace Project_Librari_Management.DAL.Gateway
{
   public class BookGateway
    {
        
        

       public string SaveBook(Book aBook)
       {

           double totalPrice=Convert.ToDouble(aBook.Quantity)*Convert.ToDouble(aBook.UnitPrice);
           DBManager manager = new DBManager();
           SqlConnection connection = manager.Connection();
            string InsertQuerty = "Insert into Books values(@name,@writer,@edition,@type,@print,@quantity,@unitprice,@totalprice,@pdate)";
          // string InsertQuerty = string.Format("Insert into Books values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",aBook.BookName,aBook.AuthorName,aBook.Edition,aBook.TypeOfBook,aBook.BookPrint,aBook.Quantity,aBook.UnitPrice,totalPrice,aBook.PurchasesDate);
          // string insertQuery = "INSERT INTO Books values('"+aBook.BookName+"','"+aBook.AuthorName+"','"+aBook.Edition+"','"+aBook.TypeOfBook+"','"+aBook.BookPrint+"','"+aBook.Quantity+"','"+aBook.UnitPrice+"','"+totalPrice+"','"+aBook.PurchasesDate+"')";
           SqlCommand cmd = new SqlCommand(InsertQuerty, connection);
           connection.Open();
           cmd.Parameters.Clear();
           cmd.Parameters.AddWithValue("@name", aBook.BookName);
           cmd.Parameters.AddWithValue("@writer", aBook.AuthorName);
           cmd.Parameters.AddWithValue("@edition", aBook.Edition);
           cmd.Parameters.AddWithValue("@type", aBook.TypeOfBook);
           cmd.Parameters.AddWithValue("@print", aBook.BookPrint);
           cmd.Parameters.AddWithValue("@quantity", aBook.Quantity);
           cmd.Parameters.AddWithValue("@unitprice", aBook.UnitPrice);
           cmd.Parameters.AddWithValue("@totalprice", totalPrice);
           cmd.Parameters.AddWithValue("@pdate", aBook.PurchasesDate);
           int i = cmd.ExecuteNonQuery();
           return i + "  Book Saved";
           // connection.Close();
       }


       

       public string DeleteInfo(Book aBook)
       {
          
               
               DBManager manager = new DBManager();
               SqlConnection connection = manager.Connection();
               string deleteQuery = "Delete from Books where [S.No]='"+aBook.SerialNo+"'";
               SqlCommand cmd = new SqlCommand(deleteQuery, connection);
               connection.Open();

                 int i = cmd.ExecuteNonQuery();

                 return i + "row deleted";
                 
               }




               

           

           
       }
    }

