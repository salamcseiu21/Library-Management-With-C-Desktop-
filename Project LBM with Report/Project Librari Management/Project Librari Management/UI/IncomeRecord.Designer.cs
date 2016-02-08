namespace Project_Librari_Management.UI
{
    partial class IncomeRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomeRecord));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sumofAllTextBox = new System.Windows.Forms.RichTextBox();
            this.othersTextBox = new System.Windows.Forms.RichTextBox();
            this.photocopyTextBox = new System.Windows.Forms.RichTextBox();
            this.bookTextBox = new System.Windows.Forms.RichTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.searchByDateButton = new System.Windows.Forms.Button();
            this.showTotalButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(25, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Income Record Show";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.deleteButton);
            this.groupBox4.Location = new System.Drawing.Point(9, 328);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 68);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Delete Row";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(65, 29);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(109, 22);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Date";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(180, 18);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 40);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(642, 287);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sumofAllTextBox);
            this.groupBox2.Controls.Add(this.othersTextBox);
            this.groupBox2.Controls.Add(this.photocopyTextBox);
            this.groupBox2.Controls.Add(this.bookTextBox);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.searchByDateButton);
            this.groupBox2.Controls.Add(this.showTotalButton);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(726, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 402);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Income Display";
            // 
            // sumofAllTextBox
            // 
            this.sumofAllTextBox.Location = new System.Drawing.Point(117, 229);
            this.sumofAllTextBox.Name = "sumofAllTextBox";
            this.sumofAllTextBox.ReadOnly = true;
            this.sumofAllTextBox.Size = new System.Drawing.Size(100, 29);
            this.sumofAllTextBox.TabIndex = 23;
            this.sumofAllTextBox.Text = "";
            // 
            // othersTextBox
            // 
            this.othersTextBox.Location = new System.Drawing.Point(117, 185);
            this.othersTextBox.Name = "othersTextBox";
            this.othersTextBox.ReadOnly = true;
            this.othersTextBox.Size = new System.Drawing.Size(100, 29);
            this.othersTextBox.TabIndex = 22;
            this.othersTextBox.Text = "";
            // 
            // photocopyTextBox
            // 
            this.photocopyTextBox.Location = new System.Drawing.Point(117, 150);
            this.photocopyTextBox.Name = "photocopyTextBox";
            this.photocopyTextBox.ReadOnly = true;
            this.photocopyTextBox.Size = new System.Drawing.Size(100, 29);
            this.photocopyTextBox.TabIndex = 21;
            this.photocopyTextBox.Text = "";
            // 
            // bookTextBox
            // 
            this.bookTextBox.Location = new System.Drawing.Point(117, 107);
            this.bookTextBox.Name = "bookTextBox";
            this.bookTextBox.ReadOnly = true;
            this.bookTextBox.Size = new System.Drawing.Size(100, 29);
            this.bookTextBox.TabIndex = 20;
            this.bookTextBox.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(68, 314);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 22);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // searchByDateButton
            // 
            this.searchByDateButton.Location = new System.Drawing.Point(190, 297);
            this.searchByDateButton.Name = "searchByDateButton";
            this.searchByDateButton.Size = new System.Drawing.Size(100, 50);
            this.searchByDateButton.TabIndex = 18;
            this.searchByDateButton.Text = "Show By Date";
            this.searchByDateButton.UseVisualStyleBackColor = true;
            this.searchByDateButton.Click += new System.EventHandler(this.searchByDateButton_Click);
            // 
            // showTotalButton
            // 
            this.showTotalButton.Location = new System.Drawing.Point(133, 35);
            this.showTotalButton.Name = "showTotalButton";
            this.showTotalButton.Size = new System.Drawing.Size(75, 50);
            this.showTotalButton.TabIndex = 17;
            this.showTotalButton.Text = "Show All Profit";
            this.showTotalButton.UseVisualStyleBackColor = true;
            this.showTotalButton.Click += new System.EventHandler(this.showTotalButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tk";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tk";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tk";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Tk";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = " Book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Photocopy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Others";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sum of All";
            // 
            // IncomeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1066, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncomeRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Income  Record Window";
            this.Load += new System.EventHandler(this.IncomeRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button searchByDateButton;
        private System.Windows.Forms.Button showTotalButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.RichTextBox bookTextBox;
        private System.Windows.Forms.RichTextBox photocopyTextBox;
        private System.Windows.Forms.RichTextBox sumofAllTextBox;
        private System.Windows.Forms.RichTextBox othersTextBox;
    }
}