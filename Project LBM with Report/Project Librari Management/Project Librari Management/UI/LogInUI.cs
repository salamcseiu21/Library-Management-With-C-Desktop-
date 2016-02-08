using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class LogInUI : Form
    {
        public LogInUI()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.MaxLength = 12;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {

            MatchUserAndPassword matchUser=new MatchUserAndPassword();
            bool status = matchUser.PasswordAndUserNameVerification(userNameTextBox.Text, passwordTextBox.Text);
            if (status)
            {
                MainMenuUI mainMenu =new MainMenuUI(userNameTextBox.Text,passwordTextBox.Text);
                this.Hide();
                mainMenu.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please enter the currect username and password", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
