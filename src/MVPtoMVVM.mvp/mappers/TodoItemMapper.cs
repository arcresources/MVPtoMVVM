using System;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;

namespace MVPtoMVVM.mappers
{
    public class TodoItemMapper : ITodoItemMapper
    {
        public TodoItem MapFrom(ITodoItemPresenter presenter)
        {
            return new TodoItem {Description = presenter.Description, DueDate = presenter.DueDate, Id = presenter.Id};
        }
    }
}