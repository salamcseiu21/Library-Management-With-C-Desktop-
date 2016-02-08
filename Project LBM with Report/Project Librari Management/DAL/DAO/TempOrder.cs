
namespace Project_Librari_Management.DAL.DAO
{
   public class TempOrder
   {
       private string serialNo;
       private string customerName;
       private string mobileNo;
       private string bookName;
       private string writerName;
       private string edition;
       private string type;
       private string print;
       private int quantity;
       private double unitprice;
       private double total;
       private double advance;
       private double due;
       private string supplyDate;
       private int id;
       private double payingAmmount;
       private int memoNumber;

       public TempOrder(string serial,string customerName,string mobile,string bookname,string writer,string
           edtion, string print,int quantity,double unitprice,double total,double advance,double due,double payYingAmount,int memoNo)
       {
           this.serialNo = serial;
           this.customerName = customerName;
           this.mobileNo = mobile;
           this.bookName = bookname;
           this.writerName = writer;
           this.edition = edtion;
           this.print = print;
           this.quantity = quantity;
           this.unitprice = unitprice;
           this.total = total;
           this.advance = advance;
           this.due = due;
           this.payingAmmount = payYingAmount;
           this.memoNumber = memoNo;

       }

       public TempOrder()
       {
           
       }



       public string SerialNo
       {
           get { return serialNo; }
           set { serialNo = value; }
       }

       public string CustomerName
       {
           get { return customerName; }
           set { customerName = value; }
       }

       public string MobileNo
       {
           get { return mobileNo; }
           set { mobileNo = value; }
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

       public double Advance
       {
           get { return advance; }
           set { advance = value; }
       }

       public double Due
       {
           get { return due; }
           set { due = value; }
       }

       public string SupplyDate
       {
           get { return supplyDate; }
           set { supplyDate = value; }
       }

       public int Id
       {
           get { return id; }
           set { id = value; }
       }

       public double PayingAmmount
       {
           get { return payingAmmount; }
           set { payingAmmount = value; }
       }

       public int MemoNumber
       {
           get { return memoNumber; }
           set { memoNumber = value; }
       }
   }
}
