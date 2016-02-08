using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_Librari_Management.BLL;
using System.Data.SqlClient;
using Project_Librari_Management.DAL.DAO;
using System.Windows.Forms;
using Project_Librari_Management.UI;

namespace Project_Librari_Management.DAL.Gateway
{
   public class BookGateway
    {
        
        

       public string SaveBook(Book aBook)
       {

           double totalPrice=Convert.ToDouble(aBook.Quantity)*Convert.ToDouble(aBook.UnitPrice);
           DBManager manager = new DBManager();
           SqlConnection connection = manager.Connection();
          
           string insertQuery = "INSERT INTO Books values('"+aBook.BookName+"','"+aBook.AuthorName+"','"+aBook.Edition+"','"+aBook.TypeOfBook+"','"+aBook.Quantity+"','"+aBook.UnitPrice+"','"+totalPrice+"','"+aBook.PurchasesDate+"')";
           SqlCommand cmd = new SqlCommand(insertQuery, connection);
           connection.Open();
           int i = cmd.ExecuteNonQuery();
           return i + "  Book Saved";
           // connection.Close();
       }


       //public List<Book> GetALLBooks()
       //{
       //    try
       //    {
       //        DBManager manager1 = new DBManager();
       //        SqlConnection connection = manager1.Connection();
       //        string seletQuery = "select * from Books";
       //        SqlCommand selectCmd = new SqlCommand(seletQuery, connection);
       //        connection.Open();
       //        SqlDataReader myReader = selectCmd.ExecuteReader();
       //        List<Book> books = new List<Book>();
       //        while (myReader.Read())
       //        {
       //            string serial = myReader[0].ToString();
       //            string name = myReader[1].ToString();
       //            string authorName = myReader[2].ToString();
       //            string edition = myReader[3].ToString();
       //            string type = myReader[4].ToString();
       //            int quantity = Convert.ToInt16(myReader[5]);
       //            double unitprice = Convert.ToDouble(myReader[6]);
       //            string date = myReader[7].ToString();
       //            Book aBook = new Book();
       //            //MessageBox.Show("Name="+name);
       //            books.Add(aBook);
       //        }

       //        return books;
       //    }
       //    catch (Exception obj)
       //    {

       //        throw new Exception("Error",obj);
       //    }
      // }


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

