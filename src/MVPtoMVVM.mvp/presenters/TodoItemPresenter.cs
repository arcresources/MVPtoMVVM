using System;
using MVPtoMVVM.domain;
using MVPtoMVVM.mvp.mappers;
using MVPtoMVVM.mvp.views;
using MVPtoMVVM.repositories;

namespace MVPtoMVVM.mvp.presenters
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
                UpdateControlState();
            }
        }

        private void UpdateControlState()
        {
            view.SaveButtonEnabled = IsDirty && IsDescriptionValid() && IsDueDateValid();
            view.DescriptionHasValidationErrors = !IsDescriptionValid();
            view.DescriptionValidationMessage = GetDescriptionValidationMessage();
            view.DueDateHasValidationErrors = !IsDueDateValid();
            view.DueDateValidationMessage = GetDueDateValidationMessage();
            view.IsDueSoon = IsDueSoon();
        }

        private bool IsDescriptionValid()
        {
            return description.Length > 0;
        }

        private bool IsDueDateValid()
        {
            return dueDate >= DateTime.Today;
        }

        private bool IsDueSoon()
        {
            return dueDate <= DateTime.Today.AddDays(1);
        }

        private string GetDescriptionValidationMessage()
        {
            return IsDescriptionValid() ? null : "You must enter a description";
        }

        private string GetDueDateValidationMessage()
        {
            return IsDueDateValid() ? null : "Due Date must be today or later";
        }
    }
}