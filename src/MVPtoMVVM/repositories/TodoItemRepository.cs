using System.Collections.Generic;
using MVPtoMVVM.domain;
using System.Linq;

namespace MVPtoMVVM.repositories
{
    class TodoItemRepository : ITodoItemRepository
    {
        private List<TodoItem> items = new List<TodoItem>();

        public void Add(TodoItem item)
        {
            items.Add(item);
        }

        public TodoItem Get(string description)
        {
            return items.FirstOrDefault(x => x.Description == description);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return items.AsEnumerable();
        }
    }
}