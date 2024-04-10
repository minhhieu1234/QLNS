using HRMngt._Repository;
using HRMngt._Repository.Home;
using HRMngt._Repository.Salary;
using HRMngt._Repository.Support;
using HRMngt.Model;
using HRMngt.Presenter;
using HRMngt.View;
using HRMngt.Views;
using HRMngt.Views.Dialogs;
using HRMngt.Views.Salary;
using HRMngt.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace HRMngt.Presenters
{
    public class MainViewPresenter
    {
        IMainView mainView;
        private readonly string sqlConnectionString;

        public MainViewPresenter(IMainView main, string sqlConnectionString)
        {
            this.mainView = main;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowDepartmentView += ShowDepartmentView;
            mainView.ShowThumbTicketView += ShowThumbTicketView;
            mainView.ShowUserView += ShowUserView;
            mainView.ShowHomeView += ShowHomeView;
            mainView.ShowSupportView += ShowSupportView;
            mainView.ShowSalaryView += ShowSalaryView;
            mainView.ShowLoginEvent += ShowLoginView;
            mainView.Show();
        }

        private void ShowLoginView(object sender, EventArgs e)
        {
            ILoginView view = new Views.LoginView();
            ILoginRepository repository = new LoginRepository(sqlConnectionString);
            new LoginPresenter(view, repository);
        }

        private void ShowSalaryView(object sender, EventArgs e)
        {
            ISalaryView view = SalaryView.GetInstance((MainView)mainView);
            ISalaryRepository repository = new SalaryRepository(sqlConnectionString);
            new SalaryPresenter(view, repository);
        }

        private void ShowSupportView(object sender, EventArgs e)
        {
            ISupport view = Support.GetInstance((MainView)mainView);
            ISupportRepository repository = new SupportRepository(sqlConnectionString);
            new SupportPresenter(view, repository);
        }

        private void ShowHomeView(object sender, EventArgs e)
        {
            IHomeView view = Home.GetInstance((MainView)mainView);
            IHomeRepository repository = new HomeRepository(sqlConnectionString);
            new HomePresenter(view, repository);
        }

        private void ShowUserView(object sender, EventArgs e)
        {
            IUserView view = UserView.GetInstance((MainView)mainView);

            IUserRepository repository = new UserRepository(sqlConnectionString);
            new UserPresenter(view, repository);
        }

        private void ShowDepartmentView(object sender, EventArgs e)
        {
            IDepartmentView view = DepartmentView.GetInstance((MainView) mainView);

            IDepartmentRepository repository = new DepartmentRepository(sqlConnectionString);
            new MainDepartmentPresenter(view, repository);
        }
        private void ShowThumbTicketView(object sender, EventArgs e)
        {
            IThumbTicketView view = ThumbTicketView.GetInstance((MainView) mainView);

            IThumbTicketRepository repository = new ThumbTicketRepository(sqlConnectionString);
            new ThumbTicketPresenter(view, repository);
        }
        
    }
}
