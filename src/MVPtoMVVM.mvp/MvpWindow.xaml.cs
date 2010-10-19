﻿using System.Collections.Generic;
using System.Linq;
using MVPtoMVVM.mvp.presenters;
using MVPtoMVVM.mvp.views;
using StructureMap;

namespace MVPtoMVVM.mvp
{
    public partial class MvpWindow : IMvpView
    {
        private IMvpPresenter presenter;

        public MvpWindow()
        {
            InitializeComponent();
            presenter = ObjectFactory.GetInstance<IMvpPresenter>();
            presenter.SetView(this);
            newItemButton.Click += (o, e) => presenter.AddNewItem();
            cancelButton.Click += (o, e) => presenter.CancelAllChanges();
        }

        public void ShowTodoItems(IEnumerable<ITodoItemPresenter> presenters)
        {
            todoItemsList.ItemsSource = presenters.Select(x => new TodoItemView(x, presenter));
        }

        public IEnumerable<ITodoItemPresenter> GetTodoItems()
        {
            return todoItemsList.ItemsSource.Cast<ITodoItemView>().Select(x => x.Presenter);
        }

    }
}
