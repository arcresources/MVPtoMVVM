using System.Collections.Generic;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using MVPtoMVVM.views;

namespace MVPtoMVVM.mappers
{
    public interface ITodoItemPresenterMapper
    {
        IEnumerable<ITodoItemPresenter> MapAll(IEnumerable<TodoItem> items);
    }
}