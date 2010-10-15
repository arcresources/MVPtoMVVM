using System.Collections.Generic;
using System.Diagnostics;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using StructureMap;

namespace MVPtoMVVM.mvp
{
    public partial class MvpWindow : IMvpView
    {
        private IMvpPresenter presenter;

        public MvpWindow()
        {
            InitializeComponent();
            Debug.Write(ObjectFactory.WhatDoIHave());
            presenter = ObjectFactory.GetInstance<IMvpPresenter>();
            presenter.SetView(this);
        }

        public void SetTodoItems(IEnumerable<TodoItem> items)
        {
            todoItemsGrid.ItemsSource = items;
        }
    }
}
