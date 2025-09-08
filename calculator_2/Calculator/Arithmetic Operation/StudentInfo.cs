using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arithmetic_Operation
{
    public partial class StudentInfo : Form
    {
        DataTable table = new DataTable("table");
        int index;
        public StudentInfo()
        {
            InitializeComponent();
        }
         
        private void StudentInfo_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.Int32"));
            table.Columns.Add("firstname", Type.GetType("System.String"));
            table.Columns.Add("lastname", Type.GetType("System.String"));
            table.Columns.Add("address", Type.GetType("System.String"));
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            string connectionString = @"Server=DESKTOP-DBL7RK0;Database=test1;Trusted_Connection=True;";

            string id = textBox1.Text;
            string name = textBox2.Text;
            string dept = textBox3.Text;
            string district = textBox4.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(dept) || string.IsNullOrWhiteSpace(district))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string query = "INSERT INTO Students (ID, NAME, DEPT,DISTRICT) VALUES (@ID, @Name, @Dept,@District)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Dept", dept);
                    cmd.Parameters.AddWithValue("@District", district);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added successfully.");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text=String.Empty;
            textBox2.Text=String.Empty;
            textBox3.Text=String.Empty;
            textBox4.Text=String.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row=dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox2.Text;
            newdata.Cells[2].Value = textBox3.Text;
            newdata.Cells[3].Value = textBox4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
        }
    }
}
