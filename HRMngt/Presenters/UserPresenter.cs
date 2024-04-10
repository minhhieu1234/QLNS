using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRMngt.Model;
using HRMngt.Models;
using HRMngt.popup;
using HRMngt.View;
using HRMngt.Views.Dialogs;

namespace HRMngt.Presenter
{
    public class UserPresenter
    {
        // Fields
        private IUserView view;
        private IUserRepository repository;
        private UserDialog dialog;
        private IEnumerable<UserModel> userList;

        public UserPresenter(IUserView view, IUserRepository repository)
        {
            this.view = view;  
            this.repository = repository;
            this.view.LoadUserDialogToAddEvent += LoadUserDialogToAddEvent;
            this.view.LoadUserDialogToEditEvent += LoadUserDialogToEditEvent;
            this.view.DeleteEvent += DeleteUser;
            LoadAllUserList();
            this.view.ShowUserList(userList);
            this.view.Show();
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = view.dgvUserList.CurrentRow;
            string id = selectedRow.Cells[0].Value.ToString();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Xóa nhân viên", buttons);
            if (result == DialogResult.Yes)
            {
                repository.Delete(id);
                SucessPopUp.ShowPopUp();
                LoadAllUserList();
                view.ShowUserList(userList);
            }
        }

        private void LoadUserDialogToEditEvent(object sender, EventArgs e)
        {
            dialog = view.ShowUserDialogToEdit(null);
            DataGridViewRow selectedRow = view.dgvUserList.CurrentRow;
            string id = selectedRow.Cells[0].Value.ToString();
            UserModel user = new UserModel();
            user = repository.GetById(id);
            dialog.ID = user.Id;
            dialog.Fullname = user.Name;
            dialog.Email = user.Email;
            dialog.Phone = user.Phone;
            dialog.Address = user.Address;
            dialog.Birthday = user.Birthday;
            dialog.Salary = user.Salary;
            dialog.Username = user.Username;
            dialog.Password = user.Password;
            dialog.ManagerID = user.ManagerID;
            dialog.DepartmentID = user.DepartmentID;
            dialog.On_boarding = user.On_boarding;
            dialog.Close_date = user.Close_date;
            dialog.Scan_contract = user.Scan_contract;
            dialog.Note = user.Note;
            dialog.Avatar = user.Ava;
            dialog.Sex = user.Sex;
            dialog.Status = user.Status;
            dialog.Position = user.Position;
            dialog.Contract_type = user.Contract_type;
            dialog.EditUserDialog += EditUserDialog;
            dialog.ShowDialog();
        }

        private void EditUserDialog(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.Id = dialog.ID;
            user.Name = dialog.Fullname;
            user.Email = dialog.Email;
            user.Phone = dialog.Phone;
            user.Address = dialog.Address;
            user.Birthday = dialog.Birthday;
            user.Salary = dialog.Salary;
            user.Username = dialog.Username;
            user.Password = dialog.Password;
            user.ManagerID = dialog.ManagerID;
            user.DepartmentID = dialog.DepartmentID;
            user.On_boarding = dialog.On_boarding;
            user.Close_date = dialog.Close_date;
            user.Scan_contract = dialog.Scan_contract;
            user.Note = dialog.Note;
            user.Ava = dialog.Avatar;
            user.Sex = dialog.Sex;
            user.Status = dialog.Status;
            user.Position = dialog.Position;
            user.Contract_type = dialog.Contract_type;
            repository.Update(user);
            this.dialog.Close();
            LoadAllUserList();
            view.ShowUserList(userList);
            SucessPopUp.ShowPopUp();
        }

        private void LoadUserDialogToAddEvent(object sender, EventArgs e)
        {
            dialog = this.view.ShowUserDialogToAdd();
            dialog.AddNewUserDialog += AddNewUserDialog;
            dialog.ShowDialog();
        }

        private void AddNewUserDialog(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.Id = dialog.ID;
            user.Name = dialog.Fullname;
            user.Email = dialog.Email;
            user.Phone = dialog.Phone;
            user.Address = dialog.Address;
            user.Birthday = dialog.Birthday;
            user.Salary = dialog.Salary;
            user.Username = dialog.Username;
            user.Password = dialog.Password;
            user.ManagerID = dialog.ManagerID;
            user.DepartmentID = dialog.DepartmentID;
            user.On_boarding = dialog.On_boarding;
            user.Close_date = dialog.Close_date;
            user.Scan_contract = dialog.Scan_contract;
            user.Note = dialog.Note;
            user.Ava = dialog.Avatar;
            user.Sex = dialog.Sex;
            user.Status = dialog.Status;
            user.Position = dialog.Position;
            user.Contract_type = dialog.Contract_type;
            repository.Add(user);
            this.dialog.Close();
            LoadAllUserList();
            view.ShowUserList(userList);
            SucessPopUp.ShowPopUp();
        }

        private void LoadAllUserList()
        {
            userList = repository.GetAll();
        }
    }
}
