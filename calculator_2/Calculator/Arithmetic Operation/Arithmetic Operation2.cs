using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic_Operation
{
    public partial class Arithmetic_Operation2 : Form
    {
        double number1 = 0;
        double number2 = 0;
        double result = 0;
        string operation = "";
        public Arithmetic_Operation2()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            operation = "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textbox1.Text = "";
            textbox2.Text = "";
            resultTxt.Text = "";
        }



       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            operation = "+";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            operation = "-";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            operation ="*";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            operation = "/";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            operation = "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool number1Ok = double.TryParse(textbox1.Text, out number1);
            bool number2Ok = double.TryParse(textbox2.Text, out number2);

            if (number1Ok && number2Ok)
            {
                //perform calculation
                switch (operation)
                {
                    case "+":
                        result = number1 + number2;
                        resultTxt.Text = result.ToString();
                        break;
                    case "-":
                        result = number1 - number2;
                        resultTxt.Text = result.ToString();
                        break;
                    case "*":
                        result = number1 * number2;
                        resultTxt.Text = result.ToString();
                        break;
                    case "/":
                        if (number2 != 0)
                        {
                            result = number1 / number2;
                            resultTxt.Text = result.ToString("0.00");
                        }
                        else
                        {
                            MessageBox.Show("Denominator can't be 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                            break;
                    case "%":
                        result = number1 % number2;
                        resultTxt.Text = result.ToString();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Data Provided is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
