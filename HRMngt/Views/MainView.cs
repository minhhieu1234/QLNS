using HRMngt.Model;
using HRMngt.Views;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace HRMngt.View
{
    public partial class MainView : Form, IMainView
    {
        private UserModel currentUser;
        
        
        public MainView()
        {
            InitializeComponent();
            RunEvent();
            /*CheckRole();*/
            /*lblNavName.Text = currentUser.Name;*/
            
        }
        public event EventHandler ShowDepartmentView;
        public event EventHandler ShowThumbTicketView;
        public event EventHandler ShowHomeView;
        public event EventHandler ShowUserView;
        public event EventHandler ShowSupportView;
        public event EventHandler ShowSalaryView;
        public event EventHandler ShowLoginEvent;

        public void RunEvent()
        {
            btnDepartment.Click += delegate { ShowDepartmentView?.Invoke(this, EventArgs.Empty); };
            btnEmployee.Click += delegate { ShowUserView?.Invoke(this, EventArgs.Empty); };
            btnHome.Click += delegate { ShowHomeView?.Invoke(this, EventArgs.Empty); };
            btnHelp.Click += delegate { ShowSupportView?.Invoke(this, EventArgs.Empty); };
            btnSalary.Click += delegate { ShowSalaryView?.Invoke(this, EventArgs.Empty); };
            lblNavName.Click += delegate {
                this.Hide();
                ShowLoginEvent?.Invoke(this, EventArgs.Empty);
                
            };
        }
        private void txtNavSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNavSearch.Text == "Nhập tìm kiếm của bạn ...")
            {
                txtNavSearch.Text = "";
                txtNavSearch.ForeColor = Color.Black;
            }    
            
        }
        private void txtNavSearch_Leave(object sender, EventArgs e)
        {
            if (txtNavSearch.Text == "")
            {
                txtNavSearch.Text = "Nhập tìm kiếm của bạn ...";
                txtNavSearch.ForeColor = Color.Black;
            }
        }

        private void picNavAva_Click(object sender, EventArgs e)
        {
            ProfileDialog profile = new ProfileDialog();
            profile.ShowDialog();
        }

        
        private void CheckMainView()
        {
            if(lblNavName.Text == "Ẩn danh")
            {

            }
        }
        private void btnDepartment_Click(object sender, EventArgs e)
        {

        }
        /*public void CheckRole()
        {
            if (currentUser.Position != "Admin")
            {
                btnEmployee.Enabled = false;
                btnSalary.Enabled = false;
                btnDepartment.Enabled = false;

            }
        }*/
    }
}
