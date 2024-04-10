using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.Views.HR
{
    public interface IHRView
    {
        ComboBox cbDepartment { get; }
        ComboBox cbStatus { get; }
        KryptonDataGridView dgvHRList { get; }

        event EventHandler AddNewHR;
        event EventHandler EditNewHR;
        event EventHandler DeleteHR;
        event EventHandler LoadHRToAdd;
        event EventHandler LoadHRToEdit;

        void Show();
        void ShowHRList();
        
    }
}
