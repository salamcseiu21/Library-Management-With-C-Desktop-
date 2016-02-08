
namespace Project_Librari_Management.DAL.DAO
{
   public class SelfOrder
   {
       private string seril_no;
       private string b_name;
       private string b_writer;
       private string b_edition;
       private string b_type;
       private string b_print;
       private int quantity;
       private int memoNo;
       public string BName
       {
           get { return b_name; }
           set { b_name = value; }
       }

       public string BWriter
       {
           get { return b_writer; }
           set { b_writer = value; }
       }

       public string BEdition
       {
           get { return b_edition; }
           set { b_edition = value; }
       }

       public int Quantity
       {
           get { return quantity; }
           set { quantity = value; }
       }

       public string BType
       {
           get { return b_type; }
           set { b_type = value; }
       }

       public string BPrint
       {
           get { return b_print; }
           set { b_print = value; }
       }

       public string SerilNo
       {
           get { return seril_no; }
           set { seril_no = value; }
       }

       public int MemoNo
       {
           get { return memoNo; }
           set { memoNo = value; }
       }
   }
}
