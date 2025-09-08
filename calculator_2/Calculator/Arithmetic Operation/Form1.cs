using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EmployeeFormApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        string connectionString = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";

        public Form()
        {
            LoadData();
        }

       

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (ID, Name, Dept, Gender, District) VALUES (@ID, @Name, @Dept, @Gender, @District)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Dept", txtDept.Text);
                cmd.Parameters.AddWithValue("@Gender", rbMale.Text);
                cmd.Parameters.AddWithValue("@District", txtDistrict.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            LoadData();
            ClearFields();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gvData.DataSource = dt;
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtDept.Clear();
         
            txtDistrict.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvData.SelectedRows.Count > 0)
            {
                int idToDelete = Convert.ToInt32(gvData.SelectedRows[0].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Employees WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", idToDelete);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}

