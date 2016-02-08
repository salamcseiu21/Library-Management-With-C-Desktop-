using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Librari_Management.UI
{
    public partial class SimpleCalculationUI : Form
    {
        public SimpleCalculationUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (no_of_Copy_TextBox.Text != null && copy_Rate_TextBox.Text != null)
                {
                    double a, b, result;
                    a = Convert.ToDouble(no_of_Copy_TextBox.Text);
                    b = Convert.ToDouble(copy_Rate_TextBox.Text);
                    result = a * b;
                    totalTextBox.Text = result.ToString();
                    DialogResult dialog = MessageBox.Show("Total =" + result + " Tk.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog == DialogResult.OK)
                    {
                        no_of_Copy_TextBox.Clear();
                        copy_Rate_TextBox.Clear();
                        totalTextBox.Clear();
                    }
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show("Please fill every field properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void no_of_Copy_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void copy_Rate_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
