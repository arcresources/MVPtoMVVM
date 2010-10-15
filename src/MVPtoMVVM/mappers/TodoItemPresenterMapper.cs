﻿using System.Collections.Generic;
using System.Linq;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;
using StructureMap;

namespace MVPtoMVVM.mappers
{
    public class TodoItemPresenterMapper : ITodoItemPresenterMapper
    {
        private ITodoItemPresenter MapFrom(TodoItem item)
        {
            var presenter = ObjectFactory.GetInstance<ITodoItemPresenter>();
            presenter.Id = item.Id;
            presenter.Description = item.Description;
            presenter.DueDate = item.DueDate;
            return presenter;
        }

        public IEnumerable<ITodoItemPresenter> MapAll(IEnumerable<TodoItem> items)
        {
            return items.Select(todoItem => MapFrom(todoItem));
        }
    }
}