using System;
using System.Collections.Generic;
using MVPtoMVVM.domain;
using MVPtoMVVM.mvp.views;
using MVPtoMVVM.repositories;
using System.Linq;

namespace MVPtoMVVM.mvp.presenters
{
    public class MvpPresenter : IMvpPresenter
    {
        private IMvpView view;
        private ITodoItemRepository itemRepository;

        public MvpPresenter(ITodoItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void SetView(IMvpView view)
        {
            this.view = view;
            InitializeView();
        }

        private void InitializeView()
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            var todoItemPresenters = itemRepository.GetAll().Select(MapFrom);
            view.ShowTodoItems(todoItemPresenters);
        }

        private ITodoItemPresenter MapFrom(TodoItem todoItem)
        {
            return new TodoItemPresenter(itemRepository) { Description = todoItem.Description, DueDate = todoItem.DueDate, Id = todoItem.Id };
        }

        public void AddNewItem()
        {
            var items = new List<ITodoItemPresenter>(view.GetTodoItems());
            var newItem = new TodoItemPresenter(itemRepository) {Description = string.Empty, DueDate = DateTime.Today} ;
            items.Add(newItem);
            view.ShowTodoItems(items);
        }

        public void CancelAllChanges()
        {
            RefreshItems();
        }

        public void Remove(int itemId)
        {
            view.ShowTodoItems(view.GetTodoItems().Where(x => x.Id != itemId));
        }

    }
}