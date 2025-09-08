using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Arithmetic_Operation
{
    public partial class Database_Connectivity : Form
    {
        public Database_Connectivity()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=DESKTOP-DBL7RK0;Database=test1;Trusted_Connection=True;";

            string id = ID_Textbox.Text;
            string name = Name_Textbox.Text;
            string dept = Dept_Textbox.Text;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(dept))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string query = "INSERT INTO Students (ID, NAME, DEPT) VALUES (@ID, @Name, @Dept)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Dept", dept);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student added successfully.");
                    }
                
                
            }
        }
    }
}
