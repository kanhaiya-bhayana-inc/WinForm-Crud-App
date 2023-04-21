using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDAPP
{
    class DbStudent
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=G1-1MS2MQ3-L;Initial Catalog=dbStudent;Integrated Security=True");
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;

        }

        public static void AddStudents(Student student)
        {
            string Query = "INSERT INTO Student VALUES (@StuName,@StuEmail,@StuPhone,@StuAddress)";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.Add("@StuName", SqlDbType.VarChar).Value = student.Name;
            cmd.Parameters.Add("@StuEmail", SqlDbType.VarChar).Value = student.Email;
            cmd.Parameters.Add("@StuPhone", SqlDbType.VarChar).Value = student.Phone;
            cmd.Parameters.Add("@StuAddress", SqlDbType.VarChar).Value = student.Address;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Student not inserted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateStudents(Student student, int id)
        {
            string Query = "UPDATE Student SET Name = @StuName, Email = @StuEmail, Phone = @StuPhone, Address = @StuAddress WHERE Id = @StuId";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.Add("@StuId", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@StuName", SqlDbType.VarChar).Value = student.Name;
            cmd.Parameters.Add("@StuEmail", SqlDbType.VarChar).Value = student.Email;
            cmd.Parameters.Add("@StuPhone", SqlDbType.VarChar).Value = student.Phone;
            cmd.Parameters.Add("@StuAddress", SqlDbType.VarChar).Value = student.Address;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Student not updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DeleteStudent(int id)
        {
            string Query = "DELETE FROM Student WHERE Id = @StuId";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.Add("@StuId", SqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Student not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dataGridView)
        {
            string sql = query;
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView.DataSource = tbl;
            con.Close();
        }


    }
}
