using System;
using MVPtoMVVM.domain;
using MVPtoMVVM.mappers;
using MVPtoMVVM.repositories;
using MVPtoMVVM.views;

namespace MVPtoMVVM.presenters
{
    public class TodoItemPresenter : ITodoItemPresenter
    {
        private ITodoItemRepository itemRepository;
        private ITodoItemMapper itemMapper;
        private ITodoItemView view;
        public int Id { get; set; }

        public TodoItemPresenter(ITodoItemRepository itemRepository, ITodoItemMapper itemMapper)
        {
            this.itemRepository = itemRepository;
            this.itemMapper = itemMapper;
        }

        public void SetView(ITodoItemView view)
        {
            this.view = view;
            InitializeView();
        }

        public void SetItem(TodoItem item)
        {
            Id = item.Id;
            Description = item.Description;
            DueDate = item.DueDate;
            IsDirty = false;
        }

        private void InitializeView()
        {
            view.Id = Id;
            view.Description = Description;
            view.DueDate = DueDate;
            view.SaveButtonEnabled = false;
        }

        public void SaveItem()
        {
            var item = itemMapper.MapFrom(this);
            itemRepository.Save(item);
            Id = item.Id;
            IsDirty = false;
        }

        public void DeleteItem()
        {
            var item = itemMapper.MapFrom(this);
            view.Remove(item.Id);
            itemRepository.Delete(item);            
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;
                IsDirty = true;
            }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value;
                IsDirty = true;
            }
        }

        private bool isDirty;
        public bool IsDirty
        {
            get { return isDirty; }
            private set { isDirty = value;
            if (view != null)
                view.SaveButtonEnabled = isDirty;
            }
        }
    }
}