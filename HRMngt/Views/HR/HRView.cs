using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.Views.HR
{
    public partial class HRView : Form, IHRView
    {
        public HRView()
        {
            InitializeComponent();
        }

        public void RunEvent()
        {
            btnAdd.Click += delegate { LoadHRToAdd?.Invoke(this, EventArgs.Empty); };
        }

        ComboBox IHRView.cbDepartment => cbDepartment;

        ComboBox IHRView.cbStatus => cbStatus;

        KryptonDataGridView IHRView.dgvHRList => dgvHRList;

        public event EventHandler AddNewHR;
        public event EventHandler EditNewHR;
        public event EventHandler DeleteHR;
        public event EventHandler LoadHRToAdd;
        public event EventHandler LoadHRToEdit;

        public void ShowHRList()
        {
            throw new NotImplementedException();
        }
    }
}
