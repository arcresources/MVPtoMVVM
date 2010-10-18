using MVPtoMVVM.domain;
using MVPtoMVVM.mvp.presenters;

namespace MVPtoMVVM.mvp.mappers
{
    public class TodoItemMapper : ITodoItemMapper
    {
        public TodoItem MapFrom(ITodoItemPresenter presenter)
        {
            return new TodoItem {Description = presenter.Description, DueDate = presenter.DueDate, Id = presenter.Id};
        }
    }
}