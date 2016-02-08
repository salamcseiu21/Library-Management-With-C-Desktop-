using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class RecordDue
   {

       private string serial;
       private string name;
       private string mobile;
       private double fbook;
       private double fcopy;
       private double fothers;
       private double total;
       private string date;
       public string Name
       {
           get { return name; }
           set { name = value; }
       }

       public string Mobile
       {
           get { return mobile; }
           set { mobile = value; }
       }

       public double Fbook
       {
           get { return fbook; }
           set { fbook = value; }
       }

       public double Fcopy
       {
           get { return fcopy; }
           set { fcopy = value; }
       }

       public double Fothers
       {
           get { return fothers; }
           set { fothers = value; }
       }

       public double Total
       {
           get { return total; }
           set { total = value; }
       }

       public string Serial
       {
           get { return serial; }
           set { serial = value; }
       }

       public string Date
       {
           get { return date; }
           set { date = value; }
       }
   }
}
