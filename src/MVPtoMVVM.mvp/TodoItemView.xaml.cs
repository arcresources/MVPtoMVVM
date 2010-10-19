﻿using System;
using System.Windows;
using System.Windows.Media;
using MVPtoMVVM.mvp.presenters;
using MVPtoMVVM.mvp.views;

namespace MVPtoMVVM.mvp
{
    public partial class TodoItemView : ITodoItemView
    {
        private readonly IMvpPresenter parent;
        private Brush defaultBorderBrush;
        private Thickness defaultBorderThickness;

        public TodoItemView(ITodoItemPresenter presenter, IMvpPresenter parent)
        {
            this.parent = parent;
            Presenter = presenter;
            InitializeComponent();
            saveButton.Click += (o, e) => presenter.SaveItem();
            deleteButton.Click += (o, e) => presenter.DeleteItem();
            description.TextChanged += (o, e) => presenter.Description = description.Text;
            dueDate.SelectedDateChanged += (o, e) => presenter.DueDate = dueDate.SelectedDate.Value;
            defaultBorderBrush = description.BorderBrush;
            defaultBorderThickness = description.BorderThickness;
            presenter.SetView(this);
        }

        public int Id{ get; set; }

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

        public bool DescriptionHasValidationErrors
        {
            set
            {
                if (value)
                {
                    description.BorderBrush = Brushes.Red;
                    description.BorderThickness = new Thickness(2);
                }
                else
                {
                    description.BorderBrush = defaultBorderBrush;
                    description.BorderThickness = defaultBorderThickness;
                }
            }
        }

        public bool DueDateHasValidationErrors
        {
            set
            {
                if (value)
                {
                    dueDate.BorderBrush = Brushes.Red;
                    dueDate.BorderThickness = new Thickness(2);
                }
                else
                {
                    dueDate.BorderBrush = defaultBorderBrush;
                    dueDate.BorderThickness = defaultBorderThickness;
                }
            }
        }

        public bool IsDueSoon
        {
            set { dueSoonAlert.Visibility = value ? Visibility.Visible : Visibility.Hidden; }
        }

        public string DescriptionValidationMessage
        {
            set { description.ToolTip = value; }
        }

        public string DueDateValidationMessage
        {
            set { dueDate.ToolTip = value; }
        }

        public void Remove(int itemId)
        {
            parent.Remove(itemId);
        }
    }
}
