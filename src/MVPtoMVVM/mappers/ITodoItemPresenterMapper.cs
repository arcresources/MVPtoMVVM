using System.Collections.Generic;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using MVPtoMVVM.views;

namespace MVPtoMVVM.mappers
{
    public interface ITodoItemPresenterMapper
    {
        ITodoItemPresenter MapFrom(TodoItem item);
        IEnumerable<ITodoItemPresenter> MapAll(IEnumerable<TodoItem> items);
    }
}