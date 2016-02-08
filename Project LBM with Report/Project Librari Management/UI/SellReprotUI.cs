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
    public partial class SellReprotUI : Form
    {
        private List<TempSell> atempSell;

        public SellReprotUI(List<TempSell> aTempSell)
        {
            InitializeComponent();
            this.atempSell = aTempSell;

        }

        private void SellReprotUI_Load(object sender, EventArgs e)
        {


            try
            {
                CrystalReport2 objRpt = new CrystalReport2();
                objRpt.SetDataSource(atempSell);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }
}
