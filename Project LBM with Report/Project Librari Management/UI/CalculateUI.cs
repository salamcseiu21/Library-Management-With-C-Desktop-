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
    public partial class CalculateUI : Form
    {
        private double result = 0;
        private string oprationPerform = "";
        private bool isOpertionPerform = false;
        public CalculateUI()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if((resultTextBox.Text=="0")||isOpertionPerform)
                resultTextBox.Clear();
            Button button = (Button) sender;
            if (button.Text.Equals("."))
            {
                if (!resultTextBox.Text.Contains("."))
                {
                    resultTextBox.Text = resultTextBox.Text + button.Text;
                } 
            }
            else
            {
                resultTextBox.Text = resultTextBox.Text + button.Text;
                 
            }
            isOpertionPerform = false; 
        }

        private void opreator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result !=0)
            {
                button16.PerformClick();
                oprationPerform = button.Text;
                current_Operation_lable.Text = result + " " + oprationPerform;
                isOpertionPerform = true;
            }
            else
            {
                oprationPerform = button.Text;
                result = Double.Parse(resultTextBox.Text);
                current_Operation_lable.Text = result + " " + oprationPerform;
                isOpertionPerform = true; 
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0"; 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";
            result = 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
            switch (oprationPerform)
            {
                case "+":
                    resultTextBox.Text = (result + Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "-":
                    resultTextBox.Text =( result - Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "*":
                    resultTextBox.Text = (result * Double.Parse(resultTextBox.Text)).ToString();
                    break;
                case "/":
                    resultTextBox.Text = (result / Double.Parse(resultTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(resultTextBox.Text);
            current_Operation_lable.Text = "";
        }
    }
}
