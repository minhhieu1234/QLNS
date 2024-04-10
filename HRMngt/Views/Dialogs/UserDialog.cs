using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.Views.Dialogs
{
    public partial class UserDialog : Form, IUserDialog
    {
        private string type;
        public UserDialog(string type)
        {
            this.type = type;
            InitializeComponent();
            if (type == "Thêm")
            {
                lblTitle.Text = "Thêm mới nhân viên";
                btnAdd.Text = "Thêm";
            }
            else if (type == "Sửa")
            {
                lblTitle.Text = "Cập nhật nhân viên";
                btnAdd.Text = "Sửa";

            }
            RunEvent();
            AutoUpdate();
            cbManagerID_SelectedIndexChanged();
            cbDepartmentID_SelectedIndexChanged();
        }

        public void RunEvent()
        {
            if (btnAdd.Text == "Thêm")
            {
                btnAdd.Click += delegate { AddNewUserDialog?.Invoke(this, EventArgs.Empty); };
            }
            else if (btnAdd.Text == "Sửa")
            {
                btnAdd.Click += delegate { EditUserDialog?.Invoke(this, EventArgs.Empty); };
            }
        }

        public string ID { get => txtID.Text; set => txtID.Text = value; }
        public string Fullname { get => txtName.Text; set => txtName.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string Phone { get => txtPhone.Text; set => txtPhone.Text = value; }
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public DateTime Birthday { get => birthday.Value; set => birthday.Value = value; }
        public string Sex { get => cbSex.Text; set => cbSex.Text = value; }
        public string Position { get => cbPosition.Text; set => cbPosition.Text = value; }
        public string Salary { get => txtSalary.Text; set => txtSalary.Text = value; }
        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public string ManagerID { get => cbManagerId.Text; set => cbManagerId.Text = value; }
        public string DepartmentID { get => cbDepartmentId.Text; set => cbDepartmentId.Text = value; }
        public string Contract_type { get => cbContractType.Text; set => cbContractType.Text = value; }
        public DateTime On_boarding { get => dtOnBoarding.Value; set => dtOnBoarding.Value = value; }
        public DateTime Close_date { get => dtClosedate.Value; set => dtClosedate.Value = value; }
        public string Scan_contract { get => txtScanContract.Text; set => txtScanContract.Text = value; }
        public string Note { get => txtNote.Text; set => txtNote.Text = value; }
        public string Avatar { get => txtAvatar.Text; set => txtAvatar.Text = value; }
        public string Status { get => cbStatus.Text; set => cbStatus.Text = value; }
        

        public event EventHandler AddNewUserDialog;
        public event EventHandler EditUserDialog;


        private void cbManagerID_SelectedIndexChanged()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=HR;Integrated Security=True;Encrypt=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select managerID from users ";
                List<string> items = new List<string>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(reader[0].ToString());
                    }
                }
                cbManagerId.DataSource = items;
                cbManagerId.DisplayMember = "Name";
                cbManagerId.Refresh();
                connection.Close();
            }
        }
        private void cbDepartmentID_SelectedIndexChanged()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=HR;Integrated Security=True;Encrypt=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select departmentID from department ";
                List<string> items = new List<string>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(reader[0].ToString());
                    }
                }
                cbDepartmentId.DataSource = items;
                cbDepartmentId.DisplayMember = "Name";
                cbDepartmentId.Refresh();
                connection.Close();
            }
        }
        private void AutoUpdate()
        {
            if(txtName.Text.Length > 0)
            {
                txtSalary.Enabled = false;
            }
        }
        
        
    }
}
