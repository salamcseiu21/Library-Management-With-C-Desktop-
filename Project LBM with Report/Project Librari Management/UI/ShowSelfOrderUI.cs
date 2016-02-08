using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Project_Librari_Management.BLL;

using iTextSharp.text;
using  iTextSharp.text.pdf;
using  System.IO;

namespace Project_Librari_Management.UI
{
    public partial class ShowSelfOrderUI : Form
    {

        private string date;

        public ShowSelfOrderUI()
        {
            InitializeComponent();
            
        }

        private DataTable dataTable;
        private string[] filesStrings;
        public void GetAllSelfOrder()
        {


            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string query =
                "Select * from Current_Self_Order where Order_Date='" +
                dateTimePicker1.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataAdapter myAdapter = new SqlDataAdapter();

            myAdapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            myAdapter.Fill(dataTable);
            BindingSource bsSource = new BindingSource();
            bsSource.DataSource = dataTable;
            dataGridView1.DataSource = dataTable;
            myAdapter.Update(dataTable);
            GetTotalQuantity();
        }

        
        public void GetTotalQuantity()
        {
            int quantity;


            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string query = " select sum(Quantity) from Current_Self_Order where Order_Date='" +
                           dateTimePicker1.Text + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                try
                {
                    if (reader1[0].Equals("") || reader1[0].Equals("0"))
                    {
                        richTextBox1.Text = "0";
                    }
                    else
                    {
                        quantity = Convert.ToInt16(reader1[0]);
                        richTextBox1.Text = quantity.ToString();
                    }
                }
                catch (InvalidCastException)
                {


                }

            }

        }

        private void showOrderButton(object sender, EventArgs e)
        {
            GetAllSelfOrder();
        }

        public void GetAllOrders()  
        {
            try
            {

                DBManager manager = new DBManager();
                SqlConnection connection = manager.Connection();

                string selectQuery = "SELECT * From Current_Self_Order";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource binding = new BindingSource();
                binding.DataSource = dataTable;
                dataGridView1.DataSource = dataTable;
                adapter.Update(dataTable);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void createPdfButton(object sender, EventArgs e)
        {

            string test = string.Format(textBox1.Text);
            if (test.Equals("")) 
                {
                    MessageBox.Show("Please enter a file name.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else if( test.Contains("\\")||test.Equals("/"))
            {
                MessageBox.Show("Invalid character \\", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            }
                else if (!test.Equals(""))
                {
                    string name = string.Format(textBox2.Text);
           
               
                //ss = string.Format(name.FullName);
                if (File.Exists(name+"\\"+textBox1.Text+".pdf"))
                {
                    MessageBox.Show("File name must be unique.","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {

                        string path = string.Format(textBox2.Text + "\\");
                        string fileName = path + test + ".pdf";
                        Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 30, 10);
                        
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                        document.Open();
                        String st = Application.StartupPath;
                        st += "\\jj.jpg";
                        iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(st);
                        png.ScaleAbsolute(70,70);
                        png.SetAbsolutePosition(document.PageSize.Width -10f -340f,document.PageSize.Height -20f -50f);
                        document.Add(png);
                        Paragraph paragraph = new Paragraph("\n\n             Campuse Library \n   Islamic University,Kushtia-7003\n E-mail:campuslibraryiu@gmail.com    \n Mobile:01913-540251,01740197701\n  " + "             Date:" + DateTime.Now.ToShortDateString());
                        paragraph.IndentationLeft = 200f;
                        document.Add(paragraph);
                        Paragraph p = new Paragraph(""+'\n');
                        document.Add(p);

                        PdfPTable table = new PdfPTable(dataGridView1.ColumnCount-1);
                        PdfPCell cell = new PdfPCell(new Phrase("Total Book Order", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 16f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.ORANGE)));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(200, 20, 120);
                        iTextSharp.text.Font fntTableFont = FontFactory.GetFont("Times New Roman", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        table.WidthPercentage = 100;
                        table.HorizontalAlignment = 0;
                        table.SpacingAfter = 10;

                        cell.Colspan = dataGridView1.ColumnCount-1;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        for (int i = 0; i < dataGridView1.ColumnCount-1; i++)
                        {
                            table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText));
                        }
                        table.HeaderRows = 1;
                        table.NormalizeHeadersFooters();
                        float[] widths = new float[] { 1f, 4f, 4.5f, 1.25f, 1f, 1.25f, 1.50f};
                        table.SetWidths(widths);

                        
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount-1; j++)
                            {
                                if (dataGridView1[j, i].Value != null)
                                {
                                    PdfPCell CellOne = new PdfPCell(new Phrase(dataGridView1[j, i].Value.ToString(), fntTableFont));
                                   
                                    table.AddCell(CellOne);
                                }
                            }
                        }
                        document.Add(table);
                        int  sum = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count;++i)
                        {
                          
                            sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["Quantity"].Value);
                        }
                        Paragraph paragraph1 = new Paragraph("Total = " + sum + "  pices", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
                        paragraph1.IndentationLeft = 450f;
                        document.Add(paragraph1);
                        MessageBox.Show("Successfully Created pdf file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        document.Close();
                        System.Diagnostics.Process.Start(path + test + ".pdf");
                    }
                    catch (Exception exception)
                    {

                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
                
               
            }
           
            
        

        private void ShowSelfOrderUI_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Maximized;
        }

        private void selectDirectoryButton(object sender, EventArgs e)
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection complete = new AutoCompleteStringCollection();
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                
                DirectoryInfo file = Directory.CreateDirectory(folderBrowser.SelectedPath);
                string[] f1 = Directory.GetFiles(folderBrowser.SelectedPath);
                textBox2.Text = file.FullName;
                foreach (string s in f1)
                {
                    string nn = Path.GetFileName(s);
                    string str = nn.Remove(nn.Length - 4);
                    complete.Add(str);
                }

            }
            textBox1.AutoCompleteCustomSource = complete;
        }

      

        private void button4_Click_1(object sender, EventArgs e)
        {
            GetAllOrders();
            GetTotalQuantity1();
        }

        public void GetTotalQuantity1()
        {
            int quantity;


            DBManager manager = new DBManager();
            SqlConnection connection = manager.Connection();

            string query = " select sum(Quantity) from Current_Self_Order";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                try
                {
                    if (reader1[0].Equals("") || reader1[0].Equals("0"))
                    {
                        richTextBox1.Text = "0";
                    }
                    else
                    {
                        quantity = Convert.ToInt16(reader1[0]);
                        richTextBox1.Text = quantity.ToString();
                    }
                }
                catch (InvalidCastException)
                {


                }

            }

        }
       

        }

       

    }

