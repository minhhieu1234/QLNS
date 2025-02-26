﻿using HRMngt.Views;
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


namespace HRMngt.View
{
    public partial class MainIndividualView : Form, IMainIndividualView
    {
        public MainIndividualView()
        {
            InitializeComponent();
            btnHome.Click += delegate { ShowThumbTicketView?.Invoke(this, EventArgs.Empty); };
            btnDepartment.Click += delegate { ShowDepartmentView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowThumbTicketView;
        public event EventHandler ShowDepartmentView;

        private void txtNavSearch_Leave(object sender, EventArgs e)
        {
            if (txtNavSearch.Text == "")
            {
                txtNavSearch.Text = "Nhập tìm kiếm của bạn ...";
                txtNavSearch.ForeColor = Color.DimGray;
            }    
        }

        private void txtNavSearch_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (txtNavSearch.Text == "Nhập tìm kiếm của bạn ...")
            {
                txtNavSearch.Text = "";
                txtNavSearch.ForeColor = Color.Black;
            }
        }


    }
}
