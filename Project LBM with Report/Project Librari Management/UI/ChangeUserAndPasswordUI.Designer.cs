namespace Project_Librari_Management.UI
{
    partial class ChangeUserAndPasswordUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserAndPasswordUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newUserNameTextBxo = new System.Windows.Forms.TextBox();
            this.currentPasswordtExtBox = new System.Windows.Forms.TextBox();
            this.CurrentUserNameTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.confirmPasswordTextBox);
            this.groupBox1.Controls.Add(this.newPasswordTextBox);
            this.groupBox1.Controls.Add(this.newUserNameTextBxo);
            this.groupBox1.Controls.Add(this.currentPasswordtExtBox);
            this.groupBox1.Controls.Add(this.CurrentUserNameTextBox);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SubmitButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(338, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change User";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(134, 173);
            this.confirmPasswordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(176, 19);
            this.confirmPasswordTextBox.TabIndex = 4;
            this.confirmPasswordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.confirmPasswordTextBox_Validating);
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(134, 139);
            this.newPasswordTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(176, 19);
            this.newPasswordTextBox.TabIndex = 3;
            this.newPasswordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.newPasswordTextBox_Validating);
            // 
            // newUserNameTextBxo
            // 
            this.newUserNameTextBxo.Location = new System.Drawing.Point(134, 101);
            this.newUserNameTextBxo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newUserNameTextBxo.Name = "newUserNameTextBxo";
            this.newUserNameTextBxo.Size = new System.Drawing.Size(176, 19);
            this.newUserNameTextBxo.TabIndex = 2;
            this.newUserNameTextBxo.Validating += new System.ComponentModel.CancelEventHandler(this.newUserNameTextBxo_Validating);
            // 
            // currentPasswordtExtBox
            // 
            this.currentPasswordtExtBox.Location = new System.Drawing.Point(134, 70);
            this.currentPasswordtExtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.currentPasswordtExtBox.Name = "currentPasswordtExtBox";
            this.currentPasswordtExtBox.Size = new System.Drawing.Size(176, 19);
            this.currentPasswordtExtBox.TabIndex = 1;
            this.currentPasswordtExtBox.Validating += new System.ComponentModel.CancelEventHandler(this.currentPasswordtExtBox_Validating);
            // 
            // CurrentUserNameTextBox
            // 
            this.CurrentUserNameTextBox.Location = new System.Drawing.Point(134, 36);
            this.CurrentUserNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CurrentUserNameTextBox.Name = "CurrentUserNameTextBox";
            this.CurrentUserNameTextBox.Size = new System.Drawing.Size(176, 19);
            this.CurrentUserNameTextBox.TabIndex = 0;
            this.CurrentUserNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CurrentUserNameTextBox_Validating);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(134, 232);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(56, 40);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(219, 232);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(56, 40);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "New User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "New Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 176);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Confirm Password";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChangeUserAndPasswordUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(398, 344);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "ChangeUserAndPasswordUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change User And Password";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CurrentUserNameTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox newUserNameTextBxo;
        private System.Windows.Forms.TextBox currentPasswordtExtBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}