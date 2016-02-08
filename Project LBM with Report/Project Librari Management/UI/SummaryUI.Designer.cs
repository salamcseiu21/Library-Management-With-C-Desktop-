namespace Project_Librari_Management.UI
{
    partial class SummaryUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.showDueTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sellingTextBOx = new System.Windows.Forms.TextBox();
            this.soldQunatityTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buyingTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lossTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.benifitTextBOx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1168, 457);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(6, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 340);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(813, 340);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.showDueTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.sellingTextBOx);
            this.groupBox2.Controls.Add(this.soldQunatityTextBox);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buyingTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lossTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.benifitTextBOx);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(827, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 366);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profit/Loss Info";
            // 
            // showDueTextBox
            // 
            this.showDueTextBox.Location = new System.Drawing.Point(130, 297);
            this.showDueTextBox.Name = "showDueTextBox";
            this.showDueTextBox.ReadOnly = true;
            this.showDueTextBox.Size = new System.Drawing.Size(111, 22);
            this.showDueTextBox.TabIndex = 23;
            this.showDueTextBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(93, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Due";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Tk";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tk";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Tk";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tk";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "pices";
            // 
            // sellingTextBOx
            // 
            this.sellingTextBOx.Location = new System.Drawing.Point(130, 130);
            this.sellingTextBOx.Name = "sellingTextBOx";
            this.sellingTextBOx.ReadOnly = true;
            this.sellingTextBOx.Size = new System.Drawing.Size(111, 22);
            this.sellingTextBOx.TabIndex = 7;
            this.sellingTextBOx.TabStop = false;
            // 
            // soldQunatityTextBox
            // 
            this.soldQunatityTextBox.Location = new System.Drawing.Point(130, 91);
            this.soldQunatityTextBox.Name = "soldQunatityTextBox";
            this.soldQunatityTextBox.ReadOnly = true;
            this.soldQunatityTextBox.Size = new System.Drawing.Size(111, 22);
            this.soldQunatityTextBox.TabIndex = 16;
            this.soldQunatityTextBox.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(141, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 40);
            this.button3.TabIndex = 0;
            this.button3.Text = "Show";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Cost_BenifitButton);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Quantity sold";
            // 
            // buyingTextBox
            // 
            this.buyingTextBox.Location = new System.Drawing.Point(130, 173);
            this.buyingTextBox.Name = "buyingTextBox";
            this.buyingTextBox.ReadOnly = true;
            this.buyingTextBox.Size = new System.Drawing.Size(111, 22);
            this.buyingTextBox.TabIndex = 8;
            this.buyingTextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = " Today\'s Loss";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selling Amount";
            // 
            // lossTextBox
            // 
            this.lossTextBox.Location = new System.Drawing.Point(130, 257);
            this.lossTextBox.Name = "lossTextBox";
            this.lossTextBox.ReadOnly = true;
            this.lossTextBox.Size = new System.Drawing.Size(111, 22);
            this.lossTextBox.TabIndex = 13;
            this.lossTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Buying Cost";
            // 
            // benifitTextBOx
            // 
            this.benifitTextBOx.Location = new System.Drawing.Point(130, 216);
            this.benifitTextBOx.Name = "benifitTextBOx";
            this.benifitTextBOx.ReadOnly = true;
            this.benifitTextBOx.Size = new System.Drawing.Size(111, 22);
            this.benifitTextBOx.TabIndex = 12;
            this.benifitTextBOx.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = " Today\'s Benifit";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(246, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 33);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 58);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show total sell ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.showSellSummaryButton);
            // 
            // SummaryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1168, 457);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SummaryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.SummaryUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox buyingTextBox;
        private System.Windows.Forms.TextBox sellingTextBOx;
        private System.Windows.Forms.TextBox benifitTextBOx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lossTextBox;
        private System.Windows.Forms.TextBox soldQunatityTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox showDueTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
    }
}