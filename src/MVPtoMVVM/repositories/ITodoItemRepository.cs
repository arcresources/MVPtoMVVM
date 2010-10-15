using System.Collections.Generic;
using MVPtoMVVM.domain;

namespace MVPtoMVVM.repositories
{
    public interface ITodoItemRepository
    {
        void Save(TodoItem item);
        TodoItem Get(int id);
        IEnumerable<TodoItem> GetAll();
        void Delete(TodoItem item);
    }
}