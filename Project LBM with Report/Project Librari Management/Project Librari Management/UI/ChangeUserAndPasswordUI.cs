using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project_Librari_Management.BLL;
using Project_Librari_Management.DAL.Gateway;

namespace Project_Librari_Management.UI
{
    public partial class ChangeUserAndPasswordUI : Form
    {

        public string userNmae, password;
        public ChangeUserAndPasswordUI(string st1,string st2)
        {
            InitializeComponent();
            this.userNmae = st1;
            this.password = st2;
            currentPasswordtExtBox.PasswordChar = '*';
            currentPasswordtExtBox.MaxLength = 20;
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.MaxLength = 20;
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.MaxLength = 20;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUserNameTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please enter the current User Name.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (currentPasswordtExtBox.Text.Equals(""))
                {
                    MessageBox.Show("Please enter the current Password.", "Message", MessageBoxButtons.OK,
                         MessageBoxIcon.Information); 
                }
                else if (newUserNameTextBxo.Text.Equals(""))
                {
                    MessageBox.Show("Please enter the new User Name.", "Message", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }
                else if (newPasswordTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please enter the new Password.", "Message", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }
                else if (confirmPasswordTextBox.Text.Equals(""))
                {
                    MessageBox.Show("Please re -enter the new password.", "Message", MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }
                else if (!newPasswordTextBox.Text.Equals(confirmPasswordTextBox.Text))
                {
                    MessageBox.Show("Password conflit", "Error", MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }
                else 
                {
                    MatchUserAndPassword matchUser=new MatchUserAndPassword();
              bool b = matchUser.PasswordAndUserNameVerification(CurrentUserNameTextBox.Text, currentPasswordtExtBox.Text);
                if (b)
                {
                    DBManager manager=new DBManager();
                    SqlConnection connection = manager.Connection();
                    string query = "UPDATE Security_12 set User_Name='"+newUserNameTextBxo.Text+"',Password='"+newPasswordTextBox.Text+"' where User_Name='" + userNmae +
                                   "'and Password='" + password + "'";

                    SqlCommand command=new SqlCommand(query,connection);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    MessageBox.Show("You have sucessfully change user name and password", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User name and Password are not currect.Please enter Currect user and Password and then try.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                } 
                }
             
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }



        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
