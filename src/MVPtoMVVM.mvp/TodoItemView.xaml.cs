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
            Presenter = presenter;
            InitializeComponent();
            presenter.SetView(this);
            saveButton.Click += (o, e) => presenter.SaveItem();
            deleteButton.Click += (o, e) => presenter.DeleteItem();
            description.TextChanged += (o, e) => presenter.Description = description.Text;
            dueDate.SelectedDateChanged += (o, e) => presenter.DueDate = dueDate.SelectedDate.Value;
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

        public ITodoItemPresenter Presenter { get; private set; }
    }
}
