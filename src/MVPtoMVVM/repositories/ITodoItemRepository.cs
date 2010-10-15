using System.Collections.Generic;
using MVPtoMVVM.domain;

namespace MVPtoMVVM.repositories
{
    public interface ITodoItemRepository
    {
        void Add(TodoItem item);
        TodoItem Get(int id);
        IEnumerable<TodoItem> GetAll();
    }
}