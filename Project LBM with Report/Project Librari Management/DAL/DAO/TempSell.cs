using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class TempSell
   {

       private int id;
       private string bookName;
       private string writerName;
       private string edition;
       private string type;
       private string print;
       private int quantity;
       private double unitprice;
       private double total;
       private double pay;
       private double due;
       private int memonumber;
       public int Id
       {
           get { return id; }
           set { id = value; }
       }

       public string BookName
       {
           get { return bookName; }
           set { bookName = value; }
       }

       public string WriterName
       {
           get { return writerName; }
           set { writerName = value; }
       }

       public string Edition
       {
           get { return edition; }
           set { edition = value; }
       }

       public string Type
       {
           get { return type; }
           set { type = value; }
       }

       public string Print
       {
           get { return print; }
           set { print = value; }
       }

       public int Quantity
       {
           get { return quantity; }
           set { quantity = value; }
       }

       public double Unitprice
       {
           get { return unitprice; }
           set { unitprice = value; }
       }

       public double Total
       {
           get { return total; }
           set { total = value; }
       }

       public double Pay
       {
           get { return pay; }
           set { pay = value; }
       }

       public double Due
       {
           get { return due; }
           set { due = value; }
       }

       public int Memonumber
       {
           get { return memonumber; }
           set { memonumber = value; }
       }
   }
}
