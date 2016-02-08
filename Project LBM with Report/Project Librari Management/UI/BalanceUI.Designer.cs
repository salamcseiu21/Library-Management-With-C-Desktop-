namespace Project_Librari_Management.UI
{
    partial class BalanceUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalIncomeTextBOx = new System.Windows.Forms.RichTextBox();
            this.othersincomeTextOBx = new System.Windows.Forms.RichTextBox();
            this.photocopyTextBpx = new System.Windows.Forms.RichTextBox();
            this.bookProfitTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 351);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Benifit Calculation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.totalIncomeTextBOx);
            this.groupBox2.Controls.Add(this.othersincomeTextOBx);
            this.groupBox2.Controls.Add(this.photocopyTextBpx);
            this.groupBox2.Controls.Add(this.bookProfitTextBox);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(28, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 267);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Income Source";
            // 
            // totalIncomeTextBOx
            // 
            this.totalIncomeTextBOx.Location = new System.Drawing.Point(130, 199);
            this.totalIncomeTextBOx.Name = "totalIncomeTextBOx";
            this.totalIncomeTextBOx.ReadOnly = true;
            this.totalIncomeTextBOx.Size = new System.Drawing.Size(93, 26);
            this.totalIncomeTextBOx.TabIndex = 23;
            this.totalIncomeTextBOx.TabStop = false;
            this.totalIncomeTextBOx.Text = "";
            // 
            // othersincomeTextOBx
            // 
            this.othersincomeTextOBx.Location = new System.Drawing.Point(130, 144);
            this.othersincomeTextOBx.Name = "othersincomeTextOBx";
            this.othersincomeTextOBx.ReadOnly = true;
            this.othersincomeTextOBx.Size = new System.Drawing.Size(93, 26);
            this.othersincomeTextOBx.TabIndex = 22;
            this.othersincomeTextOBx.TabStop = false;
            this.othersincomeTextOBx.Text = "0";
            // 
            // photocopyTextBpx
            // 
            this.photocopyTextBpx.Location = new System.Drawing.Point(130, 95);
            this.photocopyTextBpx.Name = "photocopyTextBpx";
            this.photocopyTextBpx.ReadOnly = true;
            this.photocopyTextBpx.Size = new System.Drawing.Size(93, 26);
            this.photocopyTextBpx.TabIndex = 21;
            this.photocopyTextBpx.TabStop = false;
            this.photocopyTextBpx.Text = "0";
            // 
            // bookProfitTextBox
            // 
            this.bookProfitTextBox.Location = new System.Drawing.Point(130, 52);
            this.bookProfitTextBox.Name = "bookProfitTextBox";
            this.bookProfitTextBox.ReadOnly = true;
            this.bookProfitTextBox.Size = new System.Drawing.Size(93, 26);
            this.bookProfitTextBox.TabIndex = 19;
            this.bookProfitTextBox.TabStop = false;
            this.bookProfitTextBox.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(275, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 34);
            this.button1.TabIndex = 15;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.totalIncomeCalculationButton);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tk";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(228, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "Tk";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(228, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 19);
            this.label11.TabIndex = 13;
            this.label11.Text = "Tk";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(228, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 19);
            this.label12.TabIndex = 11;
            this.label12.Text = "Tk";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(-183, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 126);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Photocopy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Others";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Book ";
            // 
            // BalanceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(455, 415);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BalanceUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Today\'s Benifit Calculation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BalanceUI_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox bookProfitTextBox;
        private System.Windows.Forms.RichTextBox photocopyTextBpx;
        private System.Windows.Forms.RichTextBox othersincomeTextOBx;
        private System.Windows.Forms.RichTextBox totalIncomeTextBOx;
    }
}