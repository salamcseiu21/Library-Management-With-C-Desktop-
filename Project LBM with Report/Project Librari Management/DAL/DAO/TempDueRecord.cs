using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Librari_Management.DAL.DAO
{
  public class TempDueRecord
  {
      private int serialNo;
      private string coustemerName;
      private string mobile;
      private double forBook;
      private double forCopy;
      private double forOthers;
      private double total;
      private double previousDue;
      private int memo_number;
      public int SerialNo
      {
          get { return serialNo; }
          set { serialNo = value; }
      }

      public string CoustemerName
      {
          get { return coustemerName; }
          set { coustemerName = value; }
      }

      public string Mobile
      {
          get { return mobile; }
          set { mobile = value; }
      }

      public double ForBook
      {
          get { return forBook; }
          set { forBook = value; }
      }

      public double ForCopy
      {
          get { return forCopy; }
          set { forCopy = value; }
      }

      public double ForOthers
      {
          get { return forOthers; }
          set { forOthers = value; }
      }

      public double Total
      {
          get { return total; }
          set { total = value; }
      }

      public double PreviousDue
      {
          get { return previousDue; }
          set { previousDue = value; }
      }

      public int MemoNumber
      {
          get { return memo_number; }
          set { memo_number = value; }
      }
  }
}
