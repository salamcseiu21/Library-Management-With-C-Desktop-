using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using  System.Data.OleDb;
using Project_Librari_Management.DAL.DAO;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class ImportExcelDataUI : Form
    {
        public ImportExcelDataUI()
        {
            InitializeComponent();
        }

        private void ImportExcelDataUI_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog=new OpenFileDialog();
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                file_Path_TextBox.Text = openFileDialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string stringCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_Path_TextBox.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                OleDbConnection connection = new OleDbConnection(stringCon);
                OleDbDataAdapter myAdapter = new OleDbDataAdapter("select * from [" + sheet_Name_TextBox.Text + "$]", connection);
                DataTable dtTable = new DataTable();
                myAdapter.Fill(dtTable);
                dataGridView1.DataSource = dtTable;
            }
            catch (Exception exception )
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            saveToolStripMenuItem.Enabled = dataGridView1.SelectedRows.Count >= 0;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BookGateway gateway=new BookGateway();
                List<Book> books = new List<Book>();
                int count = dataGridView1.RowCount;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[i];

                    string s1 = row.Cells["S#No"].Value.ToString();
                    string name = row.Cells["Name"].Value.ToString();
                    string writer = row.Cells["Writer"].Value.ToString();
                    string edition = row.Cells["Edition"].Value.ToString();
                    string type = row.Cells["Type"].Value.ToString();
                    string print = row.Cells["Book_Print"].Value.ToString();
                    int quantity = Convert.ToInt16(row.Cells["Quantiy"].Value);
                    double bookUnitPrice = Convert.ToDouble(row.Cells["B_Unit_Price"].Value);
                    //double totalPrice = Convert.ToDouble(row.Cells["Total_Price"].Value);
                    string date = row.Cells["Purchase_Date"].Value.ToString();
                    Book aBook=new Book();
                    aBook.SerialNo = s1;
                    aBook.BookName = name;
                    aBook.AuthorName = writer;
                    aBook.Edition = edition;
                    aBook.TypeOfBook = type;
                    aBook.BookPrint = print;
                    aBook.Quantity = quantity;
                    aBook.UnitPrice = bookUnitPrice;
                    aBook.PurchasesDate = date;

                    gateway.SaveBook(aBook);
                    //books.Add(aBook);
                    
                }
                
            }
            catch (Exception exception)
            {

                MessageBox.Show("Saved");
            }
        }
    }
}
