using System;
using System.Collections.Generic;
using MVPtoMVVM.domain;
using MVPtoMVVM.mappers;
using MVPtoMVVM.repositories;
using MVPtoMVVM.views;
using System.Linq;

namespace MVPtoMVVM.presenters
{
    public class MvpPresenter : IMvpPresenter
    {
        private IMvpView view;
        private ITodoItemRepository itemRepository;
        private ITodoItemPresenterMapper presenterMapper;

        public MvpPresenter(ITodoItemRepository itemRepository, ITodoItemPresenterMapper presenterMapper)
        {
            this.itemRepository = itemRepository;
            this.presenterMapper = presenterMapper;
        }

        public void SetView(IMvpView view)
        {
            this.view = view;
            InitializeView();
        }

        public void AddNewItem()
        {
            var items = new List<ITodoItemPresenter>(view.GetTodoItems());
            var newItem = presenterMapper.MapFrom(new TodoItem { DueDate = DateTime.Today});
            items.Add(newItem);
            view.SetTodoItems(items);
        }

        public void CancelAllChanges()
        {
            RefreshItems();
        }

        public void Remove(int itemId)
        {
            view.SetTodoItems(view.GetTodoItems().Where(x => x.Id != itemId));
        }

        private void InitializeView()
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            view.SetTodoItems(presenterMapper.MapAll(itemRepository.GetAll()));
        }
    }
}