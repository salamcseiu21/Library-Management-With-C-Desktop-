using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;
using Project_Librari_Management.Report;

namespace Project_Librari_Management.UI
{
    public partial class ReportDeliveryUI : Form
    {
        private List<TempOrder> tempOrders;
        public ReportDeliveryUI( List<TempOrder> tempOrders )
        {
            InitializeComponent();
           this.tempOrders = tempOrders;
        }

        private void ReportDeliveryUI_Load(object sender, EventArgs e)
        {
            
            
          
            CrystalReportDelivery crystalReportDelivery=new CrystalReportDelivery();
            crystalReportDelivery.SetDataSource(tempOrders);
            crystalReportViewer1.ReportSource = crystalReportDelivery;
            crystalReportViewer1.RefreshReport();


        }
    }
}
