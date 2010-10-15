using System;
using MVPtoMVVM.domain;
using MVPtoMVVM.views;

namespace MVPtoMVVM.presenters
{
    public class TodoItemPresenter : ITodoItemPresenter
    {
        private ITodoItemView view;
        private TodoItem item;

        public void SetView(ITodoItemView view)
        {
            this.view = view;
            InitializeView();
        }

        public void SetItem(TodoItem item)
        {
            this.item = item;
        }

        private void InitializeView()
        {
            view.Description = item.Description;
            view.DueDate = item.DueDate;
        }

    }
}