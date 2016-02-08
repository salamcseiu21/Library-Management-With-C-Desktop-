using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class Book
    {
        private string serialNo;
        private string bookName;
        private string authorName;
        private string edition;
        private string typeOfBook;
        private int quantity;
        private double unitPrice;
        private string purchasesDate;

        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
        
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
       

        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; }
        }
        

        public string TypeOfBook
        {
            get { return typeOfBook; }
            set { typeOfBook = value; }
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
        

        public string PurchasesDate
        {
            get { return purchasesDate; }
            set { purchasesDate = value; }
        }
        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }
    }
}
