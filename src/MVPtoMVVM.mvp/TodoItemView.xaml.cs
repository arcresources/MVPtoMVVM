using System;
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

        public bool SaveButtonEnabled
        {
            get { return saveButton.IsEnabled; }
            set { saveButton.IsEnabled = value; }
        }
    }
}
