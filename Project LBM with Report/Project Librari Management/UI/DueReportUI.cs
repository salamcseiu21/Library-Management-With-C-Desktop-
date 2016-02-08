using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.Report;

namespace Project_Librari_Management.UI
{
    public partial class DueReportUI : Form
    {
        private List<TempDueRecord> aList;
        private List<int> memoNo=new List<int>();
        public DueReportUI(List<TempDueRecord> aList )
        {
            InitializeComponent();
            this.aList = aList;
           // this.memoNo = memo;
        }

        private void DueReportUI_Load(object sender, EventArgs e)
        {
            //DataSet3 ds = new DataSet3();
            //DataTable t = ds.Tables.Add("Items");
            //t.Columns.Add("Due Record");
            //DataRow row,
            //    row1,
            //    row2,
            //    row3,
            //    row4,
            //    row5
            //    ;
            //row1 = t.NewRow();
            //row = t.NewRow();
            //row2 = t.NewRow();
            //row3 = t.NewRow();
            //row4 = t.NewRow();
            //row5 = t.NewRow();
            
            
           
            //row[0] = "Customer Name: " + st1;
            //row1[0] = "Mobile No: " + st2;
            //row2[0] = "For Book: " + st3+" TK";
            //row3[0] = "For Copy: " + st4+" TK";
            //row4[0] = "For Others: " + st5+" TK";
            //row5[0] = "Total: " + st6+ " TK";
            



            //t.Rows.Add(row);
            //t.Rows.Add(row1);
            //t.Rows.Add(row2);

            //t.Rows.Add(row3);
            //t.Rows.Add(row4);
            //t.Rows.Add(row5);
           

            CrystalReport3 objRpt = new CrystalReport3();
          //  CrystalReport3 soReport3=new CrystalReport3();
            objRpt.SetDataSource(aList);
            //soReport3.SetDataSource(memoNo);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.ReportSource = soReport3;
            crystalReportViewer1.Refresh();

        }
    }
}
