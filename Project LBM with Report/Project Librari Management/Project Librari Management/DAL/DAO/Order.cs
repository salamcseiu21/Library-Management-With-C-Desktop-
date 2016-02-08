using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class Order
   {
      
       private string customerName ;
       private string customerPhone;
       private string bookName;
       private string writerName;
       private string edition;
       private int quantity;
       private double unitPrice;
       private double buyUnitPrice;
       private double advance;
       private string supplyDate;


       public string CustomerName
       {
           get { return customerName; }
           set { customerName = value; }
       }

       public string CustomerPhone
       {
           get { return customerPhone; }
           set { customerPhone = value; }
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

       public int Quantity
       {
           get { return quantity; }
           set { quantity = value; }
       }

       public double UnitPrice
       {
           get { return unitPrice; }
           set { unitPrice = value; }
       }

       public double Advance
       {
           get { return advance; }
           set { advance = value; }
       }

       public string SupplyDate
       {
           get { return supplyDate; }
           set { supplyDate = value; }
       }

       public double BuyUnitPrice
       {
           get { return buyUnitPrice; }
           set { buyUnitPrice = value; }
       }
   }
}
