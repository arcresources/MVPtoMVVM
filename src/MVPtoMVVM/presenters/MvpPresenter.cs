using System;
using MVPtoMVVM.repositories;

namespace MVPtoMVVM.presenters
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
            view.SetTodoItems(itemRepository.GetAll());
        }
    }
}