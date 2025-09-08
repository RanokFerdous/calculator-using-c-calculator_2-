using System;
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
    public partial class Arithmetic_Operation : Form
    {
        public Arithmetic_Operation()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            showResult.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).
                ToString();

        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            showResult.Text = (Convert.ToInt32(textBox1.Text) - Convert.ToInt32(textBox2.Text)).
                ToString();
        }

        private void multiBtn_Click(object sender, EventArgs e)
        {
            showResult.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text)).
                ToString();
        }

        private void divBtn_Click(object sender, EventArgs e)
        {
            showResult.Text = (Convert.ToInt32(textBox1.Text) / Convert.ToInt32(textBox2.Text)).
                ToString();
        }

        private void reBtn_Click(object sender, EventArgs e)
        {
            showResult.Text = (Convert.ToInt32(textBox1.Text) % Convert.ToInt32(textBox2.Text)).
                ToString();
        }
    }
}
