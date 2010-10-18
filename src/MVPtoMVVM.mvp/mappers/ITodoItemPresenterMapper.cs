using System.Collections.Generic;
using MVPtoMVVM.domain;
using MVPtoMVVM.mvp.presenters;

namespace MVPtoMVVM.mvp.mappers
{
    public interface ITodoItemPresenterMapper
    {
        ITodoItemPresenter MapFrom(TodoItem item);
        IEnumerable<ITodoItemPresenter> MapAll(IEnumerable<TodoItem> items);
    }
}