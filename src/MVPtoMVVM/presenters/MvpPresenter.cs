using System;
using System.Linq;
using MVPtoMVVM.mappers;
using MVPtoMVVM.repositories;
using MVPtoMVVM.views;

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

        private void InitializeView()
        {
            view.SetTodoItems(presenterMapper.MapAll(itemRepository.GetAll()));
        }
    }
}