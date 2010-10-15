using System;
using System.Collections.Generic;
using System.Linq;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using MVPtoMVVM.views;
using StructureMap;

namespace MVPtoMVVM.mappers
{
    public class TodoItemPresenterMapper : ITodoItemPresenterMapper
    {
        private ITodoItemPresenter MapFrom(TodoItem item)
        {
            var presenter = ObjectFactory.GetInstance<ITodoItemPresenter>();
            presenter.SetItem(item);
            return presenter;
        }

        public IEnumerable<ITodoItemPresenter> MapAll(IEnumerable<TodoItem> items)
        {
            return items.Select(todoItem => MapFrom(todoItem));
        }
    }
}