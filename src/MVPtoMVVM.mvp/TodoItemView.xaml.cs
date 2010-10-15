using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using MVPtoMVVM.views;

namespace MVPtoMVVM.mvp
{
    /// <summary>
    /// Interaction logic for TodoItemView.xaml
    /// </summary>
    public partial class TodoItemView : ITodoItemView
    {
        public TodoItemView(ITodoItemPresenter presenter)
        {
            InitializeComponent();
            presenter.SetView(this);
        }

        public string Description
        {
            get { return description.Text; }
            set { description.Text = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate.SelectedDate.Value; }
            set { dueDate.SelectedDate = value; }
        }
    }
}
