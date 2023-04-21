using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDAPP
{
    public partial class FormStudentInfo : Form
    {
        FormStudent form;
        public FormStudentInfo()
        {
            InitializeComponent();
            form = new FormStudent(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void Display()
        {
            DbStudent.DisplayAndSearch("SELECT Id, Name, Email, Phone, Address FROM Student", dataGridView);
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void FormStudentInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            DbStudent.DisplayAndSearch("SELECT Id, Name, Email, Phone, Address FROM Student Where Name LIKE '%"+TextSearch.Text + "%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Edit
                form.Clear();
                form.id = int.Parse(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.email = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.phone = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.address = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                // Delete
                if (MessageBox.Show("Are you sure want to delte this record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DbStudent.DeleteStudent(id);
                    Display();
                }
                return;

            }
        }
    }
}
