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
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        public int id;
        public string name, email, phone, address;
        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            txtName.Text = txtEmail.Text = txtPhone.Text = txtAddress.Text = string.Empty;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Student";
            BtnSave.Text = "Update";
            txtName.Text = name;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Student";
            BtnSave.Text = "Submit";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty ( > 3)");
                return;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student email is Empty");
                return;
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student phone is Empty");
                return;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student address is Empty");
                return;
            }

            if (BtnSave.Text == "Submit")
            {
                Student std = new Student(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim());
                DbStudent.AddStudents(std);
                Clear();
            }

            if (BtnSave.Text == "Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtAddress.Text.Trim());
                DbStudent.UpdateStudents(std,id);
                Clear();
            }

            _parent.Display();
        }
    }
}
