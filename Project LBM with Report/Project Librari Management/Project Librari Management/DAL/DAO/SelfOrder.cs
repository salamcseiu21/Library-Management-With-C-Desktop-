using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class SelfOrder
   {
       private string b_name;
       private string b_writer;
       private string b_edition;
       private int quantity;
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
   }
}
