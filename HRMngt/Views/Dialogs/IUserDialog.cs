using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt.Views.Dialogs
{
    public interface IUserDialog
    {
        string ID { get; set; }
        string Fullname { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        DateTime Birthday { get; set; }
        string Sex { get; set; }
        string Position { get; set; }
        string Salary { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string ManagerID { get; set; }
        string DepartmentID { get; set; }
        string Contract_type { get; set; }
        DateTime On_boarding { get; set; }
        DateTime Close_date { get; set; }
        string Scan_contract { get; set; }
        string Note { get; set; }
        string Avatar { get; set; }
        string Status { get; set; }

        event EventHandler AddNewUserDialog;
        event EventHandler EditUserDialog;
    }
}
