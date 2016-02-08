using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.Report;

namespace Project_Librari_Management.UI
{
    public partial class InvoiceUI : Form
    {
       List<TempOrder> aTempOrder=new List<TempOrder>(); 
        public InvoiceUI(List<TempOrder> orders )
        {
            InitializeComponent();
            this.aTempOrder = orders;
           
            
        }

        private void InvoiceUI_Load(object sender, EventArgs e)
        {



            try
            {
                CrystalReport1 objRpt = new CrystalReport1();
                objRpt.SetDataSource(aTempOrder);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
            catch ( Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
