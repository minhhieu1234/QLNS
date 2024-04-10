﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMngt.Model;
using HRMngt._Repository;
using HRMngt.Views;
using HRMngt.Presenter;
using HRMngt.View;
using HRMngt.View.Popup;

namespace HRMngt.Presenters
{
    public class MainIndividualPresenter
    {
        private IMainIndividualView mainIndividual;
        private readonly string sqlConnectionString;

        public MainIndividualPresenter(IMainIndividualView mainIndividual, string sqlConnectionString)
        {
            this.mainIndividual = mainIndividual;
            this.sqlConnectionString = sqlConnectionString;
            this.mainIndividual.ShowThumbTicketView += ShowThumbTicketView;
        }

        private void ShowThumbTicketView(object sender, EventArgs e)
        {
            IThumbTicketView view = ThumbTicketView.GetInstance((MainIndividualView)mainIndividual);

            IThumbTicketRepository repository = new ThumbTicketRepository(sqlConnectionString);
            new ThumbTicketPresenter(view, repository);
        }
        private void ShowDepartmentView(object sender, EventArgs e)
        {
            IDepartmentView view = DepartmentView.GetInstance((MainIndividualView)mainIndividual);

            IDepartmentRepository repository = new DepartmentRepository(sqlConnectionString);
            new MainDepartmentPresenter(view, repository);
        }
    }
}
