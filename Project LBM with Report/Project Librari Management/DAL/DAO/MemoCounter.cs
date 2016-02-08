using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
   public class MemoCounter
   {
       private DateTime saveDate;

       private int memoNo;
       public DateTime SaveDate
       {
           get { return saveDate; }
           set { saveDate = value; }
       }

       public int MemoNo
       {
           get { return memoNo; }
           set { memoNo = value; }
       }
   }
}
